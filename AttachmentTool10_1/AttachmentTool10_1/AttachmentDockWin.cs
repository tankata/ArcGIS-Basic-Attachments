using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Catalog;
using ESRI.ArcGIS.Geodatabase;

namespace AttachmentTool10_1
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// </summary>
    public partial class AttachmentDockWin : UserControl
    {
        public AttachmentDockWin(object hook)
        {
            InitializeComponent();
            this.Hook = hook;
        }

        /// <summary>
        /// Host object of the dockable window
        /// </summary>
        private object Hook
        {
            get;
            set;
        }

        /// <summary>
        /// Implementation class of the dockable window add-in. It is responsible for 
        /// creating and disposing the user interface class of the dockable window.
        /// </summary>
        public class AddinImpl : ESRI.ArcGIS.Desktop.AddIns.DockableWindow
        {
            private AttachmentDockWin m_windowUI;

            public AddinImpl()
            {
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new AttachmentDockWin(this.Hook);
                return m_windowUI.Handle;
            }

            protected override void Dispose(bool disposing)
            {
                if (m_windowUI != null)
                    m_windowUI.Dispose(disposing);

                base.Dispose(disposing);
            }

        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;

            string[] arrAllFiles;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) // Test Result
            {
                try
                {
                    lbxAttachments.Items.Clear();
                    arrAllFiles = openFileDialog1.FileNames;
                    int itemCount = arrAllFiles.Count();

                    if (itemCount < 2)
                    {
                        lblItemsSelCount.Text = itemCount.ToString() + " File Selected"; // message
                    }
                    else
                    {
                        lblItemsSelCount.Text = itemCount.ToString() + " Files Selected"; // message
                    }

                    int boxItemHeight = lbxAttachments.ItemHeight;
                    int finalBoxHeight = (boxItemHeight * 2) + (itemCount * boxItemHeight);
                    lbxAttachments.Height = finalBoxHeight;

                    foreach (string element in arrAllFiles)
                    {
                        lbxAttachments.Items.Add(element);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnClearTextBox_Click(object sender, EventArgs e)
        {
            lbxAttachments.Items.Clear();
            lblItemsSelCount.Text = "0 Files Selected";
            lbxAttachments.Height = 0;
        }

        private void btnParcelIdentify_Click(object sender, EventArgs e)
        {
            IMxDocument pMxDoc;
            pMxDoc = (IMxDocument)ArcMap.Application.Document;
            IActiveView pActiveView;
            pActiveView = pMxDoc.ActiveView;
            IMap pMap;
            pMap = pActiveView.FocusMap;
            IEnumLayer pEnumLayer;
            pEnumLayer = pMap.get_Layers();
            pEnumLayer.Reset();
            ILayer pLayer;
            pLayer = pEnumLayer.Next();

            IQueryFilter pQueryFilter;
            pQueryFilter = new QueryFilter();
            pQueryFilter.WhereClause = "PARCEL_ID";

            IFeatureLayer pFlayer;
            IFeatureSelection pFSel;
            ISelectionSet2 pSelSet;

            try
            {
                lbxParIDs.Items.Clear();

                while (pLayer != null)
                {
                    if (pLayer is IAnnotationLayer)
                    {
                        System.Diagnostics.Debug.WriteLine(pLayer.Name);
                        pLayer = pEnumLayer.Next();
                    }
                    else if (pLayer is IFeatureLayer)
                    {
                        System.Diagnostics.Debug.WriteLine(pLayer.Name);
                        pFlayer = (IFeatureLayer)pLayer;

                        if (pFlayer.Name == "Parcels")
                        {
                            pFSel = (IFeatureSelection)pFlayer;
                            pSelSet = (ISelectionSet2)pFSel.SelectionSet;

                            if (pSelSet.Count < 1)
                            {
                                MessageBox.Show("No Parcels have been selected.");
                                break;
                            }
                            else
                            {
                                ICursor pCursor;
                                pSelSet.Search(null, true, out pCursor);

                                IFeatureCursor pFCursor;
                                pFCursor = (IFeatureCursor)pCursor;

                                IFeature pFeature;
                                pFeature = pFCursor.NextFeature();

                                IFeatureClass pFClass;
                                pFClass = pFlayer.FeatureClass;

                                List<string> listParIDs = new List<string>();

                                while (!(pFeature == null))
                                {
                                    int ParIDindex = pFClass.Fields.FindField("PARCEL_ID");
                                    string ParIDval = (string)pFeature.Value[ParIDindex];
                                    System.Diagnostics.Debug.WriteLine(ParIDval);
                                    listParIDs.Add(ParIDval);
                                    pFeature = pFCursor.NextFeature();
                                }

                                List<string> sortParIDs = new List<string>();
                                sortParIDs = listParIDs.OrderBy(x => x).ToList();

                                foreach (string parID in sortParIDs)
                                {
                                    lbxParIDs.Items.Add(parID);
                                }

                                //int selCount = pSelSet.Count;
                                //MessageBox.Show("Selected Parcels: " + selCount.ToString());
                                break;
                            }
                        }
                        else
                        {
                            pLayer = pEnumLayer.Next();
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(pLayer.Name);
                        pLayer = pEnumLayer.Next();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Exception");
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                IMxDocument pMxDoc;
                pMxDoc = (IMxDocument)ArcMap.Application.Document;
                IActiveView pActiveView;
                pActiveView = pMxDoc.ActiveView;
                IMap pMap;
                pMap = pActiveView.FocusMap;

                ITableCollection pTableCollection = (ITableCollection)pMap;
                ITable pTable = null;
                IDataset pDataset;

                bool blnFoundTable = false;

                //// Get the collection of tables in the MXD
                for (int i = 0; i <= pTableCollection.TableCount - 1; i++)
                {
                    pTable = pTableCollection.Table[i];
                    pDataset = (IDataset)pTable;

                    //// Locate the Attachment Table
                    if (pDataset.Name == "AttachmentList")
                    {
                        blnFoundTable = true;
                        IRow pRow;

                        //// Ensure that there are features and documents to attach
                        if (lbxParIDs.Items.Count == 0 && lbxAttachments.Items.Count == 0)
                        {
                            MessageBox.Show("Please Select both Parcels and Documents to Attach");
                        }

                        else if (lbxParIDs.Items.Count == 0 && lbxAttachments.Items.Count > 0)
                        {
                            MessageBox.Show("Please Select Features to attach to the listed documents.");
                        }

                        else if (lbxParIDs.Items.Count > 0 && lbxAttachments.Items.Count == 0)
                        {
                            MessageBox.Show("Please Select Documents to attach to the listed features.");
                        }

                        else
                        {
                            //// Cursor through the list boxes to get the individual features and documents
                            //// Iterate attachments first as this is many to many
                            int attachmentCount = 0;

                            for (int k = 0; k < lbxAttachments.Items.Count; k++)
                            {
                                for (int j = 0; j < lbxParIDs.Items.Count; j++)
                                {
                                    //// Fields to populate
                                    int fldIndex1 = pTable.FindField("PARCEL_ID");
                                    //int fldIndex2 = pTable.FindField("ADDRESS");
                                    int fldIndex3 = pTable.FindField("DOC_PATH");

                                    //// Get respective listbox values for each row
                                    string insertParIDfield = lbxParIDs.GetItemText(lbxParIDs.Items[j]);
                                    //string insertAddressField = "1234 Main St"; //* Still testing
                                    string insertDocPathField = lbxAttachments.GetItemText(lbxAttachments.Items[k]);
                                    string docName = Path.GetFileName(insertDocPathField);

                                    ICursor pCursor2 = null;
                                    pCursor2 = pTable.Search(null, false);
                                    IRow pSearchRow = pCursor2.NextRow();
                                    int conflictCount = 0;
                                    while (pSearchRow != null)
                                    {
                                        string parIDsearch = pSearchRow.get_Value(fldIndex1).ToString();
                                        string docSearch = pSearchRow.get_Value(fldIndex3).ToString();
                                        if (parIDsearch == insertParIDfield && docSearch == insertDocPathField)
                                        {
                                            conflictCount += 1;
                                        }
                                        pSearchRow = pCursor2.NextRow();
                                    }

                                    if (conflictCount == 0)
                                    {
                                        //// Create new Row
                                        pRow = pTable.CreateRow();

                                        //int rowID = pRow.OID; //* Incremental variable used for Address Field Test

                                        //// Set field values
                                        IRowSubtypes pRowSubTypes = (IRowSubtypes)pRow;
                                        pRowSubTypes.InitDefaultValues();
                                        pRow.set_Value(fldIndex1, insertParIDfield);
                                        //pRow.set_Value(fldIndex2, insertAddressField + "_" + rowID.ToString());
                                        pRow.set_Value(fldIndex3, insertDocPathField);
                                        pRow.Store();
                                        attachmentCount += 1;
                                    }
                                    else if (conflictCount == 1)
                                    {
                                        MessageBox.Show(docName + " has already been associated with parcel " + insertParIDfield + ".", "Duplicate Entry",MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        MessageBox.Show(docName + " has already been associated with parcel " + insertParIDfield + conflictCount.ToString() + " times. Please " +
                                            "purge the duplicates from the database.", "Multiple Duplicates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            //// Notify user that the attachment action is complete
                            if (attachmentCount == 0)
                            {
                                MessageBox.Show("No Attachments were made.", "Empty Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                DialogResult clearResults = MessageBox.Show("Would you like to clear your Parcel and Attachment lists?", "Clear?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (clearResults == DialogResult.Yes)
                                {
                                    lbxParIDs.Items.Clear();
                                    lbxAttachments.Items.Clear();
                                    lblItemsSelCount.Text = "0 Files Selected";
                                    lbxAttachments.Height = 0;
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (attachmentCount == 1)
                            {
                                MessageBox.Show("Document Attachment is Complete." + "\n\n" + attachmentCount.ToString() + " Attachment was made.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lbxParIDs.Items.Clear();
                                lbxAttachments.Items.Clear();
                                lblItemsSelCount.Text = "0 Files Selected";
                                lbxAttachments.Height = 0;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Document Attachment is Complete." + "\n\n" + attachmentCount.ToString() + " Attachments were made.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lbxParIDs.Items.Clear();
                                lbxAttachments.Items.Clear();
                                lblItemsSelCount.Text = "0 Files Selected";
                                lbxAttachments.Height = 0;
                                break;
                            }
                        }
                    }
                }
                if (blnFoundTable == false)
                {
                    MessageBox.Show("Attachment List Table is not present in the MXD", "Table Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearParIDs_Click(object sender, EventArgs e)
        {
            lbxParIDs.Items.Clear();
        }
    }
}

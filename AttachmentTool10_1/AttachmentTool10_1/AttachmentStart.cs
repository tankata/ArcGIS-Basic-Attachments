using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;

namespace AttachmentTool10_1
{
    public class AttachmentStart : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public AttachmentStart()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            ArcMap.Application.CurrentTool = null;

            UID dockableWinUID = new UIDClass();
            dockableWinUID.Value = ThisAddIn.IDs.AttachmentDockWin;

            IDockableWindow dockWinAttach = ArcMap.DockableWindowManager.GetDockableWindow(dockableWinUID);
            dockWinAttach.Show(true);
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}

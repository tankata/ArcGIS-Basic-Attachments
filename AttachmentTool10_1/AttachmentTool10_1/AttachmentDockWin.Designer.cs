namespace AttachmentTool10_1
{
    partial class AttachmentDockWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenDialog = new System.Windows.Forms.Button();
            this.lbxAttachments = new System.Windows.Forms.ListBox();
            this.lblItemsSelCount = new System.Windows.Forms.Label();
            this.btnClearTextBox = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnParcelIdentify = new System.Windows.Forms.Button();
            this.lbxParIDs = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAttach = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearParIDs = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenDialog.ForeColor = System.Drawing.Color.Blue;
            this.btnOpenDialog.Location = new System.Drawing.Point(32, 213);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(120, 33);
            this.btnOpenDialog.TabIndex = 0;
            this.btnOpenDialog.Text = "Select Files";
            this.btnOpenDialog.UseVisualStyleBackColor = true;
            this.btnOpenDialog.Click += new System.EventHandler(this.btnOpenDialog_Click);
            // 
            // lbxAttachments
            // 
            this.lbxAttachments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAttachments.FormattingEnabled = true;
            this.lbxAttachments.HorizontalScrollbar = true;
            this.lbxAttachments.ItemHeight = 16;
            this.lbxAttachments.Location = new System.Drawing.Point(32, 274);
            this.lbxAttachments.MaximumSize = new System.Drawing.Size(252, 150);
            this.lbxAttachments.Name = "lbxAttachments";
            this.lbxAttachments.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxAttachments.Size = new System.Drawing.Size(252, 20);
            this.lbxAttachments.TabIndex = 1;
            // 
            // lblItemsSelCount
            // 
            this.lblItemsSelCount.AutoSize = true;
            this.lblItemsSelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblItemsSelCount.Location = new System.Drawing.Point(32, 252);
            this.lblItemsSelCount.Name = "lblItemsSelCount";
            this.lblItemsSelCount.Size = new System.Drawing.Size(104, 16);
            this.lblItemsSelCount.TabIndex = 10;
            this.lblItemsSelCount.Text = "0 Files Selected";
            // 
            // btnClearTextBox
            // 
            this.btnClearTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearTextBox.ForeColor = System.Drawing.Color.Red;
            this.btnClearTextBox.Location = new System.Drawing.Point(164, 213);
            this.btnClearTextBox.Name = "btnClearTextBox";
            this.btnClearTextBox.Size = new System.Drawing.Size(120, 33);
            this.btnClearTextBox.TabIndex = 11;
            this.btnClearTextBox.Text = "Clear Files";
            this.btnClearTextBox.UseVisualStyleBackColor = true;
            this.btnClearTextBox.Click += new System.EventHandler(this.btnClearTextBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Step 1";
            // 
            // btnParcelIdentify
            // 
            this.btnParcelIdentify.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParcelIdentify.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnParcelIdentify.Location = new System.Drawing.Point(32, 48);
            this.btnParcelIdentify.Name = "btnParcelIdentify";
            this.btnParcelIdentify.Size = new System.Drawing.Size(192, 33);
            this.btnParcelIdentify.TabIndex = 13;
            this.btnParcelIdentify.Text = "Identify Selected Parcel(s)";
            this.btnParcelIdentify.UseVisualStyleBackColor = true;
            this.btnParcelIdentify.Click += new System.EventHandler(this.btnParcelIdentify_Click);
            // 
            // lbxParIDs
            // 
            this.lbxParIDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxParIDs.FormattingEnabled = true;
            this.lbxParIDs.ItemHeight = 20;
            this.lbxParIDs.Location = new System.Drawing.Point(32, 87);
            this.lbxParIDs.Name = "lbxParIDs";
            this.lbxParIDs.Size = new System.Drawing.Size(252, 84);
            this.lbxParIDs.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Step 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Step 3:";
            // 
            // btnAttach
            // 
            this.btnAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(32, 455);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(252, 33);
            this.btnAttach.TabIndex = 17;
            this.btnAttach.Text = "Attach";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Attach Documents to Selected Parcels";
            // 
            // btnClearParIDs
            // 
            this.btnClearParIDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearParIDs.ForeColor = System.Drawing.Color.Red;
            this.btnClearParIDs.Location = new System.Drawing.Point(229, 48);
            this.btnClearParIDs.Name = "btnClearParIDs";
            this.btnClearParIDs.Size = new System.Drawing.Size(54, 32);
            this.btnClearParIDs.TabIndex = 19;
            this.btnClearParIDs.Text = "Clear";
            this.btnClearParIDs.UseVisualStyleBackColor = true;
            this.btnClearParIDs.Click += new System.EventHandler(this.btnClearParIDs_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Select Parcels";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Select Documents to Attach";
            // 
            // AttachmentDockWin
            // 
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClearParIDs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbxParIDs);
            this.Controls.Add(this.btnParcelIdentify);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClearTextBox);
            this.Controls.Add(this.lblItemsSelCount);
            this.Controls.Add(this.lbxAttachments);
            this.Controls.Add(this.btnOpenDialog);
            this.Name = "AttachmentDockWin";
            this.Size = new System.Drawing.Size(316, 530);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenDialog;
        private System.Windows.Forms.ListBox lbxAttachments;
        private System.Windows.Forms.Label lblItemsSelCount;
        private System.Windows.Forms.Button btnClearTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnParcelIdentify;
        private System.Windows.Forms.ListBox lbxParIDs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearParIDs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

    }
}

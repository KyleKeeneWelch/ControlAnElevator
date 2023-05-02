namespace ControlAnElevator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pan1 = new System.Windows.Forms.Panel();
            this.btnRequest1 = new System.Windows.Forms.Button();
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.pan0 = new System.Windows.Forms.Panel();
            this.btnRequest0 = new System.Windows.Forms.Button();
            this.lblStatus0 = new System.Windows.Forms.Label();
            this.panCtrl = new System.Windows.Forms.Panel();
            this.btnFloor1 = new System.Windows.Forms.Button();
            this.btnFloor0 = new System.Windows.Forms.Button();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.prgSaveProgress = new System.Windows.Forms.ProgressBar();
            this.lblprogress = new System.Windows.Forms.Label();
            this.panSave = new System.Windows.Forms.Panel();
            this.pan1.SuspendLayout();
            this.pan0.SuspendLayout();
            this.panCtrl.SuspendLayout();
            this.panSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan1
            // 
            this.pan1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pan1.BackgroundImage")));
            this.pan1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan1.Controls.Add(this.btnRequest1);
            this.pan1.Controls.Add(this.lblStatus1);
            this.pan1.Location = new System.Drawing.Point(40, 30);
            this.pan1.Name = "pan1";
            this.pan1.Size = new System.Drawing.Size(589, 221);
            this.pan1.TabIndex = 0;
            // 
            // btnRequest1
            // 
            this.btnRequest1.Image = ((System.Drawing.Image)(resources.GetObject("btnRequest1.Image")));
            this.btnRequest1.Location = new System.Drawing.Point(368, 90);
            this.btnRequest1.Name = "btnRequest1";
            this.btnRequest1.Size = new System.Drawing.Size(40, 38);
            this.btnRequest1.TabIndex = 2;
            this.btnRequest1.UseVisualStyleBackColor = true;
            this.btnRequest1.Click += new System.EventHandler(this.btnRequest1_Click);
            // 
            // lblStatus1
            // 
            this.lblStatus1.BackColor = System.Drawing.Color.Gainsboro;
            this.lblStatus1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus1.Location = new System.Drawing.Point(265, 22);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(34, 31);
            this.lblStatus1.TabIndex = 1;
            this.lblStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pan0
            // 
            this.pan0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pan0.BackgroundImage")));
            this.pan0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan0.Controls.Add(this.btnRequest0);
            this.pan0.Controls.Add(this.lblStatus0);
            this.pan0.Location = new System.Drawing.Point(40, 280);
            this.pan0.Name = "pan0";
            this.pan0.Size = new System.Drawing.Size(589, 221);
            this.pan0.TabIndex = 1;
            // 
            // btnRequest0
            // 
            this.btnRequest0.Image = ((System.Drawing.Image)(resources.GetObject("btnRequest0.Image")));
            this.btnRequest0.Location = new System.Drawing.Point(368, 97);
            this.btnRequest0.Name = "btnRequest0";
            this.btnRequest0.Size = new System.Drawing.Size(40, 33);
            this.btnRequest0.TabIndex = 3;
            this.btnRequest0.UseVisualStyleBackColor = true;
            this.btnRequest0.Click += new System.EventHandler(this.btnRequest0_Click);
            // 
            // lblStatus0
            // 
            this.lblStatus0.BackColor = System.Drawing.Color.Gainsboro;
            this.lblStatus0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus0.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus0.Location = new System.Drawing.Point(265, 24);
            this.lblStatus0.Name = "lblStatus0";
            this.lblStatus0.Size = new System.Drawing.Size(34, 31);
            this.lblStatus0.TabIndex = 2;
            this.lblStatus0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panCtrl
            // 
            this.panCtrl.Controls.Add(this.btnFloor1);
            this.panCtrl.Controls.Add(this.btnFloor0);
            this.panCtrl.Location = new System.Drawing.Point(0, 0);
            this.panCtrl.Name = "panCtrl";
            this.panCtrl.Size = new System.Drawing.Size(32, 64);
            this.panCtrl.TabIndex = 4;
            // 
            // btnFloor1
            // 
            this.btnFloor1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFloor1.Location = new System.Drawing.Point(3, 31);
            this.btnFloor1.Name = "btnFloor1";
            this.btnFloor1.Size = new System.Drawing.Size(25, 25);
            this.btnFloor1.TabIndex = 1;
            this.btnFloor1.Text = "1";
            this.btnFloor1.UseVisualStyleBackColor = true;
            this.btnFloor1.Click += new System.EventHandler(this.btnFloor1_Click);
            // 
            // btnFloor0
            // 
            this.btnFloor0.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFloor0.Location = new System.Drawing.Point(3, 3);
            this.btnFloor0.Name = "btnFloor0";
            this.btnFloor0.Size = new System.Drawing.Size(25, 25);
            this.btnFloor0.TabIndex = 0;
            this.btnFloor0.Text = "0";
            this.btnFloor0.UseVisualStyleBackColor = true;
            this.btnFloor0.Click += new System.EventHandler(this.btnFloor0_Click);
            // 
            // lblEvents
            // 
            this.lblEvents.BackColor = System.Drawing.Color.White;
            this.lblEvents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEvents.Font = new System.Drawing.Font("Calibri Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEvents.Location = new System.Drawing.Point(661, 107);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Padding = new System.Windows.Forms.Padding(5);
            this.lblEvents.Size = new System.Drawing.Size(290, 43);
            this.lblEvents.TabIndex = 2;
            this.lblEvents.Text = "Events";
            this.lblEvents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstEvents
            // 
            this.lstEvents.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.ItemHeight = 21;
            this.lstEvents.Location = new System.Drawing.Point(661, 153);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(290, 214);
            this.lstEvents.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(661, 379);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DarkGray;
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.ForeColor = System.Drawing.Color.Black;
            this.btnLoad.Location = new System.Drawing.Point(807, 379);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(144, 35);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            this.btnLoad.MouseEnter += new System.EventHandler(this.btnLoad_MouseEnter);
            this.btnLoad.MouseLeave += new System.EventHandler(this.btnLoad_MouseLeave);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkGray;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(661, 420);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 38);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new System.EventHandler(this.btnClear_MouseEnter);
            this.btnClear.MouseLeave += new System.EventHandler(this.btnClear_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkGray;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(807, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(144, 38);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkGray;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(661, 464);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(290, 37);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete Trip";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseEnter += new System.EventHandler(this.btnDelete_MouseEnter);
            this.btnDelete.MouseLeave += new System.EventHandler(this.btnDelete_MouseLeave);
            // 
            // prgSaveProgress
            // 
            this.prgSaveProgress.BackColor = System.Drawing.Color.DarkGray;
            this.prgSaveProgress.ForeColor = System.Drawing.Color.Lime;
            this.prgSaveProgress.Location = new System.Drawing.Point(150, 5);
            this.prgSaveProgress.Name = "prgSaveProgress";
            this.prgSaveProgress.Size = new System.Drawing.Size(166, 29);
            this.prgSaveProgress.TabIndex = 9;
            // 
            // lblprogress
            // 
            this.lblprogress.AutoSize = true;
            this.lblprogress.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblprogress.ForeColor = System.Drawing.Color.White;
            this.lblprogress.Location = new System.Drawing.Point(3, 5);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(141, 24);
            this.lblprogress.TabIndex = 10;
            this.lblprogress.Text = "Save In Progress";
            // 
            // panSave
            // 
            this.panSave.Controls.Add(this.lblprogress);
            this.panSave.Controls.Add(this.prgSaveProgress);
            this.panSave.Location = new System.Drawing.Point(647, 30);
            this.panSave.Name = "panSave";
            this.panSave.Size = new System.Drawing.Size(327, 45);
            this.panSave.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(982, 523);
            this.Controls.Add(this.panSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.panCtrl);
            this.Controls.Add(this.pan0);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.lblEvents);
            this.Controls.Add(this.pan1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control An Elevator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pan1.ResumeLayout(false);
            this.pan0.ResumeLayout(false);
            this.panCtrl.ResumeLayout(false);
            this.panSave.ResumeLayout(false);
            this.panSave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pan1;
        private Panel pan0;
        private Label lblEvents;
        private ListBox lstEvents;
        private Button btnSave;
        private Button btnLoad;
        private Button btnRequest1;
        private Label lblStatus1;
        private Button btnRequest0;
        private Label lblStatus0;
        private Panel panCtrl;
        private Button btnFloor1;
        private Button btnFloor0;
        private Button btnClear;
        private Button btnClose;
        private Button btnDelete;
        private ProgressBar prgSaveProgress;
        private Label lblprogress;
        private Panel panSave;
    }
}
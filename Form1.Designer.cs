namespace BioStarCSVMerger
{
    partial class bioStarAccesLogMerger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bioStarAccesLogMerger));
            btnSelectFolder = new Button();
            btnSelectZip = new Button();
            txtInputPath = new TextBox();
            lblInput = new Label();
            lblOutput = new Label();
            txtOutputPath = new TextBox();
            btnMerge = new Button();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            btnOpen = new Button();
            btnSelectOutput = new Button();
            linkVersion = new LinkLabel();
            SuspendLayout();
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.BackColor = Color.DodgerBlue;
            btnSelectFolder.FlatAppearance.BorderSize = 0;
            btnSelectFolder.FlatStyle = FlatStyle.Flat;
            btnSelectFolder.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectFolder.ForeColor = Color.White;
            btnSelectFolder.Image = (Image)resources.GetObject("btnSelectFolder.Image");
            btnSelectFolder.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelectFolder.Location = new Point(154, 100);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(232, 61);
            btnSelectFolder.TabIndex = 0;
            btnSelectFolder.Text = "Select Folder";
            btnSelectFolder.UseVisualStyleBackColor = false;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // btnSelectZip
            // 
            btnSelectZip.BackColor = Color.DodgerBlue;
            btnSelectZip.FlatAppearance.BorderSize = 0;
            btnSelectZip.FlatStyle = FlatStyle.Flat;
            btnSelectZip.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSelectZip.ForeColor = Color.White;
            btnSelectZip.Image = (Image)resources.GetObject("btnSelectZip.Image");
            btnSelectZip.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelectZip.Location = new Point(404, 100);
            btnSelectZip.Name = "btnSelectZip";
            btnSelectZip.Size = new Size(232, 61);
            btnSelectZip.TabIndex = 1;
            btnSelectZip.Text = "Select ZIP";
            btnSelectZip.UseVisualStyleBackColor = false;
            btnSelectZip.Click += btnSelectZip_Click;
            // 
            // txtInputPath
            // 
            txtInputPath.Location = new Point(154, 67);
            txtInputPath.Name = "txtInputPath";
            txtInputPath.ReadOnly = true;
            txtInputPath.Size = new Size(482, 25);
            txtInputPath.TabIndex = 2;
            // 
            // lblInput
            // 
            lblInput.AutoSize = true;
            lblInput.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInput.Location = new Point(154, 46);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(83, 17);
            lblInput.TabIndex = 3;
            lblInput.Text = "Input File(s)";
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOutput.Location = new Point(154, 184);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(78, 17);
            lblOutput.TabIndex = 4;
            lblOutput.Text = "Output File";
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(154, 204);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(482, 25);
            txtOutputPath.TabIndex = 5;
            // 
            // btnMerge
            // 
            btnMerge.BackColor = Color.MediumSeaGreen;
            btnMerge.FlatAppearance.BorderSize = 0;
            btnMerge.FlatStyle = FlatStyle.Flat;
            btnMerge.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMerge.ForeColor = Color.White;
            btnMerge.Image = (Image)resources.GetObject("btnMerge.Image");
            btnMerge.ImageAlign = ContentAlignment.MiddleLeft;
            btnMerge.Location = new Point(154, 390);
            btnMerge.Name = "btnMerge";
            btnMerge.Size = new Size(232, 61);
            btnMerge.TabIndex = 6;
            btnMerge.Text = "Merge Files";
            btnMerge.UseVisualStyleBackColor = false;
            btnMerge.Click += btnMerge_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(154, 357);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(482, 26);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(154, 337);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(44, 17);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Ready";
            // 
            // btnOpen
            // 
            btnOpen.BackColor = Color.DodgerBlue;
            btnOpen.FlatAppearance.BorderSize = 0;
            btnOpen.FlatStyle = FlatStyle.Flat;
            btnOpen.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnOpen.ForeColor = Color.White;
            btnOpen.Image = (Image)resources.GetObject("btnOpen.Image");
            btnOpen.ImageAlign = ContentAlignment.MiddleLeft;
            btnOpen.Location = new Point(404, 390);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(232, 61);
            btnOpen.TabIndex = 9;
            btnOpen.Text = "Open File";
            btnOpen.UseVisualStyleBackColor = false;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSelectOutput
            // 
            btnSelectOutput.BackColor = Color.DodgerBlue;
            btnSelectOutput.FlatAppearance.BorderSize = 0;
            btnSelectOutput.FlatStyle = FlatStyle.Flat;
            btnSelectOutput.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnSelectOutput.ForeColor = Color.White;
            btnSelectOutput.Image = (Image)resources.GetObject("btnSelectOutput.Image");
            btnSelectOutput.ImageAlign = ContentAlignment.MiddleLeft;
            btnSelectOutput.Location = new Point(404, 237);
            btnSelectOutput.Name = "btnSelectOutput";
            btnSelectOutput.Size = new Size(232, 61);
            btnSelectOutput.TabIndex = 10;
            btnSelectOutput.Text = "Browse";
            btnSelectOutput.UseVisualStyleBackColor = false;
            btnSelectOutput.Click += btnSelectOutput_Click;
            // 
            // linkVersion
            // 
            linkVersion.AutoSize = true;
            linkVersion.Location = new Point(12, 484);
            linkVersion.Name = "linkVersion";
            linkVersion.Size = new Size(31, 17);
            linkVersion.TabIndex = 11;
            linkVersion.TabStop = true;
            linkVersion.Text = "v1.0";
            linkVersion.LinkClicked += linkVersion_LinkClicked;
            // 
            // bioStarAccesLogMerger
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 510);
            Controls.Add(linkVersion);
            Controls.Add(btnSelectOutput);
            Controls.Add(btnOpen);
            Controls.Add(lblStatus);
            Controls.Add(progressBar);
            Controls.Add(btnMerge);
            Controls.Add(txtOutputPath);
            Controls.Add(lblOutput);
            Controls.Add(lblInput);
            Controls.Add(txtInputPath);
            Controls.Add(btnSelectZip);
            Controls.Add(btnSelectFolder);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "bioStarAccesLogMerger";
            Text = "BioStar Access Log Merger";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectFolder;
        private Button btnSelectZip;
        private TextBox txtInputPath;
        private Label lblInput;
        private Label lblOutput;
        private TextBox txtOutputPath;
        private Button btnMerge;
        private ProgressBar progressBar;
        private Label lblStatus;
        private Button btnOpen;
        private Button btnSelectOutput;
        private LinkLabel linkVersion;
    }
}

namespace zegrisCsvParser
{
    partial class csvMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(csvMain));
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSelectedFile = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.4717F);
            this.btnClose.Location = new System.Drawing.Point(984, 679);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(128, 42);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Sluit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseUp);
            // 
            // txtSelectedFile
            // 
            this.txtSelectedFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSelectedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.26415F);
            this.txtSelectedFile.Location = new System.Drawing.Point(12, 41);
            this.txtSelectedFile.Multiline = true;
            this.txtSelectedFile.Name = "txtSelectedFile";
            this.txtSelectedFile.Size = new System.Drawing.Size(331, 31);
            this.txtSelectedFile.TabIndex = 1;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.4717F);
            this.btnSelectFile.Location = new System.Drawing.Point(349, 41);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(122, 31);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "Selecteer CSV";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSelectFile_MouseUp);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(12, 78);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(331, 550);
            this.listBox1.TabIndex = 4;
            // 
            // csvMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 733);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtSelectedFile);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "csvMain";
            this.Text = "Zegris CSV Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSelectedFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.ListBox listBox1;
    }
}


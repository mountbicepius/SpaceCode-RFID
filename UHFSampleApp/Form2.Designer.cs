namespace WindowsTestApp
{
    partial class Form2
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
            this.lblConnection = new System.Windows.Forms.Label();
            this.txtTagsList = new System.Windows.Forms.RichTextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(16, 267);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(60, 13);
            this.lblConnection.TabIndex = 16;
            this.lblConnection.Text = "connection";
            // 
            // txtTagsList
            // 
            this.txtTagsList.Location = new System.Drawing.Point(159, 57);
            this.txtTagsList.Name = "txtTagsList";
            this.txtTagsList.Size = new System.Drawing.Size(222, 175);
            this.txtTagsList.TabIndex = 15;
            this.txtTagsList.Text = "";
            this.txtTagsList.TextChanged += new System.EventHandler(this.txtTagsList_TextChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(406, 80);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(41, 13);
            this.lblCount.TabIndex = 14;
            this.lblCount.Text = "Count :";
            this.lblCount.Click += new System.EventHandler(this.lblCount_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(69, 99);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 13;
            this.btnScan.Text = "Start Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 299);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.txtTagsList);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnScan);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.RichTextBox txtTagsList;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnScan;
    }
}
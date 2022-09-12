namespace WindowsTestApp
{
    partial class Form1
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtTagsList = new System.Windows.Forms.RichTextBox();
            this.lblConnection = new System.Windows.Forms.Label();
            this.btnNewForm = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblmsg = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.trackBarPower = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarDuty = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.txttag = new System.Windows.Forms.TextBox();
            this.btnEncode = new System.Windows.Forms.Button();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuty)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(15, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(15, 55);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Start Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(20, 98);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(41, 13);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Count :";
            // 
            // txtTagsList
            // 
            this.txtTagsList.Location = new System.Drawing.Point(130, 14);
            this.txtTagsList.Name = "txtTagsList";
            this.txtTagsList.Size = new System.Drawing.Size(245, 175);
            this.txtTagsList.TabIndex = 11;
            this.txtTagsList.Text = "";
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(12, 239);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(60, 13);
            this.lblConnection.TabIndex = 12;
            this.lblConnection.Text = "connection";
            // 
            // btnNewForm
            // 
            this.btnNewForm.Location = new System.Drawing.Point(12, 128);
            this.btnNewForm.Name = "btnNewForm";
            this.btnNewForm.Size = new System.Drawing.Size(78, 23);
            this.btnNewForm.TabIndex = 13;
            this.btnNewForm.Text = "Form2";
            this.btnNewForm.UseVisualStyleBackColor = true;
            this.btnNewForm.Click += new System.EventHandler(this.btnNewForm_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(263, 229);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 23);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "Print Encode Zebra";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Location = new System.Drawing.Point(9, 205);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(26, 13);
            this.lblmsg.TabIndex = 16;
            this.lblmsg.Text = "msg";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(115, 409);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(60, 23);
            this.btnRead.TabIndex = 17;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnGetPower_Click);
            // 
            // trackBarPower
            // 
            this.trackBarPower.LargeChange = 1;
            this.trackBarPower.Location = new System.Drawing.Point(95, 310);
            this.trackBarPower.Maximum = 31;
            this.trackBarPower.Name = "trackBarPower";
            this.trackBarPower.Size = new System.Drawing.Size(208, 45);
            this.trackBarPower.TabIndex = 18;
            this.trackBarPower.TickFrequency = 10;
            this.trackBarPower.Value = 31;
            this.trackBarPower.Scroll += new System.EventHandler(this.trackBar_txpwr_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Power Slider";
            // 
            // trackBarDuty
            // 
            this.trackBarDuty.LargeChange = 1;
            this.trackBarDuty.Location = new System.Drawing.Point(96, 350);
            this.trackBarDuty.Maximum = 95;
            this.trackBarDuty.Minimum = 5;
            this.trackBarDuty.Name = "trackBarDuty";
            this.trackBarDuty.Size = new System.Drawing.Size(208, 45);
            this.trackBarDuty.TabIndex = 20;
            this.trackBarDuty.TickFrequency = 10;
            this.trackBarDuty.Value = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Duty";
            // 
            // txttag
            // 
            this.txttag.Location = new System.Drawing.Point(9, 411);
            this.txttag.Name = "txttag";
            this.txttag.Size = new System.Drawing.Size(100, 20);
            this.txttag.TabIndex = 22;
            this.txttag.TextChanged += new System.EventHandler(this.txttag_TextChanged);
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(181, 409);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(60, 23);
            this.btnEncode.TabIndex = 23;
            this.btnEncode.Text = "Encode";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(95, 231);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(162, 21);
            this.cmbPrinters.TabIndex = 47;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 444);
            this.Controls.Add(this.cmbPrinters);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.txttag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarDuty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarPower);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnNewForm);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.txtTagsList);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.RichTextBox txtTagsList;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Button btnNewForm;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TrackBar trackBarPower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarDuty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttag;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.ComboBox cmbPrinters;
    }
}


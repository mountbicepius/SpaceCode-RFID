namespace SBR2_Demo
{
    partial class NewUIDPrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUIDPrompt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOldUID = new System.Windows.Forms.TextBox();
            this.textBoxNewUID = new System.Windows.Forms.TextBox();
            this.buttonConfirmUID = new System.Windows.Forms.Button();
            this.labelWarningInvalid = new System.Windows.Forms.Label();
            this.comboBoxSelWrite = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old UID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "New UID";
            // 
            // textBoxOldUID
            // 
            this.textBoxOldUID.Location = new System.Drawing.Point(93, 10);
            this.textBoxOldUID.Name = "textBoxOldUID";
            this.textBoxOldUID.ReadOnly = true;
            this.textBoxOldUID.Size = new System.Drawing.Size(130, 20);
            this.textBoxOldUID.TabIndex = 2;
            // 
            // textBoxNewUID
            // 
            this.textBoxNewUID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNewUID.Location = new System.Drawing.Point(93, 39);
            this.textBoxNewUID.MaxLength = 17;
            this.textBoxNewUID.Name = "textBoxNewUID";
            this.textBoxNewUID.Size = new System.Drawing.Size(130, 20);
            this.textBoxNewUID.TabIndex = 3;
            this.textBoxNewUID.TextChanged += new System.EventHandler(this.textBoxNewUID_TextChanged);
            // 
            // buttonConfirmUID
            // 
            this.buttonConfirmUID.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirmUID.Enabled = false;
            this.buttonConfirmUID.Location = new System.Drawing.Point(168, 105);
            this.buttonConfirmUID.Name = "buttonConfirmUID";
            this.buttonConfirmUID.Size = new System.Drawing.Size(55, 21);
            this.buttonConfirmUID.TabIndex = 4;
            this.buttonConfirmUID.Text = "Confirm";
            this.buttonConfirmUID.UseVisualStyleBackColor = true;
            this.buttonConfirmUID.Click += new System.EventHandler(this.buttonConfirmUID_Click);
            // 
            // labelWarningInvalid
            // 
            this.labelWarningInvalid.AutoSize = true;
            this.labelWarningInvalid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarningInvalid.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelWarningInvalid.Location = new System.Drawing.Point(16, 109);
            this.labelWarningInvalid.Name = "labelWarningInvalid";
            this.labelWarningInvalid.Size = new System.Drawing.Size(142, 13);
            this.labelWarningInvalid.TabIndex = 5;
            this.labelWarningInvalid.Text = "Invalid character in new UID";
            this.labelWarningInvalid.Visible = false;
            // 
            // comboBoxSelWrite
            // 
            this.comboBoxSelWrite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelWrite.FormattingEnabled = true;
            this.comboBoxSelWrite.Items.AddRange(new object[] {
            "Classic Write SPCE2",
            "Write SPCE2 With Family",
            "Write Decimal"});
            this.comboBoxSelWrite.Location = new System.Drawing.Point(23, 65);
            this.comboBoxSelWrite.Name = "comboBoxSelWrite";
            this.comboBoxSelWrite.Size = new System.Drawing.Size(200, 21);
            this.comboBoxSelWrite.TabIndex = 6;
            // 
            // NewUIDPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 154);
            this.Controls.Add(this.comboBoxSelWrite);
            this.Controls.Add(this.labelWarningInvalid);
            this.Controls.Add(this.buttonConfirmUID);
            this.Controls.Add(this.textBoxNewUID);
            this.Controls.Add(this.textBoxOldUID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewUIDPrompt";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Tag UID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOldUID;
        private System.Windows.Forms.TextBox textBoxNewUID;
        private System.Windows.Forms.Button buttonConfirmUID;
        private System.Windows.Forms.Label labelWarningInvalid;
        private System.Windows.Forms.ComboBox comboBoxSelWrite;
    }
}
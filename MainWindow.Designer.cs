namespace SBR2_Demo
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.scanGroup = new System.Windows.Forms.GroupBox();
            this.buttonUpdateUID = new System.Windows.Forms.Button();
            this.buttonLedOnAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxTag = new System.Windows.Forms.ListBox();
            this.tagsCountLabel = new System.Windows.Forms.Label();
            this.tagsLabel = new System.Windows.Forms.Label();
            this.buttonLedOn = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUSB = new System.Windows.Forms.TabPage();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonDispose = new System.Windows.Forms.Button();
            this.buttonCreateDevice = new System.Windows.Forms.Button();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabEthernet = new System.Windows.Forms.TabPage();
            this.buttonConnectDevice = new System.Windows.Forms.Button();
            this.buttonPingCPU = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.scanGroup.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabUSB.SuspendLayout();
            this.tabEthernet.SuspendLayout();
            this.SuspendLayout();
            // 
            // scanGroup
            // 
            this.scanGroup.Controls.Add(this.buttonUpdateUID);
            this.scanGroup.Controls.Add(this.buttonLedOnAll);
            this.scanGroup.Controls.Add(this.label2);
            this.scanGroup.Controls.Add(this.listBoxTag);
            this.scanGroup.Controls.Add(this.tagsCountLabel);
            this.scanGroup.Controls.Add(this.tagsLabel);
            this.scanGroup.Controls.Add(this.buttonLedOn);
            this.scanGroup.Controls.Add(this.buttonStop);
            this.scanGroup.Controls.Add(this.buttonStart);
            this.scanGroup.Location = new System.Drawing.Point(22, 109);
            this.scanGroup.Name = "scanGroup";
            this.scanGroup.Size = new System.Drawing.Size(543, 285);
            this.scanGroup.TabIndex = 5;
            this.scanGroup.TabStop = false;
            this.scanGroup.Text = "Scan";
            // 
            // buttonUpdateUID
            // 
            this.buttonUpdateUID.Enabled = false;
            this.buttonUpdateUID.Location = new System.Drawing.Point(26, 247);
            this.buttonUpdateUID.Name = "buttonUpdateUID";
            this.buttonUpdateUID.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateUID.TabIndex = 9;
            this.buttonUpdateUID.Text = "Update UID";
            this.buttonUpdateUID.UseVisualStyleBackColor = true;
            this.buttonUpdateUID.Click += new System.EventHandler(this.buttonUpdateUID_Click);
            // 
            // buttonLedOnAll
            // 
            this.buttonLedOnAll.Enabled = false;
            this.buttonLedOnAll.Location = new System.Drawing.Point(357, 247);
            this.buttonLedOnAll.Name = "buttonLedOnAll";
            this.buttonLedOnAll.Size = new System.Drawing.Size(75, 23);
            this.buttonLedOnAll.TabIndex = 8;
            this.buttonLedOnAll.Text = "All at once";
            this.buttonLedOnAll.UseVisualStyleBackColor = true;
            this.buttonLedOnAll.Click += new System.EventHandler(this.buttonLedOnAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "LED lighting";
            // 
            // listBoxTag
            // 
            this.listBoxTag.FormattingEnabled = true;
            this.listBoxTag.Location = new System.Drawing.Point(26, 64);
            this.listBoxTag.MultiColumn = true;
            this.listBoxTag.Name = "listBoxTag";
            this.listBoxTag.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTag.Size = new System.Drawing.Size(493, 173);
            this.listBoxTag.TabIndex = 6;
            this.listBoxTag.SelectedIndexChanged += new System.EventHandler(this.listBoxTag_SelectedIndexChanged);
            // 
            // tagsCountLabel
            // 
            this.tagsCountLabel.AutoSize = true;
            this.tagsCountLabel.Location = new System.Drawing.Point(479, 39);
            this.tagsCountLabel.Name = "tagsCountLabel";
            this.tagsCountLabel.Size = new System.Drawing.Size(13, 13);
            this.tagsCountLabel.TabIndex = 5;
            this.tagsCountLabel.Text = "0";
            // 
            // tagsLabel
            // 
            this.tagsLabel.AutoSize = true;
            this.tagsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagsLabel.Location = new System.Drawing.Point(430, 39);
            this.tagsLabel.Name = "tagsLabel";
            this.tagsLabel.Size = new System.Drawing.Size(43, 13);
            this.tagsLabel.TabIndex = 4;
            this.tagsLabel.Text = "Tags: ";
            // 
            // buttonLedOn
            // 
            this.buttonLedOn.Enabled = false;
            this.buttonLedOn.Location = new System.Drawing.Point(446, 247);
            this.buttonLedOn.Name = "buttonLedOn";
            this.buttonLedOn.Size = new System.Drawing.Size(75, 23);
            this.buttonLedOn.TabIndex = 3;
            this.buttonLedOn.Text = "Step by step";
            this.buttonLedOn.UseVisualStyleBackColor = true;
            this.buttonLedOn.EnabledChanged += new System.EventHandler(this.buttonLedOn_EnabledChanged);
            this.buttonLedOn.Click += new System.EventHandler(this.buttonLedOn_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(107, 30);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(26, 30);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBarLabel
            // 
            this.statusBarLabel.Name = "statusBarLabel";
            this.statusBarLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.tabUSB);
            this.tabControl.Controls.Add(this.tabEthernet);
            this.tabControl.Location = new System.Drawing.Point(7, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(565, 70);
            this.tabControl.TabIndex = 7;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabUSB
            // 
            this.tabUSB.Controls.Add(this.buttonRefresh);
            this.tabUSB.Controls.Add(this.buttonDispose);
            this.tabUSB.Controls.Add(this.buttonCreateDevice);
            this.tabUSB.Controls.Add(this.comboBoxDevice);
            this.tabUSB.Controls.Add(this.label1);
            this.tabUSB.Location = new System.Drawing.Point(4, 25);
            this.tabUSB.Name = "tabUSB";
            this.tabUSB.Padding = new System.Windows.Forms.Padding(3);
            this.tabUSB.Size = new System.Drawing.Size(557, 41);
            this.tabUSB.TabIndex = 0;
            this.tabUSB.Text = "USB";
            this.tabUSB.UseVisualStyleBackColor = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(477, 9);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 9;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonDispose
            // 
            this.buttonDispose.Enabled = false;
            this.buttonDispose.Location = new System.Drawing.Point(396, 9);
            this.buttonDispose.Name = "buttonDispose";
            this.buttonDispose.Size = new System.Drawing.Size(75, 23);
            this.buttonDispose.TabIndex = 8;
            this.buttonDispose.Text = "Dispose";
            this.buttonDispose.UseVisualStyleBackColor = true;
            this.buttonDispose.Click += new System.EventHandler(this.buttonDispose_Click);
            // 
            // buttonCreateDevice
            // 
            this.buttonCreateDevice.Location = new System.Drawing.Point(295, 9);
            this.buttonCreateDevice.Name = "buttonCreateDevice";
            this.buttonCreateDevice.Size = new System.Drawing.Size(95, 23);
            this.buttonCreateDevice.TabIndex = 7;
            this.buttonCreateDevice.Text = "Create device";
            this.buttonCreateDevice.UseVisualStyleBackColor = true;
            this.buttonCreateDevice.Click += new System.EventHandler(this.buttonCreateDevice_Click);
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Location = new System.Drawing.Point(110, 11);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(160, 21);
            this.comboBoxDevice.TabIndex = 6;
            this.comboBoxDevice.SelectedIndexChanged += new System.EventHandler(this.comboBoxDevice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pluggued device";
            // 
            // tabEthernet
            // 
            this.tabEthernet.Controls.Add(this.buttonConnectDevice);
            this.tabEthernet.Controls.Add(this.buttonPingCPU);
            this.tabEthernet.Controls.Add(this.label4);
            this.tabEthernet.Controls.Add(this.label3);
            this.tabEthernet.Controls.Add(this.textBoxPort);
            this.tabEthernet.Controls.Add(this.textBoxIP);
            this.tabEthernet.Location = new System.Drawing.Point(4, 25);
            this.tabEthernet.Name = "tabEthernet";
            this.tabEthernet.Padding = new System.Windows.Forms.Padding(3);
            this.tabEthernet.Size = new System.Drawing.Size(557, 41);
            this.tabEthernet.TabIndex = 1;
            this.tabEthernet.Text = "Ethernet";
            this.tabEthernet.UseVisualStyleBackColor = true;
            // 
            // buttonConnectDevice
            // 
            this.buttonConnectDevice.Location = new System.Drawing.Point(427, 9);
            this.buttonConnectDevice.Name = "buttonConnectDevice";
            this.buttonConnectDevice.Size = new System.Drawing.Size(103, 23);
            this.buttonConnectDevice.TabIndex = 5;
            this.buttonConnectDevice.Text = "Connect Device";
            this.buttonConnectDevice.UseVisualStyleBackColor = true;
            this.buttonConnectDevice.Click += new System.EventHandler(this.buttonConnectDevice_Click);
            // 
            // buttonPingCPU
            // 
            this.buttonPingCPU.Location = new System.Drawing.Point(330, 9);
            this.buttonPingCPU.Name = "buttonPingCPU";
            this.buttonPingCPU.Size = new System.Drawing.Size(75, 23);
            this.buttonPingCPU.TabIndex = 4;
            this.buttonPingCPU.Text = "Ping CPU";
            this.buttonPingCPU.UseVisualStyleBackColor = true;
            this.buttonPingCPU.Click += new System.EventHandler(this.buttonPingCPU_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "IP";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(216, 10);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(43, 20);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "6901";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(70, 10);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(100, 20);
            this.textBoxIP.TabIndex = 0;
            this.textBoxIP.Text = "192.168.1.200";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.scanGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 480);
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartBoard2 Demo - SpaceCode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.scanGroup.ResumeLayout(false);
            this.scanGroup.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabUSB.ResumeLayout(false);
            this.tabUSB.PerformLayout();
            this.tabEthernet.ResumeLayout(false);
            this.tabEthernet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox scanGroup;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonLedOn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabel;
        private System.Windows.Forms.Label tagsLabel;
        private System.Windows.Forms.Label tagsCountLabel;
        private System.Windows.Forms.ListBox listBoxTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLedOnAll;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUSB;
        private System.Windows.Forms.TabPage tabEthernet;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonDispose;
        private System.Windows.Forms.Button buttonCreateDevice;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button buttonConnectDevice;
        private System.Windows.Forms.Button buttonPingCPU;
        private System.Windows.Forms.Button buttonUpdateUID;
    }
}


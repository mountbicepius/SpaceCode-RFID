using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using DataClass;
using SDK_SC_RFID_Devices;
using TcpIP_class;

namespace SBR2_Demo
{
    public partial class MainWindow : Form
    {
        private rfidPluggedInfo[] _arrayOfPluggedDevice;
        private RFID_Device _currentUSBDevice; // (USB) local device instance
        private int _selectedDevice; // (USB) devices comboBox index
        private DeviceInfo _currentEthernetDevice; // (Ethernet) remote device information
        private bool _isEthernetDeviceSPCE2; // (Ethernet) state compatible (or not) with SPCE2 tags

        TcpIpClient tcpClient = new TcpIpClient();

        public MainWindow()
        {
            InitializeComponent();

            string sampleId = "000000000000000000"; // default character number (+1) in tags name 
            int width = (int)listBoxTag.CreateGraphics().MeasureString(sampleId, listBoxTag.Font).Width;
            listBoxTag.ColumnWidth = width;
        }


        /// <summary>
        /// <c>FindDevice</c> function, discorvers device(s).
        /// </summary>
        private void FindDevice()
        {
            _arrayOfPluggedDevice = null;
            RFID_Device tmp = new RFID_Device();
            _arrayOfPluggedDevice = tmp.getRFIDpluggedDevice(true);
            buttonCreateDevice.Enabled = false;

            tmp.ReleaseDevice();
            comboBoxDevice.Items.Clear();


            if (_arrayOfPluggedDevice != null)
            {
                if (_arrayOfPluggedDevice.Length == 0) return;

                foreach (rfidPluggedInfo dev in _arrayOfPluggedDevice)
                {
                    comboBoxDevice.Items.Add(dev.SerialRFID);
                }

                comboBoxDevice.SelectedIndex = 0;
                buttonCreateDevice.Enabled = true;
            }

            else
            {
                UpdateStatusBar("Info : No device detected");
            }
        }


        /// <summary>
        /// <c>buttonCreateDevice_Click</c> is called when user clicks on Create button.
        /// This function initializes <c>_currentUSBDevice</c> by creating a new RFID_Device.
        /// </summary>
        private void buttonCreateDevice_Click(object sender, EventArgs e)
        {
            if (_currentUSBDevice != null)
            {
                if (_currentUSBDevice.ConnectionStatus != ConnectionStatus.CS_Connected)
                    _currentUSBDevice.ReleaseDevice(); // Release previous object if not connected
            }

            _currentUSBDevice = new RFID_Device(); // Create a new object 
            UpdateStatusBar("Info : In connection ");
            buttonCreateDevice.Enabled = false;
            _currentUSBDevice.NotifyRFIDEvent += (rfidDev_NotifyRFIDEvent);

            // Let's create appropriate smartboard device
            // The task is under a threadpool because scanning all ports (if you decide to do so) makes the UI freeze.
            ThreadPool.QueueUserWorkItem(
                delegate
                {
                    //  Give the COM port as second parameter to avoid looking for all com ports again => faster connection.
                    _currentUSBDevice.Create_NoFP_Device(_arrayOfPluggedDevice[_selectedDevice].SerialRFID, _arrayOfPluggedDevice[_selectedDevice].portCom);
                    // Remove the second parameter if you want to force the program to look for all COM ports again
                    if (_currentUSBDevice.get_RFID_Device.FirmwareVersion.StartsWith("1"))
                    {
                        MessageBox.Show("Invalid firmware version");
                        _currentUSBDevice.ReleaseDevice();
                    }
                });
        }


        /// <summary>
        /// <c>buttonDispose_Click</c> is called when user clicks on Dispose button.
        /// This function calls <c>ReleaseDevice</c> (from RFID_DEVICE) if a device is currently connected.
        /// </summary>
        private void buttonDispose_Click(object sender, EventArgs e)
        {
            listBoxTag.Items.Clear();
            
            if (_currentUSBDevice == null) return;

            if (_currentUSBDevice.ConnectionStatus == ConnectionStatus.CS_Connected)
                _currentUSBDevice.ReleaseDevice();

            buttonCreateDevice.Enabled = true;
            _currentUSBDevice = null;
        }


        /// <summary>
        /// RFID events handling.
        /// </summary>
        private void rfidDev_NotifyRFIDEvent(object sender, SDK_SC_RfidReader.rfidReaderArgs args)
        {
            switch (args.RN_Value)
            {
                // Event when failed to connect          
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_FailedToConnect:
                    UpdateStatusBar("Info : Failed to connect");
                    Invoke((MethodInvoker)delegate 
                    { 
                        buttonCreateDevice.Enabled = true; 
                        buttonDispose.Enabled = false;
                        scanGroup.Enabled = false;
                    });
                    break;
                // Event when release the object
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_Disconnected:
                    UpdateStatusBar("Info : Device disconnected");
                    Invoke((MethodInvoker)delegate 
                    { 
                        buttonCreateDevice.Enabled = true;
                        buttonDispose.Enabled = false;
                        scanGroup.Enabled = false; 
                    });
                    break;

                //Event when device is connected
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_Connected:
                    UpdateStatusBar("Info : Device connected");
                    Invoke((MethodInvoker)delegate 
                    { 
                        buttonCreateDevice.Enabled = false;
                        buttonDispose.Enabled = true;
                        buttonStart.Enabled = true;
                        scanGroup.Enabled = true; 
                    });
                    break;

                // Event when scan started
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ScanStarted:
                    Invoke((MethodInvoker)delegate 
                    { 
                        buttonStart.Enabled = false; 
                        buttonStop.Enabled = true;
                        buttonLedOn.Enabled = false;
                    });
                    UpdateStatusBar("Info : Scan started");
                    break;

                //event when fail to start scan
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ReaderFailToStartScan:
                    Invoke((MethodInvoker)delegate 
                    { 
                        buttonStart.Enabled = true; 
                        buttonStop.Enabled = false; 
                    });
                    UpdateStatusBar("Info : Failed to start scan");
                    break;

                //event when a new tag is identify
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_TagAdded:
                    tagsCountLabel.Invoke((MethodInvoker)delegate 
                    {
                        if (!listBoxTag.Items.Contains(args.Message))
                            listBoxTag.Items.Add(args.Message);
                        tagsCountLabel.Text = listBoxTag.Items.Count.ToString(); 
                    });
                    Application.DoEvents();
                    break;

                // Event when scan completed
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ScanCompleted:
                    Invoke((MethodInvoker)delegate
                    {
                        buttonStart.Enabled = true;
                        buttonStop.Enabled = false;
                    });
                    UpdateStatusBar("Info : Scan completed");
                    break;

                //error when error during scan
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ReaderScanTimeout:
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ErrorDuringScan:
                    Invoke((MethodInvoker)delegate
                    {
                        buttonStart.Enabled = true;
                        buttonStop.Enabled = false;
                    });
                    UpdateStatusBar("Info : Scan has error");
                    break;
                case SDK_SC_RfidReader.rfidReaderArgs.ReaderNotify.RN_ScanCancelByHost:
                    Invoke((MethodInvoker)delegate
                    {
                        buttonStart.Enabled = true;
                        buttonStop.Enabled = false;
                    });
                    UpdateStatusBar("Info : Scan cancel by host");
                    break;
            }

            Application.DoEvents();
        }


        /// <summary>
        /// <c>buttonStart_Click</c> is called when user clicks on Scan button.
        /// This function calls <c>ScanDevice</c> (from USBFeatures).
        /// </summary>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            listBoxTag.Invoke((MethodInvoker)delegate
            {
                listBoxTag.Items.Clear();
                tagsCountLabel.Text = "0";
            });
            if (tabControl.SelectedIndex == 0) // (USB) local device
            {
                if (!USBFeatures.StartScan(_currentUSBDevice , true))
                    MessageBox.Show("Device is not ready or not connected");
            }

            else // (Ethernet) Remote device
            {
                InventoryData lastScanInventory;
                if (TCPFeatures.StartScan(_currentEthernetDevice,tcpClient, out lastScanInventory) !=
                    TcpIpClient.RetCode.RC_Succeed)
                {
                    UpdateStatusBar("Ethernet Device scanning has failed");
                    return;
                }

                UpdateStatusBar("Ethernet Device scanning completed.");
                Invoke((MethodInvoker)delegate
                {
                    listBoxTag.Items.Clear();

                    tagsCountLabel.Text = lastScanInventory.nbTagAll.ToString();

                    foreach (string tagUID in lastScanInventory.listTagAll)
                        listBoxTag.Items.Add(tagUID);
                });
            }
        }


        /// <summary>
        /// <c>buttonStop_Click</c> is called when user clicks on Stop button.
        /// This function calls <c>StopScan</c> (from USBFeatures) to stop scanning.
        /// </summary>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0) // (USB) local device
                USBFeatures.StopScan(_currentUSBDevice);

            else // (Ethernet) Remote device
            {
                TCPFeatures.StopScan(_currentEthernetDevice, tcpClient);
                UpdateStatusBar("Scan request has been sent to Ethernet device");
            }
        }


        /// <summary>
        /// <c>buttonRefresh_Click</c> is called when user clicks on Refresh button.
        /// This function calls <c>FindDevice</c> to try to find new devices.
        /// </summary>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            UpdateStatusBar("Info : Looking for available device");
            FindDevice();

            // If we have only one device available and if this one is connected, FindDevice() won't find any connected device.
            // But if we DISPOSE first, and then Refresh, it will find again our only device.
            // Those two cases were added to update message in status bar.
            if (comboBoxDevice.Items.Count > 0)
                UpdateStatusBar(String.Format("Info : Available devices : {0}", comboBoxDevice.Items.Count));

            else
                UpdateStatusBar("Info : No available device detected");
        }


        /// <summary>
        /// Update stauts label in Status bar
        /// </summary>
        /// <param name="message">New status to be displayed</param>
        private void UpdateStatusBar(string message)
        {

            Invoke((MethodInvoker)delegate { statusBarLabel.Text = message; });
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            FindDevice();
        }


        /// <summary>
        /// Click on "Step by step" button. Only available for USB devices. 
        /// Enable lighting on all device's axises and send lighting order to each selected tag.
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event args</param>
        private void buttonLedOn_Click(object sender, EventArgs e)
        {
            buttonLedOn.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            if (_currentUSBDevice.get_RFID_Device.HardwareVersion.StartsWith("11"))
            {
                buttonLedOnAll_Click(null, null);
                return;
            }

            List<string> tags = new List<string>();
            Hashtable tagLedStateTable = new Hashtable();

            foreach (string item in listBoxTag.SelectedItems)
            {
                tags.Add(item);
                tagLedStateTable.Add(item, false);
            }

            int nbLighted = 0, totalLighted = 0, currentChannel = 0;
            bool userChoice = true, isLastStep = false;

            for (int i = 1; i < 5; ++i)
                _currentUSBDevice.get_RFID_Device.StartLedOn(i);

            while (userChoice && !isLastStep) // While users want to go on searching and we didn't browse all device axis
            {                
                isLastStep = _currentUSBDevice.StartLightingLeds(tags, tagLedStateTable, out currentChannel, out nbLighted);

                if (nbLighted == 0) continue;

                totalLighted += nbLighted;

                if (totalLighted == tags.Count) break;

                string message = String.Format("Channel {3} : {0} / {1} found. Until now : {2} / {1} found. Continue ?",
                    nbLighted,
                    tags.Count, totalLighted, currentChannel);

                DialogResult dialogChoice = MessageBox.Show(message, "Research in progress...", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                userChoice = (dialogChoice != DialogResult.No);
            }


            if(totalLighted == tags.Count)
            {
                string message = String.Format("Channel {3} : {0} / {1} found. Total : {2} / {1} found.",
                    nbLighted,
                    tags.Count, totalLighted, currentChannel);
                MessageBox.Show(message, "Research over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                if (isLastStep)
                {
                    string message = String.Format("All axis have been browsed. {0} tags not found. Missing tags ID :", tags.Count-totalLighted);

                    foreach (DictionaryEntry entryTag in tagLedStateTable)
                        if (! (bool) entryTag.Value)
                            message = String.Format("{0}\n{1}", message, entryTag.Key);

                    MessageBox.Show(message, "Research over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            _currentUSBDevice.StopLightingLeds();

            Cursor.Current = Cursors.Default;
            buttonLedOn.Enabled = true;
        }


        private void listBoxTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool spce2FeaturesEnabled =  tabControl.SelectedIndex == 0 || _isEthernetDeviceSPCE2; // True if USB, otherwise depends of _isEthernetDeviceSPCE2
            buttonLedOn.Enabled = spce2FeaturesEnabled;
            buttonLedOnAll.Enabled = spce2FeaturesEnabled;
            buttonUpdateUID.Enabled = spce2FeaturesEnabled;
        }


        private void buttonLedOn_EnabledChanged(object sender, EventArgs e)
        {
            buttonLedOnAll.Enabled = buttonLedOn.Enabled;
        }


        private void buttonLedOnAll_Click(object sender, EventArgs e)
        {
            if(tabControl.SelectedIndex == 0) // (USB) local device
                USBFeatures.LedOnAll(_currentUSBDevice, listBoxTag.SelectedItems.Cast<string>().ToList());

            else // (Ethernet) Remote device
            {
                TCPFeatures.LedOnAll(_currentEthernetDevice,tcpClient, listBoxTag.SelectedItems.Cast<string>().ToList());
                UpdateStatusBar("Led on All request has been sent to Ethernet device");
            }
        }


        private void comboBoxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedDevice = comboBoxDevice.SelectedIndex;
        }


        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_currentUSBDevice == null) return;
            if (_currentUSBDevice.ConnectionStatus == ConnectionStatus.CS_Connected)
                _currentUSBDevice.ReleaseDevice();
        }


        private bool TryParseIpPort(out string givenIp, out int portNumber)
        {
            givenIp = textBoxIP.Text.Trim();
            string givenPort = textBoxPort.Text.Trim();
            portNumber = 0;

            if (String.IsNullOrEmpty(givenIp) || String.IsNullOrEmpty(givenPort))
            {
                MessageBox.Show("Please fill IP Address and Port textfields.");
                return false;
            }

            IPAddress ipAddress;

            if (!IPAddress.TryParse(givenIp, out ipAddress)) // check if IP address is valid
            {
                MessageBox.Show("Given IP address is not valid.");
                return false;
            }

            if (ipAddress.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork) // check if IP is IPv4
            {
                MessageBox.Show("Please enter a valid IPv4 address.");
                return false;
            }

            if (!int.TryParse(givenPort, out portNumber))
            {
                MessageBox.Show("Port number is invalid.");
                return false;
            }

            return true;
        }


        private void buttonPingCPU_Click(object sender, EventArgs e)
        {
            buttonPingCPU.Enabled = false;

            string givenIp;
            int portNumber;

            if (!TryParseIpPort(out givenIp, out portNumber)) return;
            
            TcpIpClient.RetCode ret = tcpClient.pingServer(givenIp, portNumber);

            UpdateStatusBar(String.Format("-> {0} - Ping - {1}", DateTime.Now.ToLocalTime(), ret));
            
            buttonPingCPU.Enabled = true;
        }


        private void buttonConnectDevice_Click(object sender, EventArgs e)
        {
            string givenIp;
            int portNumber;

            if (!TryParseIpPort(out givenIp, out portNumber)) return;

            rfidPluggedInfo[] arrayDevice;
            tcpClient.getDevice(givenIp, portNumber, out arrayDevice);

            if (arrayDevice == null || arrayDevice.Length == 0)
            {
                UpdateStatusBar("No device found on this IP address"); 
                return;
            }

            if (arrayDevice.Length > 1)
            {
                MessageBox.Show("More than one device has been found on this IP address. Please check your network configuration.");
                return;
            }

            if (tcpClient.pingDevice(givenIp, portNumber, arrayDevice[0].SerialRFID) != TcpIpClient.RetCode.RC_Succeed)
            {
                MessageBox.Show(String.Format("Device {0} is not responding ({1}:{2})...", arrayDevice[0].SerialRFID, givenIp, portNumber));
                return;
            }

            bool spce2Available;

            if (tcpClient.RequestIsSPCE2Available(givenIp, portNumber, out spce2Available) != TcpIpClient.RetCode.RC_Succeed)
            {
                MessageBox.Show(String.Format("Device {0} is not SPCE2 compliant ({1}:{2})...", arrayDevice[0].SerialRFID, givenIp, portNumber));
                //return;
            }

            UpdateStatusBar(String.Format("Info : Network connection established with Device {0}", arrayDevice[0].SerialRFID));

            DeviceInfo deviceInfo = new DeviceInfo
            {
                IP_Server = givenIp,
                Port_Server = portNumber,
                SerialRFID = arrayDevice[0].SerialRFID
            };

            buttonStart.Enabled = true;
            scanGroup.Enabled = true;

            _currentEthernetDevice = deviceInfo;
            _isEthernetDeviceSPCE2 = spce2Available;
        }


        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enableScanning;

            if (tabControl.SelectedIndex == 0) // USB
            {
                enableScanning = (_currentUSBDevice != null);
                buttonStart.Enabled = enableScanning;
                scanGroup.Enabled = enableScanning;
                buttonLedOn.Visible = true;
            }

            else
            {
                enableScanning = (_currentEthernetDevice != null);
                buttonStart.Enabled = enableScanning;
                scanGroup.Enabled = enableScanning;
                buttonLedOn.Visible = false; // No step by step lighting in ethernet mode
            }
        }


        private void buttonUpdateUID_Click(object sender, EventArgs e)
        {
            if (listBoxTag.SelectedItems.Count > 1)
            {
                MessageBox.Show("Please update only one tag at a time.");
                return;
            }
            if (tabControl.SelectedIndex == 0) // (USB) local device
            {
                double fv = 0.0;
                double.TryParse(_currentUSBDevice.get_RFID_Device.FirmwareVersion.Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out fv);

                if (fv <= 2.54)
                {
                    MessageBox.Show("Please update device firmware with 2.55 or above version");
                    return;
                }
            }
            else
            {
                double fv = 0.0;
                TcpIpClient tcp = new TcpIpClient();
                tcp.RequestFirmwareVersion(_currentEthernetDevice.IP_Server, _currentEthernetDevice.Port_Server,
                    out fv);
                if (fv <= 3.54)
                {
                    MessageBox.Show("Please update device firmware with 3.55 or above version");
                    return;
                }

            }


            string oldUID = listBoxTag.SelectedItem.ToString();

            using (NewUIDPrompt newUIDPrompt = new NewUIDPrompt(oldUID))
            {
                if (newUIDPrompt.ShowDialog(this) == DialogResult.OK)
                {
                    WriteCode writingResult;

                    string newUID = newUIDPrompt.NewUID;
                    int writeMode = newUIDPrompt.modeWrite;

                    if (tabControl.SelectedIndex == 0) // (USB) local device
                    {
                        if ((_currentUSBDevice.ConnectionStatus == ConnectionStatus.CS_Connected) &&
                            (_currentUSBDevice.DeviceStatus == DeviceStatus.DS_Ready))
                        {

                            writingResult = USBFeatures.WriteNewUID(_currentUSBDevice, oldUID, newUID, writeMode);
                        }

                        else
                        {
                            MessageBox.Show("RFID device not ready");
                            return;
                        }
                    }

                    else // (Ethernet) Remote device
                    {
                        writingResult = TCPFeatures.WriteNewUID(_currentEthernetDevice,tcpClient, oldUID, newUID, writeMode);
                    }

                    switch (writingResult)
                    {
                        case WriteCode.WC_Error:
                            MessageBox.Show("An unexpected error occurred. Operation failed !");
                            break;

                        case WriteCode.WC_TagNotDetected:
                            MessageBox.Show("Tag not detected. Operation failed !");
                            break;

                        case WriteCode.WC_TagNotConfirmed:
                            MessageBox.Show("Tag not confirmed. Operation failed !");
                            break;

                        case WriteCode.WC_TagBlockedOrNotSupplied:
                            MessageBox.Show("Tag blocked or not well supplied. Operation failed !");
                            break;

                        case WriteCode.WC_TagBlocked:
                            MessageBox.Show("Tag blocked. Operation failed !");
                            break;

                        case WriteCode.WC_TagNotSupplied:
                            MessageBox.Show("Tag not well supplied. Operation failed !");
                            break;

                        case WriteCode.WC_ConfirmationFailed:
                            MessageBox.Show("Updated tag confirmation has failed.");
                            break;

                        case WriteCode.WC_Success:
                            MessageBox.Show("Tag UID succesfully updated.");
                            break;
                    }
                }
            }
        }
    }
}

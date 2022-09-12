using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UHFAPI_SPC;
using System.Collections;
using System.IO;

namespace WindowsTestApp
{
    public partial class Form1 : Form
    {
        SPC_RFID _SPC_RFID = null;
        public Form1()
        {
            _SPC_RFID = SPC_RFID.getInstance();

            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SPC_RFID.setDeviceStatusDelegate(devStAdd);
            _SPC_RFID.tagsDelegate= tagAdd;
            _SPC_RFID.deviceStatusDelegate = devStAdd;
            _SPC_RFID.errorDelegate = errorAdd;
            _SPC_RFID.scanCompleteDelegate = scanComplted;

            _SPC_RFID.connectReader(ReaderMake.Dtr);
            
        }
        public void tagAdd(string a, string r)
        {
            this.Invoke((MethodInvoker)delegate
            {
                a = (!string.IsNullOrWhiteSpace(txtTagsList.Text)) ? "\r\n" + a : a;                
                txtTagsList.AppendText(a);
                lblCount.Text = "Count : " + _SPC_RFID.Tags_id.Count;
                txtTagsList.ScrollToCaret();

            });
        }


        public void scanComplted(ArrayList tag)
        {
            this.Invoke((MethodInvoker)delegate
            {                
                lblmsg.Text = "ScanCompleted:"+ tag.Count+" :tags ";
         
            });
        }


        public void errorAdd(string a)
        {
            this.Invoke((MethodInvoker)delegate
            {
                //lblError.Text = a;
            });

        }

        public void devStAdd(string a)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lblConnection.Text = a;
            });
        }


        private void btnScan_Click(object sender, EventArgs e)
        {
            if(btnScan.Text.Equals("Start Scan"))
            {
                trackBarPower.Value = 31;

                _SPC_RFID.AllowDuplicateTagScan = false;
                _SPC_RFID.SetPower(trackBarPower.Value);
                _SPC_RFID.SetDuty(trackBarDuty.Value);
                _SPC_RFID.startScan(true);
                btnScan.Text = "Stop Scan";
            }
            else
            {
                _SPC_RFID.stopScan();
                btnScan.Text = "Start Scan";
            }
            
        }

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }


        List<string> printers = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            btnConnect.PerformClick();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                printers.Add(printer);
            }

            cmbPrinters.Items.Clear();
            cmbPrinters.DataSource = printers;

            if (printers.Count > 0)
            {
                cmbPrinters.SelectedIndex = 0;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _SPC_RFID.DisLinkReader();
        }

        private void printEncodeTRags(DataTable dt)
        {
            StringBuilder sbprn = new StringBuilder();

          
            foreach (DataRow dr in dt.Rows)
            {
                sbprn.Append(" CT~~CD,~CC^~CT~" + System.Environment.NewLine);
                sbprn.Append("^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR6,6~SD26^JUS^LRN^CI0^RR6^RS8,,,3^XZ" + System.Environment.NewLine);
                sbprn.Append("^XA" + System.Environment.NewLine);
                sbprn.Append("^MMF" + System.Environment.NewLine);
                sbprn.Append("^PW1000" + System.Environment.NewLine);
                sbprn.Append("^LL0450" + System.Environment.NewLine);
                sbprn.Append("^LS0" + System.Environment.NewLine);

                //Barcode
                sbprn.Append("^FT610,145^BY2^BCN,50,Y\\^FD" + dr[0].ToString() + "^FS" + System.Environment.NewLine); //fro barcode EAN128 Format.

                //first Line first value

                    sbprn.Append("^FT600,190^A0N,20,22^FH\\^FD" + dr.Table.Columns[1].ColumnName.ToString() + ":" + dr[1] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT745,190^A0N,20,22^FH\\^FD" + dr.Table.Columns[2].ColumnName.ToString().ToString() + ":" + dr[2] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT600,215^A0N,20,22^FH\\^FD" + dr.Table.Columns[3].ColumnName.ToString().ToString() + ":" + dr[3] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT745,215^A0N,20,22^FH\\^FD" + dr.Table.Columns[4].ColumnName.ToString().ToString() + ":" + dr[4] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT600,270^A0N,20,22^FH\\^FD" + dr.Table.Columns[5].ColumnName.ToString().ToString() + ":" + dr[5] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT745,270^A0N,20,22^FH\\^FD" + dr.Table.Columns[6].ColumnName.ToString().ToString() + ":" + dr[6] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT600,295^^A0N,20,22^FH\\^FD" + dr.Table.Columns[7].ColumnName.ToString().ToString() + ":" + dr[7] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT745,295^^A0N,20,22^FH\\^FD" + dr.Table.Columns[8].ColumnName.ToString().ToString() + ":" + dr[8] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT600,320^^A0N,20,22^FH\\^FD" + dr.Table.Columns[9].ColumnName.ToString().ToString() + ":" + dr[9] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT745,320^^A0N,20,22^FH\\^FD" + dr.Table.Columns[10].ColumnName.ToString().ToString() + ":" + dr[10] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT600,345^^A0N,20,22^FH\\^FD" + dr.Table.Columns[11].ColumnName.ToString().ToString() + ":" + dr[11] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT745,345^^A0N,20,22^FH\\^FD" + dr.Table.Columns[12].ColumnName.ToString().ToString() + ":" + dr[12] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT600,370^^A0N,20,22^FH\\^FD" + dr.Table.Columns[13].ColumnName.ToString().ToString() + ":" + dr[13] + "^FS" + System.Environment.NewLine);
                    sbprn.Append("^FT745,370^^A0N,20,22^FH\\^FD" + dr.Table.Columns[14].ColumnName.ToString().ToString() + ":" + dr[14] + "^FS" + System.Environment.NewLine);

                sbprn.Append("^WVN");
                sbprn.Append("^RFW,H,1,16,1^FD3000" + dr[0].ToString().ToHex() + "^FS");
                sbprn.Append("^PQ1,0,1,Y^XZ");
            }


           
            string printerN = cmbPrinters.Text;
            
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory+"\\t2.prn", sbprn.ToString());
            bool res = _SPC_RFID.SendStringToPrinter(printerN, sbprn.ToString());

            string msg = (res) ? "Success" : "Failed";
            MessageBox.Show(msg);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = openExcel();

            if (dt != null)
            { printEncodeTRags(dt); }
        }

        private DataTable openExcel()
        {
            DataTable excs = null;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "csv,excel files |*.csv;*.xlsx;*.xls";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                ///txtFilePath.Text = fileName;

                string ext = Path.GetExtension(dlg.FileName);
                
                switch (ext.ToLower())
                {
                    case ".csv":
                        excs = (DataTable)CommanFunctions.ReadCsvFile(fileName);
                        break;
                    case ".xls":
                    case ".xlsx":
                        excs = CommanFunctions.ImportExcelXLS(fileName, true).Tables[0];
                        break;

                }
            }
            return excs;
        }

        private void btnSetPower_Click(object sender, EventArgs e)
        {
            if (_SPC_RFID.IsInScan ==false)
            {
                _SPC_RFID.SetPower(31); //max               
            }
        }

        private void btnGetPower_Click(object sender, EventArgs e)
        {
            txttag.Text = _SPC_RFID.readSingleTag();
        }

        private void trackBar_txpwr_Scroll(object sender, EventArgs e)
        {
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            trackBarPower.Value = 6;
            if (!txttag.Text.Equals(string.Empty))
            { 
                bool res= _SPC_RFID.encodeTag(txttag.Text);
                txttag.ForeColor = (res) ? Color.Green : Color.Red;
            }
        }

        private void txttag_TextChanged(object sender, EventArgs e)
        {
            txttag.ForeColor = Color.Black;
        }
    }
}

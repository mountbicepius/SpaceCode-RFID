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

namespace WindowsTestApp
{
    public partial class Form2 : Form
    {
        SPC_RFID _SPC_RFID = null;
        public Form2()
        {
            InitializeComponent();
            _SPC_RFID = SPC_RFID.getInstance();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            _SPC_RFID.tagsDelegate = tagAdd;
            _SPC_RFID.deviceStatusDelegate = devStAdd;
            _SPC_RFID.errorDelegate = errorAdd;
            _SPC_RFID.scanCompleteDelegate = scanComplted;

            if (btnScan.Text.Equals("Start Scan"))
            {
                _SPC_RFID.startScan(false);
                btnScan.Text = "Stop Scan";
            }
            else
            {
                _SPC_RFID.stopScan();
                btnScan.Text = "Start Scan";
            }
            
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
                //lblMessage.Text = tag.ToArray()[0]+" : " + weight+ " : " + user;
                //lstControls.Items.Clear();
                //lstControls.Items.AddRange(tag.ToArray());                
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

        private void txtTagsList_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCount_Click(object sender, EventArgs e)
        {

        }
    }
}

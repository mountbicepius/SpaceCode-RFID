using System;
using System.Windows.Forms;

namespace SBR2_Demo
{
    public partial class NewUIDPrompt : Form
    {
        public string NewUID { get { return textBoxNewUID.Text; } }
        public int modeWrite { get { return comboBoxSelWrite.SelectedIndex; }}

        public NewUIDPrompt(string oldUID)
        {
            InitializeComponent();
            textBoxOldUID.Text = oldUID;
            comboBoxSelWrite.SelectedIndex = 1;
        }

        private void textBoxNewUID_TextChanged(object sender, EventArgs e)
        {
            bool isTextValid = (SDK_SC_RfidReader.DeviceBase.SerialRFID.isStringValidToWrite(textBoxNewUID.Text.Trim()));
            buttonConfirmUID.Enabled = isTextValid;
            labelWarningInvalid.Visible = !isTextValid && !String.IsNullOrEmpty(textBoxNewUID.Text);
        }

        private void buttonConfirmUID_Click(object sender, EventArgs e)
        {

        }
    }
}

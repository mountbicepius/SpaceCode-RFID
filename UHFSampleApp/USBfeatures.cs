using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataClass;
using SDK_SC_RfidReader;
using SDK_SC_RFID_Devices;

namespace SBR2_Demo
{
    public static class USBFeatures
    {
        public static bool StartScan(RFID_Device localDevice, bool bUnlockAll)
        {
            if (localDevice == null) return false;

            if ((localDevice.ConnectionStatus == ConnectionStatus.CS_Connected) &&
                (localDevice.DeviceStatus == DeviceStatus.DS_Ready))
            {
                localDevice.ScanDevice(true,bUnlockAll);
                return true;
            }

            return false;
        }


        public static void StopScan(RFID_Device localDevice)
        {
            if (localDevice == null) return;
            if ((localDevice.ConnectionStatus == ConnectionStatus.CS_Connected) &&
                  (localDevice.DeviceStatus == DeviceStatus.DS_InScan))
                localDevice.StopScan();
        }


        public static void LedOnAll(RFID_Device localDevice, List<string> tagsList)
        {
            int nbTagToLight = tagsList.Count; // initial number of tags

            localDevice.TestLighting(tagsList);

            string message = String.Format("{0} tags to find : {1} have been found.", nbTagToLight,
                nbTagToLight - tagsList.Count);

            if (tagsList.Count > 0) // some tag UIDs are still in the list : they've not been found
            {
                message += "\nMissing tags ID :";

                foreach (string missingTag in tagsList)
                    message = String.Format("{0}\n{1}", message, missingTag);
            }

            MessageBox.Show(message); // while user doesn't close the dialog, the led-lighting thread is still running

            localDevice.StopLightingLeds(); // stops lighting once user closed MessageBox
        }

        public static void ConfirmAll(RFID_Device localDevice, List<string> tagsList)
        {
            int nbTagToConfirm = tagsList.Count; // initial number of tags

            localDevice.ConfirmList(tagsList,TagType.TT_R8);

            string message = String.Format("{0} tags to Confirm: {1} have been found.", nbTagToConfirm,
                nbTagToConfirm - tagsList.Count);

            if (tagsList.Count > 0) // some tag UIDs are still in the list : they've not been found
            {
                message += "\nMissing tags ID :" + tagsList.Count + "\r\n";

                foreach (string missingTag in tagsList)
                    message = String.Format("{0}\n{1}", message, missingTag);
            }
            MessageBox.Show(message); // while user doesn't close the dialog, the led-lighting thread is still running

        
        }

        public static WriteCode WriteNewUID(RFID_Device localDevice, string oldUID, string newUID , int writeMode)
        {
            if (writeMode == 0)
                return localDevice.WriteNewUID(oldUID, newUID );
            if (writeMode == 1)
                return localDevice.WriteNewUidWithFamily(oldUID, newUID);
           if (writeMode == 2)
                return localDevice.WriteNewUidDecimal(oldUID, newUID);

            return WriteCode.WC_Error;
        
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DataClass;
using TcpIP_class;

namespace SBR2_Demo
{
    public static class TCPFeatures
    {
        public static TcpIpClient.RetCode StartScan(DeviceInfo ethernetDevice,TcpIpClient tcpClient , out InventoryData lastInventoryData)
        {
            lastInventoryData = null; // used to store inventory (once the scan is over)

            if (ethernetDevice == null) return TcpIpClient.RetCode.RC_FailedToConnect;

            string status;

            // try to get device's status
            if (tcpClient.getStatus(ethernetDevice.IP_Server, ethernetDevice.Port_Server,
                    ethernetDevice.SerialRFID, out status) != TcpIpClient.RetCode.RC_Succeed)
                return TcpIpClient.RetCode.RC_FailedToConnect;

            DeviceStatus currentStatus = (DeviceStatus)Enum.Parse(typeof(DeviceStatus), status);

            // check that device is in ready state
            if (currentStatus != DeviceStatus.DS_Ready)
                return TcpIpClient.RetCode.RC_Device_Not_In_Ready_State;

            if (tcpClient.requestScan(ethernetDevice.IP_Server, ethernetDevice.Port_Server, ethernetDevice.SerialRFID) != TcpIpClient.RetCode.RC_Succeed) // scan starting has failed
                return TcpIpClient.RetCode.RC_Failed;

            do // will loop until Device doesn't leave "InScan" state
            {
                Thread.Sleep(500); // wait 500ms before polling device (to get scan result, if scan is over)

                // try to get device's status
                if (tcpClient.getStatus(ethernetDevice.IP_Server, ethernetDevice.Port_Server,
                        ethernetDevice.SerialRFID, out status) != TcpIpClient.RetCode.RC_Succeed)
                    return TcpIpClient.RetCode.RC_FailedToConnect;

                currentStatus = (DeviceStatus)Enum.Parse(typeof(DeviceStatus), status);

            } while (currentStatus == DeviceStatus.DS_InScan);

            if (tcpClient.requestGetLastScan(ethernetDevice.IP_Server,
                        ethernetDevice.Port_Server,
                        ethernetDevice.SerialRFID, out lastInventoryData) != TcpIpClient.RetCode.RC_Succeed) // failed to get last inventorydata
                return TcpIpClient.RetCode.RC_FailedToConnect;

            return lastInventoryData == null ? TcpIpClient.RetCode.RC_UnknownError : TcpIpClient.RetCode.RC_Succeed;
        }


        public static TcpIpClient.RetCode StopScan(DeviceInfo ethernetDevice, TcpIpClient tcpClient)
        {
            if (ethernetDevice == null) return TcpIpClient.RetCode.RC_FailedToConnect;
            return tcpClient.requestStopScan(ethernetDevice.IP_Server, ethernetDevice.Port_Server, ethernetDevice.SerialRFID);
        }


        public static void LedOnAll(DeviceInfo ethernetDevice, TcpIpClient tcpClient, List<string> tagsList)
        {
            if (ethernetDevice == null) return;
           
            int nbTagToLight = tagsList.Count; // initial number of tags

            TcpIpClient.RetCode ret;
            ret = tcpClient.RequestStartLighting(ethernetDevice.IP_Server, ethernetDevice.Port_Server, tagsList);
            if( ret != TcpIpClient.RetCode.RC_Succeed)
            {
                MessageBox.Show("An unexpected error occurred during communication with device : " + ret.ToString());
                tcpClient.RequestStopLighting(ethernetDevice.IP_Server, ethernetDevice.Port_Server);
                return;
            }

            StringBuilder resultMessage = new StringBuilder(String.Format("{0} tags to find : {1} have been found.", nbTagToLight,
                nbTagToLight - tagsList.Count));

            if (tagsList.Count > 0) // some tag UIDs are still in the list : they've not been found
            {
                resultMessage.AppendLine("Missing tags ID :");

                foreach (string missingTag in tagsList)
                    resultMessage.AppendLine(missingTag);
            }

            MessageBox.Show(resultMessage.ToString());

            tcpClient.RequestStopLighting(ethernetDevice.IP_Server, ethernetDevice.Port_Server);
        }


        public static WriteCode WriteNewUID(DeviceInfo ethernetDevice, TcpIpClient tcpClient,string oldUID, string newUID , int writeMode)
        {
            WriteCode result;
            tcpClient.RequestWriteBlock(ethernetDevice.IP_Server, ethernetDevice.Port_Server, oldUID, newUID, out result, writeMode);
            return result;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace LaunchPad.Configurators
{
    class NetworkConfigurator : IConfigurator
    {
        ITerminalStation StationSettings;

        private NetworkConfigurator() { }
        public NetworkConfigurator(ITerminalStation settings)
        {
            StationSettings = settings;
        }


        public void Configure()
        {
            SetNetBIOSName();
            SetIPAddress();
            RecordSettings();
        }


        public void SetNetBIOSName()
        {
            try
            {
                object output = null;

                var MC = new ManagementClass("Win32_ComputerSystem");
                var MOC = MC.GetInstances();

                foreach (ManagementObject obj in MOC)
                {
                    var inputParams = obj.GetMethodParameters("Rename");
                    inputParams["Name"] = StationSettings.ComputerName;
                    output = obj.InvokeMethod("Rename", inputParams, null);
                }

                var returnvalue = Convert.ToInt32(((ManagementBaseObject)output).Properties["ReturnValue"].Value);
                if (returnvalue != 0)
                {
                    throw new Exception(@"Could not change network name.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(@"Could not change computer name: " + ex.Message);
                return;
            }
        }


        public void SetIPAddress()
        {
            var MC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var collection = MC.GetInstances();

            // Terminals have only one NIC, so this should be okay.
            foreach (ManagementObject obj in collection)
            {
                if ((bool)(obj["IPEnabled"]))
                {
                    var newIP = obj.GetMethodParameters("EnableStatic");

                    newIP["IPAddress"] = new string[] { StationSettings.IPAddress.ToString() };
                    newIP["SubnetMask"] = new string[] { "255.255.255.0" };

                    var setIP = obj.InvokeMethod("EnableStatic", newIP, null);
                }
            }
        }

        private void RecordSettings()
        {
            var settings = SettingsReader.Instance;
            settings.ComputerName = StationSettings.ComputerName;
            settings.IPAddress = StationSettings.IPAddress;

            if (settings.PointOfSale == PointOfSale.Positouch)
            {
                var source = (PositouchTerminalStation)StationSettings;
                if (source.PosdriverIPAddress != null)
                {
                    settings.PosdriverIPAddress = source.PosdriverIPAddress;
                }
                if (source.BackofficeIPAddress != null)
                {
                    settings.BackofficeIPAddress = source.BackofficeIPAddress;
                }
                if (source.RedundantIPAddress != null)
                {
                    settings.RedundantIPAddress = source.RedundantIPAddress;
                }
            }
        }
    }
}
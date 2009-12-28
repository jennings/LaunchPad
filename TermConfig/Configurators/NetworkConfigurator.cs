using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace TermConfig.Configurators
{
    class NetworkConfigurator : IConfigurator
    {
        TerminalStation StationSettings;


        public NetworkConfigurator( TerminalStation settings )
        {
            settings.Validate();
            StationSettings = settings;
        }


        public void Configure()
        {
            SetNetBIOSName();
            SetIPAddress();
        }


        public void SetNetBIOSName()
        {
            var MC = new ManagementClass( "Win32_ComputerSystem" );

            var inputParams = MC.GetMethodParameters( "Rename" );
            inputParams["Name"] = StationSettings.Name;
            var output = MC.InvokeMethod( "Rename", inputParams, null );

            var returnvalue = (int)output.Properties["ReturnValue"].Value;
            if ( returnvalue != 0 )
            {
                throw new Exception( @"Could not change network name." );
            }
        }


        public void SetIPAddress()
        {
            var MC = new ManagementClass( "Win32_NetworkAdapterConfiguration" );
            var collection = MC.GetInstances();

            // Terminals have only one NIC, so this should be okay.
            foreach ( ManagementObject obj in collection )
            {
                if ( (bool)( obj["IPEnabled"] ) )
                {
                    var newIP = obj.GetMethodParameters( "EnableStatic" );

                    newIP["IPAddress"] = new string[] { StationSettings.IPAddress.ToString() };
                    newIP["SubnetMask"] = new string[] { "255.255.255.0" };

                    var setIP = obj.InvokeMethod( "EnableStatic", newIP, null );
                }
            }
        }
    }
}

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
            throw new NotImplementedException();
        }


        public void SetNetBIOSName()
        {
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

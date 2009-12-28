using System;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Text;
using System.IO;
using TermConfig.Configurators;

namespace TermConfig
{
    class SettingCommitter
    {
        [Obsolete]
        public static void ChangeTerminalIPAddress( string address )
        {
            var ip = IPAddress.Parse( address );
            ChangeTerminalIPAddress( ip );
        }

        [Obsolete]
        public static void ChangeTerminalIPAddress( IPAddress address )
        {
            var MC = new ManagementClass( "Win32_NetworkAdapterConfiguration" );
            var collection = MC.GetInstances();

            // Terminals have only one NIC, so this should be okay.
            foreach ( ManagementObject obj in collection )
            {
                if ( (bool)( obj["IPEnabled"] ) )
                {
                    var newIP = obj.GetMethodParameters( "EnableStatic" );

                    newIP["IPAddress"] = new string[] { address.ToString() };
                    newIP["SubnetMask"] = new string[] { "255.255.255.0" };

                    var setIP = obj.InvokeMethod( "EnableStatic", newIP, null );
                }
            }
        }

        [Obsolete]
        public static void WritePosiw( int deviceNumber )
        {
            /*
            if ( deviceNumber < 1 || 99 < deviceNumber )
                throw new ArgumentOutOfRangeException( "Device number must be between 1 and 99." );
            var posiw = new PosiwConfigurator();
            posiw.DeviceNumber = deviceNumber;

            posiw.Write();
             */
        }

        [Obsolete]
        public static void InstallVNC( string password )
        {
        }

        [Obsolete]
        public static void RebootTerminal()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace TermConfig
{
    class SettingCommitter
    {
        public static void ChangeTerminalIPAddress( string address )
        {
            var ip = IPAddress.Parse( address );
            ChangeTerminalIPAddress( ip );
        }

        public static void ChangeTerminalIPAddress( IPAddress address )
        {
        }

        public static void CopyINIs( string remoteTerminalAddress, string username, string password )
        {
            var ip = IPAddress.Parse( remoteTerminalAddress );
            CopyINIs( ip, username, password );
        }

        public static void CopyINIs( IPAddress remoteTerminalAddress, string username, string password )
        {
        }

        public static void WritePosiw( int deviceNumber )
        {
            if ( deviceNumber < 1 || 99 < deviceNumber )
                throw new ArgumentOutOfRangeException( "Device number must be between 1 and 99." );
            var posiw = new PosiwBuilder();
            posiw.DeviceNumber = deviceNumber;

            posiw.Write();
        }

        public static void InstallVNC( string password )
        {
        }

        public static void RebootTerminal()
        {
        }
    }
}

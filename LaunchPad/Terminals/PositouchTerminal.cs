using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace LaunchPad.Terminals
{
    class PositouchTerminal
    {
        public string Name { get; set; }
        
        public int DeviceNumber { get; set; }

        public string WindowsLogonUsername { get { return "pos"; } }
        public string WindowsLogonPassword { get { return "pos"; } }
        public string WindowsAdminUsername { get { return "cbs"; } }
        public string WindowsAdminPassword { get; set; }

        public IPAddress IPAddress { get; set; }
        public IPAddress SubnetMask { get; set; }
        public IPAddress DefaultGateway { get; set; }

        public IPAddress PosdriverIPAddress { get; set; }
        public IPAddress BackofficeIPAddress { get; set; }
        public IPAddress RedundantIPAddress { get; set; }
    }
}

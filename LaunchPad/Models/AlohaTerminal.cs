using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace LaunchPad.Models
{
    public class AlohaTerminal
    {
        public string UnitName { get; set; }
        
        public int Term { get; set; }
        public string TermName { get { return "TERM" + Term; } }
        public string Workgroup { get; set; }

        public string WindowsLogonUsername { get; set; }
        public string WindowsLogonPassword { get; set; }
        public string WindowsAdminUsername { get; set; }
        public string WindowsAdminPassword { get; set; }
        
        public IPAddress IPAddress { get; set; }
        public IPAddress SubnetMask { get; set; }
        public IPAddress DefaultGateway { get; set; }
        public IPAddress DNS1 { get; set; }
        public IPAddress DNS2 { get; set; }
        
        public int NumberOfTerminals { get; set; }
        public string FileserverName { get; set; }
        
        public bool MasterCapable { get; set; }
        public bool ServerCapable { get; set; }

        // FIXME: TimeZone is too limited for this purpose.
        // public TimeZone @TimeZone { get; set; }

        public override string ToString()
        {
            return TermName;
        }
    }
}

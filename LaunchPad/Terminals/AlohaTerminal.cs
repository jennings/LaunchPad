using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace LaunchPad.Terminals
{
    class AlohaTerminal
    {
        public string UnitName { get; set; }
        
        public int Term { get; set; }
        public IPAddress IPAddress { get; set; }
        public IPAddress SubnetMask { get; set; }
        public IPAddress DefaultGateway { get; set; }
        
        public int NumberOfTerminals { get; set; }
        public string FileserverName { get; set; }
        
        public bool MasterCapable { get; set; }
        public bool ServerCapable { get; set; }
    }
}

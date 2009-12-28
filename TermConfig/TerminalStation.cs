using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace TermConfig
{
    class TerminalStation
    {
        public TerminalStationType @Type { get; set; }
        public bool PosdriverTerminal { get { return @Type == TerminalStationType.Posdriver; } }
        public bool RedundantTerminal { get { return @Type == TerminalStationType.Redunant; } }
        public bool NormalTerminal { get { return @Type == TerminalStationType.Normal; } }
        public bool Backoffice { get { return @Type == TerminalStationType.Backoffice; } }

        public string Name { get; set; }

        public int DeviceNumber { get; set; }
        public string DeviceNumberString { get { return DeviceNumber.ToString( "D2" ); } }

        public string Password { get; set; }

        public IPAddress @IPAddress { get; set; }
        public IPAddress @PosdriverIPAddress { get; set; }
        public IPAddress @RedundantIPAddress { get; set; }
    }

    enum TerminalStationType
    {
        Posdriver,
        Redunant,
        Backoffice,
        Normal
    }
}

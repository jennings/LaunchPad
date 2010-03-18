using System.Net;

namespace LaunchPad.Models
{
    public class AlohaTerminalModel
    {
        public IPAddress @IPAddress { get; set; }

        public int TerminalNumber { get; set; }
        public string ComputerName
        {
            get
            {
                return "TERM" + TerminalNumber;
            }
        }

        public int NumberOfTerminals { get; set; }
        public string FileserverName { get; set; }
        public bool MasterCapable { get; set; }
        public bool ServerCapable { get; set; }
    }
}

using System.Net;

namespace LaunchPad.Models
{
    public class PositouchTerminalSelectionModel
    {
        public IPAddress @IPAddress { get; set; }
        public IPAddress @BackofficeIPAddress { get; set; }
        public IPAddress @PosdriverIPAddress { get; set; }

        public int DeviceNumber { get; set; }
        public string ComputerName
        {
            get
            {
                if ( Type == PosiwTerminalType.PrimaryServer )
                    return "POSDRVR";
                return "TERM" + ( DeviceNumber - 1 ).ToString( "D3" );
            }
        }

        public PosiwTerminalType Type { get; set; }
    }
}

using System.Net;

namespace LaunchPad.Models
{
    public class PositouchTerminalSelectionModel
    {
        public IPAddress @IPAddress { get; set; }
        public int DeviceNumber { get; set; }
        public PosiwTerminalType Type { get; set; }
    }
}

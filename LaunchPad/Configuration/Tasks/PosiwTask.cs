using System;
using System.Net;
using LaunchPad.Models;

namespace LaunchPad.Configuration.Tasks
{
    [Serializable]
    public class PosiwTask : ITask
    {
        public int DeviceNumber { get; private set; }
        public PositouchTerminalType @Type { get; private set; }
        
        public IPAddress @BackofficeIPAddress { get; private set; }
        public IPAddress @PosdriverIPAddress { get; private set; }
        public IPAddress @RedundantIPAddress { get; private set; }

        private PosiwTask() { }

        public PosiwTask( int devicenumber, PositouchTerminalType type, IPAddress backofficeip, IPAddress posdriverip, IPAddress redundantip )
        {
            DeviceNumber = devicenumber;
            @Type = type;
            BackofficeIPAddress = backofficeip;
            PosdriverIPAddress = posdriverip;
            RedundantIPAddress = redundantip;
        }
    }
}

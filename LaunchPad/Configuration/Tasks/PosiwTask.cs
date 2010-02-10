using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace LaunchPad.Configuration.Tasks
{
    public class PosiwTask : ITask
    {
        public int DeviceNumber { get; private set; }
        public PosiwTerminalType @Type { get; private set; }
        
        public IPAddress @BackofficeIPAddress { get; private set; }
        public IPAddress @PosdriverIPAddress { get; private set; }
        public IPAddress @RedundantIPAddress { get; private set; }

        private PosiwTask() { }

        public PosiwTask( int devicenumber, PosiwTerminalType type, IPAddress backofficeip, IPAddress posdriverip, IPAddress redundantip )
        {
            DeviceNumber = devicenumber;
            @Type = type;
            BackofficeIPAddress = backofficeip;
            PosdriverIPAddress = posdriverip;
            RedundantIPAddress = redundantip;
        }
    }
}

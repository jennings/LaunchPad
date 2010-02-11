using System.Net;

namespace LaunchPad.Configuration.Tasks
{
    public class IPAddressTask : ITask
    {
        public IPAddress @IPAddress { get; private set; }

        private IPAddressTask() { }
        public IPAddressTask( IPAddress ipaddress )
        {
            IPAddress = ipaddress;
        }
    }
}

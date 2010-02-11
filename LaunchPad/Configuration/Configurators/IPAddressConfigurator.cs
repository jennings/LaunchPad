using System.Management;
using System.Net;
using LaunchPad.Configuration.Tasks;

namespace LaunchPad.Configuration.Configurators
{
    class IPAddressConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return true; } }
        public bool RequiresAuthentication { get { return false; } }

        private IPAddress NewIPAddress;

        private IPAddressConfigurator() { }
        public IPAddressConfigurator( IPAddressTask task )
        {
            NewIPAddress = task.IPAddress;
        }


        public void Configure()
        {
            var MC = new ManagementClass( "Win32_NetworkAdapterConfiguration" );
            var collection = MC.GetInstances();

            // Terminals have only one NIC, so this should be okay.
            foreach ( ManagementObject obj in collection )
            {
                if ( (bool)( obj["IPEnabled"] ) )
                {
                    var newIP = obj.GetMethodParameters( "EnableStatic" );

                    newIP["IPAddress"] = new string[] { NewIPAddress.ToString() };
                    newIP["SubnetMask"] = new string[] { "255.255.255.0" };

                    var setIP = obj.InvokeMethod( "EnableStatic", newIP, null );
                }
            }
        }
    }
}

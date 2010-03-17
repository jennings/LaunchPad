using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using LaunchPad.Configuration.Tasks;

namespace LaunchPad.Configuration.Configurators
{
    class ComputerNameConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return true; } }
        public bool RequiresAuthentication { get { return false; } }

        private string NewComputerName;

        private ComputerNameConfigurator() { }
        public ComputerNameConfigurator( ComputerNameTask task )
        {
            NewComputerName = task.ComputerName;
        }

        [DllImport( "kernel32.dll", CharSet = CharSet.Auto )]
        private static extern bool SetComputerNameEx( COMPUTER_NAME_FORMAT NameType, string lpBuffer );
        private enum COMPUTER_NAME_FORMAT
        {
            ComputerNameNetBIOS,
            ComputerNameDnsHostname,
            ComputerNameDnsDomain,
            ComputerNameDnsFullyQualified,
            ComputerNamePhysicalNetBIOS,
            ComputerNamePhysicalDnsHostname,
            ComputerNamePhysicalDnsDomain,
            ComputerNamePhysicalDnsFullyQualified
        }

        public void Configure()
        {
            bool result = SetComputerNameEx( COMPUTER_NAME_FORMAT.ComputerNamePhysicalDnsHostname, NewComputerName );
            if ( !result )
            {
                throw new Win32Exception();
            }
        }
    }
}

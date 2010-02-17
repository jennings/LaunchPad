using System;
using System.Management;
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


        public void Configure()
        {
            try
            {
                object output = null;

                var MC = new ManagementClass( "Win32_ComputerSystem" );
                var MOC = MC.GetInstances();

                foreach ( ManagementObject obj in MOC )
                {
                    var inputParams = obj.GetMethodParameters( "Rename" );
                    inputParams["Name"] = NewComputerName;
                    output = obj.InvokeMethod( "Rename", inputParams, null );
                }

                var returnvalue = Convert.ToInt32( ( (ManagementBaseObject)output ).Properties["ReturnValue"].Value );
                if ( returnvalue != 0 )
                {
                    throw new Exception( @"Could not change network name." );
                }
            }
            catch ( Exception )
            {
                // FIXME
                // System.Windows.Forms.MessageBox.Show( @"Could not change computer name: " + ex.Message );
                return;
            }
        }
    }
}

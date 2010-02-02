using System.Collections.Generic;
using LaunchPad.Authentication;
using LaunchPad.Configuration.Configurators;

namespace LaunchPad.Configuration
{
    class PositouchInitialConfiguratorController : IConfiguratorController
    {
        public bool RequiresAuthentication
        {
            get { return RemoteConfigurators.RequiresAuthentication; }
        }

        PositouchTerminalStation StationSettings;
        List<IConfigurator> Configurators = new List<IConfigurator>();
        RemoteConfiguratorDispatcher RemoteConfigurators = new RemoteConfiguratorDispatcher();

        private PositouchInitialConfiguratorController() { }
        public PositouchInitialConfiguratorController( PositouchTerminalStation settings )
        {
            settings.ValidateInitial();
            StationSettings = settings;

            RemoteConfigurators.AddCredentialTask( StationSettings.WindowsPassword );
            RemoteConfigurators.AddComputerNameTask( StationSettings.ComputerName );
            RemoteConfigurators.AddIPAddressTask( StationSettings.IPAddress );
        }

        public void Configure()
        {
            System.Windows.Forms.MessageBox.Show( "PositouchInitialConfiguratorController running as: " + GetCurrentCredentials() );

            if ( RemoteConfigurators.RequiresAuthentication )
            {
                // TODO: Challenge / Response
                RemoteConfigurators.Response = new Response( RemoteConfigurators.Challenge );
            }

            RemoteConfigurators.Process();

            foreach ( var configurator in Configurators )
            {
                configurator.Configure();
            }

            SettingsReader.Instance.Commit();

            //Rebooter.Reboot();
        }

        public string GetCurrentCredentials()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }
    }
}

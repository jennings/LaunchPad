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
            if ( RemoteConfigurators.RequiresAuthentication )
            {
                // TODO: Challenge / Response
                RemoteConfigurators.Response = new Response( RemoteConfigurators.Challenge );
            }

            RemoteConfigurators.Dispatch();

            foreach ( var configurator in Configurators )
            {
                configurator.Configure();
            }

            SettingsReader.Instance.Commit();

            //Rebooter.Reboot();
        }
    }
}

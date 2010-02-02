using System.Collections.Generic;
using LaunchPad.Configuration.Configurators;

namespace LaunchPad.Configuration
{
    class PositouchInitialConfiguratorController : IConfiguratorController
    {
        PositouchTerminalStation StationSettings;
        List<IConfigurator> Configurators = new List<IConfigurator>();

        private PositouchInitialConfiguratorController() { }
        public PositouchInitialConfiguratorController( PositouchTerminalStation settings )
        {
            settings.ValidateInitial();
            StationSettings = settings;

            Configurators.Add( new CredentialsConfigurator( StationSettings.WindowsUsername, StationSettings.WindowsPassword ) );
            Configurators.Add( new NetworkConfigurator( StationSettings ) );
        }

        public void Configure()
        {
            var remoteDispatch = new RemoteConfiguratorDispatcher();

            foreach ( var configurator in Configurators )
            {
                if ( configurator.RequiresElevation )
                {
                    remoteDispatch.Add( configurator );
                }
                else
                {
                    configurator.Configure();
                }
            }

            if ( remoteDispatch.RequiresAuthentication )
            {
                // TODO: Challenge / Response
            }
            
            remoteDispatch.Process();

            SettingsReader.Instance.Commit();

            Rebooter.Reboot();
        }
    }
}

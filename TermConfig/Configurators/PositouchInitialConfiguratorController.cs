using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace TermConfig.Configurators
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
            Configurators.Add( new RebootConfigurator() );
        }

        public void Configure()
        {
            foreach ( var configurator in Configurators )
            {
                configurator.Configure();
            }
        }
    }
}

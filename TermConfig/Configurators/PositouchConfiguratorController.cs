using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace TermConfig.Configurators
{
    class PositouchConfiguratorController : IConfiguratorController
    {
        private PositouchTerminalStation StationSettings;
        private List<IConfigurator> Configurators = new List<IConfigurator>();
        private OleDbConnection SettingsDatabase;

        private PositouchConfiguratorController() { }
        public PositouchConfiguratorController( PositouchTerminalStation terminalStation )
        {
            terminalStation.Validate();
            StationSettings = terminalStation;

            var csb = new OleDbConnectionStringBuilder()
            {
                DataSource = @"Settings.mdb",
                Provider = @"Microsoft.Jet.OLEDB.4.0"
            };
            SettingsDatabase = new OleDbConnection( csb.ConnectionString );

            Configurators.Add( new CredentialsConfigurator( StationSettings.WindowsUsername, StationSettings.WindowsPassword ) );
            Configurators.Add( new NetworkConfigurator( StationSettings ) );
            Configurators.Add( new PositermConfigurator( StationSettings ) );
            Configurators.Add( new PosiwConfigurator( StationSettings ) );
            Configurators.Add( new VNCConfigurator( StationSettings ) );
            Configurators.Add( new RebootConfigurator() );
        }

        public void Configure()
        {
            foreach ( var configurator in Configurators )
            {
                configurator.Configure( SettingsDatabase );
            }
        }
    }
}

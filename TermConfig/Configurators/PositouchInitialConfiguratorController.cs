using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Data.OleDb;
using System.IO;
using ADOX;

namespace TermConfig.Configurators
{
    class PositouchInitialConfiguratorController : IConfiguratorController
    {
        PositouchTerminalStation StationSettings;
        List<IConfigurator> Configurators = new List<IConfigurator>();
        OleDbConnection SettingsDatabase;

        private PositouchInitialConfiguratorController() { }
        public PositouchInitialConfiguratorController( PositouchTerminalStation settings )
        {
            settings.ValidateInitial();
            StationSettings = settings;

            if ( !File.Exists( @"Settings.mdb" ) )
            {
                var cat = new Catalog();
                cat.Create( @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Settings.mdb;" );
            }

            var csb = new OleDbConnectionStringBuilder()
            {
                DataSource = @"Settings.mdb",
                Provider = @"Microsoft.Jet.OLEDB.4.0"
            };
            SettingsDatabase = new OleDbConnection( csb.ConnectionString );

            Configurators.Add( new CredentialsConfigurator( StationSettings.WindowsUsername, StationSettings.WindowsPassword ) );
            Configurators.Add( new NetworkConfigurator( StationSettings ) );
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

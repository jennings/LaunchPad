using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.IO;
using ADOX;

namespace TermConfig.Launchers
{
    public class AlohaLaunchController : ILaunchController
    {
        public bool LaunchesTerminal { get; private set; }

        private List<ILauncher> Launchers = new List<ILauncher>();
        private const string ConfigDatabase = @"TermConfig.mdb";

        public AlohaLaunchController()
        {
            LaunchesTerminal = false;

            if ( !File.Exists( ConfigDatabase ) )
            {
                var cat = new Catalog();
                cat.Create( @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + ConfigDatabase + @";" );
            }

            var csb = new OleDbConnectionStringBuilder()
            {
                DataSource = ConfigDatabase,
                Provider = @"Microsoft.Jet.OLEDB.4.0"
            };

            using ( var db = new OleDbConnection( csb.ConnectionString ) )
            {
                db.Open();

                var query = @"SELECT key, value FROM tblAlohaSettings;";

                using ( var cmd = new OleDbCommand( query, db ) )
                {
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        while ( reader.Read() )
                        {
                            switch ( reader["key"].ToString().ToUpper() )
                            {
                                case "LAUNCH_ALOHATERMINAL":
                                    if ( reader["value"].ToString().ToUpper() == "YES" )
                                    {
                                        LaunchesTerminal = true;
                                        Launchers.Add( new AlohaTerminalLauncher() );
                                    }
                                    break;
                            }
                        }
                    }
                    catch ( OleDbException ex )
                    {
                        System.Windows.Forms.MessageBox.Show( "Could not read tblPositouchSettings: " + ex.Message );
                    }
                }

                db.Close();
            }
        }

        public void Launch()
        {
            foreach ( var launcher in Launchers )
            {
                launcher.Launch();
            }
        }
    }
}

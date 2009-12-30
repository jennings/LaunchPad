using System.Collections.Generic;
using System.Data.OleDb;
using ADOX;
using System.IO;

namespace TermConfig.Launchers
{
    public class PositouchLaunchController : ILaunchController
    {
        public bool LaunchesPosiw { get; private set; }
        public bool LaunchesPositerm { get; private set; }
        public bool LaunchesVNC { get; private set; }

        private List<ILauncher> Launchers = new List<ILauncher>();
        private const string ConfigDatabase = @"TermConfig.mdb";

        public PositouchLaunchController()
        {
            LaunchesPositerm = false;
            LaunchesPosiw = false;
            LaunchesVNC = false;

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

                var query = @"SELECT key, value FROM tblPositouchSettings;";

                using ( var cmd = new OleDbCommand( query, db ) )
                {
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        while ( reader.Read() )
                        {
                            switch ( reader["key"].ToString().ToUpper() )
                            {
                                case "LAUNCH_POSIW":
                                    if ( reader["value"].ToString().ToUpper() == "YES" )
                                    {
                                        LaunchesPosiw = true;
                                        Launchers.Add( new PosiwLauncher() );
                                    }
                                    break;
                                case "LAUNCH_POSITERM":
                                    if ( reader["value"].ToString().ToUpper() == "YES" )
                                    {
                                        LaunchesPositerm = true;
                                        Launchers.Add( new PositermLauncher() );
                                    }
                                    break;
                                case "LAUNCH_VNC":
                                    if ( reader["value"].ToString().ToUpper() == "YES" )
                                    {
                                        LaunchesVNC = true;
                                        Launchers.Add( new VNCLauncher() );
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

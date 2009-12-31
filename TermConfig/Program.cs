using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace TermConfig
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );

            var Positouch = File.Exists( @"POSITOUCH" );
            var Aloha = File.Exists( @"ALOHA" );

            try
            {
                bool foundOK = false;

                var csb = new OleDbConnectionStringBuilder()
                {
                    DataSource = @"Settings.mdb",
                    Provider = @"Microsoft.Jet.OLEDB.4.0"
                };

                using ( var db = new OleDbConnection( csb.ConnectionString ) )
                {
                    db.Open();
                    var query = @"SELECT key, value FROM tblSettings WHERE key='INTEGRITY';";

                    using ( var cmd = new OleDbCommand( query, db ) )
                    {
                        var reader = cmd.ExecuteReader();
                        while ( reader.Read() )
                        {
                            if ( reader["value"].ToString().ToUpper() == "OK" )
                            {
                                foundOK = true;
                            }
                        }
                    }

                    db.Close();
                }

                if ( foundOK )
                {
                    if ( Positouch )
                    {
                        Application.Run( new PositouchStartupWindow() );
                    }
                    else if ( Aloha )
                    {
                        Application.Run( new AlohaStartupWindow() );
                    }
                    else
                    {
                        MessageBox.Show( @"Add POSITOUCH or ALOHA flag file to use." );
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch ( Exception )
            {
                File.Delete( @"Settings.mdb" );
                if ( Positouch )
                {
                    Application.Run( new PositouchInitialConfigWindow() );
                }
                else if ( Aloha )
                {
                    Application.Run( new AlohaInitialConfigWindow() );
                }
                else
                {
                    MessageBox.Show( @"Add POSITOUCH or ALOHA flag file to use." );
                }
            }
        }
    }
}

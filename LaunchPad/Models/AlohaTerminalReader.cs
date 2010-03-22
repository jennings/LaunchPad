using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Net;
using System.IO;

namespace LaunchPad.Models
{
    class AlohaTerminalReader
    {
        public static bool PreconfigurationAvailable
        {
            get
            {
                return File.Exists( @"C:\LaunchPad\AlohaTerminals.csv" );
            }
        }

        private static AlohaTerminalReader _Instance = null;
        public static AlohaTerminalReader Instance
        {
            get
            {
                if ( _Instance == null )
                {
                    _Instance = new AlohaTerminalReader();
                }
                return _Instance;
            }
        }

        public List<AlohaTerminal> Terminals { get; private set; }
        public List<string> Units { get; private set; }

        private AlohaTerminalReader()
        {
            Terminals = new List<AlohaTerminal>();
            Units = new List<string>();

            ReadTerminals();
        }

        public void ReadTerminals()
        {
            Terminals.Clear();

            var cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\;";
            cs = cs + @"Extended Properties=""text;HDR=Yes;FMT=Delimited"";";

            var db = new OleDbConnection( cs );

            db.Open();

            var unitQuery = @"SELECT DISTINCT UnitName FROM AlohaTerminals.csv ORDER BY UnitName;";

            using ( var cmd = new OleDbCommand( unitQuery, db ) )
            using ( var reader = cmd.ExecuteReader() )
            {
                while ( reader.Read() )
                {
                    Units.Add( reader["UnitName"].ToString() );
                }
            }

            var query = @"SELECT * FROM AlohaTerminals.csv ORDER BY UnitName, Term;";

            using ( var cmd = new OleDbCommand( query, db ) )
            using ( var reader = cmd.ExecuteReader() )
            {
                while ( reader.Read() )
                {
                    var term = new AlohaTerminal();

                    term.UnitName = Convert.ToString( reader["UnitName"] );

                    term.Term = Convert.ToInt32( reader["Term"] );
                    term.Workgroup = Convert.ToString( reader["Workgroup"] );

                    term.IPAddress = IPAddress.Parse( Convert.ToString( reader["IPAddress"] ) );
                    term.SubnetMask = IPAddress.Parse( Convert.ToString( reader["SubnetMask"] ) );
                    term.DefaultGateway = IPAddress.Parse( Convert.ToString( reader["DefaultGateway"] ) );
                    term.DNS1 = IPAddress.Parse( Convert.ToString( reader["DNS1"] ) );
                    term.DNS2 = IPAddress.Parse( Convert.ToString( reader["DNS2"] ) );

                    term.NumberOfTerminals = Convert.ToInt32( reader["NumberOfTerminals"] );
                    term.FileserverName = Convert.ToString( reader["FileserverName"] );

                    term.MasterCapable = Convert.ToBoolean( reader["MasterCapable"] );
                    term.ServerCapable = Convert.ToBoolean( reader["ServerCapable"] );

                    // term.TimeZone = ;

                    Terminals.Add( term );
                }
            }

            db.Close();
        }

        public void WriteTerminals( List<AlohaTerminal> terminals )
        {
            throw new NotImplementedException();
        }

        public List<AlohaTerminal> ReadTerminals( string unitName, int? termNum )
        {
            var terminals = new List<AlohaTerminal>();

            var cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\;";
            cs = cs + @"Extended Properties=""text;HDR=Yes;FMT=Delimited"";";

            var db = new OleDbConnection( cs );

            db.Open();

            using ( var cmd = new OleDbCommand() )
            {
                cmd.Connection = db;

                if ( unitName != null )
                {
                    if ( termNum != null )
                    {
                        cmd.CommandText = @"SELECT * FROM AlohaTerminals.csv WHERE UnitName=@unitname AND Term=@termnum ORDER BY UnitName, Term";
                        cmd.Parameters.Add( new OleDbParameter( "@unitname", unitName ) );
                        cmd.Parameters.Add( new OleDbParameter( "@termnum", termNum ) );
                    }
                    else
                    {
                        cmd.CommandText = @"SELECT * FROM AlohaTerminals.csv WHERE UnitName=@unitnum ORDER BY UnitName, Term";
                        cmd.Parameters.Add( new OleDbParameter( "@unitname", unitName ) );
                    }
                }
                else
                {
                    cmd.CommandText = @"SELECT * FROM AlohaTerminals.csv ORDER BY UnitName, Term";
                }

                using ( var reader = cmd.ExecuteReader() )
                {
                    while ( reader.Read() )
                    {
                        var term = new AlohaTerminal();

                        term.UnitName = Convert.ToString( reader["UnitName"] );

                        term.Term = Convert.ToInt32( reader["Term"] );
                        term.Workgroup = Convert.ToString( reader["Workgroup"] );

                        term.IPAddress = IPAddress.Parse( Convert.ToString( reader["IPAddress"] ) );
                        term.SubnetMask = IPAddress.Parse( Convert.ToString( reader["SubnetMask"] ) );
                        term.DefaultGateway = IPAddress.Parse( Convert.ToString( reader["DefaultGateway"] ) );
                        term.DNS1 = IPAddress.Parse( Convert.ToString( reader["DNS1"] ) );
                        term.DNS2 = IPAddress.Parse( Convert.ToString( reader["DNS2"] ) );

                        term.NumberOfTerminals = Convert.ToInt32( reader["NumberOfTerminals"] );
                        term.FileserverName = Convert.ToString( reader["FileserverName"] );

                        term.MasterCapable = Convert.ToBoolean( reader["MasterCapable"] );
                        term.ServerCapable = Convert.ToBoolean( reader["ServerCapable"] );

                        // term.TimeZone = ;

                        terminals.Add( term );
                    }
                }
            }
            db.Close();

            return terminals;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Net;

namespace LaunchPad.Terminals
{
    class AlohaTerminalReader
    {
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
                    term.IPAddress = IPAddress.Parse( Convert.ToString( reader["IPAddress"] ) );
                    term.NumberOfTerminals = Convert.ToInt32( reader["NumberOfTerminals"] );
                    term.FileserverName = Convert.ToString( reader["FileserverName"] );
                    term.MasterCapable = Convert.ToBoolean( reader["MasterCapable"] );
                    term.ServerCapable = Convert.ToBoolean( reader["ServerCapable"] );

                    Terminals.Add( term );
                }
            }

            db.Close();
        }

        public void WriteTerminals( List<AlohaTerminal> terminals )
        {
            throw new NotImplementedException();
        }
    }
}

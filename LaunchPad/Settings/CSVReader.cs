using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.IO;

namespace LaunchPad.Settings
{
    abstract class CSVReader
    {
        protected string Filename;
        protected OleDbConnection Db;
        protected const string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\;
                                                Extended Properties=""text;HDR=Yes;FMT=Delimited"";";

        private CSVReader() { }

        protected CSVReader( string filename )
        {
            Filename = filename;
            Db = new OleDbConnection( ConnectionString );
            CreateTableIfNotExists();
        }

        protected void DeleteAllRows()
        {
            File.Delete( Filename );
            CreateTableIfNotExists();
        }

        protected abstract void CreateTableIfNotExists();
    }
}

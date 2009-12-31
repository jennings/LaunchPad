using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace TermConfig.Configurators
{
    interface IConfigurator
    {
        void Configure( OleDbConnection databaseConnection );
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using LaunchPad.Configuration.Tasks;
using System.Text.RegularExpressions;

namespace LaunchPad.Configuration.Configurators
{
    class IbercfgConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return false; } }
        public bool RequiresAuthentication { get { return false; } }

        private Dictionary<string, string> Variables;

        private IbercfgConfigurator() { }
        public IbercfgConfigurator( IbercfgTask task )
        {
            Variables = new Dictionary<string, string>();
            Variables.Add( "TERM", task.TerminalNumber.ToString() );
            Variables.Add( "SERVER", "TERM" + task.TerminalNumber );
            Variables.Add( "NUMTERMS", task.NumberTerminals.ToString() );
            Variables.Add( "TERMSTR", "TERM" );
            Variables.Add( "IBERROOT", "Aloha" );
            Variables.Add( "LOCALDIR", @"C:\%IBERROOT%" );
            Variables.Add( "ROBUST", "TRUE" );
            Variables.Add( "MASTERCAPABLE", task.MasterCapable ? "TRUE" : "FALSE" );
            Variables.Add( "SERVERCAPABLE", task.ServerCapable ? "TRUE" : "FALSE" );
            Variables.Add( "AUTOEXIT", "TRUE" );
            Variables.Add( "EDCPATH", @"\\%SERVER%\BOOTDRV\%IBERROOT%\EDC" );
        }

        public void Configure()
        {
            string ibercfg = File.ReadAllText( @"C:\IBERCFG.BAT" );

            foreach ( var val in Variables )
            {
                ibercfg = UpdateIbercfg( ibercfg, val.Key, val.Value );
            }

            File.WriteAllText( @"C:\IBERCFG.BAT", ibercfg );
        }

        private string UpdateIbercfg( string ibercfg, string variable, string value )
        {
            var rx = new Regex( @"^(SET (" + variable + ")=(.*))$", RegexOptions.IgnoreCase | RegexOptions.Multiline );
            return rx.Replace( ibercfg, @"SET $2=$3" );
        }
    }
}

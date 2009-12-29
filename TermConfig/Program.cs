using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

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

            if ( File.Exists( @"POSITOUCH" ) )
            {
                Application.Run( new PositouchStartupWindow() );
            }
            else if ( File.Exists( @"ALOHA" ) )
            {
                Application.Run( new AlohaStartupWindow() );
            }
            else
            {
                MessageBox.Show( @"Add POSITOUCH or ALOHA flag file to use." );
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
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

            var settings = SettingsReader.Instance;

            switch ( settings.PointOfSale )
            {
                case PointOfSale.Positouch:
                    if ( settings.Integrous )
                    {
                        Application.Run( new PositouchStartupWindow() );
                    }
                    else
                    {
                        Application.Run( new PositouchInitialConfigWindow() );
                    }
                    break;

                case PointOfSale.Aloha:
                    if ( settings.Integrous )
                    {
                        Application.Run( new AlohaStartupWindow() );
                    }
                    else
                    {
                        Application.Run( new AlohaInitialConfigWindow() );
                    }
                    break;

                case PointOfSale.None:
                default:
                    MessageBox.Show( @"Add POSITOUCH or ALOHA flag file to use." );
                    break;
            }
        }
    }
}

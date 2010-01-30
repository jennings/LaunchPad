using System;
using System.ServiceProcess;
using System.Windows.Forms;
using LaunchPad.Forms;

namespace LaunchPad
{
    static class LaunchPad
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( string[] args )
        {
            if ( args.Length > 0 && ( args[0].Equals( "-s" ) || args[0].Equals( "/s" ) ) )
            {
                // Run as service
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { new LaunchPadService() };
                ServiceBase.Run( ServicesToRun );
            }
            else
            {
                // Run front-end application

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
}

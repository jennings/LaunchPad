using System;
using System.ServiceProcess;
using System.Windows.Forms;
using LaunchPad.Configuration.Dispatch;
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
            string arg1 = args.Length > 0 ? args[0] : "";

            switch ( arg1 )
            {
                case "-s":
                case "-S":
                case "/s":
                case "/S":
                    // Run as service
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[] { new LaunchPadService() };
                    ServiceBase.Run( ServicesToRun );
                    break;

                case "":
                    // Run front-end application

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault( false );

                    var settings = SettingsReader.Instance;
                    RemoteConfiguratorDispatcher.RegisterClientType();

                    switch ( settings.PointOfSale )
                    {
                        case PointOfSaleType.Positouch:
                            if ( settings.Integrous )
                            {
                                Application.Run( new PositouchStartupWindow() );
                            }
                            else
                            {
                                Application.Run( new PositouchInitialConfigWindow() );
                            }
                            break;

                        case PointOfSaleType.Aloha:
                            if ( settings.Integrous )
                            {
                                Application.Run( new AlohaStartupWindow() );
                            }
                            else
                            {
                                Application.Run( new AlohaInitialConfigWindow() );
                            }
                            break;

                        case PointOfSaleType.None:
                        default:
                            MessageBox.Show( @"Add POSITOUCH or ALOHA flag file to use." );
                            break;

                    }
                    break;

                default:
                    MessageBox.Show( "Usage:\n\n   'LaunchPad.exe' to run front-end.\n\n   'LaunchPad.exe -s' to run the background service." );
                    break;
            }
        }
    }
}

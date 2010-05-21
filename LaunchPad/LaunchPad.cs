using System;
using System.ServiceProcess;
using System.Windows.Forms;
using LaunchPad.Forms;
using LaunchPad.Models;
using LaunchPad.Settings;

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

                    switch ( settings.PointOfSale )
                    {
                        case PointOfSaleType.Positouch:
                            if ( settings.IntegrousInitialSettings && settings.IntegrousLaunchSettings )
                            {
                                Application.Run( new PositouchStartupWindow() );
                            }
                            else if ( settings.IntegrousInitialSettings )
                            {
                                Application.Run( new PositouchTerminalSelectionWindow() );
                            }
                            else
                            {
                                Application.Run( new PositouchInitialConfigWindow() );
                            }
                            break;

                        case PointOfSaleType.Aloha:
                            if ( settings.IntegrousInitialSettings && settings.IntegrousLaunchSettings )
                            {
                                Application.Run( new AlohaStartupWindow() );
                            }
                            else
                            {
                                if ( AlohaTerminalReader.PreconfigurationAvailable )
                                {
                                    Application.Run( new AlohaPreconfiguredConfigWindow() );
                                }
                                else
                                {
                                    Application.Run( new AlohaManualConfigWindow() );
                                }
                            }
                            break;

                        case PointOfSaleType.None:
                        default:
                            MessageBox.Show( "Settings must have one of the following: \n\nPOS=Positouch\n\nPOS=Aloha", "Error Code 0002" );
                            break;

                    }
                    break;

                default:
                    MessageBox.Show( "Usage:\n\n   'LaunchPad.exe' to run front-end.\n\n   'LaunchPad.exe -s' to run the background service.", "Error Code 0003" );
                    break;
            }
        }
    }
}

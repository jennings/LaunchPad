using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LaunchPad.Configurators
{
    class PosiwConfigurator : IConfigurator
    {
        public PositouchTerminalStation StationSettings { get; private set; }

        private PosiwConfigurator() { }
        public PosiwConfigurator( PositouchTerminalStation TerminalStationSettings )
        {
            StationSettings = TerminalStationSettings;
        }

        public void Configure()
        {
            if ( !Directory.Exists( @"C:\SC" ) )
                Directory.CreateDirectory( @"C:\SC" );
            if ( !Directory.Exists( @"C:\Temp" ) )
                Directory.CreateDirectory( @"C:\Temp" );

            if ( File.Exists( @"C:\SC\Posiw.ini" ) )
            {
                var timestring = DateTime.Now.ToString( @"yyyyMMddHHmmss" );
                File.Move( @"C:\SC\Posiw.ini", @"C:\Temp\Posiw.ini." + timestring );
            }

            using ( var sw = new StreamWriter( @"C:\SC\Posiw.ini" ) )
            {
                sw.WriteLine( @"; POSIW Built by Launch Pad." );
                sw.WriteLine( @"; Built " + DateTime.Now.ToShortDateString() );
                sw.WriteLine( @"" );

                sw.WriteLine( @"[Startup]" );
                sw.WriteLine( @"POSDRVR=POSDRVR-89" );
                sw.WriteLine( @"POSIW=" + StationSettings.DeviceNumberString );
                sw.WriteLine( @"DateTimeServer=" + ( StationSettings.Backoffice ? "YES" : "NO" ) );
                sw.WriteLine( @"KeyServer=NO" );

                if ( StationSettings.PosdriverTerminal )
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + StationSettings.BackofficeIPAddress + @"\C" );
                    sw.WriteLine( @"NetDriveMap2=M:\\" + StationSettings.RedundantIPAddress + @"\C" );
                }
                else if ( StationSettings.RedundantTerminal )
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + StationSettings.PosdriverIPAddress + @"\C" );
                }
                else if ( StationSettings.Backoffice )
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + StationSettings.PosdriverIPAddress + @"\C" );
                    sw.WriteLine( @"NetDriveMap2=M:\\" + StationSettings.RedundantIPAddress + @"\C" );
                }
                else
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + StationSettings.PosdriverIPAddress + @"\C" );
                    sw.WriteLine( @"NetDriveMap2=M:\\" + StationSettings.RedundantIPAddress + @"\C" );
                }

                sw.WriteLine( @"" );

                sw.WriteLine( @"[Backup]" );
                sw.WriteLine( @"MirrorPath=L:\SC" );
                sw.WriteLine( @"PrimaryServer=" + ( StationSettings.PosdriverTerminal ? "YES" : "NO" ) );
                sw.WriteLine( @"BackupServer=" + ( StationSettings.RedundantTerminal ? "YES" : "NO" ) );
                sw.WriteLine( @"BackoffServer=" + ( StationSettings.Backoffice ? "YES" : "NO" ) );
                sw.WriteLine( @"FileServer=NO" );

                sw.WriteLine( @"PrimaryInterval=10" );
                sw.WriteLine( @"BackupInterval=60" );

                sw.WriteLine( @"FailureStartMode=PASSWORD" );
                sw.WriteLine( @"FailureStartMessage=EMERGENCY MODE CALL HELP DESK (800) 551-7674" );
                sw.WriteLine( @"FailureStartPassword=627" );
                sw.WriteLine( @"FailureEndMode=CONFIRM" );
                sw.WriteLine( @"FailureEndMessage=CONFIRM TO EXIT EMERGENCY MODE" );


                sw.WriteLine( @"[Install]" );
                sw.WriteLine( @"PosDrive=L" );
                sw.WriteLine( @"UpgradeInterval=5" );
                sw.WriteLine( @"INSTALL_POS_DRIVER=NO" );
                sw.WriteLine( @"INSTALL_BACKOFFICE=NO" );
                sw.WriteLine( @"INSTALL_TRANSERV=NO" );
                sw.WriteLine( @"INSTALL_POSITERM=NO" );
                sw.WriteLine( @"" );

                sw.WriteLine( @"[Nightly]" );
                sw.WriteLine( @"Night=NO" );
                sw.WriteLine( @"WorkPath=L:\SC" );
                sw.WriteLine( @"" );

                sw.WriteLine( @"[Network]" );
                sw.WriteLine( @"TCP/IP=YES" );

                if ( !StationSettings.PosdriverTerminal )
                    sw.WriteLine( @"Spcwin=" + StationSettings.PosdriverIPAddress );
                if ( !StationSettings.Backoffice )
                    sw.WriteLine( @"BackOffice=" + StationSettings.BackofficeIPAddress );

                if ( !StationSettings.RedundantTerminal )
                    sw.WriteLine( @"BackUpServer=" + StationSettings.RedundantIPAddress );

                if ( !StationSettings.Backoffice )
                    sw.WriteLine( @"Posiw99=" + StationSettings.BackofficeIPAddress );
                sw.WriteLine( @"" );

                sw.Flush();
            }
        }
    }

    enum PosiwTerminalType
    {
        PrimaryServer,
        BackupServer,
        BackoffServer,
        FileServer,
        Normal
    }
}

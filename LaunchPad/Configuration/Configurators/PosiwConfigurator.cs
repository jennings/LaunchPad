using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using LaunchPad.Configuration.Tasks;

namespace LaunchPad.Configuration.Configurators
{
    class PosiwConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return true; } }
        public bool RequiresAuthentication { get { return false; } }

        public string DeviceNumberString { get { return DeviceNumber.ToString( "D2" ); } }
        public int DeviceNumber { get; private set; }

        public PosiwTerminalType @Type { get; private set; }
        public bool Backoffice { get { return Type == PosiwTerminalType.BackoffServer; } }
        public bool PosdriverTerminal { get { return Type == PosiwTerminalType.PrimaryServer; } }
        public bool RedundantTerminal { get { return Type == PosiwTerminalType.BackupServer; } }

        public IPAddress @BackofficeIPAddress { get; private set; }
        public IPAddress @PosdriverIPAddress { get; private set; }
        public IPAddress @RedundantIPAddress { get; private set; }


        public PosiwConfigurator( PosiwTask task )
        {
            DeviceNumber = task.DeviceNumber;

            @Type = task.Type;

            BackofficeIPAddress = task.BackofficeIPAddress;
            PosdriverIPAddress = task.PosdriverIPAddress;
            RedundantIPAddress = task.RedundantIPAddress;
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
                sw.WriteLine( @"POSIW=" + DeviceNumberString );
                sw.WriteLine( @"DateTimeServer=" + ( Backoffice ? "YES" : "NO" ) );
                sw.WriteLine( @"KeyServer=NO" );

                if ( PosdriverTerminal )
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + BackofficeIPAddress + @"\C" );
                    sw.WriteLine( @"NetDriveMap2=M:\\" + RedundantIPAddress + @"\C" );
                }
                else if ( RedundantTerminal )
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + PosdriverIPAddress + @"\C" );
                }
                else if ( Backoffice )
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + PosdriverIPAddress + @"\C" );
                    sw.WriteLine( @"NetDriveMap2=M:\\" + RedundantIPAddress + @"\C" );
                }
                else
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + PosdriverIPAddress + @"\C" );
                    sw.WriteLine( @"NetDriveMap2=M:\\" + RedundantIPAddress + @"\C" );
                }

                sw.WriteLine( @"" );

                sw.WriteLine( @"[Backup]" );
                sw.WriteLine( @"MirrorPath=L:\SC" );
                sw.WriteLine( @"PrimaryServer=" + ( PosdriverTerminal ? "YES" : "NO" ) );
                sw.WriteLine( @"BackupServer=" + ( RedundantTerminal ? "YES" : "NO" ) );
                sw.WriteLine( @"BackoffServer=" + ( Backoffice ? "YES" : "NO" ) );
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

                if ( !PosdriverTerminal )
                    sw.WriteLine( @"Spcwin=" + PosdriverIPAddress );
                if ( !Backoffice )
                    sw.WriteLine( @"BackOffice=" + BackofficeIPAddress );

                if ( !RedundantTerminal )
                    sw.WriteLine( @"BackUpServer=" + RedundantIPAddress );

                if ( !Backoffice )
                    sw.WriteLine( @"Posiw99=" + BackofficeIPAddress );
                sw.WriteLine( @"" );

                sw.Flush();
            }
        }
    }
}

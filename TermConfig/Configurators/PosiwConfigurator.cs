using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TermConfig.Configurators
{
    class PosiwConfigurator : IConfigurator
    {
        TerminalStation StationSettings { get; private set; }

        string _DeviceNumberString;

        private PosiwTerminalType _TerminalType = PosiwTerminalType.Normal;

        // FIXME
        public string BackofficeIP
        { get { return "10.10.1.30"; } }

        // FIXME
        public string PosdriverIP
        { get { return "10.10.1.40"; } }

        // FIXME
        public string BackupServerIP
        { get { return "10.10.1.45"; } }

        public bool BackupServer
        {
            get { return _TerminalType == PosiwTerminalType.BackupServer; }
            set
            {
                if ( value )
                {
                    _TerminalType = PosiwTerminalType.BackupServer;
                }
                else if ( _TerminalType == PosiwTerminalType.BackupServer )
                {
                    _TerminalType = PosiwTerminalType.Normal;
                }
            }
        }
        public bool PrimaryServer
        {
            get { return _TerminalType == PosiwTerminalType.PrimaryServer; }
            set
            {
                if ( value )
                {
                    _TerminalType = PosiwTerminalType.PrimaryServer;
                }
                else if ( _TerminalType == PosiwTerminalType.PrimaryServer )
                {
                    _TerminalType = PosiwTerminalType.Normal;
                }
            }
        }
        public bool BackoffServer
        {
            get { return _TerminalType == PosiwTerminalType.BackoffServer; }
            set
            {
                if ( value )
                {
                    _TerminalType = PosiwTerminalType.BackoffServer;
                }
                else if ( _TerminalType == PosiwTerminalType.BackoffServer )
                {
                    _TerminalType = PosiwTerminalType.Normal;
                }
            }
        }
        public bool NormalTerminal
        {
            get { return _TerminalType == PosiwTerminalType.Normal; }
            set
            {
                if ( value )
                {
                    _TerminalType = PosiwTerminalType.Normal;
                }
            }
        }

        public int DeviceNumber
        {
            get { return Convert.ToInt32( _DeviceNumberString ); }
            set
            {
                if ( value < 1 || value > 99 )
                    throw new Exception( "Device Number must be between 1 and 99" );
                if ( value == 89 && !PrimaryServer )
                    throw new Exception( "Device number 89 is reserved for the posdriver." );
                if ( value == 99 && !BackoffServer )
                    throw new Exception( "Device number 99 is reserved for the backoffice." );
                _DeviceNumberString = value.ToString( "D2" );
            }
        }


        public PosiwConfigurator( TerminalStation TerminalStationSettings )
        {
            StationSettings = TerminalStationSettings;
        }

        public void Configure()
        {
        }

        public void Write()
        {
            if ( !Directory.Exists( @"C:\SC" ) ) Directory.CreateDirectory( @"C:\SC" );
            if ( !Directory.Exists( @"C:\Temp" ) ) Directory.CreateDirectory( @"C:\Temp" );

            if ( File.Exists( @"C:\SC\Posiw.ini" ) )
            {
                var timestring = DateTime.Now.ToString( @"yyyyMMddHHmmss" );
                File.Move( @"C:\SC\Posiw.ini", @"C:\Temp\Posiw.ini." + timestring );
            }

            using ( var sw = new StreamWriter( @"C:\SC\Posiw.ini" ) )
            {
                sw.WriteLine( @"; POSIW Built by TermConfig." );
                sw.WriteLine( @"; Built " + DateTime.Now.ToShortDateString() );
                sw.WriteLine( @"" );

                sw.WriteLine( @"[Startup]" );
                sw.WriteLine( @"POSDRVR=POSDRVR-89" );
                sw.WriteLine( @"POSIW=" + _DeviceNumberString );
                sw.WriteLine( @"DateTimeServer=" + ( BackoffServer ? "YES" : "NO" ) );
                sw.WriteLine( @"KeyServer=NO" );

                if ( PrimaryServer )
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + BackofficeIP + @"\C" );
                    sw.WriteLine( @"NetDriveMap2=M:\\" + BackupServerIP + @"\C" );
                }
                else if ( BackupServer )
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + PosdriverIP + @"\C" );
                }
                else if ( BackoffServer )
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + PosdriverIP + @"\C" );
                    sw.WriteLine( @"NetDriveMap2=M:\\" + BackupServerIP + @"\C" );
                }
                else
                {
                    sw.WriteLine( @"NetDriveMap1=L:\\" + PosdriverIP + @"\C" );
                    sw.WriteLine( @"NetDriveMap2=M:\\" + BackupServerIP + @"\C" );
                }

                sw.WriteLine( @"" );

                sw.WriteLine( @"[Backup]" );
                sw.WriteLine( @"MirrorPath=L:\SC" );
                sw.WriteLine( @"PrimaryServer=" + ( PrimaryServer ? "YES" : "NO" ) );
                sw.WriteLine( @"BackupServer=" + ( BackupServer ? "YES" : "NO" ) );
                sw.WriteLine( @"BackoffServer=" + ( BackoffServer ? "YES" : "NO" ) );
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

                if ( !PrimaryServer ) sw.WriteLine( @"Spcwin=" + PosdriverIP );
                if ( !BackoffServer ) sw.WriteLine( @"BackOffice=" + BackofficeIP );

                if ( !BackupServer ) sw.WriteLine( @"BackUpServer=" + BackupServerIP );

                if ( !BackoffServer ) sw.WriteLine( @"Posiw99=" + BackofficeIP );
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

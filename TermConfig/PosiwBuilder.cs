using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TermConfig
{
    class PosiwBuilder
    {
        string _DeviceNumberString;

        public bool RedundantTerminal
        {
            get { return false; }
            set { throw new NotImplementedException(); }
        }
        public bool PosdriverTerminal
        {
            get { return false; }
            set { throw new NotImplementedException(); }
        }
        public bool BackofficeTerminal
        {
            get { return false; }
            set { throw new NotImplementedException(); }
        }
        public bool NormalTerminal
        {
            get { return true; }
            set { throw new NotImplementedException(); }
        }

        public int DeviceNumber
        {
            get { return Convert.ToInt32( _DeviceNumberString ); }
            set
            {
                if ( value < 1 || value > 99 )
                    throw new Exception( "Device Number must be between 1 and 99" );
                if ( value == 89 && !PosdriverTerminal )
                    throw new Exception( "Device number 89 is reserved for the posdriver." );
                if ( value == 99 && !BackofficeTerminal )
                    throw new Exception( "Device number 99 is reserved for the backoffice." );
                _DeviceNumberString = value.ToString( "D2" );
            }
        }

        public void Write()
        {
            var timestring = DateTime.Now.ToString( @"yyyyMMddHHmmss" );
            File.Move( @"C:\SC\Posiw.ini", @"C:\Temp\Posiw.ini." + timestring );

            using ( var sw = new StreamWriter( @"C:\SC\Posiw.ini" ) )
            {
                sw.WriteLine( @"POSIW Built by TermConfig." );
                sw.WriteLine( @"Built " + DateTime.Now.ToShortDateString() );
                sw.WriteLine( @"" );

                sw.WriteLine( @"[Startup]" );
                sw.WriteLine( @"POSIW=" + _DeviceNumberString );
                sw.WriteLine( @"Posdrvr=POSDRVR-89" );
                sw.WriteLine( @"NetDriveMap=L:\\" + "" + @"\C$" );
                sw.WriteLine( @"" );

                sw.WriteLine( @"[Backup]" );
                sw.WriteLine( @"PrimaryServer=" + ( PosdriverTerminal ? "YES" : "NO" ) );
                sw.WriteLine( @"BackupServer=" + ( RedundantTerminal ? "YES" : "NO" ) );
                sw.WriteLine( @"BackoffServer=" + ( BackofficeTerminal ? "YES" : "NO" ) );
                sw.WriteLine( @"FileServer=NO" );
                sw.WriteLine( @"MirrorPath=L:\SC" );
                sw.WriteLine( @"PrimaryInterval=10" );
                sw.WriteLine( @"BackupInterval=60" );
                sw.WriteLine( @"FailureStartMode=PASSWORD" );
                sw.WriteLine( @"FailureStartMessage=EMERGENCY MODE CALL CBS (800) 551-7674" );
                sw.WriteLine( @"FailureStartPassword=1234" );
                sw.WriteLine( @"FailureEndMode=PASSWORD" );
                sw.WriteLine( @"FailureEndMessage=CONFIRM TO EXIT BACKUP MODE" );
                sw.WriteLine( @"FailureEndPassword=1234" );
                sw.WriteLine( @"" );

                sw.WriteLine( @"[Nightly]" );
                sw.WriteLine( @"Night=NO" );
                sw.WriteLine( @"WorkPath=L:\SC" );

                sw.Flush();
            }
        }
    }
}

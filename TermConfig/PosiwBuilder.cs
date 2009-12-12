using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TermConfig
{
    class PosiwBuilder
    {
        string _DeviceNumber;

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
            get { return Convert.ToInt32( _DeviceNumber ); }
            set
            {
                if ( value < 1 || value > 99 )
                    throw new Exception( "Device Number must be between 1 and 99" );
                if ( value == 89 && !PosdriverTerminal )
                    throw new Exception( "Device number 89 is reserved for the posdriver." );
                if ( value == 99 && !BackofficeTerminal )
                    throw new Exception( "Device number 99 is reserved for the backoffice." );
                _DeviceNumber = value.ToString( "D2" );
            }
        }

        public void Write()
        {
            string Posiw = @"; POSIW Built By TermConfig.";
            Posiw = Posiw + "\r\n" + @"[Startup]";
            Posiw = Posiw + "\r\n" + @"POSIW=" + _DeviceNumber;
            Posiw = Posiw + "\r\n" + @"NetDriveMap1=L:\\" + "" + @"\C$";

            Posiw = Posiw + "\r\n" + @"[Backup]";
            Posiw = Posiw + "\r\n" + @"PrimaryServer=" + ( PosdriverTerminal ? "YES" : "NO" );
            Posiw = Posiw + "\r\n" + @"BackupServer=" + ( RedundantTerminal ? "YES" : "NO" );
            Posiw = Posiw + "\r\n" + @"BackoffServer=" + ( BackofficeTerminal ? "YES" : "NO" );
            Posiw = Posiw + "\r\n" + @"FileServer=NO";
            Posiw = Posiw + "\r\n" + @"MirrorPath=L:\SC";
            Posiw = Posiw + "\r\n" + @"PrimaryInterval=10";
            Posiw = Posiw + "\r\n" + @"BackupInterval=60";
            Posiw = Posiw + "\r\n" + @"FailureStartMode=PASSWORD";
            Posiw = Posiw + "\r\n" + @"FailureStartMessage=EMERGENCY MODE CALL CBS (800) 551-7674";
            Posiw = Posiw + "\r\n" + @"FailureStartPassword=1234";
            Posiw = Posiw + "\r\n" + @"FailureEndMode=PASSWORD";
            Posiw = Posiw + "\r\n" + @"FailureEndMessage=CONFIRM TO EXIT BACKUP MODE";
            Posiw = Posiw + "\r\n" + @"FailureEndPassword=1234";

            Posiw = Posiw + "\r\n" + @"[Nightly]";
            Posiw = Posiw + "\r\n" + @"Night=NO";
            Posiw = Posiw + "\r\n" + @"WorkPath=L:\SC";

            Posiw = Posiw + "\r\n";

            var fs = File.Open( @"C:\SC\Posiw.ini", FileMode.Create );
        }
    }
}

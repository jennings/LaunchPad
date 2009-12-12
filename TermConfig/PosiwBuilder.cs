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
            string Posiw;
            Posiw = "\r\n" + Posiw + @"[Startup]";
            Posiw = "\r\n" + Posiw + @"POSIW=" + _DeviceNumber;
            Posiw = "\r\n" + Posiw + @"NetDriveMap1=L:\\" + "" + @"\C$";

            Posiw = "\r\n" + Posiw + @"[Backup]";
            Posiw = "\r\n" + Posiw + @"PrimaryServer=" + ( PosdriverTerminal ? "YES" : "NO" );
            Posiw = "\r\n" + Posiw + @"BackupServer=" + ( RedundantTerminal ? "YES" : "NO" );
            Posiw = "\r\n" + Posiw + @"BackoffServer=" + ( BackofficeTerminal ? "YES" : "NO" );
            Posiw = "\r\n" + Posiw + @"FileServer=NO";
            Posiw = "\r\n" + Posiw + @"MirrorPath=L:\SC";
            Posiw = "\r\n" + Posiw + @"PrimaryInterval=10";
            Posiw = "\r\n" + Posiw + @"BackupInterval=60";
            Posiw = "\r\n" + Posiw + @"FailureStartMode=PASSWORD";
            Posiw = "\r\n" + Posiw + @"FailureStartMessage=EMERGENCY MODE CALL CBS (800) 551-7674";
            Posiw = "\r\n" + Posiw + @"FailureStartPassword=1234";
            Posiw = "\r\n" + Posiw + @"FailureEndMode=PASSWORD";
            Posiw = "\r\n" + Posiw + @"FailureEndMessage=CONFIRM TO EXIT BACKUP MODE";
            Posiw = "\r\n" + Posiw + @"FailureEndPassword=1234";

            Posiw = "\r\n" + Posiw + @"[Nightly]";
            Posiw = "\r\n" + Posiw + @"Night=NO";
            Posiw = "\r\n" + Posiw + @"WorkPath=L:\SC";

            var fs = File.Open( @"C:\SC\Posiw.ini", FileMode.Create );
        }
    }
}

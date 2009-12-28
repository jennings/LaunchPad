﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace TermConfig
{
    class TerminalStation
    {
        public TerminalStationType @Type { get; set; }
        public bool PosdriverTerminal { get { return @Type == TerminalStationType.Posdriver; } }
        public bool RedundantTerminal { get { return @Type == TerminalStationType.Redunant; } }
        public bool NormalTerminal { get { return @Type == TerminalStationType.Normal; } }
        public bool Backoffice { get { return @Type == TerminalStationType.Backoffice; } }

        public string Name
        {
            get
            {
                if ( PosdriverTerminal ) return "POSDRVR";
                return "TERM" + DeviceNumber.ToString( "D3" );
            }
        }

        private int _DeviceNumber;
        public int DeviceNumber
        {
            get { return _DeviceNumber; }
            set
            {
                if ( value < 1 || value > 99 )
                    throw new Exception( "Device Number must be between 1 and 99" );
                if ( value == 89 && !PosdriverTerminal )
                    throw new Exception( "Device number 89 is reserved for the posdriver." );
                if ( value == 99 && !Backoffice )
                    throw new Exception( "Device number 99 is reserved for the backoffice." );
            }
        }
        public string DeviceNumberString { get { return DeviceNumber.ToString( "D2" ); } }

        public string Username { get { return "pos"; } }
        public string Password { get; set; }

        public IPAddress @IPAddress { get; set; }
        public IPAddress @PosdriverIPAddress { get; set; }
        public IPAddress @RedundantIPAddress { get; set; }
        public IPAddress @BackofficeIPAddress { get; set; }

        public void Validate()
        {
            var errors = String.Empty;
            if ( @Type == null ) errors += @"Type is not set. ";
            if ( DeviceNumber == null ) errors += @"DeviceNumber is not set. ";
            if ( Password == null ) errors += @"Password is not set. ";
            if ( @IPAddress == null ) errors += @"IPAddress is not set. ";
            if ( PosdriverIPAddress == null ) errors += @"PosdriverIPAddress is not set. ";
            // if ( RedundantIPAddress == null ) errors += @"RedundantIPAddress is not set. ";
            // if ( BackofficeIPAddress == null ) errors += @"BackofficeIPAddress is not set. ";

            if ( !errors.Equals( string.Empty ) )
            {
                throw new Exception( errors );
            }
        }
    }

    enum TerminalStationType
    {
        Posdriver,
        Redunant,
        Backoffice,
        Normal
    }
}

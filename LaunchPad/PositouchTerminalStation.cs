﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace LaunchPad
{
    class PositouchTerminalStation : ITerminalStation
    {
        public PointOfSaleType PointOfSale { get { return PointOfSaleType.Positouch; } }

        private string _WindowsPassword;
        public string WindowsUsername { get { return "pos"; } }
        public string WindowsPassword
        {
            get { return _WindowsPassword; }
            set { _WindowsPassword = value.ToUpper(); }
        }

        public PositouchTerminalType? @PositermType { get; set; }
        public bool PosdriverTerminal { get { return @PositermType == PositouchTerminalType.Posdriver; } }
        public bool RedundantTerminal { get { return @PositermType == PositouchTerminalType.Redunant; } }
        public bool NormalTerminal { get { return @PositermType == PositouchTerminalType.Normal; } }
        public bool Backoffice { get { return @PositermType == PositouchTerminalType.Backoffice; } }

        public PosiwTerminalType? @PosiwType
        {
            get
            {
                if ( PosdriverTerminal )
                    return PosiwTerminalType.PrimaryServer;
                if ( RedundantTerminal )
                    return PosiwTerminalType.BackupServer;
                if ( NormalTerminal )
                    return PosiwTerminalType.Normal;
                if ( Backoffice )
                    return PosiwTerminalType.BackoffServer;
                else
                    return null;
            }
        }

        public IPAddress IPAddress { get; set; }
        public IPAddress @PosdriverIPAddress { get; set; }
        public IPAddress @RedundantIPAddress { get; set; }
        public IPAddress @BackofficeIPAddress { get; set; }

        public string ComputerName
        {
            get
            {
                if ( DeviceNumber == null )
                {
                    return "TERMxxx";
                }
                else
                {
                    if ( PosdriverTerminal )
                        return "POSDRVR";
                    return "TERM" + DeviceNumber.GetValueOrDefault().ToString( "D3" );
                }
            }
        }

        public void ValidateInitial()
        {
            var errors = String.Empty;

            if ( WindowsPassword == null )
                errors += @"Password is not set. ";
            if ( @IPAddress == null )
                errors += @"IPAddress is not set. ";
            if ( PosdriverIPAddress == null )
                errors += @"PosdriverIPAddress is not set. ";
            if ( BackofficeIPAddress == null )
                errors += @"BackofficeIPAddress is not set. ";

            if ( !errors.Equals( string.Empty ) )
            {
                throw new Exception( errors );
            }
        }

        public void Validate()
        {
            var errors = String.Empty;
            if ( @PositermType == null )
                errors += @"Type is not set. ";
            if ( DeviceNumber == null )
                errors += @"DeviceNumber is not set. ";
            if ( DeviceNumber < 1 || 99 < DeviceNumber )
                errors += @"DeviceNumber must be between 1 and 99.";
            if ( @IPAddress == null )
                errors += @"IPAddress is not set. ";

            if ( !errors.Equals( string.Empty ) )
            {
                throw new Exception( errors );
            }
        }

        private int? _DeviceNumber;
        public int? DeviceNumber
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
                _DeviceNumber = value;
            }
        }
        public string DeviceNumberString
        {
            get { return DeviceNumber == null ? null : DeviceNumber.GetValueOrDefault().ToString( "D2" ); }
        }
    }

    public enum PositouchTerminalType
    {
        Posdriver,
        Redunant,
        Backoffice,
        Normal
    }

    public enum PosiwTerminalType
    {
        PrimaryServer,
        BackupServer,
        BackoffServer,
        FileServer,
        Normal
    }
}

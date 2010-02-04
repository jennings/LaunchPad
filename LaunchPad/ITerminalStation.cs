using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace LaunchPad
{
    interface ITerminalStation
    {
        PointOfSaleType @PointOfSale { get; }
        string WindowsUsername { get; }
        string WindowsPassword { get; set; }
        IPAddress @IPAddress { get; set; }
        string ComputerName { get; }

        void Validate();
        void ValidateInitial();
    }
}

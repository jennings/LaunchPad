using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace TermConfig
{
    interface ITerminalStation
    {
        PointOfSale @PointOfSale { get; }
        string Username { get; }
        string Password { get; set; }
        IPAddress @IPAddress { get; set; }
        string ComputerName { get; }

        void Validate();
    }

    enum PointOfSale
    {
        Positouch,
        Aloha
    }


}

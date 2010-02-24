using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace LaunchPad
{
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

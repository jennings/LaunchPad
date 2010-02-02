using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchPad.Authentication
{
    class Challenge
    {
        public DateTime Timestamp { get; private set; }

        public Challenge()
        {
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return Timestamp.ToString( "yyyyMMddHHmmss" );
        }
    }
}

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
    }
}

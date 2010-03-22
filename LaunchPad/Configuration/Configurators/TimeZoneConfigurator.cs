using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using LaunchPad.Utilities;

namespace LaunchPad.Configuration.Configurators
{
    class TimeZoneConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return true; } }
        public bool RequiresAuthentication { get { return false; } }

        public void Configure()
        {
            throw new NotImplementedException();
        }

        /// <see>http://pinvoke.net/default.aspx/kernel32/GetTimeZoneInformation.html</see>
        [DllImport( "kernel32.dll", CharSet = CharSet.Auto )]
        private static extern bool GetTimeZoneInformation( out TimeZoneInformation lpTimeZoneInformation );

        /// <see>http://pinvoke.net/default.aspx/kernel32/SetTimeZoneInformation.html</see>
        [DllImport( "kernel32.dll", CharSet = CharSet.Auto )]
        private static extern bool SetTimeZoneInformation( [In] ref TimeZoneInformation lpTimeZoneInformation );
    }
}

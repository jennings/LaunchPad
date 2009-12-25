using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace TermConfig
{
    public partial class StartupWindow : Form
    {
        public StartupWindow()
        {
            InitializeComponent();

            GetIPAddress();
            GetPosiwSetting();
            GetQSRKitchenSetting();
        }

        private void GetIPAddress()
        {
            string AddressList = String.Empty;
            var MC = new ManagementClass( "Win32_NetworkAdapterConfiguration" );
            var collection = MC.GetInstances();
            var addresses = new List<string>();

            // Terminals have only one NIC, so this should be okay.
            foreach ( ManagementObject obj in collection )
            {
                if ( (bool)( obj["IPEnabled"] ) )
                {
                    // This returns IPv6 addresses as well on Vista and higher,
                    // but terminals are all XP and lower to this is okay.
                    addresses.AddRange( (string[])( obj.GetPropertyValue( "IPAddress" ) ) );
                }
            }

            IPAddressLabel.Text = String.Join( ", ", addresses.ToArray() );
        }

        private void GetPosiwSetting()
        {
            if ( File.Exists( @"C:\SC\Posiw.ini" ) )
            {
                var rx = new Regex( @"POSIW=(\d+)", RegexOptions.IgnoreCase );
                var rxmatch = rx.Match( File.ReadAllText( @"C:\SC\Posiw.ini" ) );
                if ( rxmatch.Captures.Count > 0 )
                {
                    PosiwLabel.Text = rxmatch.Captures[0].Value;
                }
            }
        }

        private void GetQSRKitchenSetting()
        {
        }

        private void WaitThenExit()
        {
            Thread.Sleep( 1000 );
            CountdownTimerLabel.Text = "3...";
            Thread.Sleep( 1000 );
            CountdownTimerLabel.Text = "2...";
            Thread.Sleep( 1000 );
            CountdownTimerLabel.Text = "1...";
            Thread.Sleep( 1000 );

            // Launch everything
        }

        private void RCButton_Click( object sender, EventArgs e )
        {
            var config = new TermConfigWindow();
            config.ShowDialog();
        }
    }
}

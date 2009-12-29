﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TermConfig.Launchers;

namespace TermConfig
{
    public partial class AlohaStartupWindow : Form
    {
        private int SecondsBeforeClose;
        private Timer DelayTimer;

        public AlohaStartupWindow()
        {
            InitializeComponent();

            GetIPAddress();
            GetPosiwSetting();

            SecondsBeforeClose = 4;

            DelayTimer = new Timer();
            DelayTimer.Interval = 1000;
            DelayTimer.Tick += new EventHandler( CountdownTick );
            DelayTimer.Start();
        }

        private void CountdownTick( object sender, EventArgs e )
        {
            if ( SecondsBeforeClose > 0 )
            {
                SecondsBeforeClose--;
                CountdownTimerLabel.Text = SecondsBeforeClose.ToString() + "...";
            }
            else
            {
                DelayTimer.Stop();

                var Launchers = new List<ILauncher>();
                Launchers.Add( new PosiwLauncher() );
                Launchers.Add( new PositermLauncher() );
                Launchers.Add( new VNCLauncher() );

                foreach ( var launcher in Launchers )
                {
                    try
                    {
                        launcher.Launch();
                    }
                    catch ( NotImplementedException )
                    {
                        MessageBox.Show( "Launcher not implemented: " + launcher.GetType().ToString() );
                    }
                    catch ( Exception ex )
                    {
                        MessageBox.Show( "Exception: " + launcher.GetType().ToString() + ": " + ex.Message );
                    }
                }

                Application.Exit();
            }
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
                    PosiwLabel.Text = rxmatch.Result( "$1" );
                }
            }
        }

        private void RCButton_Click( object sender, EventArgs e )
        {
            DelayTimer.Stop();
            this.Hide();
            var config = new PositouchConfigWindow();
            config.ShowDialog();
            this.Show();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TermConfig.Launchers;
using System.Management;

namespace TermConfig
{
    public abstract class StartupWindow : Form
    {
        protected int SecondsBeforeClose = 4;
        protected Timer DelayTimer;
        protected List<ILauncher> LaunchList = new List<ILauncher>();

        protected virtual void CountdownTick( object sender, EventArgs e )
        {
            if ( SecondsBeforeClose > 0 )
            {
                SecondsBeforeClose--;
            }
            else
            {
                DelayTimer.Stop();

                foreach ( var launcher in LaunchList )
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

        protected string GetIPAddress()
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

            return String.Join( ", ", addresses.ToArray() );
        }
    }
}
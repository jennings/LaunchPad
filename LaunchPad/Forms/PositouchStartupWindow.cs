using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LaunchPad.Launchers;
using System.Diagnostics;

namespace LaunchPad.Forms
{
    public partial class PositouchStartupWindow : StartupWindow
    {
        public PositouchStartupWindow()
        {
            InitializeComponent();

            LaunchController = new PositouchLaunchController();
            var settings = SettingsReader.Instance;

            PositermLabel.Text = settings.LaunchPositerm ? "Yes" : "No";
            PosiwLabel.Text = settings.LaunchPosiw ? "Yes" : "No";
            VNCServerLabel.Text = settings.LaunchVNC ? "Yes" : "No";

            IPAddressLabel.Text = GetIPAddress();

            DelayTimer = new Timer();
            DelayTimer.Interval = 1000;
            DelayTimer.Tick += new EventHandler( CountdownTick );
            DelayTimer.Start();
        }

        protected override void CountdownTick( object sender, EventArgs e )
        {
            base.CountdownTick( sender, e );
            CountdownTimerLabel.Text = SecondsBeforeClose.ToString() + "...";
        }

        private void RCButton_Click( object sender, EventArgs e )
        {
            DelayTimer.Stop();
            this.Hide();
            var config = new PositouchTerminalSelectionWindow();
            config.ShowDialog();
            this.Show();
        }

        private void CalibrateButton_Click( object sender, EventArgs e )
        {
            DelayTimer.Stop();
            this.Hide();

            var eloTouchPath = Path.Combine(
                Environment.GetFolderPath( Environment.SpecialFolder.System ),
                @"EloTouch.cpl" );
            var mtsTouchPath = Path.Combine(
                Environment.GetFolderPath( Environment.SpecialFolder.System ),
                @"MtsTouch.cpl" );

            if ( File.Exists( eloTouchPath ) )
            {
                var info = new ProcessStartInfo();
                info.FileName = eloTouchPath;
                info.UseShellExecute = true;
                var proc = Process.Start( info );
                proc.WaitForExit();
            }
            else if ( File.Exists( mtsTouchPath ) )
            {
                var info = new ProcessStartInfo();
                info.FileName = mtsTouchPath;
                info.UseShellExecute = true;
                var proc = Process.Start( info );
                proc.WaitForExit();
            }
            else
            {
                MessageBox.Show( "Could not find calibration utility." );
            }

            this.Show();
        }

        private void LaunchNowButton_Click( object sender, EventArgs e )
        {
            SecondsBeforeClose = 0;
            base.CountdownTick( sender, e );
        }
    }
}

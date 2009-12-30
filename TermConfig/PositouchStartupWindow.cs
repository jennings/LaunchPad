using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TermConfig.Launchers;
using System.Diagnostics;

namespace TermConfig
{
    public partial class PositouchStartupWindow : StartupWindow
    {
        public PositouchStartupWindow()
        {
            InitializeComponent();

            LaunchController = new PositouchLaunchController();

            PositermLabel.Text = ( (PositouchLaunchController)LaunchController ).LaunchesPositerm ? "Yes" : "No";
            VNCServerLabel.Text = ( (PositouchLaunchController)LaunchController ).LaunchesVNC ? "Yes" : "No";

            IPAddressLabel.Text = GetIPAddress();

            GetPosiwSetting();

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

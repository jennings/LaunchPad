using System;
using System.Windows.Forms;
using TermConfig.Launchers;
using System.IO;
using System.Diagnostics;

namespace TermConfig
{
    public partial class AlohaStartupWindow : StartupWindow
    {
        public AlohaStartupWindow()
        {
            InitializeComponent();

            LaunchController = new AlohaLaunchController();

            AlohaFOHLabel.Text = ( (AlohaLaunchController)LaunchController ).LaunchesIbercfg ? "Yes" : "No";

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
            // var config = new PositouchConfigWindow();
            // config.ShowDialog();
            MessageBox.Show( @"TODO: No AlohaConfigWindow created yet." );
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
    }
}

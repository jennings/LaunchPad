using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TermConfig.Launchers;

namespace TermConfig
{
    public partial class PositouchStartupWindow : StartupWindow
    {
        public PositouchStartupWindow()
        {
            InitializeComponent();

            LaunchController = new PositouchLaunchController();

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
    }
}

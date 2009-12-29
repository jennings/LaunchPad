using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TermConfig.Launchers;

namespace TermConfig
{
    public partial class AlohaStartupWindow : StartupWindow
    {
        public AlohaStartupWindow()
        {
            InitializeComponent();

            PopulateLaunchList();

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

        private void PopulateLaunchList()
        {
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LaunchPad.Models;
using System.Net;
using LaunchPad.Configuration;

namespace LaunchPad.Forms
{
    public partial class AlohaPreconfiguredConfigWindow : Form
    {
        public AlohaPreconfiguredConfigWindow()
        {
            InitializeComponent();

            PopulateUnitList();
        }

        public void PopulateUnitList()
        {
            UnitListBox.Items.Clear();

            var settings = AlohaTerminalReader.Instance;
            UnitListBox.Items.AddRange( settings.Units.ToArray() );
        }

        public void PopulateTerminalList( string Unit )
        {
            TermNumListBox.Items.Clear();

            var settings = AlohaTerminalReader.Instance;
            TermNumListBox.Items.AddRange( settings.ReadTerminals( Unit, null ).ToArray() );
        }

        public void PopulateTerminalSettings( string unit, int term )
        {
            var settings = AlohaTerminalReader.Instance;

            AlohaTerminal terminal = new AlohaTerminal();

            foreach ( var t in settings.Terminals )
            {
                if ( t.UnitName.Equals( unit, StringComparison.InvariantCultureIgnoreCase ) && t.Term.Equals( term ) )
                {
                    terminal = t;
                }
            }

            TermTextBox.Text = terminal.Term.ToString();
            TermNameTextBox.Text = terminal.TermName;
            WorkgroupTextBox.Text = terminal.Workgroup;
            IPAddressTextBox.Text = terminal.IPAddress.ToString();
            SubnetMaskTextBox.Text = terminal.SubnetMask.ToString();
            DefaultGatewayTextBox.Text = terminal.DefaultGateway.ToString();
            DNS1TextBox.Text = terminal.DNS1.ToString();
            DNS2TextBox.Text = terminal.DNS2.ToString();
            FileserverNameTextBox.Text = terminal.FileserverName;
            NumberTerminalsTextBox.Text = terminal.NumberOfTerminals.ToString();
            MasterCapableTextBox.Text = terminal.MasterCapable.ToString();
            ServerCapableTextBox.Text = terminal.ServerCapable.ToString();
        }

        private void UnitListBox_SelectedValueChanged( object sender, EventArgs e )
        {
            try
            {
                PopulateTerminalList( UnitListBox.SelectedItem.ToString() );
                SettingsGroup.Visible = false;
            }
            catch ( NullReferenceException )
            { }
        }

        private void TermNumListBox_SelectedValueChanged( object sender, EventArgs e )
        {
            try
            {
                PopulateTerminalSettings(
                    UnitListBox.SelectedItem.ToString(),
                    ( (AlohaTerminal)TermNumListBox.SelectedItem ).Term );
            }
            catch ( NullReferenceException )
            { }

            SettingsGroup.Visible = true;
        }

        private void ApplyAndRebootButton_Click( object sender, EventArgs e )
        {
            var terminal = (AlohaTerminal)TermNumListBox.SelectedItem;
            var configurator = new AlohaConfiguratorController( terminal );
            configurator.Configure();
        }
    }
}

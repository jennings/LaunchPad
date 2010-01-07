﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using TermConfig.Configurators;
using System.Diagnostics;

namespace TermConfig.Forms
{
    public partial class PositouchTerminalSelectionWindow : Form
    {
        private Control CurrentControl;

        private List<Control> ControlOrder;

        public PositouchTerminalSelectionWindow()
        {
            InitializeComponent();

            ControlOrder = new List<Control>()
            {
                DeviceNumber_DeviceNumber,
                IPAddress_AddressTextBox
            };

            ResetScreen();
            SwitchToAutomatic();
            ActivateNextControl();
        }

        private void ActivateNextControl()
        {
            if ( CurrentControl == null )
            {
                CurrentControl = ControlOrder[0];
                CurrentControl.Focus();
                CurrentControl.BackColor = Color.Yellow;
                return;
            }

            var currentIndex = ControlOrder.IndexOf( CurrentControl );
            CurrentControl.BackColor = Color.Gray;

            if ( ControlOrder.Count > currentIndex + 1 )
            {
                CurrentControl = ControlOrder[currentIndex + 1];
                CurrentControl.Focus();
                CurrentControl.BackColor = Color.Yellow;
            }
            else
            {
                // Reached the end

                kbd_SaveAndReboot.Visible = true;
                kbd_SaveAndReboot.Enabled = true;
            }
        }

        private void ResetCurrentControl()
        {
            if ( CurrentControl != null )
            {
                CurrentControl.BackColor = Color.White;
                CurrentControl = null;
            }
            
            ActivateNextControl();
        }

        private void kbd_KeyPress( object sender, EventArgs e )
        {
            // Get letter
            string charPressed = ( ( (Button)sender ).Tag ).ToString();
            // Type letter
            CurrentControl.Text = CurrentControl.Text + charPressed;
        }

        private void kbd_Backspace_Click( object sender, EventArgs e )
        {
            if ( CurrentControl.GetType() == typeof( TextBox ) )
            {
                if ( CurrentControl.Text.Length > 0 )
                {
                    CurrentControl.Text = CurrentControl.Text.Remove( CurrentControl.Text.Length - 1 );
                }
            }
        }

        private void kbd_StartOver_Click( object sender, EventArgs e )
        {
            // Clear all fields
            DeviceNumber_DeviceNumber.Text = "";
            TerminalType_Normal.Select();
            kbd_SaveAndReboot.Visible = false;

            foreach ( var control in ControlOrder )
            {
                control.BackColor = Color.White;
            }

            // Activate first field
            CurrentControl = null;
            ActivateNextControl();
        }

        private void kbd_Enter_Click( object sender, EventArgs e )
        {
            ActivateNextControl();
        }


        private void kbd_SaveAndReboot_Click( object sender, EventArgs e )
        {
            if ( ( TerminalType_Backoffice.Checked || TerminalType_Posdriver.Checked ) && PosdriverBackofficePassword_Password.Text != "627" )
            {
                MessageBox.Show( @"Incorrect password! Call CBS at (800) 551-7674 for assistance." );
                return;
            }

            // Disable reboot button
            kbd_SaveAndReboot.Enabled = false;

            var settings = new PositouchTerminalStation();

            // Terminal type
            if ( TerminalType_Posdriver.Checked )
                settings.Type = TerminalStationType.Posdriver;
            else if ( TerminalType_Redundant.Checked )
                settings.Type = TerminalStationType.Redunant;
            else if ( TerminalType_Backoffice.Checked )
                settings.Type = TerminalStationType.Backoffice;
            else if ( TerminalType_Normal.Checked )
                settings.Type = TerminalStationType.Normal;
            else
                throw new Exception( @"No TerminalType radio button selected." );

            // Device number
            settings.DeviceNumber = Convert.ToInt32( DeviceNumber_DeviceNumber.Text );

            settings.Validate();

            var configuratorController = new PositouchConfiguratorController( settings );
            configuratorController.Configure();
        }

        private void TerminalType_CheckedChanged( object sender, EventArgs e )
        {
            if ( TerminalType_Backoffice.Checked )
            {
                Group_PosdriverBackofficePassword.Visible = true;
                DeviceNumber_DeviceNumber.Enabled = false;
                DeviceNumber_DeviceNumber.Text = "99";
            }
            else if ( TerminalType_Posdriver.Checked )
            {
                Group_PosdriverBackofficePassword.Visible = true;
                DeviceNumber_DeviceNumber.Enabled = false;
                DeviceNumber_DeviceNumber.Text = "89";
            }
            else if ( TerminalType_Redundant.Checked )
            {
                Group_PosdriverBackofficePassword.Visible = false;
                DeviceNumber_DeviceNumber.Enabled = true;
                DeviceNumber_DeviceNumber.Text = String.Empty;
            }
            else if ( TerminalType_Normal.Checked )
            {
                Group_PosdriverBackofficePassword.Visible = false;
                DeviceNumber_DeviceNumber.Enabled = true;
                DeviceNumber_DeviceNumber.Text = String.Empty;
            }
        }

        private void RefreshTerminalsButton_Click( object sender, EventArgs e )
        {
            TerminalsListView.Items.Clear();

            var terminals = TerminalsReader.Instance;
            terminals.RefreshTerminalList();

            foreach ( var terminal in terminals.Terminals )
            {
                ListViewItem item;
                item = new ListViewItem( terminal.DeviceNumber.ToString() );
                item.SubItems.Add( new ListViewItem.ListViewSubItem()
                {
                    Name = "Name",
                    Text = terminal.Name
                } );

                try
                {
                    item.SubItems.Add( new ListViewItem.ListViewSubItem()
                    {
                        Name = "IPAddress",
                        Text = terminal.IPAddress.ToString()
                    } );
                }
                catch ( NullReferenceException )
                {
                    item.SubItems.Add( new ListViewItem.ListViewSubItem()
                    {
                        Name = "IPAddress",
                        Text = ""
                    } );
                }

                item.SubItems.Add( new ListViewItem.ListViewSubItem()
                {
                    Name = "DeviceNumber",
                    Text = terminal.DeviceNumber.ToString()
                } );

                TerminalsListView.Items.Add( item );
            }
        }

        private void PopulateManualFields( int devnum, IPAddress ipaddress, PosiwTerminalType type )
        {
            switch ( type )
            {
                case PosiwTerminalType.BackoffServer:
                    TerminalType_Backoffice.Checked = true;
                    DeviceNumber_DeviceNumber.Text = "99";
                    break;
                case PosiwTerminalType.PrimaryServer:
                    TerminalType_Posdriver.Checked = true;
                    DeviceNumber_DeviceNumber.Text = "89";
                    break;
                case PosiwTerminalType.BackupServer:
                    TerminalType_Redundant.Checked = true;
                    DeviceNumber_DeviceNumber.Text = devnum.ToString( "D" );
                    break;
                case PosiwTerminalType.Normal:
                    TerminalType_Normal.Checked = true;
                    DeviceNumber_DeviceNumber.Text = devnum.ToString( "D" );
                    break;
            }

            IPAddress_AddressTextBox.Text = ipaddress.ToString();
        }

        private void TerminalsListView_ItemSelectionChanged( object sender, ListViewItemSelectionChangedEventArgs e )
        {
            int devnum = -1;
            IPAddress ipaddress = null;
            PosiwTerminalType type = PosiwTerminalType.Normal;

            foreach ( System.Windows.Forms.ListViewItem.ListViewSubItem subitem in e.Item.SubItems )
            {
                switch ( subitem.Name )
                {
                    case "DeviceNumber":
                        devnum = Convert.ToInt32( subitem.Text );
                        break;

                    case "IPAddress":
                        ipaddress = IPAddress.Parse( subitem.Text );
                        if ( ipaddress.Equals( SettingsReader.Instance.PosdriverIPAddress ) )
                        {
                            type = PosiwTerminalType.PrimaryServer;
                        }
                        else if ( ipaddress.Equals( SettingsReader.Instance.BackofficeIPAddress ) )
                        {
                            type = PosiwTerminalType.BackoffServer;
                        }
                        else if ( ipaddress.Equals( SettingsReader.Instance.RedundantIPAddress ) )
                        {
                            type = PosiwTerminalType.BackupServer;
                        }
                        else
                        {
                            type = PosiwTerminalType.Normal;
                        }
                        break;
                }
            }

            PopulateManualFields( devnum, ipaddress, type );
        }

        private void AutomaticManualButton_Click( object sender, EventArgs e )
        {
            switch ( AutomaticManualButton.Text )
            {
                case "Switch to Manual":
                    AutomaticManualButton.Text = "Switch to Automatic";
                    ResetScreen();
                    SwitchToManual();
                    break;
                
                default:
                    AutomaticManualButton.Text = "Switch to Manual";
                    ResetScreen();
                    SwitchToAutomatic();
                    break;
            }
        }

        private void ResetScreen()
        {
            DeviceNumber_DeviceNumber.Text = "";
            IPAddress_AddressTextBox.Text = "";
            TerminalType_Normal.Checked = true;
            TerminalsListView.Items.Clear();
        }

        private void SwitchToManual()
        {
            DeviceNumber_DeviceNumber.Enabled = true;
            IPAddress_AddressTextBox.Enabled = true;
            TerminalType_Normal.Enabled = true;
            TerminalType_Redundant.Enabled = true;
            // TerminalType_Posdriver.Enabled = true;
            // TerminalType_Backoffice.Enabled = true;
            TerminalsListView.Enabled = false;
        }

        private void SwitchToAutomatic()
        {
            DeviceNumber_DeviceNumber.Enabled = false;
            IPAddress_AddressTextBox.Enabled = false;
            TerminalType_Normal.Enabled = false;
            TerminalType_Redundant.Enabled = false;
            // TerminalType_Posdriver.Enabled = false;
            // TerminalType_Backoffice.Enabled = false;
            TerminalsListView.Enabled = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using LaunchPad.Configuration;
using LaunchPad.Models;

namespace LaunchPad.Forms
{
    public partial class AlohaManualConfigWindow : Form
    {
        private Control CurrentControl;
        private List<Control> ControlOrder;

        public AlohaManualConfigWindow()
        {
            InitializeComponent();
            ControlOrder = new List<Control>()
            {
                IPAddress_AddressTextBox,
                FileserverName_FileserverName,
                TerminalNumber_TerminalNumber,
                NumberOfTerminals_NumberOfTerminals
            };

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
                kbd_SaveAndReboot.Visible = true;
                kbd_SaveAndReboot.Enabled = true;
            }
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
            IPAddress_AddressTextBox.Text = "";
            FileserverName_FileserverName.Text = "";
            TerminalNumber_TerminalNumber.Text = "";
            NumberOfTerminals_NumberOfTerminals.Text = "";
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
            // Disable reboot button
            kbd_SaveAndReboot.Enabled = false;

            var model = new AlohaTerminal()
            {
                IPAddress = IPAddress.Parse( IPAddress_AddressTextBox.Text ),
                FileserverName = FileserverName_FileserverName.Text,
                Term = Convert.ToInt32( TerminalNumber_TerminalNumber.Text ),
                NumberOfTerminals = Convert.ToInt32( NumberOfTerminals_NumberOfTerminals.Text ),
                MasterCapable = true,
                ServerCapable = true
            };

            var config = new AlohaConfiguratorController( model );

            config.Configure();
        }
    }
}

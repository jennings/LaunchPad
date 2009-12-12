using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TermConfig
{
    public partial class TermConfigWindow : Form
    {
        private Control ActiveControl;

        public TermConfigWindow()
        {
            InitializeComponent();
            ActivateControl( IPAddress_AddressTextBox );
        }

        private void ActivateControl( Control controlToActivate )
        {
            ActiveControl = controlToActivate;
        }

        private void kbd_KeyPress( object sender, EventArgs e )
        {
            // Get letter
            // Type letter
        }

        private void kbd_Backspace_Click( object sender, EventArgs e )
        {
            if ( ActiveControl.GetType() == typeof( TextBox ) )
            {
                ActiveControl.Text = ActiveControl.Text.Remove( ActiveControl.Text.Length - 1 );
            }
        }

        private void kbd_StartOver_Click( object sender, EventArgs e )
        {
            // Clear all fields

            // Hide all groups

            // Activate first field
        }

        private void kbd_Enter_Click( object sender, EventArgs e )
        {
            switch ( ActiveControl.Name )
            {
                case "IPAddress_AddressTextBox":
                    SubmitIPAddressGroup();
                    break;
                case "SourceTerminal_IPAddress":
                    ActivateControl( SourceTerminal_Username);
                    break;
                case "SourceTerminal_Username":
                    ActivateControl( SourceTerminal_Password );
                    break;
                case "SourceTerminal_Password":
                    SubmitSourceTerminalGroup();
                    break;
                case "DeviceNumber_DeviceNumber":
                    SubmitDeviceNumberGroup();
                    break;
                case "TerminalType_Normal":
                case "TerminalType_Redundant":
                case "TerminalType_Posdriver":
                    SubmitTerminalTypeGroup();
                    break;
                case "VNC_cbsinc":
                case "VNC_sliders":
                case "VNC_CustomPassword":
                case "VNC_CustomPasswordTextBox":
                    SubmitVNCGroup();
                    break;
            }
        }

        private void kbd_SaveAndReboot_Click( object sender, EventArgs e )
        {

        }

        private void VNCSkipButton_Click( object sender, EventArgs e )
        {

        }

        private void SubmitIPAddressGroup()
        {
            // Validate IP Address
            // Set IP address
            // Disable group
            // Activate next group
        }

        private void SubmitSourceTerminalGroup()
        {
            // Validate IP address
            // Try to map drive
            // Try to copy INIs
            // Disable group
            // Activate next group
        }

        private void SubmitDeviceNumberGroup()
        {
            // Validate number
            // Disable group
            // Activate next group
        }

        private void SubmitTerminalTypeGroup()
        {
            // Validate field
            // Write posiw.ini
            // Disable group
            // Activate next group
        }

        private void SubmitVNCGroup()
        {
            // Validate field
            // Enable VNC
            // Disable group
            // Activate save and reboot button
        }
    }
}

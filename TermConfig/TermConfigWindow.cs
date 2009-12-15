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
            string charPressed = ( ( (Button)sender ).Tag ).ToString();
            // Type letter
            ActiveControl.Text = ActiveControl.Text + charPressed;
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
            IPAddress_AddressTextBox.Text = "";
            SourceTerminal_IPAddress.Text = "";
            SourceTerminal_Username.Text = "";
            SourceTerminal_Password.Text = "";
            DeviceNumber_DeviceNumber.Text = "";
            TerminalType_Normal.Select();
            VNC_cbsinc.Select();
            VNC_CustomPasswordTextBox.Text = "";
            kbd_SaveAndReboot.Visible = false;
            LogList.Items.Clear();

            // Hide all groups
            Group_SourceTerminal.Visible = false;
            Group_DeviceNumber.Visible = false;
            Group_TerminalType.Visible = false;
            Group_VNC.Visible = false;

            // Activate first field
            Group_IPAddress.Enabled = true;
            Group_IPAddress.Visible = true;
            ActivateControl( IPAddress_AddressTextBox );
        }

        private void kbd_Enter_Click( object sender, EventArgs e )
        {
            switch ( ActiveControl.Name )
            {
                case "IPAddress_AddressTextBox":
                    SubmitIPAddressGroup();
                    break;
                case "SourceTerminal_IPAddress":
                    ActivateControl( SourceTerminal_Username );
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
            // Change IP Address
            SettingCommitter.ChangeTerminalIPAddress( "" );

            // Copy INI files from remote terminal
            SettingCommitter.CopyINIs( "", "", "" );

            // Write Posiw.ini
            SettingCommitter.WritePosiw();

            // Install VNC
            SettingCommitter.InstallVNC( "" );

            // Reboot
            SettingCommitter.RebootTerminal();
        }

        private void VNCSkipButton_Click( object sender, EventArgs e )
        {

        }

        private void SubmitIPAddressGroup()
        {
            // Validate IP Address
            // Set IP address

            // Disable group
            Group_IPAddress.Enabled = false;

            // Activate next group
            Group_SourceTerminal.Enabled = true;
            Group_SourceTerminal.Visible = true;
            ActivateControl( SourceTerminal_IPAddress );
        }

        private void SubmitSourceTerminalGroup()
        {
            // Validate IP address
            // Try to map drive
            // Try to copy INIs

            // Disable group
            Group_SourceTerminal.Enabled = false;

            // Activate next group
            Group_DeviceNumber.Enabled = true;
            Group_DeviceNumber.Visible = true;
            ActivateControl( DeviceNumber_DeviceNumber );
        }

        private void SubmitDeviceNumberGroup()
        {
            // Validate number

            // Disable group
            Group_DeviceNumber.Enabled = false;

            // Activate next group
            Group_TerminalType.Enabled = true;
            Group_TerminalType.Visible = true;
            ActivateControl( TerminalType_Normal );
        }

        private void SubmitTerminalTypeGroup()
        {
            // Validate field
            // Write posiw.ini

            // Disable group
            Group_TerminalType.Enabled = false;

            // Activate next group
            Group_VNC.Enabled = true;
            Group_VNC.Visible = true;
            ActivateControl( VNC_CustomPasswordTextBox );
        }

        private void SubmitVNCGroup()
        {
            // Validate field
            // Enable VNC
            // Disable group
            Group_VNC.Enabled = false;

            // Activate save and reboot button
            kbd_SaveAndReboot.Enabled = true;
            kbd_SaveAndReboot.Visible = true;
            ActivateControl( kbd_SaveAndReboot );
        }
    }
}

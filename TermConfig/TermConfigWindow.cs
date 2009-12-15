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
        private Control CurrentControl;

        private bool SkippedIPAddress = false;
        private bool SkippedSourceTerminal = false;
        private bool SkippedVNC = false;

        public TermConfigWindow()
        {
            InitializeComponent();
            ActivateControl( IPAddress_AddressTextBox );
        }

        private void WriteLog( string text )
        {
            LogList.Items.Add( text );
        }

        private void ActivateControl( Control controlToActivate )
        {
            CurrentControl = controlToActivate;
            CurrentControl.Focus();
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
                CurrentControl.Text = CurrentControl.Text.Remove( CurrentControl.Text.Length - 1 );
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
            SkippedIPAddress = false;
            SkippedSourceTerminal = false;
            SkippedVNC = false;
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
            switch ( CurrentControl.Name )
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


        private void SkipGroup()
        {
            switch ( CurrentControl.Name )
            {
                case "IPAddress_AddressTextBox":
                    SubmitIPAddressGroup();
                    break;
                case "SourceTerminal_IPAddress":
                case "SourceTerminal_Username":
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
            // Disable reboot button
            kbd_SaveAndReboot.Enabled = false;

            try
            {
                // Change IP Address
                if ( SkippedIPAddress )
                {
                    WriteLog( "......... Skipping IP Address." );
                }
                else
                {
                    WriteLog( "......... Setting IP Address." );
                    SettingCommitter.ChangeTerminalIPAddress( IPAddress_AddressTextBox.Text );
                    WriteLog( "OK.... Set IP Address." );
                }

                // Copy INI files from remote terminal
                if ( SkippedSourceTerminal )
                {
                    WriteLog( "......... Skipping copying INIs." );
                }
                else
                {
                    WriteLog( "......... Copying INIs." );
                    SettingCommitter.CopyINIs( SourceTerminal_IPAddress.Text, SourceTerminal_Username.Text, SourceTerminal_Password.Text );
                    WriteLog( "OK.... Copied INIs." );
                }

                // Write TERM.$$$
                WriteLog( "......... Writing TERM.$$$." );
                SettingCommitter.WriteTerm( Convert.ToInt32( DeviceNumber_DeviceNumber.Text ) );
                WriteLog( "OK.... Wrote TERM.$$$." );

                // Write Posiw.ini
                WriteLog( "......... Writing Posiw.ini." );
                SettingCommitter.WritePosiw( Convert.ToInt32( DeviceNumber_DeviceNumber.Text ) );
                WriteLog( "OK.... Wrote Posiw.ini." );

                // Install VNC
                if ( SkippedVNC )
                {
                    WriteLog( "......... Skipping VNC." );
                }
                else
                {
                    WriteLog( "......... Installing VNC." );
                    if ( VNC_cbsinc.Checked ) SettingCommitter.InstallVNC( "cbsinc" );
                    else if ( VNC_sliders.Checked ) SettingCommitter.InstallVNC( "sliders" );
                    else if ( VNC_CustomPassword.Checked ) SettingCommitter.InstallVNC( VNC_CustomPasswordTextBox.Text );
                    WriteLog( "OK.... Installed VNC." );
                }

                // Reboot
                WriteLog( "Rebooting..." );
                SettingCommitter.RebootTerminal();
            }
            catch ( Exception ex )
            {
                WriteLog( "EXCEPTION: " + ex.Message );
                throw;
            }
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

        private void IPAddress_SkipButton_Click( object sender, EventArgs e )
        {
            SkippedIPAddress = true;
            SkipGroup();
        }

        private void SourceTerminal_SkipButton_Click( object sender, EventArgs e )
        {
            SkippedSourceTerminal = true;
            SkipGroup();
        }

        private void VNC_SkipButton_Click( object sender, EventArgs e )
        {
            SkippedVNC = true;
            SkipGroup();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using TermConfig.Configurators;

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
            PosdriverIP_IPAddress.Text = "";
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
            Group_PosdriverIP.Visible = false;
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

            var settings = new TerminalStation();

            // Terminal type
            if ( TerminalType_Posdriver.Checked ) settings.Type = TerminalStationType.Posdriver;
            else if ( TerminalType_Redundant.Checked ) settings.Type = TerminalStationType.Redunant;
            // else if ( TerminalType_Backoffice.Checked ) settings.Type = TerminalStationType.Backoffice;
            else if ( TerminalType_Normal.Checked ) settings.Type = TerminalStationType.Normal;
            else throw new Exception( @"No TerminalType radio button selected." );

            // Device number
            settings.DeviceNumber = Convert.ToInt32( DeviceNumber_DeviceNumber.Text );

            // IP Address
            settings.IPAddress = IPAddress.Parse( IPAddress_AddressTextBox.Text );
            settings.PosdriverIPAddress = IPAddress.Parse( PosdriverIP_IPAddress.Text );
            // settings.RedundantIPAddress = IPAddress.Parse( RedundantTerminal_IPAddress.Text );

            settings.Validate();

            var network = new NetworkConfigurator( settings );
            var positerm = new PositermConfigurator( settings );
            var posiw = new PosiwConfigurator( settings );
            var vnc = new VNCConfigurator( settings );

            WriteLog( "Configuring network..." );
            network.Configure();
            WriteLog( "Network OK" );

            WriteLog( "Configuring Positerm..." );
            positerm.Configure();
            WriteLog( "Positerm OK" );

            WriteLog( "Configuring Posiw..." );
            posiw.Configure();
            WriteLog( "Posiw OK" );

            WriteLog( "Configuring VNC..." );
            vnc.Configure();
            WriteLog( "VNC OK" );

            // Reboot
        }

        private void SubmitIPAddressGroup()
        {
            // Validate IP Address
            // Set IP address

            // Disable group
            Group_IPAddress.Enabled = false;

            // Activate next group
            Group_PosdriverIP.Enabled = true;
            Group_PosdriverIP.Visible = true;
            ActivateControl( PosdriverIP_IPAddress );
        }

        private void SubmitSourceTerminalGroup()
        {
            // Validate IP address
            // Try to map drive
            // Try to copy INIs

            // Disable group
            Group_PosdriverIP.Enabled = false;

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

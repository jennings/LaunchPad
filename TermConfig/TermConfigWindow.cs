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

        private List<Control> ControlOrder;

        public TermConfigWindow()
        {
            InitializeComponent();

            ControlOrder = new List<Control>()
            {
                IPAddress_AddressTextBox,
                PosdriverIP_IPAddress,
                BackofficeIP_IPAddress,
                AccpacID_AccpacID,
                DeviceNumber_DeviceNumber
            };

            ActivateNextControl();
        }

        private void WriteLog( string text )
        {
            LogList.Items.Add( text );
        }

        private void ActivateNextControl()
        {
            if ( CurrentControl == null )
            {
                CurrentControl = ControlOrder[0];
                return;
            }

            var currentIndex = ControlOrder.IndexOf( CurrentControl );

            if ( ControlOrder.Count > currentIndex + 1 )
            {
                CurrentControl = ControlOrder[currentIndex + 1];
            }
            else
            {
                // Reached the end

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
                CurrentControl.Text = CurrentControl.Text.Remove( CurrentControl.Text.Length - 1 );
            }
        }

        private void kbd_StartOver_Click( object sender, EventArgs e )
        {
            // Clear all fields
            IPAddress_AddressTextBox.Text = "";
            PosdriverIP_IPAddress.Text = "";
            BackofficeIP_IPAddress.Text = "";
            DeviceNumber_DeviceNumber.Text = "";
            TerminalType_Normal.Select();
            kbd_SaveAndReboot.Visible = false;
            LogList.Items.Clear();

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
    }
}

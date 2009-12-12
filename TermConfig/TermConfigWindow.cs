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

        }

        private void kbd_SaveAndReboot_Click( object sender, EventArgs e )
        {

        }

        private void VNCSkipButton_Click( object sender, EventArgs e )
        {

        }
    }
}

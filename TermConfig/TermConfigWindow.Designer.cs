﻿namespace TermConfig
{
    partial class TermConfigWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Group_IPAddress = new System.Windows.Forms.GroupBox();
            this.IPAddress_SkipButton = new System.Windows.Forms.Button();
            this.IPAddress_AddressTextBox = new System.Windows.Forms.TextBox();
            this.KeyboardPanel = new System.Windows.Forms.Panel();
            this.kbd_Shift = new System.Windows.Forms.Button();
            this.kbd_SaveAndReboot = new System.Windows.Forms.Button();
            this.kbd_6 = new System.Windows.Forms.Button();
            this.kbd_3 = new System.Windows.Forms.Button();
            this.kbd_5 = new System.Windows.Forms.Button();
            this.kbd_2 = new System.Windows.Forms.Button();
            this.kbd_9 = new System.Windows.Forms.Button();
            this.kbd_8 = new System.Windows.Forms.Button();
            this.kbd_4 = new System.Windows.Forms.Button();
            this.kbd_1 = new System.Windows.Forms.Button();
            this.kbd_0 = new System.Windows.Forms.Button();
            this.kbd_7 = new System.Windows.Forms.Button();
            this.kbd_StartOver = new System.Windows.Forms.Button();
            this.kbd_Enter = new System.Windows.Forms.Button();
            this.kbd_Backspace = new System.Windows.Forms.Button();
            this.kbd_L = new System.Windows.Forms.Button();
            this.kbd_P = new System.Windows.Forms.Button();
            this.kbd_O = new System.Windows.Forms.Button();
            this.kbd_K = new System.Windows.Forms.Button();
            this.kbd_Period = new System.Windows.Forms.Button();
            this.kbd_J = new System.Windows.Forms.Button();
            this.kbd_M = new System.Windows.Forms.Button();
            this.kbd_I = new System.Windows.Forms.Button();
            this.kbd_U = new System.Windows.Forms.Button();
            this.kbd_H = new System.Windows.Forms.Button();
            this.kbd_N = new System.Windows.Forms.Button();
            this.kbd_G = new System.Windows.Forms.Button();
            this.kbd_B = new System.Windows.Forms.Button();
            this.kbd_Y = new System.Windows.Forms.Button();
            this.kbd_T = new System.Windows.Forms.Button();
            this.kbd_F = new System.Windows.Forms.Button();
            this.kbd_V = new System.Windows.Forms.Button();
            this.kbd_D = new System.Windows.Forms.Button();
            this.kbd_C = new System.Windows.Forms.Button();
            this.kbd_R = new System.Windows.Forms.Button();
            this.kbd_E = new System.Windows.Forms.Button();
            this.kbd_S = new System.Windows.Forms.Button();
            this.kbd_X = new System.Windows.Forms.Button();
            this.kbd_A = new System.Windows.Forms.Button();
            this.kbd_Z = new System.Windows.Forms.Button();
            this.kbd_W = new System.Windows.Forms.Button();
            this.kbd_Q = new System.Windows.Forms.Button();
            this.Group_TerminalType = new System.Windows.Forms.GroupBox();
            this.TerminalType_Posdriver = new System.Windows.Forms.RadioButton();
            this.TerminalType_Redundant = new System.Windows.Forms.RadioButton();
            this.TerminalType_Normal = new System.Windows.Forms.RadioButton();
            this.Group_VNC = new System.Windows.Forms.GroupBox();
            this.VNC_SkipButton = new System.Windows.Forms.Button();
            this.VNC_CustomPasswordTextBox = new System.Windows.Forms.TextBox();
            this.VNC_CustomPassword = new System.Windows.Forms.RadioButton();
            this.VNC_sliders = new System.Windows.Forms.RadioButton();
            this.VNC_cbsinc = new System.Windows.Forms.RadioButton();
            this.Group_SourceTerminal = new System.Windows.Forms.GroupBox();
            this.SourceTerminal_SkipButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SourceTerminal_Password = new System.Windows.Forms.TextBox();
            this.SourceTerminal_Username = new System.Windows.Forms.TextBox();
            this.SourceTerminal_IPAddress = new System.Windows.Forms.TextBox();
            this.Group_DeviceNumber = new System.Windows.Forms.GroupBox();
            this.DeviceNumber_DeviceNumber = new System.Windows.Forms.TextBox();
            this.LogList = new System.Windows.Forms.ListBox();
            this.Group_IPAddress.SuspendLayout();
            this.KeyboardPanel.SuspendLayout();
            this.Group_TerminalType.SuspendLayout();
            this.Group_VNC.SuspendLayout();
            this.Group_SourceTerminal.SuspendLayout();
            this.Group_DeviceNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // Group_IPAddress
            // 
            this.Group_IPAddress.Controls.Add( this.IPAddress_SkipButton );
            this.Group_IPAddress.Controls.Add( this.IPAddress_AddressTextBox );
            this.Group_IPAddress.Location = new System.Drawing.Point( 13, 13 );
            this.Group_IPAddress.Name = "Group_IPAddress";
            this.Group_IPAddress.Size = new System.Drawing.Size( 242, 91 );
            this.Group_IPAddress.TabIndex = 0;
            this.Group_IPAddress.TabStop = false;
            this.Group_IPAddress.Text = "IP Address";
            // 
            // IPAddress_SkipButton
            // 
            this.IPAddress_SkipButton.Location = new System.Drawing.Point( 48, 51 );
            this.IPAddress_SkipButton.Name = "IPAddress_SkipButton";
            this.IPAddress_SkipButton.Size = new System.Drawing.Size( 153, 28 );
            this.IPAddress_SkipButton.TabIndex = 6;
            this.IPAddress_SkipButton.Text = "SKIP";
            this.IPAddress_SkipButton.UseVisualStyleBackColor = true;
            this.IPAddress_SkipButton.Click += new System.EventHandler( this.IPAddress_SkipButton_Click );
            // 
            // IPAddress_AddressTextBox
            // 
            this.IPAddress_AddressTextBox.Font = new System.Drawing.Font( "Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.IPAddress_AddressTextBox.Location = new System.Drawing.Point( 6, 19 );
            this.IPAddress_AddressTextBox.Name = "IPAddress_AddressTextBox";
            this.IPAddress_AddressTextBox.Size = new System.Drawing.Size( 230, 26 );
            this.IPAddress_AddressTextBox.TabIndex = 0;
            // 
            // KeyboardPanel
            // 
            this.KeyboardPanel.Controls.Add( this.kbd_Shift );
            this.KeyboardPanel.Controls.Add( this.kbd_SaveAndReboot );
            this.KeyboardPanel.Controls.Add( this.kbd_6 );
            this.KeyboardPanel.Controls.Add( this.kbd_3 );
            this.KeyboardPanel.Controls.Add( this.kbd_5 );
            this.KeyboardPanel.Controls.Add( this.kbd_2 );
            this.KeyboardPanel.Controls.Add( this.kbd_9 );
            this.KeyboardPanel.Controls.Add( this.kbd_8 );
            this.KeyboardPanel.Controls.Add( this.kbd_4 );
            this.KeyboardPanel.Controls.Add( this.kbd_1 );
            this.KeyboardPanel.Controls.Add( this.kbd_0 );
            this.KeyboardPanel.Controls.Add( this.kbd_7 );
            this.KeyboardPanel.Controls.Add( this.kbd_StartOver );
            this.KeyboardPanel.Controls.Add( this.kbd_Enter );
            this.KeyboardPanel.Controls.Add( this.kbd_Backspace );
            this.KeyboardPanel.Controls.Add( this.kbd_L );
            this.KeyboardPanel.Controls.Add( this.kbd_P );
            this.KeyboardPanel.Controls.Add( this.kbd_O );
            this.KeyboardPanel.Controls.Add( this.kbd_K );
            this.KeyboardPanel.Controls.Add( this.kbd_Period );
            this.KeyboardPanel.Controls.Add( this.kbd_J );
            this.KeyboardPanel.Controls.Add( this.kbd_M );
            this.KeyboardPanel.Controls.Add( this.kbd_I );
            this.KeyboardPanel.Controls.Add( this.kbd_U );
            this.KeyboardPanel.Controls.Add( this.kbd_H );
            this.KeyboardPanel.Controls.Add( this.kbd_N );
            this.KeyboardPanel.Controls.Add( this.kbd_G );
            this.KeyboardPanel.Controls.Add( this.kbd_B );
            this.KeyboardPanel.Controls.Add( this.kbd_Y );
            this.KeyboardPanel.Controls.Add( this.kbd_T );
            this.KeyboardPanel.Controls.Add( this.kbd_F );
            this.KeyboardPanel.Controls.Add( this.kbd_V );
            this.KeyboardPanel.Controls.Add( this.kbd_D );
            this.KeyboardPanel.Controls.Add( this.kbd_C );
            this.KeyboardPanel.Controls.Add( this.kbd_R );
            this.KeyboardPanel.Controls.Add( this.kbd_E );
            this.KeyboardPanel.Controls.Add( this.kbd_S );
            this.KeyboardPanel.Controls.Add( this.kbd_X );
            this.KeyboardPanel.Controls.Add( this.kbd_A );
            this.KeyboardPanel.Controls.Add( this.kbd_Z );
            this.KeyboardPanel.Controls.Add( this.kbd_W );
            this.KeyboardPanel.Controls.Add( this.kbd_Q );
            this.KeyboardPanel.Location = new System.Drawing.Point( 12, 384 );
            this.KeyboardPanel.Name = "KeyboardPanel";
            this.KeyboardPanel.Size = new System.Drawing.Size( 740, 126 );
            this.KeyboardPanel.TabIndex = 1;
            // 
            // kbd_Shift
            // 
            this.kbd_Shift.Location = new System.Drawing.Point( 3, 85 );
            this.kbd_Shift.Name = "kbd_Shift";
            this.kbd_Shift.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_Shift.TabIndex = 50;
            this.kbd_Shift.Text = "Shft";
            this.kbd_Shift.UseVisualStyleBackColor = true;
            // 
            // kbd_SaveAndReboot
            // 
            this.kbd_SaveAndReboot.Location = new System.Drawing.Point( 647, 3 );
            this.kbd_SaveAndReboot.Name = "kbd_SaveAndReboot";
            this.kbd_SaveAndReboot.Size = new System.Drawing.Size( 90, 117 );
            this.kbd_SaveAndReboot.TabIndex = 3;
            this.kbd_SaveAndReboot.Text = "Save and Reboot";
            this.kbd_SaveAndReboot.UseVisualStyleBackColor = true;
            this.kbd_SaveAndReboot.Visible = false;
            this.kbd_SaveAndReboot.Click += new System.EventHandler( this.kbd_SaveAndReboot_Click );
            // 
            // kbd_6
            // 
            this.kbd_6.Location = new System.Drawing.Point( 495, 44 );
            this.kbd_6.Name = "kbd_6";
            this.kbd_6.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_6.TabIndex = 49;
            this.kbd_6.Tag = "6";
            this.kbd_6.Text = "6";
            this.kbd_6.UseVisualStyleBackColor = true;
            this.kbd_6.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_3
            // 
            this.kbd_3.Location = new System.Drawing.Point( 495, 85 );
            this.kbd_3.Name = "kbd_3";
            this.kbd_3.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_3.TabIndex = 48;
            this.kbd_3.Tag = "3";
            this.kbd_3.Text = "3";
            this.kbd_3.UseVisualStyleBackColor = true;
            this.kbd_3.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_5
            // 
            this.kbd_5.Location = new System.Drawing.Point( 454, 44 );
            this.kbd_5.Name = "kbd_5";
            this.kbd_5.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_5.TabIndex = 47;
            this.kbd_5.Tag = "5";
            this.kbd_5.Text = "5";
            this.kbd_5.UseVisualStyleBackColor = true;
            this.kbd_5.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_2
            // 
            this.kbd_2.Location = new System.Drawing.Point( 454, 85 );
            this.kbd_2.Name = "kbd_2";
            this.kbd_2.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_2.TabIndex = 46;
            this.kbd_2.Tag = "2";
            this.kbd_2.Text = "2";
            this.kbd_2.UseVisualStyleBackColor = true;
            this.kbd_2.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_9
            // 
            this.kbd_9.Location = new System.Drawing.Point( 495, 3 );
            this.kbd_9.Name = "kbd_9";
            this.kbd_9.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_9.TabIndex = 45;
            this.kbd_9.Tag = "9";
            this.kbd_9.Text = "9";
            this.kbd_9.UseVisualStyleBackColor = true;
            this.kbd_9.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_8
            // 
            this.kbd_8.Location = new System.Drawing.Point( 454, 3 );
            this.kbd_8.Name = "kbd_8";
            this.kbd_8.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_8.TabIndex = 44;
            this.kbd_8.Tag = "8";
            this.kbd_8.Text = "8";
            this.kbd_8.UseVisualStyleBackColor = true;
            this.kbd_8.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_4
            // 
            this.kbd_4.Location = new System.Drawing.Point( 413, 44 );
            this.kbd_4.Name = "kbd_4";
            this.kbd_4.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_4.TabIndex = 43;
            this.kbd_4.Tag = "4";
            this.kbd_4.Text = "4";
            this.kbd_4.UseVisualStyleBackColor = true;
            this.kbd_4.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_1
            // 
            this.kbd_1.Location = new System.Drawing.Point( 413, 85 );
            this.kbd_1.Name = "kbd_1";
            this.kbd_1.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_1.TabIndex = 42;
            this.kbd_1.Tag = "1";
            this.kbd_1.Text = "1";
            this.kbd_1.UseVisualStyleBackColor = true;
            this.kbd_1.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_0
            // 
            this.kbd_0.Location = new System.Drawing.Point( 372, 85 );
            this.kbd_0.Name = "kbd_0";
            this.kbd_0.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_0.TabIndex = 40;
            this.kbd_0.Tag = "0";
            this.kbd_0.Text = "0";
            this.kbd_0.UseVisualStyleBackColor = true;
            this.kbd_0.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_7
            // 
            this.kbd_7.Location = new System.Drawing.Point( 413, 3 );
            this.kbd_7.Name = "kbd_7";
            this.kbd_7.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_7.TabIndex = 39;
            this.kbd_7.Tag = "7";
            this.kbd_7.Text = "7";
            this.kbd_7.UseVisualStyleBackColor = true;
            this.kbd_7.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_StartOver
            // 
            this.kbd_StartOver.Location = new System.Drawing.Point( 554, 44 );
            this.kbd_StartOver.Name = "kbd_StartOver";
            this.kbd_StartOver.Size = new System.Drawing.Size( 87, 35 );
            this.kbd_StartOver.TabIndex = 35;
            this.kbd_StartOver.Text = "Start Over";
            this.kbd_StartOver.UseVisualStyleBackColor = true;
            this.kbd_StartOver.Click += new System.EventHandler( this.kbd_StartOver_Click );
            // 
            // kbd_Enter
            // 
            this.kbd_Enter.Location = new System.Drawing.Point( 554, 85 );
            this.kbd_Enter.Name = "kbd_Enter";
            this.kbd_Enter.Size = new System.Drawing.Size( 87, 35 );
            this.kbd_Enter.TabIndex = 34;
            this.kbd_Enter.Text = "Enter";
            this.kbd_Enter.UseVisualStyleBackColor = true;
            this.kbd_Enter.Click += new System.EventHandler( this.kbd_Enter_Click );
            // 
            // kbd_Backspace
            // 
            this.kbd_Backspace.Location = new System.Drawing.Point( 554, 3 );
            this.kbd_Backspace.Name = "kbd_Backspace";
            this.kbd_Backspace.Size = new System.Drawing.Size( 87, 35 );
            this.kbd_Backspace.TabIndex = 32;
            this.kbd_Backspace.Text = "Backspace";
            this.kbd_Backspace.UseVisualStyleBackColor = true;
            this.kbd_Backspace.Click += new System.EventHandler( this.kbd_Backspace_Click );
            // 
            // kbd_L
            // 
            this.kbd_L.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_L.Location = new System.Drawing.Point( 331, 44 );
            this.kbd_L.Name = "kbd_L";
            this.kbd_L.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_L.TabIndex = 29;
            this.kbd_L.Tag = "l";
            this.kbd_L.Text = "L";
            this.kbd_L.UseVisualStyleBackColor = true;
            this.kbd_L.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_P
            // 
            this.kbd_P.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_P.Location = new System.Drawing.Point( 372, 3 );
            this.kbd_P.Name = "kbd_P";
            this.kbd_P.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_P.TabIndex = 27;
            this.kbd_P.Tag = "p";
            this.kbd_P.Text = "P";
            this.kbd_P.UseVisualStyleBackColor = true;
            this.kbd_P.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_O
            // 
            this.kbd_O.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_O.Location = new System.Drawing.Point( 331, 3 );
            this.kbd_O.Name = "kbd_O";
            this.kbd_O.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_O.TabIndex = 26;
            this.kbd_O.Tag = "o";
            this.kbd_O.Text = "O";
            this.kbd_O.UseVisualStyleBackColor = true;
            this.kbd_O.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_K
            // 
            this.kbd_K.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_K.Location = new System.Drawing.Point( 290, 44 );
            this.kbd_K.Name = "kbd_K";
            this.kbd_K.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_K.TabIndex = 25;
            this.kbd_K.Tag = "k";
            this.kbd_K.Text = "K";
            this.kbd_K.UseVisualStyleBackColor = true;
            this.kbd_K.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_Period
            // 
            this.kbd_Period.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_Period.Location = new System.Drawing.Point( 331, 85 );
            this.kbd_Period.Name = "kbd_Period";
            this.kbd_Period.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_Period.TabIndex = 24;
            this.kbd_Period.Tag = ".";
            this.kbd_Period.Text = ".";
            this.kbd_Period.UseVisualStyleBackColor = true;
            this.kbd_Period.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_J
            // 
            this.kbd_J.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_J.Location = new System.Drawing.Point( 249, 44 );
            this.kbd_J.Name = "kbd_J";
            this.kbd_J.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_J.TabIndex = 23;
            this.kbd_J.Tag = "j";
            this.kbd_J.Text = "J";
            this.kbd_J.UseVisualStyleBackColor = true;
            this.kbd_J.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_M
            // 
            this.kbd_M.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_M.Location = new System.Drawing.Point( 290, 85 );
            this.kbd_M.Name = "kbd_M";
            this.kbd_M.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_M.TabIndex = 22;
            this.kbd_M.Tag = "m";
            this.kbd_M.Text = "M";
            this.kbd_M.UseVisualStyleBackColor = true;
            this.kbd_M.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_I
            // 
            this.kbd_I.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_I.Location = new System.Drawing.Point( 290, 3 );
            this.kbd_I.Name = "kbd_I";
            this.kbd_I.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_I.TabIndex = 21;
            this.kbd_I.Tag = "i";
            this.kbd_I.Text = "I";
            this.kbd_I.UseVisualStyleBackColor = true;
            this.kbd_I.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_U
            // 
            this.kbd_U.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_U.Location = new System.Drawing.Point( 249, 3 );
            this.kbd_U.Name = "kbd_U";
            this.kbd_U.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_U.TabIndex = 20;
            this.kbd_U.Tag = "u";
            this.kbd_U.Text = "U";
            this.kbd_U.UseVisualStyleBackColor = true;
            this.kbd_U.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_H
            // 
            this.kbd_H.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_H.Location = new System.Drawing.Point( 208, 44 );
            this.kbd_H.Name = "kbd_H";
            this.kbd_H.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_H.TabIndex = 19;
            this.kbd_H.Tag = "h";
            this.kbd_H.Text = "H";
            this.kbd_H.UseVisualStyleBackColor = true;
            this.kbd_H.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_N
            // 
            this.kbd_N.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_N.Location = new System.Drawing.Point( 249, 85 );
            this.kbd_N.Name = "kbd_N";
            this.kbd_N.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_N.TabIndex = 18;
            this.kbd_N.Tag = "n";
            this.kbd_N.Text = "N";
            this.kbd_N.UseVisualStyleBackColor = true;
            this.kbd_N.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_G
            // 
            this.kbd_G.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_G.Location = new System.Drawing.Point( 167, 44 );
            this.kbd_G.Name = "kbd_G";
            this.kbd_G.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_G.TabIndex = 17;
            this.kbd_G.Tag = "g";
            this.kbd_G.Text = "G";
            this.kbd_G.UseVisualStyleBackColor = true;
            this.kbd_G.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_B
            // 
            this.kbd_B.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_B.Location = new System.Drawing.Point( 208, 85 );
            this.kbd_B.Name = "kbd_B";
            this.kbd_B.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_B.TabIndex = 16;
            this.kbd_B.Tag = "b";
            this.kbd_B.Text = "B";
            this.kbd_B.UseVisualStyleBackColor = true;
            this.kbd_B.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_Y
            // 
            this.kbd_Y.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_Y.Location = new System.Drawing.Point( 208, 3 );
            this.kbd_Y.Name = "kbd_Y";
            this.kbd_Y.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_Y.TabIndex = 15;
            this.kbd_Y.Tag = "y";
            this.kbd_Y.Text = "Y";
            this.kbd_Y.UseVisualStyleBackColor = true;
            this.kbd_Y.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_T
            // 
            this.kbd_T.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_T.Location = new System.Drawing.Point( 167, 3 );
            this.kbd_T.Name = "kbd_T";
            this.kbd_T.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_T.TabIndex = 14;
            this.kbd_T.Tag = "t";
            this.kbd_T.Text = "T";
            this.kbd_T.UseVisualStyleBackColor = true;
            this.kbd_T.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_F
            // 
            this.kbd_F.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_F.Location = new System.Drawing.Point( 126, 44 );
            this.kbd_F.Name = "kbd_F";
            this.kbd_F.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_F.TabIndex = 13;
            this.kbd_F.Tag = "f";
            this.kbd_F.Text = "F";
            this.kbd_F.UseVisualStyleBackColor = true;
            this.kbd_F.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_V
            // 
            this.kbd_V.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_V.Location = new System.Drawing.Point( 167, 85 );
            this.kbd_V.Name = "kbd_V";
            this.kbd_V.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_V.TabIndex = 12;
            this.kbd_V.Tag = "v";
            this.kbd_V.Text = "V";
            this.kbd_V.UseVisualStyleBackColor = true;
            this.kbd_V.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_D
            // 
            this.kbd_D.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_D.Location = new System.Drawing.Point( 85, 44 );
            this.kbd_D.Name = "kbd_D";
            this.kbd_D.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_D.TabIndex = 11;
            this.kbd_D.Tag = "d";
            this.kbd_D.Text = "D";
            this.kbd_D.UseVisualStyleBackColor = true;
            this.kbd_D.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_C
            // 
            this.kbd_C.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_C.Location = new System.Drawing.Point( 126, 85 );
            this.kbd_C.Name = "kbd_C";
            this.kbd_C.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_C.TabIndex = 10;
            this.kbd_C.Tag = "c";
            this.kbd_C.Text = "C";
            this.kbd_C.UseVisualStyleBackColor = true;
            this.kbd_C.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_R
            // 
            this.kbd_R.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_R.Location = new System.Drawing.Point( 126, 3 );
            this.kbd_R.Name = "kbd_R";
            this.kbd_R.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_R.TabIndex = 9;
            this.kbd_R.Tag = "r";
            this.kbd_R.Text = "R";
            this.kbd_R.UseVisualStyleBackColor = true;
            this.kbd_R.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_E
            // 
            this.kbd_E.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_E.Location = new System.Drawing.Point( 85, 3 );
            this.kbd_E.Name = "kbd_E";
            this.kbd_E.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_E.TabIndex = 8;
            this.kbd_E.Tag = "e";
            this.kbd_E.Text = "E";
            this.kbd_E.UseVisualStyleBackColor = true;
            this.kbd_E.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_S
            // 
            this.kbd_S.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_S.Location = new System.Drawing.Point( 44, 44 );
            this.kbd_S.Name = "kbd_S";
            this.kbd_S.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_S.TabIndex = 7;
            this.kbd_S.Tag = "s";
            this.kbd_S.Text = "S";
            this.kbd_S.UseVisualStyleBackColor = true;
            this.kbd_S.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_X
            // 
            this.kbd_X.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_X.Location = new System.Drawing.Point( 85, 85 );
            this.kbd_X.Name = "kbd_X";
            this.kbd_X.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_X.TabIndex = 6;
            this.kbd_X.Tag = "x";
            this.kbd_X.Text = "X";
            this.kbd_X.UseVisualStyleBackColor = true;
            this.kbd_X.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_A
            // 
            this.kbd_A.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_A.Location = new System.Drawing.Point( 3, 44 );
            this.kbd_A.Name = "kbd_A";
            this.kbd_A.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_A.TabIndex = 5;
            this.kbd_A.Tag = "a";
            this.kbd_A.Text = "A";
            this.kbd_A.UseVisualStyleBackColor = true;
            this.kbd_A.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_Z
            // 
            this.kbd_Z.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_Z.Location = new System.Drawing.Point( 44, 85 );
            this.kbd_Z.Name = "kbd_Z";
            this.kbd_Z.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_Z.TabIndex = 4;
            this.kbd_Z.Tag = "z";
            this.kbd_Z.Text = "Z";
            this.kbd_Z.UseVisualStyleBackColor = true;
            this.kbd_Z.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_W
            // 
            this.kbd_W.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_W.Location = new System.Drawing.Point( 44, 3 );
            this.kbd_W.Name = "kbd_W";
            this.kbd_W.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_W.TabIndex = 3;
            this.kbd_W.Tag = "w";
            this.kbd_W.Text = "W";
            this.kbd_W.UseVisualStyleBackColor = true;
            this.kbd_W.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // kbd_Q
            // 
            this.kbd_Q.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.kbd_Q.Location = new System.Drawing.Point( 3, 3 );
            this.kbd_Q.Name = "kbd_Q";
            this.kbd_Q.Size = new System.Drawing.Size( 35, 35 );
            this.kbd_Q.TabIndex = 2;
            this.kbd_Q.Tag = "q";
            this.kbd_Q.Text = "Q";
            this.kbd_Q.UseVisualStyleBackColor = true;
            this.kbd_Q.Click += new System.EventHandler( this.kbd_KeyPress );
            // 
            // Group_TerminalType
            // 
            this.Group_TerminalType.Controls.Add( this.TerminalType_Posdriver );
            this.Group_TerminalType.Controls.Add( this.TerminalType_Redundant );
            this.Group_TerminalType.Controls.Add( this.TerminalType_Normal );
            this.Group_TerminalType.Location = new System.Drawing.Point( 261, 13 );
            this.Group_TerminalType.Name = "Group_TerminalType";
            this.Group_TerminalType.Size = new System.Drawing.Size( 242, 100 );
            this.Group_TerminalType.TabIndex = 1;
            this.Group_TerminalType.TabStop = false;
            this.Group_TerminalType.Text = "This is a";
            this.Group_TerminalType.Visible = false;
            // 
            // TerminalType_Posdriver
            // 
            this.TerminalType_Posdriver.AutoSize = true;
            this.TerminalType_Posdriver.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.TerminalType_Posdriver.Location = new System.Drawing.Point( 20, 71 );
            this.TerminalType_Posdriver.Name = "TerminalType_Posdriver";
            this.TerminalType_Posdriver.Size = new System.Drawing.Size( 84, 20 );
            this.TerminalType_Posdriver.TabIndex = 2;
            this.TerminalType_Posdriver.Text = "Posdriver";
            this.TerminalType_Posdriver.UseVisualStyleBackColor = true;
            // 
            // TerminalType_Redundant
            // 
            this.TerminalType_Redundant.AutoSize = true;
            this.TerminalType_Redundant.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.TerminalType_Redundant.Location = new System.Drawing.Point( 20, 45 );
            this.TerminalType_Redundant.Name = "TerminalType_Redundant";
            this.TerminalType_Redundant.Size = new System.Drawing.Size( 142, 20 );
            this.TerminalType_Redundant.TabIndex = 1;
            this.TerminalType_Redundant.Text = "Redundant terminal";
            this.TerminalType_Redundant.UseVisualStyleBackColor = true;
            // 
            // TerminalType_Normal
            // 
            this.TerminalType_Normal.AutoSize = true;
            this.TerminalType_Normal.Checked = true;
            this.TerminalType_Normal.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.TerminalType_Normal.Location = new System.Drawing.Point( 20, 19 );
            this.TerminalType_Normal.Name = "TerminalType_Normal";
            this.TerminalType_Normal.Size = new System.Drawing.Size( 120, 20 );
            this.TerminalType_Normal.TabIndex = 0;
            this.TerminalType_Normal.TabStop = true;
            this.TerminalType_Normal.Text = "Normal terminal";
            this.TerminalType_Normal.UseVisualStyleBackColor = true;
            // 
            // Group_VNC
            // 
            this.Group_VNC.Controls.Add( this.VNC_SkipButton );
            this.Group_VNC.Controls.Add( this.VNC_CustomPasswordTextBox );
            this.Group_VNC.Controls.Add( this.VNC_CustomPassword );
            this.Group_VNC.Controls.Add( this.VNC_sliders );
            this.Group_VNC.Controls.Add( this.VNC_cbsinc );
            this.Group_VNC.Location = new System.Drawing.Point( 261, 119 );
            this.Group_VNC.Name = "Group_VNC";
            this.Group_VNC.Size = new System.Drawing.Size( 242, 180 );
            this.Group_VNC.TabIndex = 1;
            this.Group_VNC.TabStop = false;
            this.Group_VNC.Text = "VNC Password";
            this.Group_VNC.Visible = false;
            // 
            // VNC_SkipButton
            // 
            this.VNC_SkipButton.Location = new System.Drawing.Point( 46, 135 );
            this.VNC_SkipButton.Name = "VNC_SkipButton";
            this.VNC_SkipButton.Size = new System.Drawing.Size( 153, 28 );
            this.VNC_SkipButton.TabIndex = 7;
            this.VNC_SkipButton.Text = "SKIP";
            this.VNC_SkipButton.UseVisualStyleBackColor = true;
            this.VNC_SkipButton.Click += new System.EventHandler( this.VNC_SkipButton_Click );
            // 
            // VNC_CustomPasswordTextBox
            // 
            this.VNC_CustomPasswordTextBox.Font = new System.Drawing.Font( "Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.VNC_CustomPasswordTextBox.Location = new System.Drawing.Point( 41, 94 );
            this.VNC_CustomPasswordTextBox.Name = "VNC_CustomPasswordTextBox";
            this.VNC_CustomPasswordTextBox.Size = new System.Drawing.Size( 179, 26 );
            this.VNC_CustomPasswordTextBox.TabIndex = 6;
            // 
            // VNC_CustomPassword
            // 
            this.VNC_CustomPassword.AutoSize = true;
            this.VNC_CustomPassword.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.VNC_CustomPassword.Location = new System.Drawing.Point( 18, 68 );
            this.VNC_CustomPassword.Name = "VNC_CustomPassword";
            this.VNC_CustomPassword.Size = new System.Drawing.Size( 71, 20 );
            this.VNC_CustomPassword.TabIndex = 4;
            this.VNC_CustomPassword.Text = "Custom";
            this.VNC_CustomPassword.UseVisualStyleBackColor = true;
            // 
            // VNC_sliders
            // 
            this.VNC_sliders.AutoSize = true;
            this.VNC_sliders.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.VNC_sliders.Location = new System.Drawing.Point( 18, 42 );
            this.VNC_sliders.Name = "VNC_sliders";
            this.VNC_sliders.Size = new System.Drawing.Size( 66, 20 );
            this.VNC_sliders.TabIndex = 3;
            this.VNC_sliders.Text = "sliders";
            this.VNC_sliders.UseVisualStyleBackColor = true;
            // 
            // VNC_cbsinc
            // 
            this.VNC_cbsinc.AutoSize = true;
            this.VNC_cbsinc.Checked = true;
            this.VNC_cbsinc.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.VNC_cbsinc.Location = new System.Drawing.Point( 18, 19 );
            this.VNC_cbsinc.Name = "VNC_cbsinc";
            this.VNC_cbsinc.Size = new System.Drawing.Size( 65, 20 );
            this.VNC_cbsinc.TabIndex = 2;
            this.VNC_cbsinc.TabStop = true;
            this.VNC_cbsinc.Text = "cbsinc";
            this.VNC_cbsinc.UseVisualStyleBackColor = true;
            // 
            // Group_SourceTerminal
            // 
            this.Group_SourceTerminal.Controls.Add( this.SourceTerminal_SkipButton );
            this.Group_SourceTerminal.Controls.Add( this.label2 );
            this.Group_SourceTerminal.Controls.Add( this.label1 );
            this.Group_SourceTerminal.Controls.Add( this.SourceTerminal_Password );
            this.Group_SourceTerminal.Controls.Add( this.SourceTerminal_Username );
            this.Group_SourceTerminal.Controls.Add( this.SourceTerminal_IPAddress );
            this.Group_SourceTerminal.Location = new System.Drawing.Point( 13, 110 );
            this.Group_SourceTerminal.Name = "Group_SourceTerminal";
            this.Group_SourceTerminal.Size = new System.Drawing.Size( 242, 160 );
            this.Group_SourceTerminal.TabIndex = 1;
            this.Group_SourceTerminal.TabStop = false;
            this.Group_SourceTerminal.Text = "Copy settings from (IP address)";
            this.Group_SourceTerminal.Visible = false;
            // 
            // SourceTerminal_SkipButton
            // 
            this.SourceTerminal_SkipButton.Location = new System.Drawing.Point( 48, 120 );
            this.SourceTerminal_SkipButton.Name = "SourceTerminal_SkipButton";
            this.SourceTerminal_SkipButton.Size = new System.Drawing.Size( 153, 28 );
            this.SourceTerminal_SkipButton.TabIndex = 5;
            this.SourceTerminal_SkipButton.Text = "SKIP";
            this.SourceTerminal_SkipButton.UseVisualStyleBackColor = true;
            this.SourceTerminal_SkipButton.Click += new System.EventHandler( this.SourceTerminal_SkipButton_Click );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 6, 88 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53, 13 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 6, 56 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 55, 13 );
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // SourceTerminal_Password
            // 
            this.SourceTerminal_Password.Font = new System.Drawing.Font( "Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.SourceTerminal_Password.Location = new System.Drawing.Point( 67, 83 );
            this.SourceTerminal_Password.Name = "SourceTerminal_Password";
            this.SourceTerminal_Password.Size = new System.Drawing.Size( 169, 26 );
            this.SourceTerminal_Password.TabIndex = 2;
            // 
            // SourceTerminal_Username
            // 
            this.SourceTerminal_Username.Font = new System.Drawing.Font( "Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.SourceTerminal_Username.Location = new System.Drawing.Point( 67, 51 );
            this.SourceTerminal_Username.Name = "SourceTerminal_Username";
            this.SourceTerminal_Username.Size = new System.Drawing.Size( 169, 26 );
            this.SourceTerminal_Username.TabIndex = 1;
            // 
            // SourceTerminal_IPAddress
            // 
            this.SourceTerminal_IPAddress.Font = new System.Drawing.Font( "Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.SourceTerminal_IPAddress.Location = new System.Drawing.Point( 6, 19 );
            this.SourceTerminal_IPAddress.Name = "SourceTerminal_IPAddress";
            this.SourceTerminal_IPAddress.Size = new System.Drawing.Size( 230, 26 );
            this.SourceTerminal_IPAddress.TabIndex = 0;
            // 
            // Group_DeviceNumber
            // 
            this.Group_DeviceNumber.Controls.Add( this.DeviceNumber_DeviceNumber );
            this.Group_DeviceNumber.Location = new System.Drawing.Point( 13, 276 );
            this.Group_DeviceNumber.Name = "Group_DeviceNumber";
            this.Group_DeviceNumber.Size = new System.Drawing.Size( 242, 56 );
            this.Group_DeviceNumber.TabIndex = 2;
            this.Group_DeviceNumber.TabStop = false;
            this.Group_DeviceNumber.Text = "Device number (from spcwin.ini)";
            this.Group_DeviceNumber.Visible = false;
            // 
            // DeviceNumber_DeviceNumber
            // 
            this.DeviceNumber_DeviceNumber.Font = new System.Drawing.Font( "Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.DeviceNumber_DeviceNumber.Location = new System.Drawing.Point( 29, 19 );
            this.DeviceNumber_DeviceNumber.Name = "DeviceNumber_DeviceNumber";
            this.DeviceNumber_DeviceNumber.Size = new System.Drawing.Size( 47, 26 );
            this.DeviceNumber_DeviceNumber.TabIndex = 5;
            // 
            // LogList
            // 
            this.LogList.FormattingEnabled = true;
            this.LogList.Location = new System.Drawing.Point( 508, 13 );
            this.LogList.Name = "LogList";
            this.LogList.Size = new System.Drawing.Size( 245, 355 );
            this.LogList.TabIndex = 0;
            // 
            // TermConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 764, 522 );
            this.Controls.Add( this.LogList );
            this.Controls.Add( this.Group_DeviceNumber );
            this.Controls.Add( this.Group_SourceTerminal );
            this.Controls.Add( this.Group_TerminalType );
            this.Controls.Add( this.Group_VNC );
            this.Controls.Add( this.KeyboardPanel );
            this.Controls.Add( this.Group_IPAddress );
            this.Name = "TermConfigWindow";
            this.Text = "TermConfig - Custom Business Solutions";
            this.Group_IPAddress.ResumeLayout( false );
            this.Group_IPAddress.PerformLayout();
            this.KeyboardPanel.ResumeLayout( false );
            this.Group_TerminalType.ResumeLayout( false );
            this.Group_TerminalType.PerformLayout();
            this.Group_VNC.ResumeLayout( false );
            this.Group_VNC.PerformLayout();
            this.Group_SourceTerminal.ResumeLayout( false );
            this.Group_SourceTerminal.PerformLayout();
            this.Group_DeviceNumber.ResumeLayout( false );
            this.Group_DeviceNumber.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.GroupBox Group_IPAddress;
        private System.Windows.Forms.Panel KeyboardPanel;
        private System.Windows.Forms.Button kbd_K;
        private System.Windows.Forms.Button kbd_Period;
        private System.Windows.Forms.Button kbd_J;
        private System.Windows.Forms.Button kbd_M;
        private System.Windows.Forms.Button kbd_I;
        private System.Windows.Forms.Button kbd_U;
        private System.Windows.Forms.Button kbd_H;
        private System.Windows.Forms.Button kbd_N;
        private System.Windows.Forms.Button kbd_G;
        private System.Windows.Forms.Button kbd_B;
        private System.Windows.Forms.Button kbd_Y;
        private System.Windows.Forms.Button kbd_T;
        private System.Windows.Forms.Button kbd_F;
        private System.Windows.Forms.Button kbd_V;
        private System.Windows.Forms.Button kbd_D;
        private System.Windows.Forms.Button kbd_C;
        private System.Windows.Forms.Button kbd_R;
        private System.Windows.Forms.Button kbd_E;
        private System.Windows.Forms.Button kbd_S;
        private System.Windows.Forms.Button kbd_X;
        private System.Windows.Forms.Button kbd_A;
        private System.Windows.Forms.Button kbd_Z;
        private System.Windows.Forms.Button kbd_W;
        private System.Windows.Forms.Button kbd_Q;
        private System.Windows.Forms.Button kbd_6;
        private System.Windows.Forms.Button kbd_3;
        private System.Windows.Forms.Button kbd_5;
        private System.Windows.Forms.Button kbd_2;
        private System.Windows.Forms.Button kbd_9;
        private System.Windows.Forms.Button kbd_8;
        private System.Windows.Forms.Button kbd_4;
        private System.Windows.Forms.Button kbd_1;
        private System.Windows.Forms.Button kbd_0;
        private System.Windows.Forms.Button kbd_7;
        private System.Windows.Forms.Button kbd_StartOver;
        private System.Windows.Forms.Button kbd_Enter;
        private System.Windows.Forms.Button kbd_Backspace;
        private System.Windows.Forms.Button kbd_L;
        private System.Windows.Forms.Button kbd_P;
        private System.Windows.Forms.Button kbd_O;
        private System.Windows.Forms.TextBox IPAddress_AddressTextBox;
        private System.Windows.Forms.GroupBox Group_TerminalType;
        private System.Windows.Forms.GroupBox Group_VNC;
        private System.Windows.Forms.GroupBox Group_SourceTerminal;
        private System.Windows.Forms.TextBox SourceTerminal_Username;
        private System.Windows.Forms.TextBox SourceTerminal_IPAddress;
        private System.Windows.Forms.TextBox SourceTerminal_Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton TerminalType_Redundant;
        private System.Windows.Forms.RadioButton TerminalType_Normal;
        private System.Windows.Forms.GroupBox Group_DeviceNumber;
        private System.Windows.Forms.TextBox DeviceNumber_DeviceNumber;
        private System.Windows.Forms.Button kbd_SaveAndReboot;
        private System.Windows.Forms.RadioButton VNC_sliders;
        private System.Windows.Forms.RadioButton VNC_cbsinc;
        private System.Windows.Forms.ListBox LogList;
        private System.Windows.Forms.TextBox VNC_CustomPasswordTextBox;
        private System.Windows.Forms.RadioButton VNC_CustomPassword;
        private System.Windows.Forms.RadioButton TerminalType_Posdriver;
        private System.Windows.Forms.Button SourceTerminal_SkipButton;
        private System.Windows.Forms.Button VNC_SkipButton;
        private System.Windows.Forms.Button kbd_Shift;
        private System.Windows.Forms.Button IPAddress_SkipButton;
    }
}


namespace LaunchPad.Forms
{
    partial class AlohaPreconfiguredConfigWindow
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
            this.UnitListBox = new System.Windows.Forms.ListBox();
            this.TermNumListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IPAddressTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FileserverNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NumberTerminalsTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SubnetMaskTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ServerCapableTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DNS1TextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.MasterCapableTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DefaultGatewayTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.DNS2TextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.WorkgroupTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TermNameTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TimeZoneTextBox = new System.Windows.Forms.TextBox();
            this.SettingsGroup = new System.Windows.Forms.GroupBox();
            this.SettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // UnitListBox
            // 
            this.UnitListBox.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.UnitListBox.FormattingEnabled = true;
            this.UnitListBox.ItemHeight = 20;
            this.UnitListBox.Location = new System.Drawing.Point( 12, 34 );
            this.UnitListBox.Name = "UnitListBox";
            this.UnitListBox.Size = new System.Drawing.Size( 175, 464 );
            this.UnitListBox.TabIndex = 0;
            this.UnitListBox.SelectedValueChanged += new System.EventHandler( this.UnitListBox_SelectedValueChanged );
            // 
            // TermNumListBox
            // 
            this.TermNumListBox.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.TermNumListBox.FormattingEnabled = true;
            this.TermNumListBox.ItemHeight = 20;
            this.TermNumListBox.Location = new System.Drawing.Point( 193, 34 );
            this.TermNumListBox.Name = "TermNumListBox";
            this.TermNumListBox.Size = new System.Drawing.Size( 175, 464 );
            this.TermNumListBox.TabIndex = 1;
            this.TermNumListBox.SelectedValueChanged += new System.EventHandler( this.TermNumListBox_SelectedValueChanged );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label1.Location = new System.Drawing.Point( 12, 11 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 93, 20 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Unit Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label2.Location = new System.Drawing.Point( 193, 11 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 144, 20 );
            this.label2.TabIndex = 3;
            this.label2.Text = "Terminal Number";
            // 
            // IPAddressTextBox
            // 
            this.IPAddressTextBox.Enabled = false;
            this.IPAddressTextBox.Location = new System.Drawing.Point( 22, 157 );
            this.IPAddressTextBox.Name = "IPAddressTextBox";
            this.IPAddressTextBox.Size = new System.Drawing.Size( 165, 26 );
            this.IPAddressTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label3.Location = new System.Drawing.Point( 19, 137 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 86, 17 );
            this.label3.TabIndex = 5;
            this.label3.Text = "IP Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label4.Location = new System.Drawing.Point( 190, 37 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 126, 17 );
            this.label4.TabIndex = 7;
            this.label4.Text = "Fileserver Name";
            // 
            // FileserverNameTextBox
            // 
            this.FileserverNameTextBox.Enabled = false;
            this.FileserverNameTextBox.Location = new System.Drawing.Point( 193, 57 );
            this.FileserverNameTextBox.Name = "FileserverNameTextBox";
            this.FileserverNameTextBox.Size = new System.Drawing.Size( 165, 26 );
            this.FileserverNameTextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label5.Location = new System.Drawing.Point( 190, 86 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 159, 17 );
            this.label5.TabIndex = 11;
            this.label5.Text = "Number of Terminals";
            // 
            // NumberTerminalsTextBox
            // 
            this.NumberTerminalsTextBox.Enabled = false;
            this.NumberTerminalsTextBox.Location = new System.Drawing.Point( 193, 106 );
            this.NumberTerminalsTextBox.Name = "NumberTerminalsTextBox";
            this.NumberTerminalsTextBox.Size = new System.Drawing.Size( 165, 26 );
            this.NumberTerminalsTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label6.Location = new System.Drawing.Point( 19, 186 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 101, 17 );
            this.label6.TabIndex = 9;
            this.label6.Text = "Subnet Mask";
            // 
            // SubnetMaskTextBox
            // 
            this.SubnetMaskTextBox.Enabled = false;
            this.SubnetMaskTextBox.Location = new System.Drawing.Point( 22, 206 );
            this.SubnetMaskTextBox.Name = "SubnetMaskTextBox";
            this.SubnetMaskTextBox.Size = new System.Drawing.Size( 165, 26 );
            this.SubnetMaskTextBox.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label7.Location = new System.Drawing.Point( 190, 186 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 120, 17 );
            this.label7.TabIndex = 19;
            this.label7.Text = "Server Capable";
            // 
            // ServerCapableTextBox
            // 
            this.ServerCapableTextBox.Enabled = false;
            this.ServerCapableTextBox.Location = new System.Drawing.Point( 193, 206 );
            this.ServerCapableTextBox.Name = "ServerCapableTextBox";
            this.ServerCapableTextBox.Size = new System.Drawing.Size( 165, 26 );
            this.ServerCapableTextBox.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label8.Location = new System.Drawing.Point( 19, 286 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 54, 17 );
            this.label8.TabIndex = 17;
            this.label8.Text = "DNS 1";
            // 
            // DNS1TextBox
            // 
            this.DNS1TextBox.Enabled = false;
            this.DNS1TextBox.Location = new System.Drawing.Point( 22, 306 );
            this.DNS1TextBox.Name = "DNS1TextBox";
            this.DNS1TextBox.Size = new System.Drawing.Size( 165, 26 );
            this.DNS1TextBox.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label9.Location = new System.Drawing.Point( 190, 137 );
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size( 121, 17 );
            this.label9.TabIndex = 15;
            this.label9.Text = "Master Capable";
            // 
            // MasterCapableTextBox
            // 
            this.MasterCapableTextBox.Enabled = false;
            this.MasterCapableTextBox.Location = new System.Drawing.Point( 193, 157 );
            this.MasterCapableTextBox.Name = "MasterCapableTextBox";
            this.MasterCapableTextBox.Size = new System.Drawing.Size( 165, 26 );
            this.MasterCapableTextBox.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label10.Location = new System.Drawing.Point( 19, 237 );
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size( 127, 17 );
            this.label10.TabIndex = 13;
            this.label10.Text = "Default Gateway";
            // 
            // DefaultGatewayTextBox
            // 
            this.DefaultGatewayTextBox.Enabled = false;
            this.DefaultGatewayTextBox.Location = new System.Drawing.Point( 22, 257 );
            this.DefaultGatewayTextBox.Name = "DefaultGatewayTextBox";
            this.DefaultGatewayTextBox.Size = new System.Drawing.Size( 165, 26 );
            this.DefaultGatewayTextBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.button1.Location = new System.Drawing.Point( 213, 377 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 136, 59 );
            this.button1.TabIndex = 13;
            this.button1.Text = "Set Manually";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LimeGreen;
            this.button2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.button2.Location = new System.Drawing.Point( 213, 254 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 136, 101 );
            this.button2.TabIndex = 12;
            this.button2.Text = "Apply and Reboot";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label11.Location = new System.Drawing.Point( 19, 337 );
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size( 54, 17 );
            this.label11.TabIndex = 23;
            this.label11.Text = "DNS 2";
            // 
            // DNS2TextBox
            // 
            this.DNS2TextBox.Enabled = false;
            this.DNS2TextBox.Location = new System.Drawing.Point( 22, 357 );
            this.DNS2TextBox.Name = "DNS2TextBox";
            this.DNS2TextBox.Size = new System.Drawing.Size( 165, 26 );
            this.DNS2TextBox.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label12.Location = new System.Drawing.Point( 19, 86 );
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size( 87, 17 );
            this.label12.TabIndex = 27;
            this.label12.Text = "Workgroup";
            // 
            // WorkgroupTextBox
            // 
            this.WorkgroupTextBox.Enabled = false;
            this.WorkgroupTextBox.Location = new System.Drawing.Point( 22, 106 );
            this.WorkgroupTextBox.Name = "WorkgroupTextBox";
            this.WorkgroupTextBox.Size = new System.Drawing.Size( 165, 26 );
            this.WorkgroupTextBox.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label13.Location = new System.Drawing.Point( 19, 37 );
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size( 117, 17 );
            this.label13.TabIndex = 25;
            this.label13.Text = "Terminal Name";
            // 
            // TermNameTextBox
            // 
            this.TermNameTextBox.Enabled = false;
            this.TermNameTextBox.Location = new System.Drawing.Point( 22, 57 );
            this.TermNameTextBox.Name = "TermNameTextBox";
            this.TermNameTextBox.Size = new System.Drawing.Size( 165, 26 );
            this.TermNameTextBox.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label14.Location = new System.Drawing.Point( 19, 386 );
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size( 85, 17 );
            this.label14.TabIndex = 29;
            this.label14.Text = "Time Zone";
            // 
            // TimeZoneTextBox
            // 
            this.TimeZoneTextBox.Enabled = false;
            this.TimeZoneTextBox.Location = new System.Drawing.Point( 22, 406 );
            this.TimeZoneTextBox.Name = "TimeZoneTextBox";
            this.TimeZoneTextBox.Size = new System.Drawing.Size( 165, 26 );
            this.TimeZoneTextBox.TabIndex = 7;
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.Controls.Add( this.label14 );
            this.SettingsGroup.Controls.Add( this.TimeZoneTextBox );
            this.SettingsGroup.Controls.Add( this.label12 );
            this.SettingsGroup.Controls.Add( this.WorkgroupTextBox );
            this.SettingsGroup.Controls.Add( this.label13 );
            this.SettingsGroup.Controls.Add( this.TermNameTextBox );
            this.SettingsGroup.Controls.Add( this.label11 );
            this.SettingsGroup.Controls.Add( this.DNS2TextBox );
            this.SettingsGroup.Controls.Add( this.button2 );
            this.SettingsGroup.Controls.Add( this.button1 );
            this.SettingsGroup.Controls.Add( this.label7 );
            this.SettingsGroup.Controls.Add( this.ServerCapableTextBox );
            this.SettingsGroup.Controls.Add( this.label8 );
            this.SettingsGroup.Controls.Add( this.DNS1TextBox );
            this.SettingsGroup.Controls.Add( this.label9 );
            this.SettingsGroup.Controls.Add( this.MasterCapableTextBox );
            this.SettingsGroup.Controls.Add( this.label10 );
            this.SettingsGroup.Controls.Add( this.DefaultGatewayTextBox );
            this.SettingsGroup.Controls.Add( this.label5 );
            this.SettingsGroup.Controls.Add( this.NumberTerminalsTextBox );
            this.SettingsGroup.Controls.Add( this.label6 );
            this.SettingsGroup.Controls.Add( this.SubnetMaskTextBox );
            this.SettingsGroup.Controls.Add( this.label4 );
            this.SettingsGroup.Controls.Add( this.FileserverNameTextBox );
            this.SettingsGroup.Controls.Add( this.label3 );
            this.SettingsGroup.Controls.Add( this.IPAddressTextBox );
            this.SettingsGroup.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.SettingsGroup.Location = new System.Drawing.Point( 374, 12 );
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.Size = new System.Drawing.Size( 378, 486 );
            this.SettingsGroup.TabIndex = 2;
            this.SettingsGroup.TabStop = false;
            this.SettingsGroup.Text = "Settings";
            this.SettingsGroup.Visible = false;
            // 
            // AlohaPreconfiguredConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 764, 522 );
            this.Controls.Add( this.SettingsGroup );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.TermNumListBox );
            this.Controls.Add( this.UnitListBox );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlohaPreconfiguredConfigWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aloha Terminal Selection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SettingsGroup.ResumeLayout( false );
            this.SettingsGroup.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UnitListBox;
        private System.Windows.Forms.ListBox TermNumListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPAddressTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FileserverNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NumberTerminalsTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SubnetMaskTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ServerCapableTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox DNS1TextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox MasterCapableTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox DefaultGatewayTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox DNS2TextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox WorkgroupTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TermNameTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TimeZoneTextBox;
        private System.Windows.Forms.GroupBox SettingsGroup;
    }
}
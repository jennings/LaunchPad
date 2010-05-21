namespace LaunchPad.Forms
{
    partial class AlohaStartupWindow
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
            this.RCButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VNCServerLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IPAddressLabel = new System.Windows.Forms.Label();
            this.AlohaLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CountdownTimerLabel = new System.Windows.Forms.Label();
            this.CalibrateButton = new System.Windows.Forms.Button();
            this.LaunchNowButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RCButton
            // 
            this.RCButton.BackColor = System.Drawing.Color.IndianRed;
            this.RCButton.Font = new System.Drawing.Font( "Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.RCButton.Location = new System.Drawing.Point( 321, 12 );
            this.RCButton.Name = "RCButton";
            this.RCButton.Size = new System.Drawing.Size( 62, 62 );
            this.RCButton.TabIndex = 0;
            this.RCButton.Text = "RC";
            this.RCButton.UseVisualStyleBackColor = false;
            this.RCButton.Click += new System.EventHandler( this.RCButton_Click );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.VNCServerLabel );
            this.groupBox1.Controls.Add( this.label8 );
            this.groupBox1.Controls.Add( this.label5 );
            this.groupBox1.Controls.Add( this.IPAddressLabel );
            this.groupBox1.Controls.Add( this.AlohaLabel );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Location = new System.Drawing.Point( 12, 80 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 371, 181 );
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // VNCServerLabel
            // 
            this.VNCServerLabel.AutoSize = true;
            this.VNCServerLabel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.VNCServerLabel.Location = new System.Drawing.Point( 142, 129 );
            this.VNCServerLabel.Name = "VNCServerLabel";
            this.VNCServerLabel.Size = new System.Drawing.Size( 18, 20 );
            this.VNCServerLabel.TabIndex = 7;
            this.VNCServerLabel.Text = "?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label8.Location = new System.Drawing.Point( 6, 129 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 45, 20 );
            this.label8.TabIndex = 6;
            this.label8.Text = "VNC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label5.Location = new System.Drawing.Point( 6, 64 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 66, 20 );
            this.label5.TabIndex = 4;
            this.label5.Text = "Ibercfg";
            // 
            // IPAddressLabel
            // 
            this.IPAddressLabel.AutoSize = true;
            this.IPAddressLabel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.IPAddressLabel.Location = new System.Drawing.Point( 142, 33 );
            this.IPAddressLabel.Name = "IPAddressLabel";
            this.IPAddressLabel.Size = new System.Drawing.Size( 18, 20 );
            this.IPAddressLabel.TabIndex = 2;
            this.IPAddressLabel.Text = "?";
            // 
            // AlohaLabel
            // 
            this.AlohaLabel.AutoSize = true;
            this.AlohaLabel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.AlohaLabel.Location = new System.Drawing.Point( 142, 64 );
            this.AlohaLabel.Name = "AlohaLabel";
            this.AlohaLabel.Size = new System.Drawing.Size( 18, 20 );
            this.AlohaLabel.TabIndex = 1;
            this.AlohaLabel.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label1.Location = new System.Drawing.Point( 6, 33 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 97, 20 );
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // CountdownTimerLabel
            // 
            this.CountdownTimerLabel.AutoSize = true;
            this.CountdownTimerLabel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.CountdownTimerLabel.Location = new System.Drawing.Point( 260, 29 );
            this.CountdownTimerLabel.Name = "CountdownTimerLabel";
            this.CountdownTimerLabel.Size = new System.Drawing.Size( 46, 26 );
            this.CountdownTimerLabel.TabIndex = 2;
            this.CountdownTimerLabel.Text = "4...";
            this.CountdownTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CalibrateButton
            // 
            this.CalibrateButton.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 0 ) ) ) ), ( (int)( ( (byte)( 192 ) ) ) ), ( (int)( ( (byte)( 0 ) ) ) ) );
            this.CalibrateButton.Font = new System.Drawing.Font( "Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.CalibrateButton.ForeColor = System.Drawing.Color.Black;
            this.CalibrateButton.Location = new System.Drawing.Point( 12, 12 );
            this.CalibrateButton.Name = "CalibrateButton";
            this.CalibrateButton.Size = new System.Drawing.Size( 128, 62 );
            this.CalibrateButton.TabIndex = 3;
            this.CalibrateButton.Text = "Calibrate";
            this.CalibrateButton.UseVisualStyleBackColor = false;
            this.CalibrateButton.Click += new System.EventHandler( this.CalibrateButton_Click );
            // 
            // LaunchNowButton
            // 
            this.LaunchNowButton.Location = new System.Drawing.Point( 146, 12 );
            this.LaunchNowButton.Name = "LaunchNowButton";
            this.LaunchNowButton.Size = new System.Drawing.Size( 90, 62 );
            this.LaunchNowButton.TabIndex = 4;
            this.LaunchNowButton.Text = "Launch Now";
            this.LaunchNowButton.UseVisualStyleBackColor = true;
            this.LaunchNowButton.Click += new System.EventHandler( this.LaunchNowButton_Click );
            // 
            // AlohaStartupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 395, 270 );
            this.Controls.Add( this.LaunchNowButton );
            this.Controls.Add( this.CalibrateButton );
            this.Controls.Add( this.CountdownTimerLabel );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.RCButton );
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlohaStartupWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launch Pad (Aloha)";
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RCButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label VNCServerLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label IPAddressLabel;
        private System.Windows.Forms.Label AlohaLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CountdownTimerLabel;
        private System.Windows.Forms.Button CalibrateButton;
        private System.Windows.Forms.Button LaunchNowButton;
    }
}
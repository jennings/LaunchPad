namespace TermConfig
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
            this.label5 = new System.Windows.Forms.Label();
            this.IPAddressLabel = new System.Windows.Forms.Label();
            this.AlohaFOHLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CountdownTimerLabel = new System.Windows.Forms.Label();
            this.CalibrateButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RCButton
            // 
            this.RCButton.Location = new System.Drawing.Point( 274, 12 );
            this.RCButton.Name = "RCButton";
            this.RCButton.Size = new System.Drawing.Size( 109, 62 );
            this.RCButton.TabIndex = 0;
            this.RCButton.Text = "RC";
            this.RCButton.UseVisualStyleBackColor = true;
            this.RCButton.Click += new System.EventHandler( this.RCButton_Click );
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.label5 );
            this.groupBox1.Controls.Add( this.IPAddressLabel );
            this.groupBox1.Controls.Add( this.AlohaFOHLabel );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Location = new System.Drawing.Point( 12, 80 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 371, 181 );
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label5.Location = new System.Drawing.Point( 6, 64 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 77, 20 );
            this.label5.TabIndex = 4;
            this.label5.Text = "Terminal";
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
            // AlohaFOHLabel
            // 
            this.AlohaFOHLabel.AutoSize = true;
            this.AlohaFOHLabel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.AlohaFOHLabel.Location = new System.Drawing.Point( 142, 64 );
            this.AlohaFOHLabel.Name = "AlohaFOHLabel";
            this.AlohaFOHLabel.Size = new System.Drawing.Size( 18, 20 );
            this.AlohaFOHLabel.TabIndex = 1;
            this.AlohaFOHLabel.Text = "?";
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
            this.CountdownTimerLabel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.CountdownTimerLabel.Location = new System.Drawing.Point( 216, 32 );
            this.CountdownTimerLabel.Name = "CountdownTimerLabel";
            this.CountdownTimerLabel.Size = new System.Drawing.Size( 34, 20 );
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
            this.CalibrateButton.TabIndex = 4;
            this.CalibrateButton.Text = "Calibrate";
            this.CalibrateButton.UseVisualStyleBackColor = false;
            this.CalibrateButton.Click += new System.EventHandler( this.CalibrateButton_Click );
            // 
            // AlohaStartupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 395, 270 );
            this.Controls.Add( this.CalibrateButton );
            this.Controls.Add( this.CountdownTimerLabel );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.RCButton );
            this.MinimizeBox = false;
            this.Name = "AlohaStartupWindow";
            this.Text = "CBS Terminal Config (Aloha)";
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RCButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label IPAddressLabel;
        private System.Windows.Forms.Label AlohaFOHLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CountdownTimerLabel;
        private System.Windows.Forms.Button CalibrateButton;
    }
}
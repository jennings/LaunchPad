using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TermConfig.Launchers;

namespace TermConfig
{
    public abstract class StartupWindow : Form
    {
        protected int SecondsBeforeClose;
        protected Timer DelayTimer;
        protected List<ILauncher> LaunchList;

        protected void CountdownTick( object sender, EventArgs e )
        {
            if ( SecondsBeforeClose > 0 )
            {
                SecondsBeforeClose--;
            }
            else
            {
                DelayTimer.Stop();

                foreach ( var launcher in LaunchList )
                {
                    try
                    {
                        launcher.Launch();
                    }
                    catch ( NotImplementedException )
                    {
                        MessageBox.Show( "Launcher not implemented: " + launcher.GetType().ToString() );
                    }
                    catch ( Exception ex )
                    {
                        MessageBox.Show( "Exception: " + launcher.GetType().ToString() + ": " + ex.Message );
                    }
                }

                Application.Exit();
            }
        }
    }
}

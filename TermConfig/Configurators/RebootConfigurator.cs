﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace TermConfig.Configurators
{
    class RebootConfigurator : IConfigurator
    {
        public void Configure()
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass( "Win32_OperatingSystem" );
            mcWin32.Get();

            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams = mcWin32.GetMethodParameters( "Win32Shutdown" );

            mboShutdownParams["Flags"] = "6";
            mboShutdownParams["Reserved"] = "0";

            foreach ( ManagementObject obj in mcWin32.GetInstances() )
            {
                mboShutdown = obj.InvokeMethod( "Win32Shutdown", mboShutdownParams, null );
            }
        }
    }
}
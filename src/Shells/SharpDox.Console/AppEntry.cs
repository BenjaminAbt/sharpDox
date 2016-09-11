using System;
using System.Diagnostics;
using Autofac;
using SharpDox.Core;

namespace SharpDox.Console
{
    public static class AppEntry
    {
        [STAThread]
        public static int Main(string[] args)
        {
            var exitCode = -1;
            try
            {
                var mainContainerConfig = new MainContainerConfig();
                mainContainerConfig.RegisterAsSelf<SDConsole>();
                var mainContainer = mainContainerConfig.BuildContainer();

                exitCode = mainContainer.Resolve<SDConsole>().Start(args);
            }
            catch(Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return exitCode;
        }
    }
}

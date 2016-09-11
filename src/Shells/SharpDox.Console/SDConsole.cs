using System;
using System.Collections.Generic;
using System.Linq;
using SharpDox.Build;
using SharpDox.Sdk.Config;
using static System.String;

namespace SharpDox.Console
{
    public class SDConsole
    {
        private readonly Func<BuildController> _builderFactory;
        private readonly IConfigController _configController;
        private readonly BuildMessenger _buildMessenger;

        public SDConsole(IConfigController configController, BuildMessenger buildMessenger, Func<BuildController> builderFactory)
        {
            _buildMessenger = buildMessenger;
            _configController = configController;
            _builderFactory = builderFactory;
        }

        public int Start(string[] commandLineArgs)
        {
            int exitCode;

            SDoxConsoleCommandLineOptions options = new SDoxConsoleCommandLineOptions();
            if(CommandLine.Parser.Default.ParseArguments(commandLineArgs, options))
            {
                // prio 1: config, ignores all other arguments
                if (!string.IsNullOrWhiteSpace(options.ConfgFilename))
                {
                    _configController.Load(options.ConfgFilename);
                    _buildMessenger.OnBuildMessage += System.Console.WriteLine;
                    _builderFactory().StartBuild(_configController.GetConfigSection<ICoreConfigSection>(), false);

                    exitCode = 0;
                }
                else
                {
                    _configController.Load(options.ConfgFilename);
                    _buildMessenger.OnBuildMessage += System.Console.WriteLine;
                    _builderFactory().StartBuild(_configController.GetConfigSection<ICoreConfigSection>(), false);
                }
            }

            exitCode = 0;


#if DEBUG
            System.Console.WriteLine("Done. Press enter to exit debug.");
            System.Console.ReadLine();
#endif

            return exitCode;
        }

        public bool IsGui => false;
    }
}

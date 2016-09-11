using System;
using SharpDox.Build;
using SharpDox.Sdk.Config;

namespace SharpDox.Console
{
    public class SDConsole
    {
        private readonly Func<BuildController> _builderFactory;
        private readonly IConfigController _configController;

        private readonly BuildMessenger _buildMessenger;
        private readonly SDConsoleStrings _strings;

        public SDConsole(SDConsoleStrings strings, IConfigController configController, BuildMessenger buildMessenger, Func<BuildController> builderFactory)
        {
            _strings = strings;
            _buildMessenger = buildMessenger;
            _configController = configController;
            _builderFactory = builderFactory;
        }

        public int Start(string[] args)
        {
            ConsoleArguments arguments = new ConsoleArguments(args);

            if(arguments["config"] == null)
            {
                System.Console.WriteLine(_strings.ConfigMissing + " -config " + _strings.Path);
                return -1;
            }

            BuildController buildController = _builderFactory();

            _configController.Load(arguments["config"]);

            _buildMessenger.OnBuildMessage += System.Console.WriteLine;

            buildController.StartBuild(_configController.GetConfigSection<ICoreConfigSection>(), false);

#if DEBUG
            System.Console.WriteLine(_strings.PressToEnd);
            System.Console.ReadLine();
#endif

            return 0;
        }

        public bool IsGui => false;
    }
}

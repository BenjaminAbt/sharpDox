using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using CommandLine;
using CommandLine.Text;

namespace SharpDox.Console
{
    public class SDoxConsoleCommandLineOptions
    {
        [Option("config", Required = true, HelpText = "Path to your config file..", MutuallyExclusiveSet = "configFile")]
        public string ConfgFilename { get; set; }

        [Option("Author", Required = false, HelpText = "Name of the author", MutuallyExclusiveSet = "commandLine")]
        public string Author { get; set; }

        [Option("AuthorUrl", Required = false, HelpText = "Url to the author", MutuallyExclusiveSet = "commandLine")]
        public string AuthorUrl { get; set; }

        [Option("ProjectName", Required = true, HelpText = "Name of the project", MutuallyExclusiveSet = "commandLine")]
        public string ProjectName { get; set; }

        [Option("ProjectUrl", Required = false, HelpText = "Url to the project", MutuallyExclusiveSet = "commandLine")]
        public string ProjectUrl { get; set; }

        [Option("LogoFilename", Required = false, HelpText = "Filename of the logo to embed into docs", MutuallyExclusiveSet = "commandLine")]
        public string LogoFilename { get; set; }

        [Option("DocLanguage", Required = true, HelpText = "Path to the output folder", MutuallyExclusiveSet = "commandLine")]
        public string OutputPath { get; set; }

        [Option("InputFile", Required = true, HelpText = "Path to solution or project", MutuallyExclusiveSet = "commandLine")]
        public string InputFile { get; set; }

        [Option("docLanguage", Required = false, HelpText = "Language of the documentation", MutuallyExclusiveSet = "commandLine")]
        public string DocLanguage { get; set; }

        [Option("Version", Required = false, HelpText = "Version", MutuallyExclusiveSet = "commandLine")]
        public string Version { get; set; }

        [Option("ExcludePrivate", Required = false, HelpText = "whether all private members are excluded", MutuallyExclusiveSet = "commandLine")]
        public bool ExcludePrivate { get; set; }

        [Option("ExcludeProtected", Required = false, HelpText = "whether all protected members are excluded.", MutuallyExclusiveSet = "commandLine")]
        public bool ExcludeProtected { get; set; }

        [Option("ExcludeInternal", Required = false, HelpText = "whether all internal members are excluded", MutuallyExclusiveSet = "commandLine")]
        public bool ExcludeInternal { get; set; }

        [Option("ExcludedIdentifiers", Required = false, HelpText = "all exluded identifiers", MutuallyExclusiveSet = "commandLine")]
        public IEnumerable<string> ExcludedIdentifiers { get; set; }

        [Option("ActivatedExporters", Required = false, HelpText = "all activated exporters", MutuallyExclusiveSet = "commandLine")]
        public IEnumerable<string> ActivatedExporters { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText();
            {
                help.AddDashesToOption = true;
                help.Heading = "SharpDox CommandLine";
            }
            help.AddPreOptionsLine("Usage of command line with all options.");
            help.AddOptions(this);
            return help;
        }
    }

}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDox.Sdk;
using SharpDox.Sdk.Config;

namespace SharpDox.Console
{
    internal class ConsoleConfig : ICoreConfigSection
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Guid Guid { get; }
        public bool IsSaved { get; set; }
        public string Author { get; set; }
        public string AuthorUrl { get; set; }
        public string ProjectUrl { get; set; }
        public string ConfigFileName { get; set; }
        public SDPath InputFile { get; set; }
        public SDPath LogoPath { get; set; }
        public SDPath OutputPath { get; set; }
        public string DocLanguage { get; set; }
        public string ProjectName { get; set; }
        public string VersionNumber { get; set; }
        public bool ExcludePrivate { get; set; }
        public bool ExcludeProtected { get; set; }
        public bool ExcludeInternal { get; set; }
        public ObservableCollection<string> ExcludedIdentifiers { get; set; }
        public ObservableCollection<string> ActivatedExporters { get; set; }
    }
}

using SharpDox.Sdk.Config;
using SharpDox.Sdk.Config.Attributes;

namespace SharpDox.Core.Config
{
    [Name(typeof(CoreStrings), "ConfigTitle")]
    public class SaveableConfigSection : CoreConfigSection, ISaveableConfig
    {
        public SaveableConfigSection(CoreStrings strings)
        {
            _strings = strings;
        }

        private bool _isSaved;
        private string _configFileName;
        private readonly CoreStrings _strings;

        public bool IsSaved
        {
            get { return _isSaved; }
            set
            {
                if(_isSaved != value)
                {
                    _isSaved = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ConfigFileName
        {
            get { return string.IsNullOrEmpty(_configFileName) ? _strings.NewConfig : _configFileName; }
            set
            {
                if(_configFileName != value)
                {
                    _configFileName = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
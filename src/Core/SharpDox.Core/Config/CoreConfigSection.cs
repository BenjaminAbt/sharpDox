using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SharpDox.Sdk;
using SharpDox.Sdk.Config;
using SharpDox.Sdk.Config.Attributes;

namespace SharpDox.Core.Config
{
    [Name(typeof (CoreStrings), "ConfigTitle")]
    public class CoreConfigSection : ICoreConfigSection
    {
        private string _author;
        private SDPath _inputFile;
        private SDPath _outputPath;
        private SDPath _logoPath;
        private string _projectUrl;
        private string _authorUrl;
        private string _docLanguage;
        private string _projectName;
        private string _versionNumber;
        private bool _excludePrivate;
        private bool _excludeProtected;
        private bool _excludeInternal;
        private ObservableCollection<string> _excludedIdentifiers;
        private ObservableCollection<string> _activatedExporters;
       
        [Required]
        [Name(typeof(CoreStrings), nameof(ProjectName))]
        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                if (_projectName != value)
                {
                    _projectName = value;
                    OnPropertyChanged();
                }
            }
        }

        [Name(typeof(CoreStrings), nameof(ProjectUrl))]
        public string ProjectUrl
        {
            get { return _projectUrl; }
            set
            {
                if (_projectUrl != value)
                {
                    _projectUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        [Name(typeof(CoreStrings), nameof(Author))]
        public string Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    OnPropertyChanged();
                }
            }
        }

        [Name(typeof(CoreStrings), nameof(AuthorUrl))]
        public string AuthorUrl
        {
            get { return _authorUrl; }
            set
            {
                if (_authorUrl != value)
                {
                    _authorUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        [Name(typeof(CoreStrings), nameof(VersionNumber))]
        public string VersionNumber
        {
            get { return _versionNumber; }
            set
            {
                if (_versionNumber != value)
                {
                    _versionNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        [ConfigEditor(EditorType.Filepicker, "Image File(.png; .jpg; .bmp)|*.png; *.jpg; *.bmp")]
        [Name(typeof(CoreStrings), nameof(LogoPath))]
        public SDPath LogoPath
        {
            get { return _logoPath; }
            set
            {
                if (_logoPath != value)
                {
                    _logoPath = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        [ConfigEditor(EditorType.Filepicker, "Solution/ Project/ sharpDox Navigation (*.sln; *.csproj; *.sdnav)|*.sln; *.csproj; *.sdnav")]
        [Name(typeof(CoreStrings), nameof(InputFile))]
        public SDPath InputFile
        {
            get { return _inputFile; }
            set
            {
                if (_inputFile != value)
                {
                    _inputFile = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        [ConfigEditor(EditorType.Folderpicker)]
        [Name(typeof(CoreStrings), nameof(OutputPath))]
        public SDPath OutputPath
        {
            get { return _outputPath; }
            set
            {
                if (_outputPath != value)
                {
                    _outputPath = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        [ConfigEditor(EditorType.ComboBox, typeof(LanguageList))]
        [Name(typeof(CoreStrings), nameof(DocLanguage))]
        public string DocLanguage
        {
            get { return string.IsNullOrEmpty(_docLanguage) ? "en" : _docLanguage; }
            set
            {
                if (_docLanguage != value)
                {
                    _docLanguage = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ExcludePrivate
        {
            get { return _excludePrivate; }
            set
            {
                if (_excludePrivate != value)
                {
                    _excludePrivate = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ExcludeProtected
        {
            get { return _excludeProtected; }
            set
            {
                if (_excludeProtected != value)
                {
                    _excludeProtected = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ExcludeInternal
        {
            get { return _excludeInternal; }
            set
            {
                if (_excludeInternal != value)
                {
                    _excludeInternal = value;
                    OnPropertyChanged();
                }
            }
        }

        [Name(typeof(CoreStrings), nameof(ExcludedIdentifiers))]
        public ObservableCollection<string> ExcludedIdentifiers
        {
            get { return _excludedIdentifiers ?? (_excludedIdentifiers = new ObservableCollection<string>()); }
            set
            {
                _excludedIdentifiers = value;
                if (_excludedIdentifiers != null)
                    _excludedIdentifiers.CollectionChanged += (s, a) => OnPropertyChanged();
                OnPropertyChanged();
            }
        }

        [ConfigEditor(EditorType.CheckBoxList)]
        [Name(typeof(CoreStrings), nameof(ActivatedExporters))]
        public ObservableCollection<string> ActivatedExporters
        {
            get { return _activatedExporters ?? (_activatedExporters = new ObservableCollection<string>()); }
            set
            {
                _activatedExporters = value;
                if (_activatedExporters != null)
                    _activatedExporters.CollectionChanged += (s, a) => OnPropertyChanged();
                OnPropertyChanged();
            }
        }

        public Guid Guid
        {
            get { return new Guid("FEACBCE2-8290-4D90-BB05-373B9D7DBBFC"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
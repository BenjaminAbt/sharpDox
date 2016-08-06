﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SharpDox.Sdk;
using SharpDox.Sdk.Config;
using SharpDox.Sdk.Config.Attributes;

namespace SharpDox.Core.Config
{
    [Name(typeof (CoreStrings), "ConfigTitle")]
    public class CoreConfigSection : ICoreConfigSection
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isSaved;
        private string _author;
        private string _configFileName;
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

        private readonly CoreStrings _strings;

        public CoreConfigSection(CoreStrings strings)
        {
            _strings = strings;
        }

        public bool IsSaved
        {
            get { return _isSaved; }
            set
            {
                if (_isSaved != value)
                {
                    _isSaved = value;
                    OnPropertyChanged("IsSaved");
                }
            }
        }

        public string ConfigFileName
        {
            get { return string.IsNullOrEmpty(_configFileName) ? _strings.NewConfig : _configFileName; }
            set
            {
                if (_configFileName != value)
                {
                    _configFileName = value;
                    OnPropertyChanged("ConfigFileName");
                }
            }
        }

        [Required]
        [Name(typeof(CoreStrings), "ProjectName")]
        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                if (_projectName != value)
                {
                    _projectName = value;
                    OnPropertyChanged("ProjectName");
                }
            }
        }

        [Name(typeof(CoreStrings), "ProjectUrl")]
        public string ProjectUrl
        {
            get { return _projectUrl; }
            set
            {
                if (_projectUrl != value)
                {
                    _projectUrl = value;
                    OnPropertyChanged("ProjectUrl");
                }
            }
        }

        [Name(typeof(CoreStrings), "Author")]
        public string Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    OnPropertyChanged("Author");
                }
            }
        }

        [Name(typeof(CoreStrings), "AuthorUrl")]
        public string AuthorUrl
        {
            get { return _authorUrl; }
            set
            {
                if (_authorUrl != value)
                {
                    _authorUrl = value;
                    OnPropertyChanged("AuthorUrl");
                }
            }
        }

        [Name(typeof(CoreStrings), "VersionNumber")]
        public string VersionNumber
        {
            get { return _versionNumber; }
            set
            {
                if (_versionNumber != value)
                {
                    _versionNumber = value;
                    OnPropertyChanged("VersionNumber");
                }
            }
        }

        [ConfigEditor(EditorType.Filepicker, "Image File(.png; .jpg; .bmp)|*.png; *.jpg; *.bmp")]
        [Name(typeof(CoreStrings), "LogoPath")]
        public SDPath LogoPath
        {
            get { return _logoPath; }
            set
            {
                if (_logoPath != value)
                {
                    _logoPath = value;
                    OnPropertyChanged("LogoPath");
                }
            }
        }

        [Required]
        [ConfigEditor(EditorType.Filepicker, "Solution/ Project/ sharpDox Navigation (*.sln; *.csproj; *.sdnav)|*.sln; *.csproj; *.sdnav")]
        [Name(typeof(CoreStrings), "InputFile")]
        public SDPath InputFile
        {
            get { return _inputFile; }
            set
            {
                if (_inputFile != value)
                {
                    _inputFile = value;
                    OnPropertyChanged("InputFile");
                }
            }
        }

        [Required]
        [ConfigEditor(EditorType.Folderpicker)]
        [Name(typeof(CoreStrings), "OutputPath")]
        public SDPath OutputPath
        {
            get { return _outputPath; }
            set
            {
                if (_outputPath != value)
                {
                    _outputPath = value;
                    OnPropertyChanged("OutputPath");
                }
            }
        }

        [Required]
        [ConfigEditor(EditorType.ComboBox, typeof(LanguageList))]
        [Name(typeof(CoreStrings), "DocLanguage")]
        public string DocLanguage
        {
            get { return string.IsNullOrEmpty(_docLanguage) ? "en" : _docLanguage; }
            set
            {
                if (_docLanguage != value)
                {
                    _docLanguage = value;
                    OnPropertyChanged("DocLanguage");
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
                    OnPropertyChanged("ExcludePrivate");
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
                    OnPropertyChanged("ExcludeProtected");
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
                    OnPropertyChanged("ExcludeInternal");
                }
            }
        }

        [Name(typeof(CoreStrings), "ExcludedIdentifiers")]
        public ObservableCollection<string> ExcludedIdentifiers
        {
            get { return _excludedIdentifiers ?? (_excludedIdentifiers = new ObservableCollection<string>()); }
            set
            {
                _excludedIdentifiers = value;
                if (_excludedIdentifiers != null)
                    _excludedIdentifiers.CollectionChanged += (s, a) => OnPropertyChanged("ExcludedIdentifiers");
                OnPropertyChanged("ExcludedIdentifiers");
            }
        }

        [ConfigEditor(EditorType.CheckBoxList)]
        [Name(typeof(CoreStrings), "Exporters")]
        public ObservableCollection<string> ActivatedExporters
        {
            get { return _activatedExporters ?? (_activatedExporters = new ObservableCollection<string>()); }
            set
            {
                _activatedExporters = value;
                if (_activatedExporters != null)
                    _activatedExporters.CollectionChanged += (s, a) => OnPropertyChanged("ActivatedExporters");
                OnPropertyChanged("ActivatedExporters");
            }
        }

        public Guid Guid
        {
            get { return new Guid("FEACBCE2-8290-4D90-BB05-373B9D7DBBFC"); }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
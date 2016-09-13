﻿using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SharpDox.Sdk.Config
{
    /// <default>
    ///     <summary>
    ///     All core configuration items of sharpDox.
    ///     </summary>
    /// </default>
    /// <de>
    ///     <summary>
    ///     Alle Basis-Einstellungen für sharpDox.
    ///     </summary>
    /// </de>
    public interface ICoreConfigSection : IConfigSection, INotifyPropertyChanged
    {
        /// <default>
        ///     <summary>
        ///     Returns the author.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert den Autoren.
        ///     </summary>
        /// </de>
        string Author { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns the author homepage.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert die Autoren Homepage.
        ///     </summary>
        /// </de>
        string AuthorUrl { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns the project homepage.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert die Projekt Homepage.
        ///     </summary>
        /// </de>
        string ProjectUrl { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns the input path.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert den Eingabepfad.
        ///     </summary>
        /// </de>
        SDPath InputFile { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns the path to the logo.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert den Pfad zum Logo.
        ///     </summary>
        /// </de>
        SDPath LogoPath { get; set; }

        /// <default>
        ///     <summary>
        ///     Return the output path.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert den Ausgabepfad.
        ///     </summary>
        /// </de>
        SDPath OutputPath { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns the default documentation language.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert die standard Dokumentationssprache.
        ///     </summary>
        /// </de>
        string DocLanguage { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns the project name.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert den Namen des Projekts.
        ///     </summary>
        /// </de>
        string ProjectName { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns the version number.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert die Versionsnummer.
        ///     </summary>
        /// </de>
        string VersionNumber { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns whether all private members are excluded.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert einen Wert der angibt, ob alle 'private' Mitglieder ausgeschlossen sind.
        ///     </summary>
        /// </de>
        bool ExcludePrivate { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns whether all protected members are excluded.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert einen Wert der angibt, ob alle 'protected' Mitglieder ausgeschlossen sind.
        ///     </summary>
        /// </de>
        bool ExcludeProtected { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns whether all internal members are excluded.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert einen Wert der angibt, ob alle 'internal' Mitglieder ausgeschlossen sind.
        ///     </summary>
        /// </de>
        bool ExcludeInternal { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns all exluded identifiers.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert alle ausgeschlossenen Identifiers.
        ///     </summary>
        /// </de>
        ObservableCollection<string> ExcludedIdentifiers { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns all activated exporters.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert alle aktivierten Exporter.
        ///     </summary>
        /// </de>
        ObservableCollection<string> ActivatedExporters { get; set; }
    }
}
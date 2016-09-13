using System.ComponentModel;

namespace SharpDox.Sdk.Config
{
    public interface ISaveableConfig : ICoreConfigSection
    {
        /// <default>
        ///     <summary>
        ///     Returns whether the actual configuration is saved or not.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert einen Wert der angibt, ob die Konfiguration gespeichert ist.
        ///     </summary>
        /// </de>
        bool IsSaved { get; set; }

        /// <default>
        ///     <summary>
        ///     Returns the name of the configuration file.
        ///     </summary>
        /// </default>
        /// <de>
        ///     <summary>
        ///     Liefert den Namen der Konfigurationsdatei.
        ///     </summary>
        /// </de>
        string ConfigFileName { get; set; }

    }
}

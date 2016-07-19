﻿//------------------------------------------------------------------------------
// <copyright file="SharpDoxConfigWindow.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace SharpDox.Vsix.Tools
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("2e1b0fd5-6823-4edb-93c9-f6365e8c3078")]
    public class ConfigWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigWindow"/> class.
        /// </summary>
        public ConfigWindow() : base(null)
        {
            this.Caption = "SharpDoxConfigWindow";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new ConfigWindowControl();
        }
    }
}

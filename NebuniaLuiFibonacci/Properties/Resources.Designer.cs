﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NebuniaLuiFibonacci.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NebuniaLuiFibonacci.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot start a Worker that has been previously started.
        /// </summary>
        internal static string Exception_GenericStartWorkerError {
            get {
                return ResourceManager.GetString("Exception_GenericStartWorkerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot re-start a finished Worker.
        /// </summary>
        internal static string Exception_StartFinishedWorker {
            get {
                return ResourceManager.GetString("Exception_StartFinishedWorker", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot stop Worker that is not currently running.
        /// </summary>
        internal static string Exception_StopWorkerError {
            get {
                return ResourceManager.GetString("Exception_StopWorkerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 3000.
        /// </summary>
        internal static string TaskDelay {
            get {
                return ResourceManager.GetString("TaskDelay", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 2000.
        /// </summary>
        internal static string ThreadDelay {
            get {
                return ResourceManager.GetString("ThreadDelay", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 500.
        /// </summary>
        internal static string Tick {
            get {
                return ResourceManager.GetString("Tick", resourceCulture);
            }
        }
    }
}

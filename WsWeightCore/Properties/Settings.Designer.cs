﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeightCore.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("WeightCore")]
        public string AppNameWeightCore {
            get {
                return ((string)(this["AppNameWeightCore"]));
            }
            set {
                this["AppNameWeightCore"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Software\\VladimirStandardCorp")]
        public string RegVladimirStandardCorp {
            get {
                return ((string)(this["RegVladimirStandardCorp"]));
            }
            set {
                this["RegVladimirStandardCorp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Software\\VladimirStandardCorp\\ScalesUI")]
        public string RegScalesUI {
            get {
                return ((string)(this["RegScalesUI"]));
            }
            set {
                this["RegScalesUI"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Software\\VladimirStandardCorp\\ScalesUI\\SQL")]
        public string RegScalesUISql {
            get {
                return ((string)(this["RegScalesUISql"]));
            }
            set {
                this["RegScalesUISql"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%ProgramFiles%\\VladimirStandardCorp\\ScalesUI\\")]
        public string DirOut {
            get {
                return ((string)(this["DirOut"]));
            }
            set {
                this["DirOut"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("7B832E43-BAA4-11EA-BC3C-AC1F6B02AD52")]
        public string Guid {
            get {
                return ((string)(this["Guid"]));
            }
            set {
                this["Guid"] = value;
            }
        }
    }
}
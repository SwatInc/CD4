﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CD4.ExcelInterface.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"{""MainFormTitle"":""CD4 Interface"",""AnalyserName"":""PCR1"",""ExcelFileDirectory"":""C:\\Logs\\"",""ExportPath"":""C:\\Export\\"",""DataExtension"":""json"",""ControlFileExtension"":""ok"",""LisExportExtension"":""*.xls"",""BatchId"":{""Row"":0,""Column"":0},""DataRange"":{""StartRow"":4,""EndRow"":47},""SidColumn"":2,""SamplePositionColumn"":1,""ExcludeRows"":[2],""PositiveControlSID"":"""",""NegativeControlSID"":"""",""Measurements"":[{""TestCodeColumn"":3,""MeasurementValueColumn"":4,""Unit"":""""},{""TestCodeColumn"":6,""MeasurementValueColumn"":7,""Unit"":""""},{""TestCodeColumn"":9,""MeasurementValueColumn"":10,""Unit"":""""},{""TestCodeColumn"":12,""MeasurementValueColumn"":13,""Unit"":""""}]}")]
        public string Config {
            get {
                return ((string)(this["Config"]));
            }
            set {
                this["Config"] = value;
            }
        }
    }
}
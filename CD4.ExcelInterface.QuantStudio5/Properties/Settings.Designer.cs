﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CD4.ExcelInterface.QuantStudio5.Properties {
    
    
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
        [global::System.Configuration.DefaultSettingValueAttribute(@"{""MainFormTitle"":""CD4 Interface (QuantStudio5)"",""AnalyserName"":""QuantStudio5-01"",""ExcelFileDirectory"":""C:\\Logs\\"",""ExportPath"":""C:\\Export\\"",""DataExtension"":""json"",""ControlFileExtension"":""ok"",""LisExportExtension"":""*.xlsx"",""FileReadMaxTries"":10,""FileReadDelay"":5000,""BatchId"":{""ScanColumnIndex"":0,""DataColumnIndex"":1,""CsvKeyWords"":""Experiment File Name, Experiment Name""},""DataRange"":{""AutoDetectStartRow"":{""Active"":true,""Keyword"":""Well"",""ColumnIndex"":0},""StartRow"":45,""EndRow"":110},""SidColumn"":3,""SamplePositionColumn"":1,""ExcludeRows"":[2],""PositiveControlSID"":"""",""NegativeControlSID"":"""",""Measurements"":[{""TestCodeColumn"":4,""MeasurementValueColumn"":8,""Unit"":""""}]}")]
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

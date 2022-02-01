using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Vmmaker.ViewModel
{
    internal class MainModel : ObservableObject
    {
        public RelayCommand copyCommand { get; }
        public RelayCommand genCommand { get; }
        public RelayCommand setConfCommand { get; }
        public RelayCommand setVmCommand { get; }

        private string _copyText;
        public string CopyText { 
            get
            {
                return _copyText;
            }
            set
            {
                
                SetProperty(ref _copyText, value);
            }
        }
        private string _vmPath;
        public string vmPath
        {
            get
            {
                return _vmPath;
            }
            set {   SetProperty(ref _vmPath, value); }
        }
        private string _configPath;
        public string ConfigPath
        {
            get { return _configPath; }
            set {  SetProperty(ref _configPath, value); }
        }
        public MainModel()
        {
            vmPath = @"D:\ja-netfilter";
            ConfigPath = @"D:\configuration";
            CopyText = "dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained false";
            copyCommand = new RelayCommand(copyTxt);
            setConfCommand = new RelayCommand(selectConf_Click);
            genCommand = new RelayCommand(vm_Click);
            setVmCommand = new RelayCommand(selectPath_Click);
         }
        public void copyTxt()
        { //clear before copy
            Clipboard.Clear();
            Clipboard.SetText(CopyText);
            MessageBox.Show("已复制");
        }

        private string[] vmList ={"idea", "clion", "phpstorm", "goland", "pycharm", "webstorm", "webide", "rider", "datagrip", "rubymine",
            "appcode", "dataspell", "gateway", "jetbrains_client", "jetbrainsclient" };
        public string vmOptionPath { get; set; } = "vmoptions";
       public void vm_Click( )
        {
            CopyText = "hhhhh";
            if (!File.Exists(vmPath+ @"\vmoptions"))
            {
                Directory.CreateDirectory(vmPath + @"\vmoptions");
            }
            foreach (string vm in vmList)
            {
                File.WriteAllText($@"{vmPath }\vmoptions\{vm}.vmoption", vmsText(ConfigPath , vm), Encoding.UTF8);
            }
            writeEnv();
            MessageBox.Show($"在{vmPath}创建成功");

        }
        public void cleanEnv()
        {
            foreach (var item in vmList)
            {
                Settings.Remove(item.ToUpper() + "_VM_OPTIONS");
            }

        }

        public void writeEnv()
        {
            foreach (var item in vmList)
            {
                Settings.Set(item.ToUpper() + "_VM_OPTIONS", $@"{vmPath}\vmoptions\{item}.vmoption", RegistryValueKind.ExpandString);
            }

        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        public void cleanVms(string path)
        {
            Directory.Delete(vmPath);
            MessageBox.Show("删除成功");
        }
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path"></param>
        public string vmsText(string confPath, string app)
        {
            string defaultText = @"-Xms128m
-Xmx1024m
-XX:ReservedCodeCacheSize=512m
-XX:+IgnoreUnrecognizedVMOptions
-XX:+UseG1GC
-XX:SoftRefLRUPolicyMSPerMB=50
-XX:CICompilerCount=2
-XX:+HeapDumpOnOutOfMemoryError
-XX:-OmitStackTraceInFastThrow
-ea
-Dsun.io.useCanonCaches=false
-Djdk.http.auth.tunneling.disabledSchemes=""
-Djdk.attach.allowAttachSelf=true
-Djdk.module.illegalAccess.silent=true
-Dkotlinx.coroutines.debug=off
-XX:ErrorFile=$USER_HOME/java_error_in_idea_%p.log
-XX:HeapDumpPath=$USER_HOME/java_error_in_idea.hprof
";
            string split_txt = "#divide\n";
            string conf = $@"-Didea.config.path={confPath}\{app}Conf\\config
-Didea.system.path={confPath}\{app}Conf\\system
-Didea.log.path={confPath}\{app}Conf\\system\\log;
-javaagent:D:\ja-netfilter\ja-netfilter.jar=jetbrains";
            return defaultText + split_txt + conf;
        }
        public void selectPath_Click( )
        {
            var dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Please select a folder.";
            dialog.UseDescriptionForTitle = true; // This applies to the Vista style dialog only, not the old dialog.

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
            {
                MessageBox.Show(  "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            }

            if ((bool)dialog.ShowDialog( ))
            {

                MessageBox.Show(  $"The selected folder was:{Environment.NewLine}{dialog.SelectedPath}", "Sample folder browser dialog");
                vmPath  = dialog.SelectedPath;
            }
        }

        public void selectConf_Click( )
        {
            var dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Please select a folder.";
            dialog.UseDescriptionForTitle = true; // This applies to the Vista style dialog only, not the old dialog.

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
            {
                MessageBox.Show( "Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            }

            if ((bool)dialog.ShowDialog( ))
            {

                ConfigPath  = dialog.SelectedPath;
                string a = "aaa";
                MessageBox.Show($"The selected folder was:{Environment.NewLine}{ConfigPath}", "Sample folder browser dialog");
            }
        }
    }
}

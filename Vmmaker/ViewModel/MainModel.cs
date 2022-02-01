using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vmmaker.Utils;
namespace Vmmaker.ViewModel
{
    internal class MainModel : ObservableObject
    {
        public RelayCommand copyCommand { get; }
        public RelayCommand genCommand { get; }
        public RelayCommand setConfCommand { get; }
        public RelayCommand setVmCommand { get; }
        public RelayCommand openWebCommand { get; }
        public  RelayCommand setDefaultCommand { get; }
        public  RelayCommand clearCommand { get; }
        public RelayCommand copyProxyCommand { get; }
        public RelayCommand openExeCommand { get; }
        private string _oneSetText;
        public string OneSetText
        {
            get { return _oneSetText; }
            set { SetProperty(ref _oneSetText, value); }
        }
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
        
        private bool isOneSet { get; set; }
        public MainModel()
        {
            
            OneSetText = "一键设置";

            vmPath =  RegConf.GetOrDefault("vmPath", appPath);
            ConfigPath =  RegConf.GetOrDefault("configPath", @"D:\configuration")  ;
            CopyText = "dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained false";
            copyCommand = new RelayCommand(copyTxt);
            setConfCommand = new RelayCommand(selectConf_Click);
            genCommand = new RelayCommand(vm_Click);
            setVmCommand = new RelayCommand(selectPath_Click);
            openWebCommand = new RelayCommand(openWeb);
            setDefaultCommand = new  RelayCommand(setDefaultAsync);
            clearCommand = new RelayCommand(cleanEnv);
            copyProxyCommand = new RelayCommand(copyProxy);
            openExeCommand = new RelayCommand(openExe);
         }
        public void copyTxt()
        { //clear before copy
            Clipboard.Clear();
            Clipboard.SetText(CopyText);
            MessageBox.Show("已复制");
        }
        private string save = Path.GetTempPath() + @"\ja-netfilter.zip";
        private string[] vmList ={"idea", "clion", "phpstorm", "goland", "pycharm", "webstorm", "webide", "rider", "datagrip", "rubymine",
            "appcode", "dataspell", "gateway", "jetbrains_client", "jetbrainsclient" };
        public string vmOptionPath { get; set; } = "vmoptions";
        string appPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\ja-netfilter";
        public void vm_Click( )  
        {
             
            if (!File.Exists(vmPath+ @"\vmoptions"))
            {
                Directory.CreateDirectory(vmPath + @"\vmoptions");
            }
            foreach (string vm in vmList)
            {
                try
                {
                    //重要:生成utf-8无bom,切换行符为lf的vmoptions  默认的utf8包含bom,不能用
  File.WriteAllText($@"{vmPath }\vmoptions\{vm}.vmoptions",   vmsText(ConfigPath, vm) , Encoding.Default);
                }
                catch (IOException)
                {
                    MessageBox.Show("vmoptions文件被占用,请先关掉jetbrains的软件","警告");
                    throw;
                }
            }
            //这里必须清除isoneset
            isOneSet = false;
            writeEnv();
            File.Delete(save);
            OneSetText = "一键设置";
            MessageBox.Show($"在{vmPath}创建成功");

        }
        public void openExe()
        {
            Process.Start(new ProcessStartInfo("explorer.exe",appPath) {  }); 
        }
        public void copyProxy()
        {
            Clipboard.Clear();
            Clipboard.SetText("https://jetbra.in");
        }
        
        public void setDefaultAsync()
        {
            OneSetText = "设置中...";
            isOneSet = true;
            string jaNetfilterLink = "https://github.com/copyer98/my-utils/raw/main/ja-netfilter-all.zip";
            
           
            Debug.WriteLine(save);
            FileInfo file = new FileInfo(save);

            Task downloadTask = Task.Run(async () =>
            {
                await  VmUtils.DownloadFile(jaNetfilterLink, file);

            });
            downloadTask.Wait();
           
            VmUtils.ZipDeCompress(save, appPath);
            vmPath = appPath;
            RegConf.Set("configPath", ConfigPath,RegistryValueKind.ExpandString);
            RegConf.Set("vmPath", vmPath,RegistryValueKind.ExpandString);
             
            
            vm_Click();
            

        }
        public void openWeb()
        {
           ProcessStartInfo startInfo=new ProcessStartInfo("https://jetbra.in/s") { UseShellExecute=true};
            Process.Start(startInfo);
        }
        public void cleanEnv()
        {
            foreach (var item in vmList)
            {
                RegConf.Remove("configPath");
                RegConf.Remove("vmPath");
                Settings.Remove(item.ToUpper() + "_VM_OPTIONS");
            }

        }

        public void writeEnv()
        {
            foreach (var item in vmList)
            {
                Settings.Set(item.ToUpper() + "_VM_OPTIONS", $@"{vmPath}\vmoptions\{item}.vmoptions", RegistryValueKind.ExpandString);
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
//            方式一：

//不用 @ 时转义
//      System.Console.WriteLine("\"hello\"");

//            方式二：
//用 @ 时, 两个引号表示一个引号
//      System.Console.WriteLine(@"""hello""");
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
-Djdk.http.auth.tunneling.disabledSchemes=""""
-Djdk.attach.allowAttachSelf=true
-Djdk.module.illegalAccess.silent=true
-Dkotlinx.coroutines.debug=off
-XX:ErrorFile=$USER_HOME/java_error_in_idea_%p.log
-XX:HeapDumpPath=$USER_HOME/java_error_in_idea.hprof
";
            string split_txt = "#divide\n";
            if (app=="webide")
            {
                app = "webstorm";
            }
            string conf = $@"-Didea.config.path={confPath}\\{app}Conf\\config
-Didea.system.path={confPath}\\{app}Conf\\system
-Didea.plugins.path={confPath}\\{app}Conf\\config\\plugins
-Didea.log.path={confPath}\\{app}Conf\\system\\log
-javaagent:{vmPath}\ja-netfilter.jar=jetbrains" ;
            string resultText = isOneSet ? defaultText + split_txt : defaultText + split_txt + conf;
            
            return resultText;
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
                 
                vmPath  = dialog.SelectedPath;
                
                RegConf.Set("vmPath", vmPath, RegistryValueKind.ExpandString);
                if (!File.Exists("ja-netfilter.jar"))
                {
                    MessageBox.Show( "当前文件夹内没有ja-netfilter.jar!", "警告");
                }
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
                RegConf.Set("configPath", ConfigPath, RegistryValueKind.ExpandString);
                

            }
        }
    }
}

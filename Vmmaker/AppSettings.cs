using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Vmmaker
{
    internal class AppSettings
    {
        public static string UserDataDirectory
        {
            //C:\Users\UserName\AppData\Local\CompanyName\ProductName\ProductVersion
            //C:\Users\yanni\AppData\Local\ja-netfilter\config.json
            get { return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\ja-netfilter"; }
        }
        public static string ConfigPath
        {
            get { return UserDataDirectory + @"\config.json"; }
        }

    }
}

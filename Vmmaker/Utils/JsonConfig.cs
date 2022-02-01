using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace Vmmaker.Utils
{
    public enum plistType
    {
        Auto, Binary, Xml
    }
    public class JsonConfig
    {
        //public string FileVersion
        //{
        //    get { 
        //        return Get<string>("$$FileVersion", null); 
        //    }
        //    set
        //    {
        //        Set("$$FileVersion",value);
        //    }
        //}
        public Confs confs { get; set; }

        public string PlistPath { get; set; }

        /// <summary>
        /// 创建一个空的Config
        /// </summary>
       

        /// <summary>
        /// 创建并指定要加载或保存的plist文件位置
        /// </summary>
        /// <param name="plistPath">Plist path.</param>
        public JsonConfig(string plistPath)
        {
            PlistPath = plistPath;
            Load();
        }

        public JsonConfig(Stream stream, bool closeStream)
        {
            Load(stream, closeStream);
        }

        private void Load()
        {
            if (PlistPath == null)
                throw new InvalidOperationException("未指定需要加载的plist文件路径");
            if (!File.Exists(PlistPath))
            {
                 File.Copy(@"res\aaf.json",AppSettings.ConfigPath, true);
                return;
            }

            StreamReader reader = new StreamReader(PlistPath);
            confs = JsonConvert.DeserializeObject<Confs>(reader.ReadToEnd());
            //Dict = (Dictionary<string, object>)Plist.readPlist(PlistPath);
        }

        private void Load(Stream stream, bool closeStream = false)
        {
            if (stream == null || !stream.CanRead) throw new ArgumentException("stream");

            try
            {
                StreamReader reader = new StreamReader(PlistPath);
                confs = JsonConvert.DeserializeObject<Confs>(reader.ReadToEnd());

            }
            catch (Exception)
            {
                if (closeStream && stream != null) stream.Close();
                throw;
            }




        }
        public   bool Exists()
        {
            return File.Exists(AppSettings.ConfigPath);
        }

        public void Save()
        {
            if (PlistPath == null)
                throw new InvalidOperationException("未指定需要保存到的plist文件路径(PlistPath属性)");

            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(PlistPath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, confs);

            }
            //Plist.writeXml(Dict, PlistPath);
        }

        public void Import(JsonConfig config)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(PlistPath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, config.confs);

            }
        }

        
    }

}

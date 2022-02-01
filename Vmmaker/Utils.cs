using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vmmaker
{
    internal class Utils
    {/// <summary>
     /// unZip文件解压缩
     /// </summary>
     /// <param name="sourceFile">要解压的文件</param>
     /// <param name="path">要解压到的目录</param>
        public static void ZipDeCompress(string sourceFile, string path)
        {
            if (!File.Exists(sourceFile))
            {
                throw new ArgumentException("要解压的文件不存在。");
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(sourceFile)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string fileName = Path.GetFileName(theEntry.Name);
                    string directoryName = Path.GetDirectoryName(theEntry.Name);


                    // create directory
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(path + @"\" + directoryName);
                    }
                    if (fileName != string.Empty)
                    {
                        using (FileStream streamWriter = File.Create(path + @"\" + theEntry.Name))
                        {
                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}

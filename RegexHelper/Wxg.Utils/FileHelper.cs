using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace Wxg.Utils
{
    public class FileHelper
    {
        public static Encoding Encoding
        {
            get
            {
                string encoding = Xmler.GetAppSettingValue("encoding");
                if (string.IsNullOrEmpty(encoding))
                {
                    return Encoding.Default;
                }

                return Encoding.GetEncoding(encoding);   
            }
        }

        public static string AssemblyPath
        {
            get
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                return Path.GetDirectoryName(asm.Location);
            }
        }

        public static void Rename(string sourceFileName, string destFileName)
        {
            // old file not exits 
            if (!File.Exists(sourceFileName)) return;

            string oldfolder = Path.GetDirectoryName(sourceFileName);
            string newfolder = Path.GetDirectoryName(destFileName);
            if (string.IsNullOrEmpty(newfolder))
            {
                destFileName = Path.Combine(oldfolder, destFileName);
            }

            // new file has exited
            if (File.Exists(destFileName)) return;

            File.Move(sourceFileName, destFileName);
        }
    }
}

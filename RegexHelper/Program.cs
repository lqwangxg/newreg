using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wxg.Replace;
using System.IO;
using Wxg.Utils;

namespace Wxg.Regexer
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string schemaPath = Path.Combine(path, Xmler.GetAppSettingValue("schema"));
            string xmlPath = Path.Combine(path, Xmler.GetAppSettingValue("rules"));
            string xmlPathTemplate = Path.Combine(path, Xmler.GetAppSettingValue("template"));
            ReplaceLoader.InitXmlSchema(schemaPath);
            ReplaceLoader.LoadTemplate(xmlPath);
            ReplaceLoader.LoadTemplateXML(xmlPathTemplate);
            Application.Run(new FrmMDI());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string msg = string.Format("Exception:{0}\r\nSource:{1}\r\nTraceStack:{2}\r\n",
                e.Exception.Message, e.Exception.Source, e.Exception.StackTrace);

            MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
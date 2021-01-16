using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Resources;
using System.Reflection;

namespace Wxg.Utils
{
    public class Parameters
    {
        /// <summary>
        /// Not New. 
        /// </summary>
        private Parameters() { }
        private Dictionary<string, string> _patterns = new Dictionary<string, string>();

        public Dictionary<string, string> Patterns
        {
            get
            {
                return _patterns;
            }
        }

        private static Parameters instance;
        public static Parameters Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new Parameters();
                    instance.LoadSystemParameters();
                }
                return instance;
            }
        }

        public string this[string key]
        {
            get
            {
                if (Patterns.ContainsKey(key))
                {
                    return Patterns[key];
                }
                return string.Empty;
            }
        }
        private void LoadSystemParameters()
        {
            string configfilename = Xmler.GetAppSettingValue("wxgconfig", "wxgconfig.xml");
            string configfile = Path.Combine(FileHelper.AssemblyPath, configfilename);
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(configfile))
            {
                doc.LoadXml( Resources.WxgConfig);
            }
            else
            {
                doc.Load(configfile);
            }
            // Load Patterns
            XmlNode patternNode = doc.SelectSingleNode("wxg/system/patterns");
            LoadSystemPattern(patternNode);
        }
        
        /// <summary>
        /// Load System Pattern 
        /// </summary>
        /// <param name="patternNode">Pattern Node</param>
        private void LoadSystemPattern(XmlNode patternNode)
        {
            foreach (XmlNode node in patternNode.SelectNodes("pattern"))
            {
                string key = Xmler.GetAttribute(node, "name");
                if (string.IsNullOrEmpty(key)) continue;

                Patterns[key] = node.InnerText.Trim();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Linq;
using Wxg.Utils;
using System.Data;

namespace Wxg.Replace
{
    public interface IReplaceLoader
    {
        void Load(string xmlPath, string schemaPath);
    }

    public class ReplaceLoader  
    {
        private static TemplateDataSet dsTemplate;
        public static TemplateDataSet TemplateDataSet
        {
            get 
            {
                if (dsTemplate == null)
                {
                    dsTemplate = new TemplateDataSet();
                }
                return dsTemplate; 
            }
        }
        private static string _sampleXml;
        public static string SampleTemplate
        {
            get
            {
                return _sampleXml;
            }
        }

        private static ReplaceLoader instance;

        private Dictionary<string, ReplaceTemplate> templates;
        public Dictionary<string, ReplaceTemplate> Templates
        {
            get { return templates; }
        }

        public ReplaceTemplate this[string key]
        {
            get { return Templates[key]; }
        }
        
        private ReplaceLoader()
        {
            this.templates = new Dictionary<string, ReplaceTemplate>();
        }

        public void LoadXml(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            //ReplaceTemplate item;
            foreach (XmlNode node in doc.SelectNodes("replaces/template"))
            {
                //Load Sub File. 
                string file = Xmler.GetAttribute(node, "file");
                if (File.Exists(file)) LoadXml(file);

                // Load Current File
                string name = Xmler.GetAttribute(node, "name");
                if (string.IsNullOrEmpty(name)) continue;
                
                string temp = name;
                int i = 0;
                while (templates.ContainsKey(temp))
                {
                    i++;
                    temp = temp + i.ToString();
                }
                name = temp;
            }
        }

        public static void InitXmlSchema(string schemaPath)
        {
            string schema = Xmler.GetAppSettingValue("schema");
            if (string.IsNullOrEmpty(schema))
            {
                throw new XmlException("Missing schema config in App.config.");
            }

            TemplateDataSet.ReadXmlSchema(schemaPath);
        }

        public static void LoadTemplateXML(string xmlPath)
        {
            using (StreamReader sr = new StreamReader(xmlPath))
            {
                _sampleXml = sr.ReadToEnd();
            }
        }
        public static void LoadTemplate(string xmlPath)
        {
            if (instance ==null)
            {
                instance = new ReplaceLoader(); 
            }
            
            instance.templates = dsTemplate.LoadFromFile(xmlPath);
        }
    }
} 

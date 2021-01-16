using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using Wxg.Utils;
using Wxg.IO;
using System.Data;

namespace Wxg.Replace
{
    public class ReplaceTemplate
    {
        private bool _extract;
        public bool Extract
        {
            get { return _extract; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
        }

        private List<ReplaceTemplateItem> _items;

        public List<ReplaceTemplateItem> Items
        {
            get { return _items; }
        }

        private Dictionary<string, string> _dictionary;

        public Dictionary<string, string> Dictionary
        {
            get { return _dictionary; }
        }

        public ReplaceTemplate(string name)
        {
            this._extract = true;
            this._name = name;
            _items = new List<ReplaceTemplateItem>();
            _dictionary = new Dictionary<string, string>();
        }

        #region ====
        
        public static ReplaceTemplate GetInstance(string xmlsnippet)
        {
            Random rd = new Random(10000);
            string name = DateTime.Now.ToString("yyyyMMddhhmmss--") + rd.Next().ToString();
            ReplaceTemplate inst = new ReplaceTemplate(name);
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlsnippet);
            inst.LoadXml(doc);
            
            return inst;
        }

        public void LoadXml(XmlNode node)
        {
            LoadDictionary(node);
            
            //Dictionary<string, bool> Filters = GetCommonFilters(node);

            //ReplaceTemplateItem item = null;
            //foreach (XmlNode itemNode in node.SelectNodes("item"))
            //{
            //    item = new ReplaceTemplateItem(this.Dictionary);
            //    LoadItemXml(itemNode, item);
            //    Items.Add(item);

            //    //CollectionUtil.Combine(Filters, item.Filters);
            //}
        }
        /// <summary>
        /// Load reference Dictionary form text file.
        /// </summary>
        /// <param name="node"></param>
        private void LoadDictionary(XmlNode node)
        {
            string file = Xmler.GetAttribute(node, "dictionary");
            if (File.Exists(file))
            {
                string[] contents = File.ReadAllLines(file, FileHelper.Encoding);
                string key = string.Empty;
                string value = string.Empty;
                foreach (string kv in contents)
                {
                    Match match = Regex.Match(kv, @"^\s*(\w+)=");
                    if (match.Success)
                    {
                        key = match.Groups[1].Value;
                        value = kv.Substring(match.Index + match.Length);
                        this.Dictionary[key] = value;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="item"></param>
        private void LoadItemXml(XmlNode node, ReplaceTemplateItem item)
        {
            //item.Pattern = node.SelectSingleNode("pattern").InnerText.Trim();
            //foreach (XmlNode repNode in node.SelectNodes("replace"))
            //{
            //    string value = repNode.InnerText;
            //    string group = Xmler.GetAttribute(repNode, "group");
            //    int groupindex;
            //    if (int.TryParse(group, out groupindex))
            //    {
            //        item.ReplacePairs[groupindex] = repNode.InnerText.Trim();
            //    }
            //}

            //// Load Item Private Filters
            //CollectionUtil.Combine(GetFilters(node), item.Filters);
        }
        /// <summary>
        /// Get filters of do or undo.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Dictionary<string, bool> GetFilters(XmlNode node)
        {
            Dictionary<string, bool> Filters = new Dictionary<string, bool>();
            foreach (XmlNode doNode in node.SelectNodes("inside"))
            {
                string filter = doNode.InnerText.Trim();
                if (string.IsNullOrEmpty(filter)) continue;
                string action = Xmler.GetAttribute(doNode, "action");
                bool isAction = false;
                bool.TryParse(action, out isAction);
                Filters[filter] = isAction;
            }
            return Filters;
        }
        /// <summary>
        /// Get Common Filters Outside the items.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Dictionary<string, bool> GetCommonFilters(XmlNode node)
        {
            Dictionary<string, bool> Filters = new Dictionary<string,bool>();
            foreach (XmlNode itemNode in node.SelectNodes("filters"))
            {
                Dictionary<string,bool> dic = GetFilters(itemNode);
                CollectionUtil.Combine(dic, Filters);
            }
            return Filters;
        }
        #endregion

    }
}

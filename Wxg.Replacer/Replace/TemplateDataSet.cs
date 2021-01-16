using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace Wxg.Replace
{
    public class TemplateDataSet : DataSet
    {
        public Dictionary<string, ReplaceTemplate> LoadFromFile(string filename)
        {
            base.ReadXml(filename);
            return GetTemplates();
        }

        public Dictionary<string, ReplaceTemplate> LoadFromXml(string xml)
        {
            StringReader reader = new StringReader(xml);
            base.ReadXml(reader);
            return GetTemplates();
        }

        #region GetTemplates
        private Dictionary<string, ReplaceTemplate> GetTemplates()
        {
            string templateName = string.Empty;
            Dictionary<string, ReplaceTemplate> templates =
                new Dictionary<string, ReplaceTemplate>();

            foreach (DataRow row in this.Tables["template"].Rows)
            {
                if (row.IsNull("name")) continue;

                templateName = row["name"].ToString();
                templates[templateName] = GetTemplate(row, templateName);
            }
            return templates;
        }

        private ReplaceTemplate GetTemplate(DataRow drTemplate, string templateName)
        {
            ReplaceTemplate template = new ReplaceTemplate(templateName);
            foreach (DataRow row in drTemplate.GetChildRows("template_item"))
            {
                template.Items.Add(ReplaceUtils.GetTemplateItem(row));
            }
            return template;
        }
        #endregion
    }
}

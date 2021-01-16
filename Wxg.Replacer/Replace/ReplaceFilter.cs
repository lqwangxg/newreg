using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Wxg.Utils;
using System.Data;
using System.Linq;
namespace Wxg.Replace
{
    internal class ReplaceFilter
    {
        public static bool CanReplace(  string input, 
                                        Match match, 
                                        ReplaceTemplateItem item)
        {
            List<FilterItem> lstFilter = GetFilters(input, match, item);
            if (lstFilter.Count == 0) return true;

            return !lstFilter.Any(filter=> filter.Index <= match.Index
                  && match.Index + match.Length <= filter.Index + filter.Length
                  && !filter.Enable);
        }

        private static List<FilterItem> GetFilters( string input, 
                                                    Match match, 
                                                    ReplaceTemplateItem item)
        {
            List<FilterItem> lstFilter = new List<FilterItem>();
            foreach (DataRow drWhen in item.When)
            {
                bool action = false;
                if (drWhen.IsNull("action"))
                {
                    action = (bool)drWhen.Table.Columns["action"].DefaultValue;
                }
                else
                {
                    action = (bool)drWhen["action"];
                }

                string pattern = ReplaceUtils.GetRegexPattern(drWhen);
                //pattern = ReplaceReference.Reference(pattern, match);
                RegexOptions options = ReplaceUtils.GetRegexOptions(drWhen);
                Regex reg = new Regex(pattern, options);
                if (reg != null)
                {
                    GetFilters(input, reg, action, lstFilter);
                }                
            }

            return lstFilter;
        }

        private static void GetFilters( string input, 
                                        Regex reg, 
                                        bool enable,
                                        List<FilterItem> lstFilter)
        {
            MatchCollection matches = reg.Matches(input);

            foreach (Match match in matches)
            {
                FilterItem item = new FilterItem();
                item.Index = match.Index;
                item.Length = match.Length;
                item.Enable = enable;
                lstFilter.Add(item);
            }
        }
    }
}

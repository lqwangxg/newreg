using System;
using System.Collections.Generic;
using System.Text;
using Wxg.Utils;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.Linq;

namespace Wxg.Replace
{
    internal class ReplaceUtils
    {
        public static string ReplaceMatchValue(Match match, Dictionary<int, string> ReplacePairs)
        {
            Dictionary<Capture, string> map = new Dictionary<Capture, string>();
            foreach (KeyValuePair<int, string> kv in ReplacePairs)
            {
                map[match.Groups[kv.Key]] = kv.Value;
            }
            //return GetReplaced(match.Value, map, match.Index);
            
            // --------[MAT===================CH]-------------END
            // --------[cidx-----------------END]-------------END
            int idx = 0;
            string header;
            StringBuilder sb = new StringBuilder();
            string input = match.Value;
            foreach (KeyValuePair<Capture, string> kv in map)
            {
                // |----------------------------------------------|
                // 0-------[MATCH]------------[MATCH]-------------LENTH
                // cidx----[idx--]------------[idx--]-------------END
                header = input.Substring(idx, kv.Key.Index - match.Index);
                sb.Append(header);
                sb.Append(kv.Value);
                idx = kv.Key.Index - match.Index + kv.Key.Length;
            }
            // 末まで
            sb.Append(input.Substring(idx));
            return sb.ToString();
        }

        public static string GetReplaced(string input, Dictionary<Capture, string> mapResult)
        {
            return GetReplaced(input, mapResult, 0);
        }
        public static string GetReplaced(string input, Dictionary<Capture, string> mapResult, int cidx)
        {
            int idx = 0;
            string header;
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<Capture, string> kv in mapResult)
            {
                // |----------------------------------------------|
                // 0-------[MATCH]------------[MATCH]-------------LENTH
                // cidx----[idx--]------------[idx--]-------------END
                header = input.Substring(idx, kv.Key.Index - idx - cidx);
                sb.Append(header);
                sb.Append(kv.Value);
                idx = kv.Key.Index + kv.Key.Length - cidx;
            }
            sb.Append(input.Substring(idx));

            return sb.ToString();
        }

        public static string GetRegexPattern(DataRow drPatternType)
        {
            if (drPatternType == null) return string.Empty;

            string text = string.Format("{0}_text", drPatternType.Table.TableName);
            return drPatternType[text].ToString().Trim();
        }

        public static RegexOptions GetRegexOptions(DataRow drPatternType)
        {
            List<string> optionNames = new List<string>(Enum.GetNames(typeof(RegexOptions)));
            RegexOptions options = RegexOptions.None;
            foreach (DataColumn col in drPatternType.Table.Columns)
            {
                if (optionNames.IndexOf(col.ColumnName) < 0) continue;

                if (drPatternType.IsNull(col))
                {
                    if (col.DefaultValue.Equals(true))
                    {
                        options |= (RegexOptions)Enum.Parse(typeof(RegexOptions), col.ColumnName);
                    }
                }
                else
                {
                    if (drPatternType[col].Equals(true))
                    {
                        options |= (RegexOptions)Enum.Parse(typeof(RegexOptions), col.ColumnName);
                    }
                }
            }

            return options;
        }

        public static Regex GetRegex(DataRow drPatternType)
        {
            return GetRegex(drPatternType, null);
        }

        public static Regex GetRegex(DataRow drPatternType, 
                                     Func<DataRow, string> reference)
        {
            string patterns = GetRegexPattern(drPatternType);
            if (reference != null)
            {
                patterns = reference.Invoke(drPatternType);
            }

            RegexOptions options = GetRegexOptions(drPatternType);
            return new Regex(patterns, options);
        }

        public static ReplaceTemplateItem GetTemplateItem(DataRow drTemplateType)
        {
            ReplaceTemplateItem template = new ReplaceTemplateItem();
            template.Pattern = drTemplateType.GetChildRows("item_pattern")[0];
            template.Replace = drTemplateType.GetChildRows("item_replace");
            template.When = drTemplateType.GetChildRows("item_when");
            return template;
        }
    }
}

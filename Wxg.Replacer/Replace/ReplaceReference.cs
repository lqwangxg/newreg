using System;
using System.Collections.Generic;
using System.Text;
using Wxg.Utils;
using System.Text.RegularExpressions;
using System.Data;

namespace Wxg.Replace
{
    internal class ReplaceReference
    {
        #region #Replace references
        /// <summary>
        /// Trim Reference to Const Strings.
        /// <remarks>
        /// e.g
        /// [$ABCD$] => ABCD
        /// </remarks>
        /// </summary>
        /// <param name="input">Trim Object</param>
        /// <returns>real string</returns>
        public static string Reference(string input)
        {
            // ==============================================
            string refconst = Parameters.Instance["refconst"];
            if (string.IsNullOrEmpty(refconst)) return input;

            Dictionary<Capture, string> map = new Dictionary<Capture, string>();
            MatchCollection matches = Regex.Matches(input, refconst);
            foreach (Match mt in matches)
            {
                map[mt] = mt.Groups[1].Value;
            }
            return ReplaceUtils.GetReplaced(input, map);
        }

        /// <summary>
        /// string Reference Dictionary<name, value>.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Reference(string input, string pattern, Dictionary<string, string> args)
        {
            MatchCollection matches = Regex.Matches(input, pattern);
            Dictionary<Capture, string> map = new Dictionary<Capture, string>();
            foreach (Match mt in matches)
            {
                string key = mt.Groups[1].Value;
                if (!args.ContainsKey(key)) continue;

                map[mt] = args[key];
            }

            return ReplaceUtils.GetReplaced(input, map);
        }

       
        public static string Reference(string input, Match match)
        {
            // ==============================================
            // First: Reference Match Group, get groupindex \{\$(\d+)\$\}
            string pattern = Parameters.Instance["refmatch"];
            if (string.IsNullOrEmpty(pattern)) return input;

            Dictionary<Capture, string> map = new Dictionary<Capture, string>();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match mt in matches)
            {
                int idx = int.Parse(mt.Groups[1].Value);
                map[mt] = match.Groups[idx].Value;
            }

            return ReplaceUtils.GetReplaced(input, map);
        }

        /// <summary>
        /// Trim Reference of Replacement.ReplacePairs to Const Strings.
        /// <remarks>
        /// e.g
        /// [$ABCD$] => ABCD
        /// </remarks>
        /// </summary>
        public static void Reference(ReplaceTemplateItem rep)
        {
            foreach (DataRow row in rep.Replace)
            {
                //f2[kv.Key] = Reference(kv.Value);
            }
            //CollectionUtil.Combine(f2, rep.ReplacePairs);
        }

        /// <summary>
        /// Replacement refercences Dictionary<name, value>.
        /// </summary>
        /// <param name="rep"></param>
        /// <param name="args"></param>
        public static void Reference(ReplaceTemplateItem rep, Dictionary<string, string> args)
        {
            string refargs = Parameters.Instance["refargs"];
            if (string.IsNullOrEmpty(refargs)) return;

            // Check Pattern 
            //rep.Pattern = Reference(rep.Pattern, refargs, args);

            //========================================================
            // Check Filters 
            string key = string.Empty;
            Dictionary<string, bool> tFilters = new Dictionary<string, bool>();
            //foreach (KeyValuePair<string, bool> kv in rep.Filters)
            //{
            //    key = Reference(kv.Key, refargs, args);
            //    tFilters[key] = kv.Value;
            //}
            //rep.Filters.Clear();
            //CollectionUtil.Combine(tFilters, rep.Filters);

            //========================================================
            // Check ReplacePairs 
            //Dictionary<int, string> f2 = new Dictionary<int, string>();
            //string value = string.Empty;
            //foreach (KeyValuePair<int, string> kv in rep.ReplacePairs)
            //{
            //    f2[kv.Key] = Reference(kv.Value, refargs, args);
            //}

            //rep.ReplacePairs.Clear();
            //CollectionUtil.Combine(f2, rep.ReplacePairs);
        }

        /// <summary>
        /// Replacement refercences Match.
        /// </summary>
        /// <param name="replacement"></param>
        /// <param name="match"></param>
        public static Dictionary<int, string> Reference(ReplaceTemplateItem replacement, Match match)
        {
            string replace = string.Empty;
            Dictionary<int, string> pair = new Dictionary<int, string>();
            //foreach (KeyValuePair<int, string> kv in replacement.ReplacePairs)
            //{
            //    replace = kv.Value;
            //    //================================
            //    if (replace.Equals("#REFRENCE_DIC_COMPLETE"))
            //    {
            //        replace = match.Groups[kv.Key].Value;
            //        replace = CollectionUtil.GetValue(replacement.Dictionary, replace);
            //    }

            //    replace = Reference(replace, match);
            //    //================================
            //    pair[kv.Key] = replace;
            //}

            return pair;
        }

        /// <summary>
        /// Replacement refercences Match.
        /// </summary>
        /// <param name="replacement"></param>
        /// <param name="match"></param>
        public static void ReferenceDictionary(ReplaceTemplateItem replacement, Match match)
        {
            string pattern = string.Empty;
            string replace = string.Empty;
            
            Dictionary<int, string> pair = new Dictionary<int, string>();
            //foreach (KeyValuePair<int, string> kv in replacement.ReplacePairs)
            //{
            //    replace = kv.Value;
            //    //================================
            //    replace = Reference(replace, match, kv.Key, replacement.Dictionary);

            //    replace = Reference(replace, match);
            //    //================================
            //    pair[kv.Key] = replace;
            //}

            //replacement.ReplacePairs.Clear();
            //CollectionUtil.Combine(pair, replacement.ReplacePairs);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="match"></param>
        /// <param name="groupindex"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        private static string Reference(string input, Match match, int groupindex, 
            Dictionary<string, string> map)
        {
            //================================
            // \<\$KEY:([\w]+)\$\>
            string pattern = Parameters.Instance["refdicfile"];
            Match mt = Regex.Match(input, pattern);
            if (mt.Success)
            {
                // KEY:ABC
                string key = mt.Groups[1].Value;

                // KEY:__CURRENT_GROUP_VALUE__
                string ckey = Parameters.Instance["refdicfile_currentgroup"];
                if (key.Equals(ckey))
                {
                    key = match.Groups[groupindex].Value;
                }
                input = CollectionUtil.GetValue(map, key);
            }

            //file \<\$KEY:([\w]+)(\[\d+\])\$\>
            pattern = Parameters.Instance["refdicfile_index"];
            mt = Regex.Match(input, pattern);
            if (mt.Success)
            {
                // KEY:ABC
                string key = mt.Groups[1].Value;

                // KEY:__GROUP_INDEX__
                string ckey = Parameters.Instance["refdicfile_groupindex"];

                if (key.Equals(ckey))
                {
                    int idx = int.Parse(mt.Groups[2].Value);
                    key = match.Groups[idx].Value;
                }
                input = CollectionUtil.GetValue(map, key);
            }
            return input;
        }
        #endregion
    }
}

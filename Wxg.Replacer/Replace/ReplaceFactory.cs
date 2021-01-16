using System;
using System.Collections.Generic;
using System.Text;
using Wxg.Replace.Impl;
using System.Text.RegularExpressions;
using Wxg.Utils;
using System.IO;
using Wxg.IO;

namespace Wxg.Replace
{
    public class ReplaceFactory
    {
        #region Default Replacer
        //=========================================
        private static IReplacer replacer = null;
        public static IReplacer DefaultReplacer
        {
            get
            {
                if (replacer == null)
                {
                    replacer = Activator.CreateInstance(typeof(GroupReplacer)) as IReplacer;
                }
                return replacer;
            }
        }
        #endregion

        #region Replace Groups

        public static string ReplaceGroup(string input, ReplaceTemplate template)
        {
            foreach (ReplaceTemplateItem replacement in template.Items)
            {
                //ReplaceReference.Reference(replacement);
                input = ReplaceGroup(input, replacement);
            }

            return input;
        }

        public static string ReplaceGroup(string input, ReplaceTemplateItem replacement)
        {
            return DefaultReplacer.Replace(input, replacement);
        }
        #endregion

        #region Replace File

        public static void ReplaceSingleFile(string file, 
                                            ReplaceTemplate template, 
                                            Action<string> afterAction)
        {
            if (!File.Exists(file)) return;
            string content = File.ReadAllText(file, FileHelper.Encoding);

            int h1 = content.GetHashCode();
            foreach (ReplaceTemplateItem doitem in template.Items)
            {
                content = ReplaceGroup(content, template);
            }
            int h2 = content.GetHashCode();

            if (h1 != h2)
            {
                if (afterAction !=null)
                {
                    afterAction(file);
                }
                
                FileInfo fi = new FileInfo(file);
                FileHelper.Rename(file, file + ".bak");
                File.WriteAllText(file, content, FileHelper.Encoding);
            }
        }

        public static void ReplaceFiles(string[] files, 
                                        ReplaceTemplate template, 
                                        Action<string> afterAction)
        {
            foreach (string file in files)
            {
                ReplaceSingleFile(file, template, afterAction);
            }
        }
        //============================================================================
        #endregion

    }
}

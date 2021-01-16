using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Wxg.Replace.Impl
{
    public class GroupReplacer : IReplacer
    {
        #region IReplacer
        string IReplacer.Replace(string input, ReplaceTemplateItem item)
        {
            if (item.Replace.Length == 0) return input;
            
            MatchCollection matches = item.Matches(input);

            Dictionary<Capture, string> map = new Dictionary<Capture, string>();
            foreach (Match match in matches)
            {
                if (ReplaceFilter.CanReplace(input, match, item))
                {
                    Dictionary<int, string> pair = ReplaceReference.Reference(item, match);

                    map[match] = ReplaceUtils.ReplaceMatchValue(match, pair);
                }
            }

            return ReplaceUtils.GetReplaced(input, map);
        }
        #endregion
    }
}

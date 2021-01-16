using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Wxg.Replace
{
    public interface IReplacer
    {
        string Replace(string input, ReplaceTemplateItem replacement);
    }
}

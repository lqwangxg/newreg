using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.Linq;

namespace Wxg.Replace
{
    public class ReplaceTemplateItem
    {
        #region Properties
        private DataRow pattern;
        public DataRow Pattern
        {
            get { return pattern; }
            set { pattern = value; }
        }
        private DataRow[] replace;
        public DataRow[] Replace
        {
            get { return replace; }
            set { replace = value; }
        }
        private DataRow[] when;
        public DataRow[] When
        {
            get { return when; }
            set { when = value; }
        }

        private Dictionary<string, string> _dictionary;
        public Dictionary<string, string> Dictionary
        {
            get {
                if (_dictionary == null)
                {
                    _dictionary = new Dictionary<string, string>();
                }
                return _dictionary; 
            }
        }

        private Regex _Finder;
        public Regex Finder
        {
            get
            {
                if (_Finder == null)
                {
                    _Finder = ReplaceUtils.GetRegex(this.Pattern);
                }
                return _Finder;
            }
        }
        private string inputString =null;
        private MatchCollection matches = null;
        #endregion

        public ReplaceTemplateItem()
        {
        }
        public MatchCollection Matches(string input)
        {
            this.inputString = input;
            this.matches = Finder.Matches(input);
            return this.matches;
        }

        public string ReplaceMatches()
        {
            if (string.IsNullOrEmpty(this.inputString)) return this.inputString;
            if (this.matches == null) return this.inputString;

            
            return string.Empty;
        }
        private bool _changed;
        public bool CanReplaced
        {
            get { return _changed; }
            set { _changed = value; }
        }
        public void CanReplace(Match result)
        {
            foreach (DataRow drWhen in this.When)
            {
                
                Regex wFinder = ReplaceUtils.GetRegex(drWhen);
                
            }
        }
        
    }
}

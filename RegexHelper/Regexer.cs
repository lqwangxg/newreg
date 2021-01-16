using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wxg.UI.Forms;
using System.Text.RegularExpressions;
using Wxg.Utils;
using System.Diagnostics;

namespace Wxg.Replace
{
    public partial class Regexer : UserControl
    {
        /// <summary>
        /// Matches Collection Result.
        /// </summary>
        private MatchCollection matches;
        /// <summary>
        /// Replace Pattern Format
        /// </summary>
        private const string replaceformat = @"";
        private RegexOptions options = RegexOptions.None;
        public RegexOptions Options
        {
            set { options = value; }
        }

        public Regexer()
        {
            InitializeComponent();
            txtReplaceRule.Text = ReplaceLoader.SampleTemplate;
            TreeDataBinder.DataBind(treeTemplate, ReplaceLoader.TemplateDataSet, "template");
        }

        #region
        /// <summary>
        /// Do regex match, show the result on tree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnMatch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text)) return;
            if (string.IsNullOrEmpty(txtPattern.Text)) return;

            Regex reg = new Regex(txtPattern.Text, options);
            this.matches = reg.Matches(txtInput.Text);
            BindMatchTree(matches, reg);
            
            tabResult.SelectedTab = tpMatch;
        }

        /// <summary>
        /// Do replace, show the result on replaced textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnReplace_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text)) return;
            if (string.IsNullOrEmpty(txtReplaceRule.Text)) return;

            TemplateDataSet ds = new TemplateDataSet();
            Dictionary<string, ReplaceTemplate> dicTMP = ds.LoadFromXml(txtReplaceRule.Text);

            this.txtResult.Text = txtInput.Text;
            foreach(KeyValuePair<string, ReplaceTemplate> kv in dicTMP)
            {
                this.txtResult.Text = ReplaceFactory.ReplaceGroup(txtResult.Text, kv.Value);
            }
            tabResult.SelectedTab = tpMatch;
        }

        /// <summary>
        /// Show Pattern Config file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnOpen_Click(object sender, EventArgs e)
        {
            string txtopener = Xmler.GetAppSettingValue("txtopener");
            string replacepatterns = Xmler.GetAppSettingValue("replacepatterns");

            if (!string.IsNullOrEmpty(txtopener))
            {
                Process.Start(txtopener, replacepatterns);
            }
            else
            {
                MessageBox.Show("Txt File Editor is Missing or not Config."
                    + "\nPlease Confirm the [txtopener] on *.exe.config ");
            }

        }
        /// <summary>
        /// Show Replace files window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnReplaceFile_Click(object sender, EventArgs e)
        {
            FrmReplaceFile frm = new FrmReplaceFile();
            frm.Show();
        }

        /// <summary>
        /// F5-F8 Key down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FrmRegex_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    btnMatch_Click(sender, e);
                    break;
                case Keys.F6:
                    btnReplace_Click(sender, e);
                    break;
                case Keys.F7:
                    btnOpen_Click(sender, e);
                    break;
                case Keys.F8:
                    btnReplaceFile_Click(sender, e);
                    break;
                default:
                return;
            }
        }
        #endregion

        #region Bind MatchCollection to Tree
        /// <summary>
        /// Show the match result on tree.
        /// </summary>
        /// <param name="matches"></param>
        private void BindMatchTree(MatchCollection matches, Regex reg)
        {
            HighLight hl = new HighLight(txtInput);
            hl.Reset2Default();
            treeMatch.Nodes.Clear();
            foreach (Match match in matches)
            {
                hl.Highlight(match);

                TreeNode nodeMatch = treeMatch.Nodes.Add(match.Value);
                BindGroup(nodeMatch, match, reg);
            }
        }

        /// <summary>
        /// Show the match result on tree node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="match"></param>
        private static void BindGroup(TreeNode node, Match match, Regex reg)
        {
            for (int i = 0; i < match.Groups.Count; i++)
            {
                Group group = match.Groups[i];
                string groupName = reg.GroupNameFromNumber(i);
                string Value = string.Format("[{0}:{1}]{2}", i, groupName, group.Value);
                TreeNode nodeGroup = node.Nodes.Add(Value);
                BindCapture(nodeGroup, group);
            }
        }
        /// <summary>
        /// Show the match group result on tree node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="group"></param>
        private static void BindCapture(TreeNode node, Group group)
        {
            foreach (Capture capture in group.Captures)
            {
                string Value = string.Format("[{0}:{1}]:{2}",
                    capture.Index, capture.Length, capture.Value);
                node.Nodes.Add(Value);
            }
        }
        #endregion 
    }
}

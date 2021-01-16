using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Wxg.Replace;
using Wxg.UI.Forms;
using System.Diagnostics;
using System.IO;
using Wxg.IO;
using Wxg.Utils;
using System.Xml;
using System.Xml.XPath;

namespace Wxg
{
    public partial class FrmRegex : Form
    {
        
        /// <summary>
        /// Regex Form Construction
        /// </summary>
        public FrmRegex()
        {
            InitializeComponent();
            
        }
        
        #region 
        /// <summary>
        /// Do regex match, show the result on tree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMatch_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtInput.Text)) return;
            //if (string.IsNullOrEmpty(txtPattern.Text)) return;

            //Regex reg = new Regex(txtPattern.Text, options);
            //this.matches = reg.Matches(txtInput.Text);
            //BindMatchTree(matches);
        }
        
        /// <summary>
        /// Do replace, show the result on replaced textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplace_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtInput.Text)) return;
            //if (string.IsNullOrEmpty(txtReplaceRule.Text)) return;

            //ReplaceTemplate pattern = ReplaceTemplate.GetInstance(txtReplace.Text);
            //this.txtReplaced.Text = ReplaceFactory.ReplaceGroup(txtInput.Text, pattern);
        }
        /// <summary>
        /// Show Pattern Config file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            //string txtopener = Xmler.GetAppSettingValue("txtopener");
            //string replacepatterns = Xmler.GetAppSettingValue("replacepatterns");

            //if (!string.IsNullOrEmpty(txtopener))
            //{
            //    Process.Start(txtopener, replacepatterns);
            //}
            //else
            //{
            //    MessageBox.Show("Txt File Editor is Missing or not Config."
            //        + "\nPlease Confirm the [txtopener] on *.exe.config ");
            //}
            
        }
        /// <summary>
        /// Show Replace files window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplaceFile_Click(object sender, EventArgs e)
        {
            FrmReplaceFile frm = new FrmReplaceFile();
            frm.Show();
        }

        /// <summary>
        /// F5-F8 Key down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRegex_KeyDown(object sender, KeyEventArgs e)
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
            }
        }
        #endregion

        #region Bind MatchCollection to Tree
        ///// <summary>
        ///// Show the match result on tree.
        ///// </summary>
        ///// <param name="matches"></param>
        //private void BindMatchTree(MatchCollection matches)
        //{
        //    HighLight hl = new HighLight(txtInput);
        //    hl.Reset2Default();
        //    treeMatch.Nodes.Clear();
        //    foreach (Match match in matches)
        //    {
        //        hl.Highlight(match);

        //        TreeNode nodeMatch = treeMatch.Nodes.Add(match.Value);
        //        BindGroup(nodeMatch, match);
        //    }
        //}
        /// <summary>
        /// Show the match result on tree node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="match"></param>
        private static void BindGroup(TreeNode node, Match match)
        {
            for (int i = 0; i < match.Groups.Count;i++ )
            {
                Group group = match.Groups[i];
                string Value = string.Format("[{0}]:{1}", i, group.Value);
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
        
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void spcFirst_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
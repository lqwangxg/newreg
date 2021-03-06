using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace Wxg.UI.Forms
{
    public class HighLight
    {
        private RichTextBox txtbox;
        private Font oldFont;
        private Color oldBackColor;
        private Color oldForeColor;
        public HighLight(RichTextBox richTxtBox)
        {
            txtbox = richTxtBox;
            oldFont = richTxtBox.Font;
            oldForeColor = richTxtBox.ForeColor;
            oldBackColor = richTxtBox.BackColor;
        }

        public void Highlight(string highvalue)
        {
            int start = txtbox.Find(highvalue, 0, RichTextBoxFinds.None);
            while (start >= 0 && start < txtbox.Text.Length)
            {
                Highlight( start,highvalue.Length);
                start = start + highvalue.Length;
                start = txtbox.Find(highvalue, start, RichTextBoxFinds.None);
            }
        }

        public void Highlight(Match match)
        {
            Highlight(match.Index, match.Length);
        }

        public void Highlight(int start, int length)
        {
            Font f = new Font(txtbox.Font.FontFamily, txtbox.Font.Size, FontStyle.Bold);
            Highlight( start, length, f, Color.Black, Color.Yellow);
        }

        public void Highlight(int start, int length, 
            Font f, Color foreColor, Color backColor)
        {
            int selectstart = txtbox.SelectionStart;
            
            txtbox.SelectionStart = start;
            txtbox.SelectionLength = length;

            txtbox.SelectionColor = foreColor;
            txtbox.SelectionBackColor = backColor;
            txtbox.SelectionFont = f;

            txtbox.SelectionStart = selectstart;
            txtbox.SelectionLength = 0;
        }

        public void Reset2Default()
        {
            int selectstart = txtbox.SelectionStart;

            Highlight(0, txtbox.Text.Length, oldFont, oldForeColor, oldBackColor);

            txtbox.SelectionStart = selectstart;
            txtbox.SelectionLength = 0;
        }
        
    }
}

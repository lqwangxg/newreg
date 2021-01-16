using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Wxg.Replace
{
    public partial class FrmEditor : Form
    {
        private string thisFile = string.Empty;

        public string ThisFile
        {
            set { thisFile = value; }
        }

        public FrmEditor()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!string.IsNullOrEmpty(thisFile) && File.Exists(thisFile))
            {
                txtContent.Text = File.ReadAllText(dlgOpen.FileName);
                this.Text = string.Format("FrmEditor: {0}", thisFile);
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    btnOpen_Click(sender, e);
                    break;
                case Keys.F6:
                    btnSave_Click(sender, e);
                    break;
                case Keys.F7:
                    btnSaveAs_Click(sender, e);
                    break;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                thisFile = dlgOpen.FileName;
                txtContent.Text = File.ReadAllText(dlgOpen.FileName);
                this.Text = string.Format("FrmEditor: {0}", thisFile);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(thisFile))
            {
                btnSaveAs_Click(sender, e);
            }
            else
            {
                File.WriteAllText(thisFile, txtContent.Text);
                this.Text = string.Format("FrmEditor: {0}", thisFile);
            }
            
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                thisFile = dlgSave.FileName;
                File.WriteAllText(thisFile, txtContent.Text);
                this.Text = string.Format("FrmEditor: {0}", thisFile);
            }
        }
    }
}
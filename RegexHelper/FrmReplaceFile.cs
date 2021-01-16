using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Wxg.Replace;
using Wxg.UI.Forms;
using Wxg.IO;
using Wxg.Utils;

namespace Wxg
{
    public partial class FrmReplaceFile : Form
    {
        #region fields and properties
        /// <summary>
        /// Pattern Config Loader
        /// </summary>
        private static ReplaceLoader patternLoader;
        /// <summary>
        /// Get Pattern Config Loader.
        /// </summary>
        public static ReplaceLoader PatternLoader
        {
            get {

                //if (File.Exists(PatternConfigFile))
                //{
                //    patternLoader = ReplaceTemplates.GetInstance();
                //    patternLoader.LoadXml(PatternConfigFile);
                //}
                //else
                //{
                //    throw new FileNotFoundException("[replacepatterns] xml file is not found. ");
                //}
                //return patternLoader; 
                return null;
            }
        }
        /// <summary>
        /// Replace Files 
        /// </summary>
        private List<string> lstFiles = new List<string>();
        /// <summary>
        /// Pattern Config File
        /// </summary>
        private static string patternConfigFile = string.Empty;
        
        /// <summary>
        /// Get or Set Pattern Config File Path.
        /// </summary>
        public static string PatternConfigFile
        {
            get 
            {
                if (string.IsNullOrEmpty(patternConfigFile))
                {
                    string filename = Xmler.GetAppSettingValue("replacepatterns");
                    patternConfigFile = Path.Combine(FileHelper.AssemblyPath, filename);
                }
                return patternConfigFile;
            }
            set { patternConfigFile = value; }
        }
        #endregion

        /// <summary>
        /// Form Construction
        /// </summary>
        public FrmReplaceFile()
        {
            InitializeComponent();
            cmbPattern.DataSource = PatternLoader.Templates;
            cmbPattern.DisplayMember = "Key";
        }
        #region File select 
        /// <summary>
        /// Drag and Drop Files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFiles_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            string[] files = (string[])e.Data.GetData("FileDrop");
            
            foreach (string file in files)
            {
                if (File.Exists(file) && !lstFiles.Contains(file))
                {
                    lstFiles.Add(file);
                    txtFiles.AppendText(file);
                    txtFiles.AppendText(Environment.NewLine);
                }
            }
        }
        /// <summary>
        /// Drag file enter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        /// <summary>
        /// double click for select files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFiles_DoubleClick(object sender, EventArgs e)
        {
            if (dlgFile.ShowDialog() == DialogResult.OK)
            {

                string[] files = dlgFile.FileNames;

                foreach (string file in files)
                {
                    if (File.Exists(file) && !lstFiles.Contains(file))
                    {
                        lstFiles.Add(file);
                        txtFiles.AppendText(file);
                        txtFiles.AppendText(Environment.NewLine);
                    }
                }
            }
        }
        #endregion

        #region do and clear
        /// <summary>
        /// Do File Replace 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {

            HighLight hl = new HighLight(txtFiles);
            hl.Reset2Default();

            if (txtFiles.Lines.Length == 0)
            {
                txtFiles_DoubleClick(sender, e);
                return;
            }

            if (string.IsNullOrEmpty(cmbPattern.Text))
            {
                MessageBox.Show("Please select a pattern !");
                return;
            }

            ReplaceTemplate pattern = patternLoader[cmbPattern.Text];
            ReplaceFactory.ReplaceFiles(txtFiles.Lines, pattern, hl.Highlight);
        }

        /// <summary>
        /// Clear the target files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            lstFiles.Clear();
            txtFiles.Clear();
            HighLight hl = new HighLight(txtFiles);
            hl.Reset2Default();
        }
        #endregion

    }
}
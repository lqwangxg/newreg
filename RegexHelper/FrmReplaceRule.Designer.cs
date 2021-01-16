namespace Wxg.Replace
{
    partial class FrmReplaceRule
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReplaceRule));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMultiline = new System.Windows.Forms.ToolStripButton();
            this.btnIgnoreCase = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.grpReplace = new System.Windows.Forms.GroupBox();
            this.txtReplaceRule = new System.Windows.Forms.RichTextBox();
            this.toolStrip.SuspendLayout();
            this.grpReplace.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.btnMultiline,
            this.btnIgnoreCase,
            this.toolStripSeparator2,
            this.helpToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(669, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "ToolStrip";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "新規";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "開く";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "上書き保存";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnMultiline
            // 
            this.btnMultiline.Checked = true;
            this.btnMultiline.CheckOnClick = true;
            this.btnMultiline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnMultiline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMultiline.Image = ((System.Drawing.Image)(resources.GetObject("btnMultiline.Image")));
            this.btnMultiline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMultiline.Name = "btnMultiline";
            this.btnMultiline.Size = new System.Drawing.Size(69, 22);
            this.btnMultiline.Text = "Multiline(&M)";
            // 
            // btnIgnoreCase
            // 
            this.btnIgnoreCase.Checked = true;
            this.btnIgnoreCase.CheckOnClick = true;
            this.btnIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnIgnoreCase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnIgnoreCase.Image = ((System.Drawing.Image)(resources.GetObject("btnIgnoreCase.Image")));
            this.btnIgnoreCase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIgnoreCase.Name = "btnIgnoreCase";
            this.btnIgnoreCase.Size = new System.Drawing.Size(82, 22);
            this.btnIgnoreCase.Text = "IgnoreCase(&C)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "ヘルプ";
            // 
            // grpReplace
            // 
            this.grpReplace.BackColor = System.Drawing.Color.Transparent;
            this.grpReplace.Controls.Add(this.txtReplaceRule);
            this.grpReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReplace.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpReplace.Location = new System.Drawing.Point(0, 25);
            this.grpReplace.Name = "grpReplace";
            this.grpReplace.Size = new System.Drawing.Size(669, 480);
            this.grpReplace.TabIndex = 3;
            this.grpReplace.TabStop = false;
            this.grpReplace.Text = "Replace Rule";
            // 
            // txtReplaceRule
            // 
            this.txtReplaceRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReplaceRule.Location = new System.Drawing.Point(3, 18);
            this.txtReplaceRule.Name = "txtReplaceRule";
            this.txtReplaceRule.Size = new System.Drawing.Size(663, 459);
            this.txtReplaceRule.TabIndex = 0;
            this.txtReplaceRule.Text = "";
            // 
            // FrmReplaceRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 505);
            this.Controls.Add(this.grpReplace);
            this.Controls.Add(this.toolStrip);
            this.Name = "FrmReplaceRule";
            this.Text = "FrmReplaceRule";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpReplace.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnMultiline;
        private System.Windows.Forms.ToolStripButton btnIgnoreCase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.GroupBox grpReplace;
        private System.Windows.Forms.RichTextBox txtReplaceRule;

    }
}
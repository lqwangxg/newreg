namespace Wxg.Replace
{
    partial class Regexer
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.spcFrame = new System.Windows.Forms.SplitContainer();
            this.spcLeft = new System.Windows.Forms.SplitContainer();
            this.grpMatch = new System.Windows.Forms.GroupBox();
            this.txtPattern = new System.Windows.Forms.RichTextBox();
            this.spcResult = new System.Windows.Forms.SplitContainer();
            this.tabResult = new System.Windows.Forms.TabControl();
            this.tpMatch = new System.Windows.Forms.TabPage();
            this.spcMatch = new System.Windows.Forms.SplitContainer();
            this.txtInput = new System.Windows.Forms.RichTextBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.tabReplaceRules = new System.Windows.Forms.TabPage();
            this.txtReplaceRule = new System.Windows.Forms.RichTextBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.tcRight = new System.Windows.Forms.TabControl();
            this.tabMatches = new System.Windows.Forms.TabPage();
            this.treeMatch = new System.Windows.Forms.TreeView();
            this.tabTemplates = new System.Windows.Forms.TabPage();
            this.treeTemplate = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.spcFrame)).BeginInit();
            this.spcFrame.Panel1.SuspendLayout();
            this.spcFrame.Panel2.SuspendLayout();
            this.spcFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft)).BeginInit();
            this.spcLeft.Panel1.SuspendLayout();
            this.spcLeft.Panel2.SuspendLayout();
            this.spcLeft.SuspendLayout();
            this.grpMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcResult)).BeginInit();
            this.spcResult.Panel1.SuspendLayout();
            this.spcResult.Panel2.SuspendLayout();
            this.spcResult.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.tpMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMatch)).BeginInit();
            this.spcMatch.Panel1.SuspendLayout();
            this.spcMatch.Panel2.SuspendLayout();
            this.spcMatch.SuspendLayout();
            this.tabReplaceRules.SuspendLayout();
            this.tcRight.SuspendLayout();
            this.tabMatches.SuspendLayout();
            this.tabTemplates.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcFrame
            // 
            this.spcFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcFrame.Location = new System.Drawing.Point(0, 0);
            this.spcFrame.Name = "spcFrame";
            // 
            // spcFrame.Panel1
            // 
            this.spcFrame.Panel1.Controls.Add(this.spcLeft);
            // 
            // spcFrame.Panel2
            // 
            this.spcFrame.Panel2.Controls.Add(this.tcRight);
            this.spcFrame.Size = new System.Drawing.Size(785, 636);
            this.spcFrame.SplitterDistance = 526;
            this.spcFrame.SplitterWidth = 2;
            this.spcFrame.TabIndex = 1;
            this.spcFrame.TabStop = false;
            // 
            // spcLeft
            // 
            this.spcLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcLeft.IsSplitterFixed = true;
            this.spcLeft.Location = new System.Drawing.Point(0, 0);
            this.spcLeft.Name = "spcLeft";
            this.spcLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcLeft.Panel1
            // 
            this.spcLeft.Panel1.AutoScroll = true;
            this.spcLeft.Panel1.AutoScrollMinSize = new System.Drawing.Size(0, 50);
            this.spcLeft.Panel1.Controls.Add(this.grpMatch);
            // 
            // spcLeft.Panel2
            // 
            this.spcLeft.Panel2.Controls.Add(this.spcResult);
            this.spcLeft.Size = new System.Drawing.Size(526, 636);
            this.spcLeft.SplitterDistance = 69;
            this.spcLeft.SplitterWidth = 5;
            this.spcLeft.TabIndex = 0;
            this.spcLeft.TabStop = false;
            // 
            // grpMatch
            // 
            this.grpMatch.BackColor = System.Drawing.Color.Transparent;
            this.grpMatch.Controls.Add(this.txtPattern);
            this.grpMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMatch.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpMatch.Location = new System.Drawing.Point(0, 0);
            this.grpMatch.Name = "grpMatch";
            this.grpMatch.Size = new System.Drawing.Size(526, 69);
            this.grpMatch.TabIndex = 2;
            this.grpMatch.TabStop = false;
            this.grpMatch.Text = "Pattern";
            // 
            // txtPattern
            // 
            this.txtPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPattern.Location = new System.Drawing.Point(3, 18);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(520, 48);
            this.txtPattern.TabIndex = 0;
            this.txtPattern.Text = "";
            // 
            // spcResult
            // 
            this.spcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcResult.Location = new System.Drawing.Point(0, 0);
            this.spcResult.Name = "spcResult";
            this.spcResult.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcResult.Panel1
            // 
            this.spcResult.Panel1.Controls.Add(this.tabResult);
            // 
            // spcResult.Panel2
            // 
            this.spcResult.Panel2.Controls.Add(this.txtLog);
            this.spcResult.Size = new System.Drawing.Size(526, 562);
            this.spcResult.SplitterDistance = 523;
            this.spcResult.SplitterWidth = 2;
            this.spcResult.TabIndex = 1;
            this.spcResult.TabStop = false;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.tpMatch);
            this.tabResult.Controls.Add(this.tabReplaceRules);
            this.tabResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResult.Location = new System.Drawing.Point(0, 0);
            this.tabResult.Name = "tabResult";
            this.tabResult.SelectedIndex = 0;
            this.tabResult.Size = new System.Drawing.Size(526, 523);
            this.tabResult.TabIndex = 3;
            this.tabResult.TabStop = false;
            // 
            // tpMatch
            // 
            this.tpMatch.Controls.Add(this.spcMatch);
            this.tpMatch.Location = new System.Drawing.Point(4, 21);
            this.tpMatch.Name = "tpMatch";
            this.tpMatch.Padding = new System.Windows.Forms.Padding(3);
            this.tpMatch.Size = new System.Drawing.Size(518, 498);
            this.tpMatch.TabIndex = 0;
            this.tpMatch.Text = "Match/Replace Result";
            this.tpMatch.UseVisualStyleBackColor = true;
            // 
            // spcMatch
            // 
            this.spcMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMatch.Location = new System.Drawing.Point(3, 3);
            this.spcMatch.Name = "spcMatch";
            // 
            // spcMatch.Panel1
            // 
            this.spcMatch.Panel1.Controls.Add(this.txtInput);
            // 
            // spcMatch.Panel2
            // 
            this.spcMatch.Panel2.Controls.Add(this.txtResult);
            this.spcMatch.Panel2MinSize = 0;
            this.spcMatch.Size = new System.Drawing.Size(512, 492);
            this.spcMatch.SplitterDistance = 482;
            this.spcMatch.SplitterWidth = 2;
            this.spcMatch.TabIndex = 3;
            this.spcMatch.TabStop = false;
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Location = new System.Drawing.Point(0, 0);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(482, 492);
            this.txtInput.TabIndex = 2;
            this.txtInput.Text = "";
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(0, 0);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(28, 492);
            this.txtResult.TabIndex = 4;
            this.txtResult.TabStop = false;
            this.txtResult.Text = "";
            // 
            // tabReplaceRules
            // 
            this.tabReplaceRules.Controls.Add(this.txtReplaceRule);
            this.tabReplaceRules.Location = new System.Drawing.Point(4, 21);
            this.tabReplaceRules.Name = "tabReplaceRules";
            this.tabReplaceRules.Size = new System.Drawing.Size(518, 498);
            this.tabReplaceRules.TabIndex = 2;
            this.tabReplaceRules.Text = "Replace Rules";
            this.tabReplaceRules.UseVisualStyleBackColor = true;
            // 
            // txtReplaceRule
            // 
            this.txtReplaceRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReplaceRule.Location = new System.Drawing.Point(0, 0);
            this.txtReplaceRule.Name = "txtReplaceRule";
            this.txtReplaceRule.Size = new System.Drawing.Size(518, 498);
            this.txtReplaceRule.TabIndex = 1;
            this.txtReplaceRule.Text = "";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(526, 37);
            this.txtLog.TabIndex = 7;
            this.txtLog.TabStop = false;
            this.txtLog.Text = "";
            // 
            // tcRight
            // 
            this.tcRight.Controls.Add(this.tabMatches);
            this.tcRight.Controls.Add(this.tabTemplates);
            this.tcRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcRight.Location = new System.Drawing.Point(0, 0);
            this.tcRight.Name = "tcRight";
            this.tcRight.SelectedIndex = 0;
            this.tcRight.Size = new System.Drawing.Size(257, 636);
            this.tcRight.TabIndex = 1;
            this.tcRight.TabStop = false;
            // 
            // tabMatches
            // 
            this.tabMatches.Controls.Add(this.treeMatch);
            this.tabMatches.Location = new System.Drawing.Point(4, 21);
            this.tabMatches.Name = "tabMatches";
            this.tabMatches.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatches.Size = new System.Drawing.Size(249, 611);
            this.tabMatches.TabIndex = 0;
            this.tabMatches.Text = "Matches";
            this.tabMatches.UseVisualStyleBackColor = true;
            // 
            // treeMatch
            // 
            this.treeMatch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.treeMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMatch.Location = new System.Drawing.Point(3, 3);
            this.treeMatch.Name = "treeMatch";
            this.treeMatch.Size = new System.Drawing.Size(243, 605);
            this.treeMatch.TabIndex = 3;
            this.treeMatch.TabStop = false;
            // 
            // tabTemplates
            // 
            this.tabTemplates.Controls.Add(this.treeTemplate);
            this.tabTemplates.Location = new System.Drawing.Point(4, 21);
            this.tabTemplates.Name = "tabTemplates";
            this.tabTemplates.Padding = new System.Windows.Forms.Padding(3);
            this.tabTemplates.Size = new System.Drawing.Size(249, 611);
            this.tabTemplates.TabIndex = 1;
            this.tabTemplates.Text = "Templates";
            this.tabTemplates.UseVisualStyleBackColor = true;
            // 
            // treeTemplate
            // 
            this.treeTemplate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.treeTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTemplate.Location = new System.Drawing.Point(3, 3);
            this.treeTemplate.Name = "treeTemplate";
            this.treeTemplate.Size = new System.Drawing.Size(272, 670);
            this.treeTemplate.TabIndex = 2;
            this.treeTemplate.TabStop = false;
            // 
            // Regexer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcFrame);
            this.Name = "Regexer";
            this.Size = new System.Drawing.Size(785, 636);
            this.spcFrame.Panel1.ResumeLayout(false);
            this.spcFrame.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcFrame)).EndInit();
            this.spcFrame.ResumeLayout(false);
            this.spcLeft.Panel1.ResumeLayout(false);
            this.spcLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft)).EndInit();
            this.spcLeft.ResumeLayout(false);
            this.grpMatch.ResumeLayout(false);
            this.spcResult.Panel1.ResumeLayout(false);
            this.spcResult.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcResult)).EndInit();
            this.spcResult.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            this.tpMatch.ResumeLayout(false);
            this.spcMatch.Panel1.ResumeLayout(false);
            this.spcMatch.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMatch)).EndInit();
            this.spcMatch.ResumeLayout(false);
            this.tabReplaceRules.ResumeLayout(false);
            this.tcRight.ResumeLayout(false);
            this.tabMatches.ResumeLayout(false);
            this.tabTemplates.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcFrame;
        private System.Windows.Forms.SplitContainer spcLeft;
        private System.Windows.Forms.GroupBox grpMatch;
        private System.Windows.Forms.RichTextBox txtPattern;
        private System.Windows.Forms.SplitContainer spcResult;
        private System.Windows.Forms.TabControl tabResult;
        private System.Windows.Forms.TabPage tpMatch;
        private System.Windows.Forms.SplitContainer spcMatch;
        private System.Windows.Forms.RichTextBox txtInput;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.TabPage tabReplaceRules;
        private System.Windows.Forms.RichTextBox txtReplaceRule;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.TabControl tcRight;
        private System.Windows.Forms.TabPage tabMatches;
        private System.Windows.Forms.TreeView treeMatch;
        private System.Windows.Forms.TabPage tabTemplates;
        private System.Windows.Forms.TreeView treeTemplate;
    }
}

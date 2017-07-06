namespace WindowsFormsApplication1
{
    partial class ShiftReportPPTGenerator
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.openDataExcelButton = new System.Windows.Forms.Button();
            this.viewDataButton = new System.Windows.Forms.Button();
            this.outputPPTButton = new System.Windows.Forms.Button();
            this.outputFilteredExcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.filterThresholdTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 248);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(300, 25);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Excel文件：";
            // 
            // openDataExcelButton
            // 
            this.openDataExcelButton.Location = new System.Drawing.Point(164, 9);
            this.openDataExcelButton.Name = "openDataExcelButton";
            this.openDataExcelButton.Size = new System.Drawing.Size(113, 23);
            this.openDataExcelButton.TabIndex = 10;
            this.openDataExcelButton.Text = "打开文件";
            this.openDataExcelButton.UseVisualStyleBackColor = true;
            this.openDataExcelButton.Click += new System.EventHandler(this.openDataExcelButton_Click);
            // 
            // viewDataButton
            // 
            this.viewDataButton.Location = new System.Drawing.Point(16, 57);
            this.viewDataButton.Name = "viewDataButton";
            this.viewDataButton.Size = new System.Drawing.Size(261, 24);
            this.viewDataButton.TabIndex = 13;
            this.viewDataButton.Text = "查看Excel数据";
            this.viewDataButton.UseVisualStyleBackColor = true;
            this.viewDataButton.Click += new System.EventHandler(this.viewDataButton_Click);
            // 
            // outputPPTButton
            // 
            this.outputPPTButton.Location = new System.Drawing.Point(16, 96);
            this.outputPPTButton.Name = "outputPPTButton";
            this.outputPPTButton.Size = new System.Drawing.Size(261, 23);
            this.outputPPTButton.TabIndex = 14;
            this.outputPPTButton.Text = "输出PPT";
            this.outputPPTButton.UseVisualStyleBackColor = true;
            this.outputPPTButton.Click += new System.EventHandler(this.outputPPTButton_Click);
            // 
            // outputFilteredExcel
            // 
            this.outputFilteredExcel.Location = new System.Drawing.Point(16, 186);
            this.outputFilteredExcel.Name = "outputFilteredExcel";
            this.outputFilteredExcel.Size = new System.Drawing.Size(261, 23);
            this.outputFilteredExcel.TabIndex = 15;
            this.outputFilteredExcel.Text = "输出过滤后的Excel（按城市分类）";
            this.outputFilteredExcel.UseVisualStyleBackColor = true;
            this.outputFilteredExcel.Click += new System.EventHandler(this.outputFilteredExcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "过滤小于";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "的品牌";
            // 
            // filterThresholdTextBox
            // 
            this.filterThresholdTextBox.Location = new System.Drawing.Point(85, 158);
            this.filterThresholdTextBox.Name = "filterThresholdTextBox";
            this.filterThresholdTextBox.Size = new System.Drawing.Size(117, 25);
            this.filterThresholdTextBox.TabIndex = 17;
            this.filterThresholdTextBox.Text = "10000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 273);
            this.Controls.Add(this.filterThresholdTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputFilteredExcel);
            this.Controls.Add(this.outputPPTButton);
            this.Controls.Add(this.viewDataButton);
            this.Controls.Add(this.openDataExcelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openDataExcelButton;
        private System.Windows.Forms.Button viewDataButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button outputPPTButton;
        private System.Windows.Forms.Button outputFilteredExcel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox filterThresholdTextBox;
    }
}


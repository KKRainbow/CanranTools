namespace WindowsFormsApplication1
{
    partial class KAOConsumerPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectRowDataExcelButton = new System.Windows.Forms.Button();
            this.OutputModelButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.OutputSummaryButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectRowDataExcelButton
            // 
            this.SelectRowDataExcelButton.Location = new System.Drawing.Point(64, 100);
            this.SelectRowDataExcelButton.Name = "SelectRowDataExcelButton";
            this.SelectRowDataExcelButton.Size = new System.Drawing.Size(161, 23);
            this.SelectRowDataExcelButton.TabIndex = 0;
            this.SelectRowDataExcelButton.Text = "选择原始数据Excel";
            this.SelectRowDataExcelButton.UseVisualStyleBackColor = true;
            this.SelectRowDataExcelButton.Click += new System.EventHandler(this.SelectRowDataExcelButton_Click);
            // 
            // OutputModelButton
            // 
            this.OutputModelButton.Location = new System.Drawing.Point(64, 144);
            this.OutputModelButton.Name = "OutputModelButton";
            this.OutputModelButton.Size = new System.Drawing.Size(161, 23);
            this.OutputModelButton.TabIndex = 1;
            this.OutputModelButton.Text = "输出Model结果";
            this.OutputModelButton.UseVisualStyleBackColor = true;
            this.OutputModelButton.Click += new System.EventHandler(this.OutputModelButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 263);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(607, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoToolTip = true;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 19);
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OutputSummaryButton
            // 
            this.OutputSummaryButton.Location = new System.Drawing.Point(64, 183);
            this.OutputSummaryButton.Name = "OutputSummaryButton";
            this.OutputSummaryButton.Size = new System.Drawing.Size(161, 23);
            this.OutputSummaryButton.TabIndex = 1;
            this.OutputSummaryButton.Text = "输出Summary结果";
            this.OutputSummaryButton.UseVisualStyleBackColor = true;
            this.OutputSummaryButton.Click += new System.EventHandler(this.OutputSummaryButton_Click);
            // 
            // KAOConsumerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 285);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.OutputSummaryButton);
            this.Controls.Add(this.OutputModelButton);
            this.Controls.Add(this.SelectRowDataExcelButton);
            this.Name = "KAOConsumerPanel";
            this.Text = "KAOConsumerPanel";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectRowDataExcelButton;
        private System.Windows.Forms.Button OutputModelButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button OutputSummaryButton;
    }
}
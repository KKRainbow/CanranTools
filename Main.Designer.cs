namespace WindowsFormsApplication1
{
    partial class Main
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
            this.KAOConsumberPanelButton = new System.Windows.Forms.Button();
            this.ShiftReportPPT = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KAOConsumberPanelButton
            // 
            this.KAOConsumberPanelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KAOConsumberPanelButton.Location = new System.Drawing.Point(3, 108);
            this.KAOConsumberPanelButton.Name = "KAOConsumberPanelButton";
            this.KAOConsumberPanelButton.Size = new System.Drawing.Size(557, 99);
            this.KAOConsumberPanelButton.TabIndex = 0;
            this.KAOConsumberPanelButton.Text = "KAO Consumer Panel Model数据自动拷贝";
            this.KAOConsumberPanelButton.UseVisualStyleBackColor = true;
            this.KAOConsumberPanelButton.Click += new System.EventHandler(this.KAOConsumberPanelButton_Click);
            // 
            // ShiftReportPPT
            // 
            this.ShiftReportPPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShiftReportPPT.Location = new System.Drawing.Point(3, 213);
            this.ShiftReportPPT.Name = "ShiftReportPPT";
            this.ShiftReportPPT.Size = new System.Drawing.Size(557, 99);
            this.ShiftReportPPT.TabIndex = 0;
            this.ShiftReportPPT.Text = "得失报告由Excel生成PPT";
            this.ShiftReportPPT.UseVisualStyleBackColor = true;
            this.ShiftReportPPT.Click += new System.EventHandler(this.ShiftReportPPT_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ShiftReportPPT, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.KAOConsumberPanelButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(704, 527);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(557, 105);
            this.label1.TabIndex = 1;
            this.label1.Text = "工具名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(566, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 105);
            this.label2.TabIndex = 2;
            this.label2.Text = "说明";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 527);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Main";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button KAOConsumberPanelButton;
        private System.Windows.Forms.Button ShiftReportPPT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
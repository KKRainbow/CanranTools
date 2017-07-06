namespace WindowsFormsApplication1
{
    partial class DataViewer
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
            this.provinceDropdown = new System.Windows.Forms.ComboBox();
            this.listView = new System.Windows.Forms.ListView();
            this.dataView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // provinceDropdown
            // 
            this.provinceDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.provinceDropdown.FormattingEnabled = true;
            this.provinceDropdown.Location = new System.Drawing.Point(34, 43);
            this.provinceDropdown.Margin = new System.Windows.Forms.Padding(4);
            this.provinceDropdown.Name = "provinceDropdown";
            this.provinceDropdown.Size = new System.Drawing.Size(240, 23);
            this.provinceDropdown.TabIndex = 9;
            this.provinceDropdown.SelectedIndexChanged += new System.EventHandler(this.provinceDropdown_SelectedIndexChanged);
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(34, 75);
            this.listView.Margin = new System.Windows.Forms.Padding(4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(240, 440);
            this.listView.TabIndex = 8;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // dataView
            // 
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Location = new System.Drawing.Point(283, 7);
            this.dataView.Margin = new System.Windows.Forms.Padding(4);
            this.dataView.Name = "dataView";
            this.dataView.RowTemplate.Height = 23;
            this.dataView.Size = new System.Drawing.Size(623, 510);
            this.dataView.TabIndex = 7;
            // 
            // DataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 525);
            this.Controls.Add(this.provinceDropdown);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.dataView);
            this.Name = "DataViewer";
            this.Text = "DataViewer";
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox provinceDropdown;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.DataGridView dataView;
    }
}
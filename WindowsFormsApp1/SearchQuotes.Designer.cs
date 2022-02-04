namespace MegaDesk2
{
    partial class SearchQuotes
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
            this.searchBMT = new System.Windows.Forms.ComboBox();
            this.buttonBackFromSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SearchDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBMT
            // 
            this.searchBMT.FormattingEnabled = true;
            this.searchBMT.Location = new System.Drawing.Point(242, 12);
            this.searchBMT.Name = "searchBMT";
            this.searchBMT.Size = new System.Drawing.Size(121, 21);
            this.searchBMT.TabIndex = 0;
            this.searchBMT.SelectedValueChanged += new System.EventHandler(this.searchBMT_SelectedValueChanged);
            // 
            // buttonBackFromSearch
            // 
            this.buttonBackFromSearch.BackColor = System.Drawing.Color.Black;
            this.buttonBackFromSearch.Font = new System.Drawing.Font("Lucida Sans Unicode", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackFromSearch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBackFromSearch.Location = new System.Drawing.Point(458, 351);
            this.buttonBackFromSearch.Name = "buttonBackFromSearch";
            this.buttonBackFromSearch.Size = new System.Drawing.Size(239, 48);
            this.buttonBackFromSearch.TabIndex = 1;
            this.buttonBackFromSearch.Text = "Back";
            this.buttonBackFromSearch.UseVisualStyleBackColor = false;
            this.buttonBackFromSearch.Click += new System.EventHandler(this.goBackToMain);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search By Material Type";
            // 
            // SearchDataGridView
            // 
            this.SearchDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SearchDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.SearchDataGridView.Location = new System.Drawing.Point(12, 39);
            this.SearchDataGridView.Name = "SearchDataGridView";
            this.SearchDataGridView.Size = new System.Drawing.Size(685, 306);
            this.SearchDataGridView.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Customer";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Date";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Material";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quote Total";
            this.Column4.Name = "Column4";
            // 
            // SearchQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 411);
            this.ControlBox = false;
            this.Controls.Add(this.SearchDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBackFromSearch);
            this.Controls.Add(this.searchBMT);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchQuotes";
            this.Text = "SearchQuotes";
            ((System.ComponentModel.ISupportInitialize)(this.SearchDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox searchBMT;
        private System.Windows.Forms.Button buttonBackFromSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SearchDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
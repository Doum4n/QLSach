namespace QLSach.view
{
    partial class RecentUpdateByGenre
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lb_genre = new Label();
            tablePane_recentUpdate = new TableLayoutPanel();
            SuspendLayout();
            // 
            // lb_genre
            // 
            lb_genre.AutoSize = true;
            lb_genre.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_genre.Location = new Point(20, 19);
            lb_genre.Name = "lb_genre";
            lb_genre.Size = new Size(76, 31);
            lb_genre.TabIndex = 0;
            lb_genre.Text = "label1";
            // 
            // tablePane_recentUpdate
            // 
            tablePane_recentUpdate.AutoSize = true;
            tablePane_recentUpdate.ColumnCount = 1;
            tablePane_recentUpdate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePane_recentUpdate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePane_recentUpdate.Location = new Point(20, 68);
            tablePane_recentUpdate.Name = "tablePane_recentUpdate";
            tablePane_recentUpdate.RowCount = 1;
            tablePane_recentUpdate.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePane_recentUpdate.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePane_recentUpdate.Size = new Size(214, 222);
            tablePane_recentUpdate.TabIndex = 1;
            // 
            // RecentUpdateByGenre
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tablePane_recentUpdate);
            Controls.Add(lb_genre);
            Name = "RecentUpdateByGenre";
            Size = new Size(860, 330);
            Load += RecentUpdateByGenre_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_genre;
        private TableLayoutPanel tablePane_recentUpdate;
    }
}

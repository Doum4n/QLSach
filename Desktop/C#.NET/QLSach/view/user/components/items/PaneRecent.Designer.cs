namespace QLSach.view.components.items
{
    partial class PaneRecent
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            more_newlyBook = new Guna.UI2.WinForms.Guna2Button();
            tbLayoutPanel = new TableLayoutPanel();
            SuspendLayout();
            // 
            // more_newlyBook
            // 
            more_newlyBook.CustomizableEdges = customizableEdges1;
            more_newlyBook.DisabledState.BorderColor = Color.DarkGray;
            more_newlyBook.DisabledState.CustomBorderColor = Color.DarkGray;
            more_newlyBook.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            more_newlyBook.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            more_newlyBook.FillColor = Color.FromArgb(67, 104, 80);
            more_newlyBook.Font = new Font("Segoe UI", 9F);
            more_newlyBook.ForeColor = Color.White;
            more_newlyBook.Location = new Point(689, 16);
            more_newlyBook.Margin = new Padding(3, 4, 3, 4);
            more_newlyBook.Name = "more_newlyBook";
            more_newlyBook.ShadowDecoration.CustomizableEdges = customizableEdges2;
            more_newlyBook.Size = new Size(125, 40);
            more_newlyBook.TabIndex = 14;
            more_newlyBook.Text = "Xem thêm";
            more_newlyBook.Click += more_newlyBook_Click;
            // 
            // tbLayoutPanel
            // 
            tbLayoutPanel.AutoSize = true;
            tbLayoutPanel.BackColor = Color.FromArgb(251, 250, 218);
            tbLayoutPanel.ColumnCount = 1;
            tbLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutPanel.Location = new Point(13, 89);
            tbLayoutPanel.Name = "tbLayoutPanel";
            tbLayoutPanel.RowCount = 1;
            tbLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbLayoutPanel.Size = new Size(186, 207);
            tbLayoutPanel.TabIndex = 15;
            // 
            // PaneRecent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            Controls.Add(more_newlyBook);
            Controls.Add(tbLayoutPanel);
            Name = "PaneRecent";
            Size = new Size(834, 306);
            Load += PaneRecent_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button more_newlyBook;
        private TableLayoutPanel tbLayoutPanel;
    }
}

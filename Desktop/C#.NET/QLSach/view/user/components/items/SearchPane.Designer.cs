namespace QLSach.view.user.components.items
{
    partial class SearchPane
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            tablePane_recentUpdate = new TableLayoutPanel();
            lb_SearchString = new Label();
            btn_last = new Guna.UI2.WinForms.Guna2Button();
            btn_first = new Guna.UI2.WinForms.Guna2Button();
            btn_next = new Guna.UI2.WinForms.Guna2Button();
            btn_previous = new Guna.UI2.WinForms.Guna2Button();
            lb_index = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 29);
            label1.Name = "label1";
            label1.Size = new Size(214, 20);
            label1.TabIndex = 0;
            label1.Text = "Thông tin tìm kiếm cho tác giả:";
            // 
            // tablePane_recentUpdate
            // 
            tablePane_recentUpdate.AutoSize = true;
            tablePane_recentUpdate.ColumnCount = 1;
            tablePane_recentUpdate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePane_recentUpdate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablePane_recentUpdate.Location = new Point(23, 74);
            tablePane_recentUpdate.Name = "tablePane_recentUpdate";
            tablePane_recentUpdate.RowCount = 1;
            tablePane_recentUpdate.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePane_recentUpdate.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablePane_recentUpdate.Size = new Size(250, 125);
            tablePane_recentUpdate.TabIndex = 1;
            // 
            // lb_SearchString
            // 
            lb_SearchString.AutoSize = true;
            lb_SearchString.Location = new Point(243, 29);
            lb_SearchString.Name = "lb_SearchString";
            lb_SearchString.Size = new Size(50, 20);
            lb_SearchString.TabIndex = 2;
            lb_SearchString.Text = "label2";
            // 
            // btn_last
            // 
            btn_last.CustomizableEdges = customizableEdges1;
            btn_last.DisabledState.BorderColor = Color.DarkGray;
            btn_last.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_last.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_last.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_last.Font = new Font("Segoe UI", 9F);
            btn_last.ForeColor = Color.White;
            btn_last.Location = new Point(847, 615);
            btn_last.Name = "btn_last";
            btn_last.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_last.Size = new Size(129, 40);
            btn_last.TabIndex = 12;
            btn_last.Text = "Trang cuối";
            btn_last.Click += btn_last_Click;
            // 
            // btn_first
            // 
            btn_first.CustomizableEdges = customizableEdges3;
            btn_first.DisabledState.BorderColor = Color.DarkGray;
            btn_first.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_first.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_first.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_first.Font = new Font("Segoe UI", 9F);
            btn_first.ForeColor = Color.White;
            btn_first.Location = new Point(398, 615);
            btn_first.Name = "btn_first";
            btn_first.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_first.Size = new Size(129, 40);
            btn_first.TabIndex = 11;
            btn_first.Text = "Trang đầu";
            btn_first.Click += btn_first_Click;
            // 
            // btn_next
            // 
            btn_next.CustomizableEdges = customizableEdges5;
            btn_next.DisabledState.BorderColor = Color.DarkGray;
            btn_next.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_next.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_next.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_next.Font = new Font("Segoe UI", 9F);
            btn_next.ForeColor = Color.White;
            btn_next.Location = new Point(703, 615);
            btn_next.Name = "btn_next";
            btn_next.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_next.Size = new Size(129, 40);
            btn_next.TabIndex = 10;
            btn_next.Text = "Trang kế";
            btn_next.Click += btn_next_Click;
            // 
            // btn_previous
            // 
            btn_previous.CustomizableEdges = customizableEdges7;
            btn_previous.DisabledState.BorderColor = Color.DarkGray;
            btn_previous.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_previous.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_previous.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_previous.Font = new Font("Segoe UI", 9F);
            btn_previous.ForeColor = Color.White;
            btn_previous.Location = new Point(558, 615);
            btn_previous.Name = "btn_previous";
            btn_previous.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_previous.Size = new Size(129, 40);
            btn_previous.TabIndex = 9;
            btn_previous.Text = "Trang trước";
            btn_previous.Click += btn_previous_Click;
            // 
            // lb_index
            // 
            lb_index.AutoSize = true;
            lb_index.Location = new Point(897, 24);
            lb_index.Name = "lb_index";
            lb_index.Size = new Size(50, 20);
            lb_index.TabIndex = 13;
            lb_index.Text = "label3";
            // 
            // SearchPane
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lb_index);
            Controls.Add(btn_last);
            Controls.Add(btn_first);
            Controls.Add(btn_next);
            Controls.Add(btn_previous);
            Controls.Add(lb_SearchString);
            Controls.Add(tablePane_recentUpdate);
            Controls.Add(label1);
            Name = "SearchPane";
            Size = new Size(989, 670);
            Load += SearchPane_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TableLayoutPanel tablePane_recentUpdate;
        private Label lb_SearchString;
        private Guna.UI2.WinForms.Guna2Button btn_last;
        private Guna.UI2.WinForms.Guna2Button btn_first;
        private Guna.UI2.WinForms.Guna2Button btn_next;
        private Guna.UI2.WinForms.Guna2Button btn_previous;
        private Label lb_index;
    }
}

namespace QLSach.view.components.items
{
    partial class PaneMostView
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tbLayoutPanel = new TableLayoutPanel();
            btn_thisYear = new Guna.UI2.WinForms.Guna2Button();
            btn_thisMonth = new Guna.UI2.WinForms.Guna2Button();
            btn_thisWeek = new Guna.UI2.WinForms.Guna2Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // tbLayoutPanel
            // 
            tbLayoutPanel.AutoSize = true;
            tbLayoutPanel.ColumnCount = 1;
            tbLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutPanel.Location = new Point(18, 71);
            tbLayoutPanel.Name = "tbLayoutPanel";
            tbLayoutPanel.RowCount = 1;
            tbLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbLayoutPanel.Size = new Size(186, 207);
            tbLayoutPanel.TabIndex = 16;
            // 
            // btn_thisYear
            // 
            btn_thisYear.CustomizableEdges = customizableEdges1;
            btn_thisYear.DisabledState.BorderColor = Color.DarkGray;
            btn_thisYear.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_thisYear.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_thisYear.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_thisYear.FillColor = Color.FromArgb(106, 156, 137);
            btn_thisYear.Font = new Font("Segoe UI", 9F);
            btn_thisYear.ForeColor = Color.White;
            btn_thisYear.Location = new Point(652, 21);
            btn_thisYear.Name = "btn_thisYear";
            btn_thisYear.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_thisYear.Size = new Size(130, 43);
            btn_thisYear.TabIndex = 7;
            btn_thisYear.Text = "Trong 12 thàng";
            btn_thisYear.Click += btn_thisYear_Click;
            // 
            // btn_thisMonth
            // 
            btn_thisMonth.CustomizableEdges = customizableEdges3;
            btn_thisMonth.DisabledState.BorderColor = Color.DarkGray;
            btn_thisMonth.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_thisMonth.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_thisMonth.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_thisMonth.FillColor = Color.FromArgb(106, 156, 137);
            btn_thisMonth.Font = new Font("Segoe UI", 9F);
            btn_thisMonth.ForeColor = Color.White;
            btn_thisMonth.Location = new Point(511, 21);
            btn_thisMonth.Name = "btn_thisMonth";
            btn_thisMonth.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_thisMonth.Size = new Size(121, 45);
            btn_thisMonth.TabIndex = 6;
            btn_thisMonth.Text = "Tháng này";
            btn_thisMonth.Click += btn_thisMonth_Click;
            // 
            // btn_thisWeek
            // 
            btn_thisWeek.CustomizableEdges = customizableEdges5;
            btn_thisWeek.DisabledState.BorderColor = Color.DarkGray;
            btn_thisWeek.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_thisWeek.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_thisWeek.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_thisWeek.FillColor = Color.FromArgb(106, 156, 137);
            btn_thisWeek.Font = new Font("Segoe UI", 9F);
            btn_thisWeek.ForeColor = Color.White;
            btn_thisWeek.Location = new Point(373, 21);
            btn_thisWeek.Name = "btn_thisWeek";
            btn_thisWeek.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_thisWeek.Size = new Size(121, 45);
            btn_thisWeek.TabIndex = 5;
            btn_thisWeek.Text = "Tuần này";
            btn_thisWeek.Click += btn_thisWeek_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // PaneMostView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(btn_thisYear);
            Controls.Add(btn_thisMonth);
            Controls.Add(tbLayoutPanel);
            Controls.Add(btn_thisWeek);
            Name = "PaneMostView";
            Size = new Size(806, 299);
            Load += PaneMostView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tbLayoutPanel;
        private Guna.UI2.WinForms.Guna2Button btn_thisYear;
        private Guna.UI2.WinForms.Guna2Button btn_thisMonth;
        private Guna.UI2.WinForms.Guna2Button btn_thisWeek;
        private System.Windows.Forms.Timer timer1;
    }
}

namespace QLSach.view.admin
{
    partial class PaneCategory
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
            btn_add_category = new Guna.UI2.WinForms.Guna2Button();
            btn_modify_pagination = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            paneMain = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_add_category
            // 
            btn_add_category.CustomizableEdges = customizableEdges1;
            btn_add_category.DisabledState.BorderColor = Color.DarkGray;
            btn_add_category.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_add_category.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_add_category.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_add_category.Font = new Font("Segoe UI", 9F);
            btn_add_category.ForeColor = Color.White;
            btn_add_category.Location = new Point(18, 22);
            btn_add_category.Name = "btn_add_category";
            btn_add_category.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_add_category.Size = new Size(138, 40);
            btn_add_category.TabIndex = 0;
            btn_add_category.Text = "Thêm danh mục";
            btn_add_category.Click += btn_add_category_Click;
            // 
            // btn_modify_pagination
            // 
            btn_modify_pagination.CustomizableEdges = customizableEdges3;
            btn_modify_pagination.DisabledState.BorderColor = Color.DarkGray;
            btn_modify_pagination.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_modify_pagination.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_modify_pagination.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_modify_pagination.Font = new Font("Segoe UI", 9F);
            btn_modify_pagination.ForeColor = Color.White;
            btn_modify_pagination.Location = new Point(175, 22);
            btn_modify_pagination.Name = "btn_modify_pagination";
            btn_modify_pagination.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_modify_pagination.Size = new Size(165, 40);
            btn_modify_pagination.TabIndex = 2;
            btn_modify_pagination.Text = "Phân loại";
            btn_modify_pagination.Click += btn_modify_pagination_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(btn_modify_pagination);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(1055, 81);
            guna2Panel1.TabIndex = 4;
            // 
            // paneMain
            // 
            paneMain.CustomizableEdges = customizableEdges7;
            paneMain.Location = new Point(45, 104);
            paneMain.Name = "paneMain";
            paneMain.ShadowDecoration.CustomizableEdges = customizableEdges8;
            paneMain.Size = new Size(975, 667);
            paneMain.TabIndex = 9;
            paneMain.Paint += paneMain_Paint;
            // 
            // PaneCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_add_category);
            Controls.Add(guna2Panel1);
            Controls.Add(paneMain);
            Name = "PaneCategory";
            Size = new Size(1055, 813);
            Load += Category_Load;
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_add_category;
        private Guna.UI2.WinForms.Guna2Button btn_modify_pagination;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel paneMain;
    }
}

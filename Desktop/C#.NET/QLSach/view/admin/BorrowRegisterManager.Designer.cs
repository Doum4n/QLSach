namespace QLSach.view.admin
{
    partial class BorrowRegisterManager
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
            btn_borrowed = new Guna.UI2.WinForms.Guna2Button();
            btn_registed = new Guna.UI2.WinForms.Guna2Button();
            pane_main = new Guna.UI2.WinForms.Guna2Panel();
            SuspendLayout();
            // 
            // btn_borrowed
            // 
            btn_borrowed.CustomizableEdges = customizableEdges1;
            btn_borrowed.DisabledState.BorderColor = Color.DarkGray;
            btn_borrowed.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_borrowed.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_borrowed.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_borrowed.FillColor = Color.FromArgb(106, 156, 137);
            btn_borrowed.Font = new Font("Segoe UI", 9F);
            btn_borrowed.ForeColor = Color.White;
            btn_borrowed.Location = new Point(31, 31);
            btn_borrowed.Name = "btn_borrowed";
            btn_borrowed.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_borrowed.Size = new Size(139, 50);
            btn_borrowed.TabIndex = 1;
            btn_borrowed.Text = "Quản lý mượn";
            btn_borrowed.Click += btn_borrowed_Click;
            // 
            // btn_registed
            // 
            btn_registed.CustomizableEdges = customizableEdges3;
            btn_registed.DisabledState.BorderColor = Color.DarkGray;
            btn_registed.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_registed.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_registed.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_registed.FillColor = Color.FromArgb(106, 156, 137);
            btn_registed.Font = new Font("Segoe UI", 9F);
            btn_registed.ForeColor = Color.White;
            btn_registed.Location = new Point(197, 31);
            btn_registed.Name = "btn_registed";
            btn_registed.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_registed.Size = new Size(139, 50);
            btn_registed.TabIndex = 2;
            btn_registed.Text = "Quản lý đăng ký";
            btn_registed.Click += btn_registed_Click;
            // 
            // pane_main
            // 
            pane_main.AutoSize = true;
            pane_main.CustomizableEdges = customizableEdges5;
            pane_main.Location = new Point(17, 99);
            pane_main.Name = "pane_main";
            pane_main.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pane_main.Size = new Size(975, 426);
            pane_main.TabIndex = 3;
            // 
            // BorrowRegisterManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(btn_registed);
            Controls.Add(btn_borrowed);
            Controls.Add(pane_main);
            Name = "BorrowRegisterManager";
            Size = new Size(1013, 550);
            Load += RegisterManager_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btn_borrowed;
        private Guna.UI2.WinForms.Guna2Button btn_registed;
        private Guna.UI2.WinForms.Guna2Panel pane_main;
    }
}

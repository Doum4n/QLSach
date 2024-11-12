namespace QLSach.view
{
    partial class DashBoard
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBox_Banner = new Guna.UI2.WinForms.Guna2PictureBox();
            btn_newlyUpdate = new Guna.UI2.WinForms.Guna2Button();
            btn_popula = new Guna.UI2.WinForms.Guna2Button();
            btn_mostView = new Guna.UI2.WinForms.Guna2Button();
            pane = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Banner).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_Banner
            // 
            pictureBox_Banner.CustomizableEdges = customizableEdges1;
            pictureBox_Banner.ImageRotate = 0F;
            pictureBox_Banner.Location = new Point(18, 21);
            pictureBox_Banner.Margin = new Padding(3, 4, 3, 4);
            pictureBox_Banner.Name = "pictureBox_Banner";
            pictureBox_Banner.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pictureBox_Banner.Size = new Size(824, 299);
            pictureBox_Banner.TabIndex = 0;
            pictureBox_Banner.TabStop = false;
            pictureBox_Banner.VisibleChanged += DashBoard_Load;
            // 
            // btn_newlyUpdate
            // 
            btn_newlyUpdate.CustomizableEdges = customizableEdges3;
            btn_newlyUpdate.DisabledState.BorderColor = Color.DarkGray;
            btn_newlyUpdate.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_newlyUpdate.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_newlyUpdate.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_newlyUpdate.Font = new Font("Segoe UI", 9F);
            btn_newlyUpdate.ForeColor = Color.White;
            btn_newlyUpdate.Location = new Point(18, 340);
            btn_newlyUpdate.Margin = new Padding(3, 4, 3, 4);
            btn_newlyUpdate.Name = "btn_newlyUpdate";
            btn_newlyUpdate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_newlyUpdate.Size = new Size(180, 56);
            btn_newlyUpdate.TabIndex = 1;
            btn_newlyUpdate.Text = "Mới cập nhật";
            btn_newlyUpdate.Click += btn_newlyUpdate_Click;
            // 
            // btn_popula
            // 
            btn_popula.CustomizableEdges = customizableEdges5;
            btn_popula.DisabledState.BorderColor = Color.DarkGray;
            btn_popula.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_popula.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_popula.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_popula.Font = new Font("Segoe UI", 9F);
            btn_popula.ForeColor = Color.White;
            btn_popula.Location = new Point(218, 340);
            btn_popula.Margin = new Padding(3, 4, 3, 4);
            btn_popula.Name = "btn_popula";
            btn_popula.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_popula.Size = new Size(180, 56);
            btn_popula.TabIndex = 2;
            btn_popula.Text = "Nổi bật";
            btn_popula.Click += btn_popula_Click;
            // 
            // btn_mostView
            // 
            btn_mostView.CustomizableEdges = customizableEdges7;
            btn_mostView.DisabledState.BorderColor = Color.DarkGray;
            btn_mostView.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_mostView.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_mostView.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_mostView.Font = new Font("Segoe UI", 9F);
            btn_mostView.ForeColor = Color.White;
            btn_mostView.Location = new Point(419, 340);
            btn_mostView.Margin = new Padding(3, 4, 3, 4);
            btn_mostView.Name = "btn_mostView";
            btn_mostView.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_mostView.Size = new Size(180, 56);
            btn_mostView.TabIndex = 3;
            btn_mostView.Text = "Xem nhiều";
            btn_mostView.Click += btn_mostView_Click;
            // 
            // pane
            // 
            pane.AutoSize = true;
            pane.CustomizableEdges = customizableEdges9;
            pane.Location = new Point(18, 412);
            pane.Name = "pane";
            pane.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pane.Size = new Size(824, 240);
            pane.TabIndex = 14;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(btn_mostView);
            Controls.Add(btn_popula);
            Controls.Add(btn_newlyUpdate);
            Controls.Add(pictureBox_Banner);
            Controls.Add(pane);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DashBoard";
            Size = new Size(872, 675);
            Load += DashBoard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_Banner).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pictureBox_Banner;
        private Guna.UI2.WinForms.Guna2Button btn_newlyUpdate;
        private Guna.UI2.WinForms.Guna2Button btn_popula;
        private Guna.UI2.WinForms.Guna2Button btn_mostView;
        private Guna.UI2.WinForms.Guna2Panel pane;
    }
}

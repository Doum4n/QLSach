namespace QLSach
{
    partial class Login
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btn_signIn = new Guna.UI2.WinForms.Guna2Button();
            tb_name = new Guna.UI2.WinForms.Guna2TextBox();
            tb_pw = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // btn_signIn
            // 
            btn_signIn.CustomizableEdges = customizableEdges1;
            btn_signIn.DisabledState.BorderColor = Color.DarkGray;
            btn_signIn.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_signIn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_signIn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_signIn.Font = new Font("Segoe UI", 9F);
            btn_signIn.ForeColor = Color.White;
            btn_signIn.Location = new Point(234, 280);
            btn_signIn.Margin = new Padding(3, 4, 3, 4);
            btn_signIn.Name = "btn_signIn";
            btn_signIn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_signIn.Size = new Size(128, 56);
            btn_signIn.TabIndex = 0;
            btn_signIn.Text = "Sign in";
            btn_signIn.Click += SignIn_click;
            // 
            // tb_name
            // 
            tb_name.Cursor = Cursors.IBeam;
            tb_name.CustomizableEdges = customizableEdges3;
            tb_name.DefaultText = "";
            tb_name.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tb_name.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tb_name.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tb_name.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tb_name.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_name.Font = new Font("Segoe UI", 9F);
            tb_name.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_name.Location = new Point(180, 72);
            tb_name.Margin = new Padding(3, 5, 3, 5);
            tb_name.Name = "tb_name";
            tb_name.PasswordChar = '\0';
            tb_name.PlaceholderText = "Tên tài khoản";
            tb_name.SelectedText = "";
            tb_name.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tb_name.Size = new Size(229, 60);
            tb_name.TabIndex = 1;
            // 
            // tb_pw
            // 
            tb_pw.Cursor = Cursors.IBeam;
            tb_pw.CustomizableEdges = customizableEdges5;
            tb_pw.DefaultText = "";
            tb_pw.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tb_pw.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tb_pw.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tb_pw.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tb_pw.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_pw.Font = new Font("Segoe UI", 9F);
            tb_pw.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_pw.Location = new Point(180, 171);
            tb_pw.Margin = new Padding(3, 5, 3, 5);
            tb_pw.Name = "tb_pw";
            tb_pw.PasswordChar = '*';
            tb_pw.PlaceholderText = "Mật khẩu";
            tb_pw.SelectedText = "";
            tb_pw.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tb_pw.Size = new Size(229, 60);
            tb_pw.TabIndex = 2;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 381);
            Controls.Add(tb_pw);
            Controls.Add(tb_name);
            Controls.Add(btn_signIn);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Login";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_signIn;
        private Guna.UI2.WinForms.Guna2TextBox tb_name;
        private Guna.UI2.WinForms.Guna2TextBox tb_pw;
    }
}


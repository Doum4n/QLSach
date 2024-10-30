namespace QLSach.view.components.items
{
    partial class comment
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
            textBox_comment = new Guna.UI2.WinForms.Guna2TextBox();
            name = new Label();
            avatar = new Panel();
            btn_reply = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // textBox_comment
            // 
            textBox_comment.CustomizableEdges = customizableEdges1;
            textBox_comment.DefaultText = "";
            textBox_comment.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            textBox_comment.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            textBox_comment.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            textBox_comment.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            textBox_comment.Enabled = false;
            textBox_comment.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            textBox_comment.Font = new Font("Segoe UI", 9F);
            textBox_comment.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            textBox_comment.Location = new Point(112, 52);
            textBox_comment.Margin = new Padding(3, 4, 3, 4);
            textBox_comment.Name = "textBox_comment";
            textBox_comment.PasswordChar = '\0';
            textBox_comment.PlaceholderText = "";
            textBox_comment.SelectedText = "";
            textBox_comment.ShadowDecoration.CustomizableEdges = customizableEdges2;
            textBox_comment.Size = new Size(651, 64);
            textBox_comment.TabIndex = 0;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(113, 17);
            name.Name = "name";
            name.Size = new Size(46, 20);
            name.TabIndex = 2;
            name.Text = "name";
            // 
            // avatar
            // 
            avatar.Location = new Point(18, 20);
            avatar.Name = "avatar";
            avatar.Size = new Size(76, 69);
            avatar.TabIndex = 3;
            // 
            // btn_reply
            // 
            btn_reply.CustomizableEdges = customizableEdges3;
            btn_reply.DisabledState.BorderColor = Color.DarkGray;
            btn_reply.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_reply.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_reply.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_reply.Font = new Font("Segoe UI", 9F);
            btn_reply.ForeColor = Color.White;
            btn_reply.Location = new Point(653, 123);
            btn_reply.Name = "btn_reply";
            btn_reply.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_reply.Size = new Size(110, 26);
            btn_reply.TabIndex = 4;
            btn_reply.Text = "Trả lời";
            btn_reply.Click += btn_reply_Click;
            // 
            // comment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_reply);
            Controls.Add(avatar);
            Controls.Add(name);
            Controls.Add(textBox_comment);
            Name = "comment";
            Size = new Size(786, 160);
            Load += comment_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox textBox_comment;
        private Label name;
        private Panel avatar;
        private Guna.UI2.WinForms.Guna2Button btn_reply;
    }
}

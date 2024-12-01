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
            textBox_comment = new Guna.UI2.WinForms.Guna2TextBox();
            lb_name = new Label();
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
            textBox_comment.Location = new Point(17, 52);
            textBox_comment.Margin = new Padding(3, 4, 3, 4);
            textBox_comment.Name = "textBox_comment";
            textBox_comment.PasswordChar = '\0';
            textBox_comment.PlaceholderText = "";
            textBox_comment.SelectedText = "";
            textBox_comment.ShadowDecoration.CustomizableEdges = customizableEdges2;
            textBox_comment.Size = new Size(650, 64);
            textBox_comment.TabIndex = 0;
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.Location = new Point(17, 28);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(46, 20);
            lb_name.TabIndex = 2;
            lb_name.Text = "name";
            // 
            // comment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lb_name);
            Controls.Add(textBox_comment);
            Name = "comment";
            Size = new Size(679, 131);
            Load += comment_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox textBox_comment;
        private Label lb_name;
    }
}

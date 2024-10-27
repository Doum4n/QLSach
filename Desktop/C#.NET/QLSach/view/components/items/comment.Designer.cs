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
            avata = new Guna.UI2.WinForms.Guna2PictureBox();
            name = new Label();
            ((System.ComponentModel.ISupportInitialize)avata).BeginInit();
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
            textBox_comment.Size = new Size(286, 60);
            textBox_comment.TabIndex = 0;
            // 
            // avata
            // 
            avata.CustomizableEdges = customizableEdges3;
            avata.ImageRotate = 0F;
            avata.Location = new Point(18, 17);
            avata.Name = "avata";
            avata.ShadowDecoration.CustomizableEdges = customizableEdges4;
            avata.Size = new Size(73, 65);
            avata.TabIndex = 1;
            avata.TabStop = false;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(113, 17);
            name.Name = "name";
            name.Size = new Size(50, 20);
            name.TabIndex = 2;
            name.Text = "label1";
            // 
            // comment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(name);
            Controls.Add(avata);
            Controls.Add(textBox_comment);
            Name = "comment";
            Size = new Size(444, 143);
            ((System.ComponentModel.ISupportInitialize)avata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox textBox_comment;
        private Guna.UI2.WinForms.Guna2PictureBox avata;
        private Label name;
    }
}

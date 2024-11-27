namespace QLSach.view.user.components.items
{
    partial class ProgressForm
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
            Progress_Bar = new Guna.UI2.WinForms.Guna2ProgressBar();
            SuspendLayout();
            // 
            // Progress_Bar
            // 
            Progress_Bar.CustomizableEdges = customizableEdges1;
            Progress_Bar.Location = new Point(62, 54);
            Progress_Bar.Name = "Progress_Bar";
            Progress_Bar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            Progress_Bar.Size = new Size(375, 38);
            Progress_Bar.TabIndex = 0;
            Progress_Bar.Text = "guna2ProgressBar1";
            Progress_Bar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // ProgressBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 147);
            Controls.Add(Progress_Bar);
            Name = "ProgressBar";
            Text = "ProgressBar";
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ProgressBar Progress_Bar;
    }
}
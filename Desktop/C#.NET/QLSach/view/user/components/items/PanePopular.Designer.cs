namespace QLSach.view.components.items
{
    partial class PanePopular
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
            tbLayoutPanel = new TableLayoutPanel();
            SuspendLayout();
            // 
            // tbLayoutPanel
            // 
            tbLayoutPanel.AutoSize = true;
            tbLayoutPanel.ColumnCount = 1;
            tbLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutPanel.Location = new Point(20, 21);
            tbLayoutPanel.Name = "tbLayoutPanel";
            tbLayoutPanel.RowCount = 1;
            tbLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbLayoutPanel.Size = new Size(186, 207);
            tbLayoutPanel.TabIndex = 16;
            // 
            // PanePopular
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(tbLayoutPanel);
            Name = "PanePopular";
            Size = new Size(834, 260);
            Load += PanePopular_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tbLayoutPanel;
    }
}

namespace QLSach.view.user
{
    partial class RegistedBooks
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
            label1 = new Label();
            data = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)data).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(22, 66, 60);
            label1.Location = new Point(30, 24);
            label1.Name = "label1";
            label1.Size = new Size(247, 41);
            label1.TabIndex = 3;
            label1.Text = "Sách đã đăng ký";
            // 
            // data
            // 
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data.BackgroundColor = Color.FromArgb(251, 250, 218);
            data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data.Location = new Point(30, 85);
            data.Name = "data";
            data.RowHeadersWidth = 51;
            data.Size = new Size(711, 188);
            data.TabIndex = 2;
            // 
            // RegistedBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(data);
            Name = "RegistedBooks";
            Size = new Size(769, 295);
            Load += RegistedBooks_Load;
            ((System.ComponentModel.ISupportInitialize)data).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView data;
    }
}

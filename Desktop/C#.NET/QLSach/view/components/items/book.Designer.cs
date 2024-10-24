namespace QLSach.view.components.items
{
    partial class book
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
            picture = new PictureBox();
            lb_name_Book = new Label();
            lb_name_Author = new Label();
            lb_source = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            SuspendLayout();
            // 
            // picture
            // 
            picture.Location = new Point(15, 21);
            picture.Margin = new Padding(3, 4, 3, 4);
            picture.Name = "picture";
            picture.Size = new Size(128, 154);
            picture.TabIndex = 0;
            picture.TabStop = false;
            picture.Click += onClick;
            // 
            // lb_name_Book
            // 
            lb_name_Book.AutoSize = true;
            lb_name_Book.Location = new Point(79, 196);
            lb_name_Book.Name = "lb_name_Book";
            lb_name_Book.Size = new Size(16, 20);
            lb_name_Book.TabIndex = 1;
            lb_name_Book.Text = "x";
            // 
            // lb_name_Author
            // 
            lb_name_Author.AutoSize = true;
            lb_name_Author.Location = new Point(106, 228);
            lb_name_Author.Name = "lb_name_Author";
            lb_name_Author.Size = new Size(16, 20);
            lb_name_Author.TabIndex = 2;
            lb_name_Author.Text = "x";
            // 
            // lb_source
            // 
            lb_source.AutoSize = true;
            lb_source.Location = new Point(79, 261);
            lb_source.Name = "lb_source";
            lb_source.Size = new Size(16, 20);
            lb_source.TabIndex = 3;
            lb_source.Text = "x";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 196);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 4;
            label1.Text = "Tên sách";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 228);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 5;
            label2.Text = "Tên tác giả";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 261);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 6;
            label3.Text = "Nguồn";
            // 
            // book
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            Controls.Add(picture);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lb_source);
            Controls.Add(lb_name_Author);
            Controls.Add(lb_name_Book);
            Margin = new Padding(20);
            Name = "book";
            Size = new Size(157, 292);
            Click += onClick;
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label lb_name_Book;
        private System.Windows.Forms.Label lb_name_Author;
        private System.Windows.Forms.Label lb_source;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}

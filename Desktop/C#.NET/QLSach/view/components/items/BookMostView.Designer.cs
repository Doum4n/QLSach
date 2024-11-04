namespace QLSach.view.components.items
{
    partial class BookMostView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lb_bookName = new Label();
            lb_author = new Label();
            rating = new Guna.UI2.WinForms.Guna2RatingStar();
            btn_wantToRead = new Guna.UI2.WinForms.Guna2Button();
            picture = new PictureBox();
            lb_reading = new Label();
            lb_index = new Label();
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            SuspendLayout();
            // 
            // lb_bookName
            // 
            lb_bookName.AutoSize = true;
            lb_bookName.Location = new Point(207, 26);
            lb_bookName.Name = "lb_bookName";
            lb_bookName.Size = new Size(65, 20);
            lb_bookName.TabIndex = 1;
            lb_bookName.Text = "Tên sách";
            // 
            // lb_author
            // 
            lb_author.AutoSize = true;
            lb_author.Location = new Point(207, 69);
            lb_author.Name = "lb_author";
            lb_author.Size = new Size(81, 20);
            lb_author.TabIndex = 2;
            lb_author.Text = "Tên tác giả";
            // 
            // rating
            // 
            rating.Location = new Point(207, 108);
            rating.Name = "rating";
            rating.Size = new Size(150, 35);
            rating.TabIndex = 3;
            // 
            // btn_wantToRead
            // 
            btn_wantToRead.CustomizableEdges = customizableEdges3;
            btn_wantToRead.DisabledState.BorderColor = Color.DarkGray;
            btn_wantToRead.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_wantToRead.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_wantToRead.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_wantToRead.Font = new Font("Segoe UI", 9F);
            btn_wantToRead.ForeColor = Color.White;
            btn_wantToRead.Location = new Point(525, 87);
            btn_wantToRead.Name = "btn_wantToRead";
            btn_wantToRead.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_wantToRead.Size = new Size(225, 56);
            btn_wantToRead.TabIndex = 4;
            btn_wantToRead.Text = "Muốn đọc";
            btn_wantToRead.Click += btn_wantToRead_Click;
            // 
            // picture
            // 
            picture.Location = new Point(28, 31);
            picture.Name = "picture";
            picture.Size = new Size(152, 184);
            picture.TabIndex = 5;
            picture.TabStop = false;
            picture.Click += onClick;
            // 
            // lb_reading
            // 
            lb_reading.AutoSize = true;
            lb_reading.Location = new Point(207, 195);
            lb_reading.Name = "lb_reading";
            lb_reading.Size = new Size(123, 20);
            lb_reading.TabIndex = 6;
            lb_reading.Text = "Số lượng đọc giả";
            // 
            // lb_index
            // 
            lb_index.AutoSize = true;
            lb_index.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_index.Location = new Point(714, 26);
            lb_index.Name = "lb_index";
            lb_index.Size = new Size(35, 28);
            lb_index.TabIndex = 7;
            lb_index.Text = "#1";
            // 
            // BookMostView
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(lb_index);
            Controls.Add(lb_reading);
            Controls.Add(picture);
            Controls.Add(btn_wantToRead);
            Controls.Add(rating);
            Controls.Add(lb_author);
            Controls.Add(lb_bookName);
            Name = "BookMostView";
            Size = new Size(806, 251);
            Load += BookMostView_Load;
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lb_bookName;
        private Label lb_author;
        private Guna.UI2.WinForms.Guna2RatingStar rating;
        private Guna.UI2.WinForms.Guna2Button btn_wantToRead;
        private PictureBox picture;
        private Label lb_reading;
        private Label lb_index;
    }
}

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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lb_bookName = new Label();
            lb_author = new Label();
            ratingStar = new Guna.UI2.WinForms.Guna2RatingStar();
            btn_borrow = new Guna.UI2.WinForms.Guna2Button();
            picture = new PictureBox();
            lb_reading = new Label();
            lb_index = new Label();
            label1 = new Label();
            lb_status = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
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
            // ratingStar
            // 
            ratingStar.BorderColor = Color.FromArgb(255, 162, 76);
            ratingStar.Location = new Point(207, 108);
            ratingStar.Name = "ratingStar";
            ratingStar.RatingColor = Color.FromArgb(254, 236, 55);
            ratingStar.Size = new Size(150, 35);
            ratingStar.TabIndex = 3;
            ratingStar.Click += rating_click;
            // 
            // btn_borrow
            // 
            btn_borrow.CustomizableEdges = customizableEdges1;
            btn_borrow.DisabledState.BorderColor = Color.DarkGray;
            btn_borrow.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_borrow.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_borrow.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_borrow.FillColor = Color.FromArgb(67, 104, 80);
            btn_borrow.Font = new Font("Segoe UI", 9F);
            btn_borrow.ForeColor = Color.White;
            btn_borrow.Location = new Point(524, 87);
            btn_borrow.Name = "btn_borrow";
            btn_borrow.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_borrow.Size = new Size(225, 56);
            btn_borrow.TabIndex = 4;
            btn_borrow.Text = "Mượn";
            btn_borrow.Click += btn_borrow_Click;
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
            lb_reading.Location = new Point(304, 195);
            lb_reading.Name = "lb_reading";
            lb_reading.Size = new Size(45, 20);
            lb_reading.TabIndex = 6;
            lb_reading.Text = "views";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(524, 178);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 8;
            label1.Text = "Trạng thái:";
            // 
            // lb_status
            // 
            lb_status.AutoSize = true;
            lb_status.Location = new Point(608, 178);
            lb_status.Name = "lb_status";
            lb_status.Size = new Size(50, 20);
            lb_status.TabIndex = 9;
            lb_status.Text = "label2";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(207, 195);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 10;
            label2.Text = "Số lược xem";
            // 
            // BookMostView
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(251, 250, 218);
            Controls.Add(label2);
            Controls.Add(lb_status);
            Controls.Add(label1);
            Controls.Add(lb_index);
            Controls.Add(lb_reading);
            Controls.Add(picture);
            Controls.Add(btn_borrow);
            Controls.Add(ratingStar);
            Controls.Add(lb_author);
            Controls.Add(lb_bookName);
            Name = "BookMostView";
            Size = new Size(806, 251);
            Load += BookMostView_Load;
            VisibleChanged += OnVisible;
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lb_bookName;
        private Label lb_author;
        private Guna.UI2.WinForms.Guna2RatingStar ratingStar;
        private Guna.UI2.WinForms.Guna2Button btn_borrow;
        private PictureBox picture;
        private Label lb_reading;
        private Label lb_index;
        private Label label1;
        private Label lb_status;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
    }
}

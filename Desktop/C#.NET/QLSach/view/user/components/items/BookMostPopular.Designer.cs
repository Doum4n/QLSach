﻿namespace QLSach.view.components.items
{
    partial class BookMostPopular
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
            lb_index = new Label();
            picture = new PictureBox();
            btn_register = new Guna.UI2.WinForms.Guna2Button();
            rating = new Guna.UI2.WinForms.Guna2RatingStar();
            lb_author = new Label();
            lb_bookName = new Label();
            lb_status = new Label();
            label1 = new Label();
            tb_info = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            SuspendLayout();
            // 
            // lb_index
            // 
            lb_index.AutoSize = true;
            lb_index.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_index.Location = new Point(195, 19);
            lb_index.Name = "lb_index";
            lb_index.Size = new Size(35, 28);
            lb_index.TabIndex = 14;
            lb_index.Text = "#1";
            // 
            // picture
            // 
            picture.Location = new Point(16, 19);
            picture.Name = "picture";
            picture.Size = new Size(152, 184);
            picture.TabIndex = 12;
            picture.TabStop = false;
            picture.Click += onClick;
            // 
            // btn_register
            // 
            btn_register.CustomizableEdges = customizableEdges3;
            btn_register.DisabledState.BorderColor = Color.DarkGray;
            btn_register.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_register.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_register.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_register.Font = new Font("Segoe UI", 9F);
            btn_register.ForeColor = Color.White;
            btn_register.Location = new Point(195, 196);
            btn_register.Name = "btn_register";
            btn_register.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_register.Size = new Size(225, 56);
            btn_register.TabIndex = 11;
            btn_register.Text = "Muốn đọc";
            btn_register.Click += btn_wantToRead_Click;
            // 
            // rating
            // 
            rating.Location = new Point(195, 145);
            rating.Name = "rating";
            rating.Size = new Size(150, 35);
            rating.TabIndex = 10;
            // 
            // lb_author
            // 
            lb_author.AutoSize = true;
            lb_author.Location = new Point(195, 106);
            lb_author.Name = "lb_author";
            lb_author.Size = new Size(81, 20);
            lb_author.TabIndex = 9;
            lb_author.Text = "Tên tác giả";
            // 
            // lb_bookName
            // 
            lb_bookName.AutoSize = true;
            lb_bookName.Location = new Point(195, 63);
            lb_bookName.Name = "lb_bookName";
            lb_bookName.Size = new Size(65, 20);
            lb_bookName.TabIndex = 8;
            lb_bookName.Text = "Tên sách";
            // 
            // lb_status
            // 
            lb_status.AutoSize = true;
            lb_status.Location = new Point(289, 276);
            lb_status.Name = "lb_status";
            lb_status.Size = new Size(22, 20);
            lb_status.TabIndex = 17;
            lb_status.Text = "lb";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(195, 276);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 18;
            label1.Text = "Trạng thái:";
            // 
            // tb_info
            // 
            tb_info.BorderStyle = BorderStyle.None;
            tb_info.Location = new Point(199, 308);
            tb_info.Name = "tb_info";
            tb_info.Size = new Size(549, 49);
            tb_info.TabIndex = 19;
            tb_info.Text = "";
            // 
            // BookMostPopular
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(tb_info);
            Controls.Add(label1);
            Controls.Add(lb_status);
            Controls.Add(lb_index);
            Controls.Add(picture);
            Controls.Add(btn_register);
            Controls.Add(rating);
            Controls.Add(lb_author);
            Controls.Add(lb_bookName);
            Name = "BookMostPopular";
            Size = new Size(760, 366);
            Load += BookMostPopular_Load;
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_index;
        private PictureBox picture;
        private Guna.UI2.WinForms.Guna2Button btn_register;
        private Guna.UI2.WinForms.Guna2RatingStar rating;
        private Label lb_author;
        private Label lb_bookName;
        private Label lb_status;
        private Label label1;
        private RichTextBox tb_info;
    }
}
namespace QLSach.view.admin
{
    partial class addToCategory
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            data = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            combobox_category_name = new Guna.UI2.WinForms.Guna2ComboBox();
            rtb_description = new RichTextBox();
            tb_count = new Guna.UI2.WinForms.Guna2TextBox();
            btn_add = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)data).BeginInit();
            SuspendLayout();
            // 
            // data
            // 
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data.Location = new Point(94, 143);
            data.Name = "data";
            data.RowHeadersWidth = 51;
            data.Size = new Size(946, 451);
            data.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 32);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 1;
            label1.Text = "Tên danh mục";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(412, 24);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 2;
            label2.Text = "Mô tả";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 73);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 3;
            label3.Text = "Số lượng";
            // 
            // combobox_category_name
            // 
            combobox_category_name.BackColor = Color.Transparent;
            combobox_category_name.CustomizableEdges = customizableEdges1;
            combobox_category_name.DrawMode = DrawMode.OwnerDrawFixed;
            combobox_category_name.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox_category_name.FocusedColor = Color.FromArgb(94, 148, 255);
            combobox_category_name.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            combobox_category_name.Font = new Font("Segoe UI", 10F);
            combobox_category_name.ForeColor = Color.FromArgb(68, 88, 112);
            combobox_category_name.ItemHeight = 30;
            combobox_category_name.Location = new Point(137, 24);
            combobox_category_name.Name = "combobox_category_name";
            combobox_category_name.ShadowDecoration.CustomizableEdges = customizableEdges2;
            combobox_category_name.Size = new Size(175, 36);
            combobox_category_name.TabIndex = 4;
            // 
            // rtb_description
            // 
            rtb_description.BorderStyle = BorderStyle.None;
            rtb_description.Location = new Point(479, 24);
            rtb_description.Name = "rtb_description";
            rtb_description.Size = new Size(380, 80);
            rtb_description.TabIndex = 5;
            rtb_description.Text = "";
            // 
            // tb_count
            // 
            tb_count.CustomizableEdges = customizableEdges3;
            tb_count.DefaultText = "";
            tb_count.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tb_count.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tb_count.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tb_count.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tb_count.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_count.Font = new Font("Segoe UI", 9F);
            tb_count.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_count.Location = new Point(137, 73);
            tb_count.Margin = new Padding(3, 4, 3, 4);
            tb_count.Name = "tb_count";
            tb_count.PasswordChar = '\0';
            tb_count.PlaceholderText = "";
            tb_count.SelectedText = "";
            tb_count.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tb_count.Size = new Size(92, 37);
            tb_count.TabIndex = 6;
            // 
            // btn_add
            // 
            btn_add.CustomizableEdges = customizableEdges5;
            btn_add.DisabledState.BorderColor = Color.DarkGray;
            btn_add.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_add.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_add.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_add.Font = new Font("Segoe UI", 9F);
            btn_add.ForeColor = Color.White;
            btn_add.Location = new Point(900, 62);
            btn_add.Name = "btn_add";
            btn_add.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_add.Size = new Size(140, 42);
            btn_add.TabIndex = 7;
            btn_add.Text = "Thêm";
            btn_add.Click += btn_add_Click;
            // 
            // addToCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_add);
            Controls.Add(tb_count);
            Controls.Add(rtb_description);
            Controls.Add(combobox_category_name);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(data);
            Name = "addToCategory";
            Size = new Size(1081, 615);
            Load += addToCategory_Load;
            ((System.ComponentModel.ISupportInitialize)data).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView data;
        private Label label1;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox combobox_category_name;
        private RichTextBox rtb_description;
        private Guna.UI2.WinForms.Guna2TextBox tb_count;
        private Guna.UI2.WinForms.Guna2Button btn_add;
    }
}

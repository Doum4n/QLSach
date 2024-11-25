namespace QLSach.view.admin
{
    partial class RegisterManager
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
            label1 = new Label();
            combobox_filter = new Guna.UI2.WinForms.Guna2ComboBox();
            tb_search = new Guna.UI2.WinForms.Guna2TextBox();
            data = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)data).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(22, 66, 60);
            label1.Location = new Point(17, 13);
            label1.Name = "label1";
            label1.Size = new Size(462, 46);
            label1.TabIndex = 3;
            label1.Text = "Quản lý dăng ký mượn sách";
            // 
            // combobox_filter
            // 
            combobox_filter.BackColor = Color.Transparent;
            combobox_filter.CustomizableEdges = customizableEdges1;
            combobox_filter.DrawMode = DrawMode.OwnerDrawFixed;
            combobox_filter.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox_filter.FocusedColor = Color.FromArgb(94, 148, 255);
            combobox_filter.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            combobox_filter.Font = new Font("Segoe UI", 10F);
            combobox_filter.ForeColor = Color.FromArgb(68, 88, 112);
            combobox_filter.ItemHeight = 30;
            combobox_filter.Location = new Point(205, 71);
            combobox_filter.Name = "combobox_filter";
            combobox_filter.ShadowDecoration.CustomizableEdges = customizableEdges2;
            combobox_filter.Size = new Size(144, 36);
            combobox_filter.TabIndex = 19;
            // 
            // tb_search
            // 
            tb_search.CustomizableEdges = customizableEdges3;
            tb_search.DefaultText = "";
            tb_search.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tb_search.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tb_search.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tb_search.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tb_search.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_search.Font = new Font("Segoe UI", 9F);
            tb_search.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tb_search.Location = new Point(17, 72);
            tb_search.Margin = new Padding(3, 4, 3, 4);
            tb_search.Name = "tb_search";
            tb_search.PasswordChar = '\0';
            tb_search.PlaceholderText = "Tìm kiếm";
            tb_search.SelectedText = "";
            tb_search.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tb_search.Size = new Size(171, 36);
            tb_search.TabIndex = 18;
            tb_search.TextChanged += tb_search_TextChanged;
            // 
            // data
            // 
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data.Location = new Point(17, 137);
            data.Name = "data";
            data.RowHeadersWidth = 51;
            data.Size = new Size(919, 373);
            data.TabIndex = 20;
            // 
            // RegisterManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(data);
            Controls.Add(combobox_filter);
            Controls.Add(tb_search);
            Controls.Add(label1);
            Name = "RegisterManager";
            Size = new Size(974, 530);
            Load += RegisterManager_Load;
            ((System.ComponentModel.ISupportInitialize)data).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox combobox_filter;
        private Guna.UI2.WinForms.Guna2TextBox tb_search;
        private DataGridView data;
    }
}

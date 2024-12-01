namespace QLSach.view.admin
{
    partial class ReaderManager
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
            label1 = new Label();
            combobox_fillter = new Guna.UI2.WinForms.Guna2ComboBox();
            tb_search = new Guna.UI2.WinForms.Guna2TextBox();
            dataBook = new DataGridView();
            cbb_history = new Guna.UI2.WinForms.Guna2ComboBox();
            dataReader = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataBook).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataReader).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(22, 66, 60);
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(269, 46);
            label1.TabIndex = 0;
            label1.Text = "Quản lý đọc giả";
            // 
            // combobox_fillter
            // 
            combobox_fillter.BackColor = Color.Transparent;
            combobox_fillter.CustomizableEdges = customizableEdges1;
            combobox_fillter.DrawMode = DrawMode.OwnerDrawFixed;
            combobox_fillter.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox_fillter.FocusedColor = Color.FromArgb(94, 148, 255);
            combobox_fillter.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            combobox_fillter.Font = new Font("Segoe UI", 10F);
            combobox_fillter.ForeColor = Color.FromArgb(68, 88, 112);
            combobox_fillter.ItemHeight = 30;
            combobox_fillter.Location = new Point(280, 91);
            combobox_fillter.Name = "combobox_fillter";
            combobox_fillter.ShadowDecoration.CustomizableEdges = customizableEdges2;
            combobox_fillter.Size = new Size(143, 36);
            combobox_fillter.TabIndex = 6;
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
            tb_search.Location = new Point(29, 91);
            tb_search.Margin = new Padding(3, 4, 3, 4);
            tb_search.Name = "tb_search";
            tb_search.PasswordChar = '\0';
            tb_search.PlaceholderText = "Tìm kiếm";
            tb_search.SelectedText = "";
            tb_search.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tb_search.Size = new Size(245, 36);
            tb_search.TabIndex = 5;
            tb_search.TextChanged += tb_search_TextChanged;
            // 
            // dataBook
            // 
            dataBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataBook.BackgroundColor = Color.FromArgb(232, 223, 202);
            dataBook.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataBook.Location = new Point(29, 434);
            dataBook.Name = "dataBook";
            dataBook.RowHeadersWidth = 51;
            dataBook.Size = new Size(783, 204);
            dataBook.TabIndex = 4;
            // 
            // cbb_history
            // 
            cbb_history.BackColor = Color.Transparent;
            cbb_history.CustomizableEdges = customizableEdges5;
            cbb_history.DrawMode = DrawMode.OwnerDrawFixed;
            cbb_history.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb_history.FocusedColor = Color.FromArgb(94, 148, 255);
            cbb_history.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbb_history.Font = new Font("Segoe UI", 10F);
            cbb_history.ForeColor = Color.FromArgb(68, 88, 112);
            cbb_history.ItemHeight = 30;
            cbb_history.Location = new Point(654, 383);
            cbb_history.Name = "cbb_history";
            cbb_history.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cbb_history.Size = new Size(158, 36);
            cbb_history.TabIndex = 13;
            // 
            // dataReader
            // 
            dataReader.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataReader.BackgroundColor = Color.FromArgb(232, 223, 202);
            dataReader.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataReader.Location = new Point(29, 144);
            dataReader.Name = "dataReader";
            dataReader.RowHeadersWidth = 51;
            dataReader.Size = new Size(783, 216);
            dataReader.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(567, 383);
            label2.Name = "label2";
            label2.Size = new Size(81, 18);
            label2.TabIndex = 15;
            label2.Text = "Trạng thái";
            // 
            // ReaderManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 239, 230);
            Controls.Add(label2);
            Controls.Add(dataReader);
            Controls.Add(cbb_history);
            Controls.Add(combobox_fillter);
            Controls.Add(tb_search);
            Controls.Add(dataBook);
            Controls.Add(label1);
            Name = "ReaderManager";
            Size = new Size(843, 671);
            Load += ReaderManager_Load;
            ((System.ComponentModel.ISupportInitialize)dataBook).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataReader).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox combobox_fillter;
        private Guna.UI2.WinForms.Guna2TextBox tb_search;
        private DataGridView dataBook;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_history;
        private DataGridView dataReader;
        private Label label2;
    }
}

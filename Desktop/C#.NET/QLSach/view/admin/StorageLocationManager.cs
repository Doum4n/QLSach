using QLSach.component;
using QLSach.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.view.admin
{
    public partial class StorageLocationManager : UserControl
    {
        private StorageLocationManagerVM viewModel;
        private DataGridViewButtonColumn button = new DataGridViewButtonColumn();
        private DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn();

        private int index;

        public StorageLocationManager()
        {
            InitializeComponent();
            viewModel = new StorageLocationManagerVM(data);
            Bind();
        }

        private void Bind()
        {
            tb_search.DataBindings.Add("Text", viewModel, "SearchText", true, DataSourceUpdateMode.OnPropertyChanged);
            combobox_fillter.DataBindings.Add("SelectedValue", viewModel, "SelectedFilter", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void StorageLocation_Load(object sender, EventArgs e)
        {
            data.DataSource = viewModel.StorageLocation;
            dataBooks.DataSource = viewModel.Books;

            viewModel.Load();
            viewModel.AssignFillterList(combobox_fillter);

            button.Text = "Sửa";
            button.HeaderText = "Thao tác";
            button.UseColumnTextForButtonValue = true;
            data.Columns.Add(button);

            checkBox.Visible = false;
            checkBox.HeaderText = "Thao tác";
            data.Columns.Add(checkBox);

            data.CellClick += (sender, e) =>
            {
                var selectedRow = data.Rows[e.RowIndex];

                if (data.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    index = e.RowIndex;
                    btn_action.Text = "Cập nhật";

                    var Name = selectedRow.Cells["Name"].Value.ToString();
                    var Description = selectedRow.Cells["Description"].Value.ToString();

                    tb_location_name.Text = Name;
                    rtb_description.Text = Description;

                    pane_add.Visible = true;
                }
                viewModel.locationName = selectedRow.Cells["Name"].Value.ToString();

                dataBooks.Columns["Id"].HeaderText = "Mã sách";
                dataBooks.Columns["name"].HeaderText = "Tên sách";
                dataBooks.Columns["description"].HeaderText = "Mô tả";
                dataBooks.Columns["storage_location"].Visible = false;
            };

            data.CellContentClick += (sender, e) => 
            {
                if (data.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    viewModel.addSelectedId(e.RowIndex, "Name");
                }
            };

            pane_add.Visible = false;

            data.Columns["Name"].HeaderText = "Tên vị trí";
            data.Columns["Description"].HeaderText = "Mô tả";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            btn_action.Text = "Thêm";
            pane_add.Visible = true;
            checkBox.Visible = false;
            button.Visible = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            checkBox.Visible = true;
            button.Visible = false;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Singleton.getInstance.DataSet.Tables["StorageLocations"].RejectChanges();

            viewModel.Rollback("StorageLocations");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            viewModel.SaveChange("StorageLocations");
        }

        private void btn_delete_data_Click(object sender, EventArgs e)
        {
            viewModel.Delete("StorageLocations", "Name");
        }

        private void btn_action_Click(object sender, EventArgs e)
        {
            if(btn_action.Text == "Thêm")
                viewModel.addLocation(tb_location_name.Text, rtb_description.Text);
            else
                viewModel.UpdateLocation(tb_location_name.Text, rtb_description.Text, index);
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Clover_Shop
{
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();

            LoadData();

            this.KeyPreview = true;

            idField.Hide();
        }

        DB db = new DB();

        DataLoad dataLoad = new DataLoad();

        DataCheck dataCheck = new DataCheck();

        DataDelete dataDelete = new DataDelete();

        private void LoadData()
        {
            foreach (string[] s in dataLoad.InDGV("SELECT * FROM `supplier` ORDER BY `id`", 4))
                dataGridView.Rows.Add(s);

            LoadSearchField();

            findField.Text = "Введите наименование поставщика";
            findField.ForeColor = Color.Gray;

            deleteField.Text = "Введите ID поставщика";
            deleteField.ForeColor = Color.Gray;

            idField.Text = "";
            supplierField.Text = "";
            addressField.Text = "";
            mailField.Text = "";

            this.ActiveControl = null;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonClose_MouseEnter(object sender, EventArgs e)
        {
            ButtonClose.ForeColor = Color.BlanchedAlmond;
        }

        private void ButtonClose_MouseLeave(object sender, EventArgs e)
        {
            ButtonClose.ForeColor = Color.Black;
        }

        Point lastPoint;
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainForm mainForm = new MainForm();
            mainForm.Show();

            Close();
        }

        private void SupplierForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                idField.Text = "";
                supplierField.Text = "";
                addressField.Text = "";
                mailField.Text = "";

                findField.Text = "Введите наименование поставщика";
                findField.ForeColor = Color.Gray;

                deleteField.Text = "Введите ID поставщика";
                deleteField.ForeColor = Color.Gray;

                this.ActiveControl = null;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentCell.Value != null)
            {
                idField.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
                supplierField.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
                addressField.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
                mailField.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void DeleteField_Enter(object sender, EventArgs e)
        {
            if (deleteField.Text == "Введите ID поставщика")
            {
                deleteField.Text = "";
                deleteField.ForeColor = Color.Black;
            }
        }

        private void DeleteField_Leave(object sender, EventArgs e)
        {
            if (deleteField.Text == "")
            {
                deleteField.Text = "Введите ID поставщика";
                deleteField.ForeColor = Color.Gray;
            }
        }

        private void FindField_Enter(object sender, EventArgs e)
        {
            if (findField.Text == "Введите наименование поставщика")
            {
                findField.Text = "";
                findField.ForeColor = Color.Black;
            }
        }

        private void FindField_Leave(object sender, EventArgs e)
        {
            if (findField.Text == "")
            {
                findField.Text = "Введите наименование поставщика";
                findField.ForeColor = Color.Gray;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (dataCheck.FieldInSupplier (supplierField.Text, addressField.Text, mailField.Text))
                return;

            MySqlCommand commandAddData = new MySqlCommand("INSERT into `supplier` (`name`, `address`, `mail`) VALUES (@name, @address, @mail)", db.GetConnection());
            commandAddData.Parameters.Add("@name", MySqlDbType.VarChar).Value = supplierField.Text;
            commandAddData.Parameters.Add("@address", MySqlDbType.VarChar).Value = addressField.Text;
            commandAddData.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mailField.Text;

            dataCheck.IsDataAdd(commandAddData, db);

            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataCheck.BeforeDelete(deleteField.Text, "Введите ID поставщика"))
                return;

            if (dataCheck.RowsInReader("SELECT * FROM `supply` WHERE id_supplier = @valueInDB", deleteField.Text, db))
            {
                MessageBox.Show("Вы не можете удалить данного поставщика, так как у вас имеются его поставки","Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
            }

            dataDelete.FromDB("DELETE FROM `supplier` WHERE `supplier`.`id` = @id", deleteField.Text);

            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (dataCheck.BeforeUpdate(idField.Text))
                return;

            if (dataCheck.FieldInSupplier(supplierField.Text, addressField.Text, mailField.Text))
                return;

            MySqlCommand commandUpdateData = new MySqlCommand("UPDATE `supplier` SET `name` = @name, `address` = @address, `mail` = @mail WHERE `supplier`.`id` = @id;", db.GetConnection());
            commandUpdateData.Parameters.Add("@id", MySqlDbType.Int32).Value = idField.Text;
            commandUpdateData.Parameters.Add("@name", MySqlDbType.VarChar).Value = supplierField.Text;
            commandUpdateData.Parameters.Add("@address", MySqlDbType.VarChar).Value = addressField.Text;
            commandUpdateData.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mailField.Text;

            dataCheck.IsDataUpdate(commandUpdateData, db);

            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            if (dataCheck.BeforeFind(findField.SelectedIndex, findField.Text, "Введите наименование поставщика", "Выберите из списка или введите наименование поставщика полностью"))
                return;

            dataGridView.Rows.Clear();

            foreach (string[] s in dataLoad.ForFind("SELECT * FROM `supplier` WHERE name = @valueInDB", findField.Text, 4))
                dataGridView.Rows.Add(s);

            findField.Text = "Введите наименование поставщика";
            findField.ForeColor = Color.Gray;
        }

        private void ButtonShowAll_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            LoadData();
        }

        private void ButtonExportExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = "Рабочий стол:";
            saveFileDialog.Title = "Сохранить как Excel файл";
            saveFileDialog.FileName = "Поставщики";
            saveFileDialog.Filter = "Книга Excel | * .xlsx";

            if(saveFileDialog.ShowDialog()!=DialogResult.Cancel)
             {
                Excel.Application ExcelApp = new Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns[1].ColumnWidth = 5;
                ExcelApp.Columns[2].ColumnWidth = 20;
                ExcelApp.Columns[3].ColumnWidth = 40;
                ExcelApp.Columns[4].ColumnWidth = 40;

                for (int i =0; i < dataGridView.Columns.Count;i++)
                {
                    ExcelApp.Cells[1, i+1] = dataGridView.Columns[i].HeaderText;
                }

                for (int i=0; i < dataGridView.Rows.Count-1; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }

                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();

                MessageBox.Show("Данные были успешно экспортированы", "Экспорт данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void LoadSearchField()
        {
            DataTable tableSupplier = dataLoad.ComboBox("SELECT DISTINCT `name` FROM `supplier` ORDER BY `name`");

            findField.DataSource = tableSupplier;
            findField.DisplayMember = "name";
            findField.ValueMember = "name";

            findField.Text = null;
            findField.Text = "Введите наименование поставщика";
        }
    }
}

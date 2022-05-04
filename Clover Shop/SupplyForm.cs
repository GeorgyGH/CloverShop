using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Clover_Shop
{
    public partial class SupplyForm : Form
    {
        public SupplyForm()
        {
            InitializeComponent();
           
            this.KeyPreview = true;

            idField.Hide();

            idSupplierField.Text = null;
            idUserField.Text = null;

            LoadData();
        }

        DB db = new DB();

        DataLoad dataLoad = new DataLoad();

        DataCheck dataCheck = new DataCheck();

        DataDelete dataDelete = new DataDelete();

        private void LoadData()
        {
            foreach (string[] s in dataLoad.InDGV("SELECT * FROM `supply` ORDER BY `id`", 6))
                dataGridView.Rows.Add(s);

          
            LoadSupplierField();
            LoadUserField();
            LoadSearchField();

            findField.Text = "Введите наименование товара";
            findField.ForeColor = Color.Gray;

            deleteField.Text = "Введите ID поставки";
            deleteField.ForeColor = Color.Gray;

            idField.Text = "";
            idSupplierField.Text = "";
            productField.Text = "";
            countField.Text = "";
            dateField.Text = "";
            idUserField.Text = "";
            
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

        private void dateField_Enter(object sender, EventArgs e)
        {
            if (dateField.Text.Length < 1)
                dateField.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void SupplyForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                idField.Text = "";
                idSupplierField.Text = "";
                productField.Text = "";
                countField.Text = "";
                dateField.Text = "";
                idUserField.Text = "";

                deleteField.Text = "Введите ID поставки";
                deleteField.ForeColor = Color.Gray;

                findField.Text = "Введите наименование товара";
                findField.ForeColor = Color.Gray;

                this.ActiveControl = null;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentCell.Value != null)
            {
                idField.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
                idSupplierField.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
                productField.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
                countField.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
                dateField.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
                idUserField.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void DeleteField_Enter(object sender, EventArgs e)
        {
            if (deleteField.Text == "Введите ID поставки")
            {
                deleteField.Text = "";
                deleteField.ForeColor = Color.Black;
            }
        }

        private void DeleteField_Leave(object sender, EventArgs e)
        {
            if (deleteField.Text == "")
            {
                deleteField.Text = "Введите ID поставки";
                deleteField.ForeColor = Color.Gray;
            }
        }

        private void findhField_Enter(object sender, EventArgs e)
        {
            if (findField.Text == "Введите наименование товара")
            {
                findField.Text = "";
                findField.ForeColor = Color.Black;
            }
        }

        private void findField_Leave(object sender, EventArgs e)
        {
            if (findField.Text == "")
            {
                findField.Text = "Введите наименование товара";
                findField.ForeColor = Color.Gray;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (dataCheck.FieldInSupply(idSupplierField.SelectedIndex, productField.Text, countField.Text, dateField.Text, idUserField.SelectedIndex))
                return;

            MySqlCommand commandAddData = new MySqlCommand("INSERT INTO `supply` (`id_supplier`, `product`, `count`,`date`,`id_user`) VALUES (@supplier, @product, @count, @date, @id_user)", db.GetConnection());
            commandAddData.Parameters.Add("@supplier", MySqlDbType.Int32).Value = idSupplierField.Text;
            commandAddData.Parameters.Add("@product", MySqlDbType.VarChar).Value = productField.Text;
            commandAddData.Parameters.Add("@count", MySqlDbType.Int32).Value = countField.Text;
            commandAddData.Parameters.Add("@date", MySqlDbType.VarChar).Value = dateField.Text;
            commandAddData.Parameters.Add("@id_user", MySqlDbType.Int32).Value = idUserField.Text;

            db.OpenConnection();

            if (commandAddData.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Данные не были добавлены", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                db.CloseConnection();

                dataGridView.Rows.Clear();

                LoadData();

                return;
            }

            db.CloseConnection();

            string idSupply = dataLoad.ValueInDb("SELECT `id` FROM `supply` WHERE `product` = @valueInDB ORDER BY `id` DESC", productField.Text);

            MySqlCommand commandAddDataProduct = new MySqlCommand("INSERT INTO `product` (`name`, `count`, `id_supply`) VALUES (@product, @count, @id_supply)", db.GetConnection());
            commandAddDataProduct.Parameters.Add("@product", MySqlDbType.VarChar).Value = productField.Text;
            commandAddDataProduct.Parameters.Add("@count", MySqlDbType.Int32).Value = countField.Text;
            commandAddDataProduct.Parameters.Add("@id_supply", MySqlDbType.Int32).Value = idSupply;

            db.OpenConnection();

            dataCheck.IsDataAdd(commandAddDataProduct, db);

            db.CloseConnection();

            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataCheck.BeforeDelete(deleteField.Text, "Введите ID поставки"))
                return;
            
            if (dataCheck.RowsInReader("SELECT `count` FROM `shipment` WHERE `id_supply` =@valueInDB", deleteField.Text, db))
            {
                MessageBox.Show("Вы не можете удалить данную поставку, так как у вас уже имеется отгрузка данного товара","Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;

            }

            if (dataCheck.RowsInReader("SELECT `count` FROM `location_product` WHERE `id_supply` = @valueInDB", deleteField.Text, db))
            {
                MessageBox.Show("Сперва удалите информацию из расположения товаров", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;

            }

            MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM `supply` WHERE `supply`.`id` = @id", db.GetConnection());
            deleteCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = deleteField.Text;

            db.OpenConnection();

            if (deleteCommand.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Данные не были удалены", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                db.CloseConnection();

                dataGridView.Rows.Clear();

                LoadData();

                return;
            }

            db.CloseConnection();

            dataDelete.FromDB("DELETE FROM `product` WHERE `product`.`id_supply` = @id", deleteField.Text);

            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (dataCheck.FieldInSupply(idSupplierField.SelectedIndex, productField.Text, countField.Text, dateField.Text, idUserField.SelectedIndex))
                return;

            if (dataCheck.RowsInReader("SELECT `count` FROM `shipment` WHERE `id_supply` =@valueInDB", idField.Text, db))
            {
                MessageBox.Show("Вы не можете обновлять данную поставку, так как у вас уже имеется отгрузка данного товара", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
            }

            if (dataCheck.RowsInReader("SELECT `count` FROM `location_product` WHERE `id_supply` = @valueInDB", idField.Text, db))
            {
                MessageBox.Show("Сперва удалите информацию из расположения товаров", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
            }

            MySqlCommand commandUpdateDataProduct = new MySqlCommand("UPDATE `product` SET `name` = @product, `count` = @count WHERE `product`.`id_supply` = @id;", db.GetConnection());
            commandUpdateDataProduct.Parameters.Add("@id", MySqlDbType.Int32).Value = idField.Text;
            commandUpdateDataProduct.Parameters.Add("@product", MySqlDbType.VarChar).Value = productField.Text;
            commandUpdateDataProduct.Parameters.Add("@count", MySqlDbType.Int32).Value = countField.Text;

            db.OpenConnection();

            if (commandUpdateDataProduct.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Данные не были обновлены", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                db.CloseConnection();

                return;
            }
           
            MySqlCommand commandUpdateData = new MySqlCommand("UPDATE `supply` SET `id_supplier` = @supplier, `product` = @product, `count` = @count, `date` = @date,`id_user` = @user WHERE `supply`.`id` = @id;", db.GetConnection());
            commandUpdateData.Parameters.Add("@id", MySqlDbType.Int32).Value = idField.Text;
            commandUpdateData.Parameters.Add("@supplier", MySqlDbType.Int32).Value = idSupplierField.Text;
            commandUpdateData.Parameters.Add("@product", MySqlDbType.VarChar).Value = productField.Text;
            commandUpdateData.Parameters.Add("@count", MySqlDbType.Int32).Value = countField.Text;
            commandUpdateData.Parameters.Add("@date", MySqlDbType.VarChar).Value = dateField.Text;
            commandUpdateData.Parameters.Add("@user", MySqlDbType.Int32).Value = idUserField.Text;

            db.OpenConnection();

            dataCheck.IsDataUpdate(commandUpdateData, db);

            db.CloseConnection();

            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {

            if (dataCheck.BeforeFind(findField.SelectedIndex, findField.Text, "Введите наименование товара", "Выберите из списка или введите наименование товара полностью"))
                return;

            dataGridView.Rows.Clear();

            foreach (string[] s in dataLoad.ForFind("SELECT * FROM `supply` WHERE product = @valueInDB", findField.Text, 6))
                dataGridView.Rows.Add(s);

            findField.Text = "Введите наименование товара";
            findField.ForeColor = Color.Gray;
        }

        private void ButtonShwoAll_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "Рабочий стол:";
            saveFileDialog1.Title = "Сохранить как Excel файл";
            saveFileDialog1.FileName = "Поставки";
            saveFileDialog1.Filter = "Книга Excel | * .xlsx";
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)

            {
                Excel.Application ExcelApp = new Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns[1].ColumnWidth = 5;
                ExcelApp.Columns[2].ColumnWidth = 15;
                ExcelApp.Columns[3].ColumnWidth = 60;
                ExcelApp.Columns[4].ColumnWidth = 15;
                ExcelApp.Columns[5].ColumnWidth = 15;
                ExcelApp.Columns[6].ColumnWidth = 15;

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    ExcelApp.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }

                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();

                MessageBox.Show("Данные были успешно экспортированы", "Экспорт данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void LoadSupplierField ()
        {
            string textInField = dataCheck.TextInCombobox(productField.Text);

            DataTable tableSupplier = dataLoad.ComboBox("SELECT `id` FROM `supplier` ORDER BY `id`");
           
            idSupplierField.DataSource = tableSupplier; 
            idSupplierField.DisplayMember = "id";
            idSupplierField.ValueMember = "id";

            db.CloseConnection();

            idSupplierField.Text = textInField;
        }

        private void LoadUserField()
        {
            DataTable tableUser = dataLoad.ComboBox("SELECT `id` FROM `users` ORDER BY `id`");

            idUserField.DataSource = tableUser;
            idUserField.DisplayMember = "id";
            idUserField.ValueMember = "id";

            db.CloseConnection();

            idUserField.Text = null;
        }

        private void LoadSearchField()
        {
            DataTable tableProduct = dataLoad.ComboBox("SELECT DISTINCT `product` FROM `supply` ORDER BY `product`");

            findField.DataSource = tableProduct;
            findField.DisplayMember = "product";
            findField.ValueMember = "product";

            findField.Text = null;
            findField.Text = "Введите наименование товара";
        }
    }
}
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Clover_Shop
{
    public partial class ShipmentForm : Form
    {
        public ShipmentForm()
        {
            InitializeComponent();

            this.KeyPreview = true;

            idField.Hide();

            StartSupplyBox();

            LoadData();
        }

        DB db = new DB();

        DataLoad dataLoad = new DataLoad();

        DataCheck dataCheck = new DataCheck();

        DataDelete dataDelete = new DataDelete();

        private void LoadData()
        {
            foreach (string[] s in dataLoad.InDGV("SELECT * FROM `shipment` ORDER BY `id`", 6))
                dataGridView.Rows.Add(s);

            idField.Hide();

            findField.Text = "Введите наименование товара";
            findField.ForeColor = Color.Gray;

            deleteField.Text = "Введите ID отгрузки";
            deleteField.ForeColor = Color.Gray;

            LoadProductBox();
            LoadSearchField();
            LoadUserBox();

            idSupplyField.Text = "";
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

        private void DateField_Enter(object sender, EventArgs e)
        {
            if (dateField.Text.Length < 1)
                dateField.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void SupplyForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                idField.Text = "";
                idSupplyField.Text = "";
                productField.Text = "";
                countField.Text = "";
                dateField.Text = "";
                idUserField.Text = "";

                findField.Text = "Введите наименование товара";
                findField.ForeColor = Color.Gray;

                deleteField.Text = "Введите ID отгрузки";
                deleteField.ForeColor = Color.Gray;

                this.ActiveControl = null;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentCell.Value != null)
            {
                idField.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
                productField.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
                countField.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
                dateField.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
                idSupplyField.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
                idUserField.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            }

            LoadSupplyBox();
        }

        private void DeleteField_Enter(object sender, EventArgs e)
        {
            if (deleteField.Text == "Введите ID отгрузки")
            {
                deleteField.Text = "";
                deleteField.ForeColor = Color.Black;
            }
        }

        private void DeleteField_Leave(object sender, EventArgs e)
        {
            if (deleteField.Text == "")
            {
                deleteField.Text = "Введите ID отгрузки";
                deleteField.ForeColor = Color.Gray;
            }
        }

        private void FindField_Enter(object sender, EventArgs e)
        {
            if (findField.Text == "Введите наименование товара")
            {
                findField.Text = "";
                findField.ForeColor = Color.Black;
            }
        }

        private void FindField_Leave(object sender, EventArgs e)
        {
            if (findField.Text == "")
            {
                findField.Text = "Введите наименование товара";
                findField.ForeColor = Color.Gray;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (dataCheck.FieldInShipment(productField.SelectedIndex, productField.Text, countField.Text, dateField.Text, idSupplyField.SelectedIndex, idSupplyField.Text, idUserField.SelectedIndex))
                return;

            int countInProduct = Int32.Parse(dataLoad.ValueInDb("SELECT `count` FROM `product` WHERE `id_supply` =@valueInDB", idSupplyField.Text));

            int countInField = Int32.Parse(countField.Text);

            if (countInField > countInProduct)
            {
                MessageBox.Show("Вы пытаетесь отгрузить больше, чем имеется в наличии", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
            }

            int countInLP = dataLoad.CountInLP(idSupplyField.Text);

            if (countInProduct-countInLP < Int32.Parse(countField.Text))
            {
                    MessageBox.Show("Сперва отредактируйте информацию о данном товаре в форме расположение товаров", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    db.CloseConnection();

                    return;
             }

            MySqlCommand commandAddData = new MySqlCommand("INSERT INTO `shipment` ( `product`, `count`,`date`, `id_supply`,`id_user`) VALUES (@product, @count, @date, @id_supply, @id_user)", db.GetConnection());
            commandAddData.Parameters.Add("@product", MySqlDbType.VarChar).Value = productField.Text;
            commandAddData.Parameters.Add("@count", MySqlDbType.Int32).Value = countField.Text;
            commandAddData.Parameters.Add("@date", MySqlDbType.VarChar).Value = dateField.Text;
            commandAddData.Parameters.Add("@id_supply", MySqlDbType.Int32).Value = idSupplyField.Text;
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

            int resultCount = countInProduct - countInField;

            if (resultCount != 0)
            {
                MySqlCommand commandUpdateProduct = new MySqlCommand("UPDATE `product` SET  `count` = @count WHERE `product`.`id_supply` = @idSupply;", db.GetConnection());
                commandUpdateProduct.Parameters.Add("@idSupply", MySqlDbType.Int32).Value = idSupplyField.Text;
                commandUpdateProduct.Parameters.Add("@count", MySqlDbType.Int32).Value = resultCount.ToString();

                dataCheck.IsDataAdd(commandUpdateProduct, db);

                dataGridView.Rows.Clear();

                LoadData();
            }
            else
            {
                MySqlCommand commandDeleteProduct = new MySqlCommand("DELETE FROM `product` WHERE `product`.`id_supply` = @id", db.GetConnection());
                commandDeleteProduct.Parameters.Add("@id", MySqlDbType.VarChar).Value = idSupplyField.Text;

                db.OpenConnection();

                db.CloseConnection();

                dataCheck.IsDataAdd(commandDeleteProduct, db);

                dataGridView.Rows.Clear();

                LoadData();
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataCheck.BeforeDelete(deleteField.Text, "Введите ID отгрузки"))
                return;

            string countInDB;

            if (dataCheck.RowsInReader("SELECT `count` FROM `shipment` WHERE `shipment`.`id` = @valueInDB", deleteField.Text, db))
            {
                countInDB = dataLoad.ValueInDb("SELECT `count` FROM `shipment` WHERE `id` =@valueInDB", deleteField.Text);
            }

            else
            {
                MessageBox.Show("Данные не были удалены", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                dataGridView.Rows.Clear();

                LoadData();

                return;
            }

            string idSupplyInDB = dataLoad.ValueInDb("SELECT `id_supply` FROM `shipment` WHERE `shipment`.`id` = @valueInDB", deleteField.Text);

            string productInDB = dataLoad.ValueInDb("SELECT `product` FROM `shipment` WHERE `shipment`.`id` = @valueInDB", deleteField.Text);

            int countInProduct;

            int countInShipment = Int32.Parse(countInDB);

            if (dataCheck.RowsInReader("SELECT `count` FROM `product` WHERE `product`.`id_supply` = @valueInDB", idSupplyInDB, db))
            {
                countInProduct = Int32.Parse(dataLoad.ValueInDb("SELECT `count` FROM `product` WHERE `product`.`id_supply` = @valueInDB", idSupplyInDB));

                int resultCount = countInProduct + countInShipment;

                MySqlCommand commandUpdateCount = new MySqlCommand("UPDATE `product` SET  `count` = @count WHERE `product`.`id_supply` = @idSupply;", db.GetConnection());
                commandUpdateCount.Parameters.Add("@count", MySqlDbType.Int32).Value = resultCount.ToString();
                commandUpdateCount.Parameters.Add("@idSupply", MySqlDbType.Int32).Value = idSupplyInDB;

                db.OpenConnection();

                if (commandUpdateCount.ExecuteNonQuery() != 1)
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
            }
            else
            {
                MySqlCommand addCommand = new MySqlCommand("INSERT INTO `product` ( `name`, `count`, `id_supply`) VALUES (@product, @count, @id_supply)", db.GetConnection());
                addCommand.Parameters.Add("@product", MySqlDbType.VarChar).Value = productInDB;
                addCommand.Parameters.Add("@count", MySqlDbType.Int32).Value = countInDB;
                addCommand.Parameters.Add("@id_supply", MySqlDbType.Int32).Value = idSupplyInDB;

                db.OpenConnection();

                if (addCommand.ExecuteNonQuery() != 1)
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
            }

            if (dataCheck.BeforeDelete(deleteField.Text, "Введите ID расположения товара"))
                return;

            dataDelete.FromDB("DELETE FROM `shipment` WHERE `shipment`.`id` = @id", deleteField.Text);

            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (dataCheck.BeforeUpdate(idField.Text))
                return;

            if (dataCheck.FieldInShipment(productField.SelectedIndex, productField.Text, countField.Text, dateField.Text, idSupplyField.SelectedIndex, idSupplyField.Text, idUserField.SelectedIndex))
                return;

            int countInShipment = Int32.Parse(dataLoad.ValueInDb("SELECT `count` FROM `shipment` WHERE `id` =@valueInDB", idField.Text));

            string idShipmentInDB = dataLoad.ValueInDb("SELECT `id_supply` FROM `shipment` WHERE `id` =@valueInDB", idField.Text);

            int countInField = Int32.Parse(countField.Text);

            int countInProduct = 0;

            if (dataCheck.RowsInReader("SELECT `count` FROM `product` WHERE `id_supply` =@valueInDB",  idShipmentInDB, db))
            {
                countInProduct = Int32.Parse(dataLoad.ValueInDb("SELECT `count` FROM `product` WHERE `id_supply` = @valueInDB", idShipmentInDB));

                if (countInProduct + countInShipment < Int32.Parse(countField.Text))
                {
                    MessageBox.Show("Вы пытаетесь отгрузить больше, чем имеется в наличии", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return;
                }

                int countInLp = dataLoad.CountInLP(idSupplyField.Text);

                countInLp = countInProduct- countInLp + countInShipment - Int32.Parse(countField.Text);

                if (countInLp < 0 )
                {
                    MessageBox.Show("Сперва отредактируйте информацию о данном товаре в форме расположение товаров", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return;
                }
            }
            else
            {
                int result = countInShipment - Int32.Parse(countField.Text);

                if (result < 0)
                {
                    MessageBox.Show("Вы пытаетесь отгрузить больше, чем имеется в наличии", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return;
                }
                int countInLp = dataLoad.CountInLP(idSupplyField.Text);

                countInLp = countInProduct - countInLp + countInShipment - Int32.Parse(countField.Text);

                if (countInLp < 0)
                {
                    MessageBox.Show("Сперва отредактируйте информацию о данном товаре в форме Расположение товаров", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return;
                }
                
                if(result > 0)
                {
                    MySqlCommand commandAddInProduct = new MySqlCommand("INSERT INTO `product` ( `name`, `count`, `id_supply`) VALUES (@product, @count, @id_supply)", db.GetConnection());
                    commandAddInProduct.Parameters.Add("@product", MySqlDbType.VarChar).Value = productField.Text;
                    commandAddInProduct.Parameters.Add("@count", MySqlDbType.Int32).Value = result;
                    commandAddInProduct.Parameters.Add("@id_supply", MySqlDbType.Int32).Value = idSupplyField.Text;

                    db.OpenConnection();

                    if (commandAddInProduct.ExecuteNonQuery() != 1)
                    {
                        MessageBox.Show("Данные не были обновлены", "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                        db.CloseConnection();

                        dataGridView.Rows.Clear();

                        LoadData();

                        return;
                    }

                    db.CloseConnection();
                }

                MySqlCommand commandUpdateData = new MySqlCommand("UPDATE `shipment` SET  `product` = @product, `count` = @count, `date` = @date, `id_supply` = @supply,`id_user` = @user WHERE `shipment`.`id` = @id;", db.GetConnection());
                commandUpdateData.Parameters.Add("@id", MySqlDbType.Int32).Value = idField.Text;
                commandUpdateData.Parameters.Add("@supply", MySqlDbType.Int32).Value = idSupplyField.Text;
                commandUpdateData.Parameters.Add("@product", MySqlDbType.VarChar).Value = productField.Text;
                commandUpdateData.Parameters.Add("@count", MySqlDbType.Int32).Value = countField.Text;
                commandUpdateData.Parameters.Add("@date", MySqlDbType.VarChar).Value = dateField.Text;
                commandUpdateData.Parameters.Add("@user", MySqlDbType.Int32).Value = idUserField.Text;

                dataCheck.IsDataUpdate(commandUpdateData, db);

                db.CloseConnection();

                dataGridView.Rows.Clear();

                LoadData();

                return;
            }

            countInProduct = countInProduct + countInShipment - countInField;

            if (countInProduct < 0)
            {
                MessageBox.Show("Вы пытаетесь отгрузить больше, чем имеется в наличии", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
            }

            MySqlCommand commandUpdate = new MySqlCommand("UPDATE `shipment` SET  `product` = @product, `count` = @count, `date` = @date, `id_supply` = @supply,`id_user` = @user WHERE `shipment`.`id` = @id;", db.GetConnection());
            commandUpdate.Parameters.Add("@id", MySqlDbType.Int32).Value = idField.Text;
            commandUpdate.Parameters.Add("@supply", MySqlDbType.Int32).Value = idSupplyField.Text;
            commandUpdate.Parameters.Add("@product", MySqlDbType.VarChar).Value = productField.Text;
            commandUpdate.Parameters.Add("@count", MySqlDbType.Int32).Value = countField.Text;
            commandUpdate.Parameters.Add("@date", MySqlDbType.VarChar).Value = dateField.Text;
            commandUpdate.Parameters.Add("@user", MySqlDbType.Int32).Value = idUserField.Text;

            db.OpenConnection();

            if (commandUpdate.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Данные не были обновлены","Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                db.CloseConnection();

                dataGridView.Rows.Clear();

                LoadData();

                return;
            }

            db.CloseConnection();

            if (countInProduct != 0)
            {
                MySqlCommand commandUpdateProduct = new MySqlCommand("UPDATE `product` SET  `count` = @count WHERE `product`.`id_supply` = @idSupply;", db.GetConnection());
                commandUpdateProduct.Parameters.Add("@idSupply", MySqlDbType.Int32).Value = idSupplyField.Text;
                commandUpdateProduct.Parameters.Add("@count", MySqlDbType.Int32).Value = countInProduct.ToString();
                db.OpenConnection();

                dataCheck.IsDataUpdate(commandUpdateProduct, db);

                db.CloseConnection();

                dataGridView.Rows.Clear();

                LoadData();
            }
            else
            {
                MySqlCommand commandDeleteFromProduct = new MySqlCommand("DELETE FROM `product` WHERE `product`.`id_supply` = @id", db.GetConnection());
                commandDeleteFromProduct.Parameters.Add("@id", MySqlDbType.Int32).Value = idSupplyField.Text;

                db.OpenConnection();

                if (commandDeleteFromProduct.ExecuteNonQuery() == 1)
                    MessageBox.Show("Данные были обновлены", "Обновление данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                else
                    MessageBox.Show("Данные не были обновлены", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                db.CloseConnection();

                dataGridView.Rows.Clear();

                LoadData();
            }
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            if (dataCheck.BeforeFind(findField.SelectedIndex, findField.Text, "Введите наименование товара", "Выберите из списка или введите наименование товара полностью"))
                return;

            dataGridView.Rows.Clear();

            foreach (string[] s in dataLoad.ForFind("SELECT * FROM `shipment` WHERE product = @valueInDB", findField.Text, 6))
                dataGridView.Rows.Add(s);

            findField.Text = "Введите наименование товара";
            findField.ForeColor = Color.Gray;
        }

        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonExportExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = "Рабочий стол:";
            saveFileDialog.Title = "Сохранить как Excel файл";
            saveFileDialog.FileName = "Отгрузки";
            saveFileDialog.Filter = "Книга Excel | * .xlsx";

            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                Excel.Application ExcelApp = new Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns[1].ColumnWidth = 5;
                ExcelApp.Columns[2].ColumnWidth = 60;
                ExcelApp.Columns[3].ColumnWidth = 15;
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

                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();

                MessageBox.Show("Данные были успешно экспортированы", "Экспорт данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void LoadProductBox()
        {
            DataTable tableProduct = dataLoad.ComboBox("SELECT DISTINCT `name` FROM `product` ORDER BY `name`");

            productField.DataSource = tableProduct;
            productField.DisplayMember = "name";
            productField.ValueMember = "name";

            productField.Text = null;
        }

        private void LoadSupplyBox()
        {
            string text = dataCheck.TextInCombobox(idSupplyField.Text);

            DataTable tableIdSupply = dataLoad.ForIdSupplyBox("SELECT `id` FROM `supply` WHERE `product` = @product  ORDER BY `id`", productField.Text);

            idSupplyField.DataSource = tableIdSupply;
            idSupplyField.DisplayMember = "id";
            idSupplyField.ValueMember = "id";

            idSupplyField.Text = text;
        }

        private void LoadUserBox()
        {
            DataTable tableUser = dataLoad.ComboBox("SELECT `id` FROM `users` ORDER BY `id`");

            idUserField.DataSource = tableUser;
            idUserField.DisplayMember = "id";
            idUserField.ValueMember = "id";

            idUserField.Text = null;
        }

        private void LoadSearchField()
        {
            DataTable tableProduct = dataLoad.ComboBox("SELECT DISTINCT `product` FROM `shipment` ORDER BY `product`");

            findField.DataSource = tableProduct;
            findField.DisplayMember = "product";
            findField.ValueMember = "product";

            findField.Text = null;
            findField.Text = "Введите наименование товара";
        }

        private void StartSupplyBox()
        {
            DataTable tableIdSupply = dataLoad.ComboBox("SELECT `id` FROM `supply` ORDER BY `id`");

            idSupplyField.DataSource = tableIdSupply;
            idSupplyField.DisplayMember = "id";
            idSupplyField.ValueMember = "id";

            idSupplyField.Text = null;
        }

        private void SupplyBox_Click(object sender, EventArgs e)
        {
            LoadSupplyBox();
        }

        private void ProductBox_TextChanged(object sender, EventArgs e)
        {
            idSupplyField.Text = "";

            if (productField.SelectedIndex > 1)
                LoadSupplyBox();
        }
    }
}
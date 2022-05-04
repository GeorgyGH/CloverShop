using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Clover_Shop
{
    public partial class LocationProductForm : Form
    {
        public LocationProductForm()
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

            foreach (string[] s in dataLoad.InDGV("SELECT * FROM `location_product` ORDER BY `id`",5))
                dataGridView.Rows.Add(s);

            idField.Hide();

            findField.Text = "Введите наименование товара";
            findField.ForeColor = Color.Gray;

            deleteField.Text = "Введите ID расположения товара";
            deleteField.ForeColor = Color.Gray;

            LoadFindField();
            LoadProductBox();

            idField.Text = "";
            idSupplyField.Text = "";
            productField.Text = "";
            countField.Text = "";
            adressField.Text = "";

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

        private void SupplyForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                idField.Text = "";
                idSupplyField.Text = "";
                productField.Text = "";
                countField.Text = "";
                adressField.Text = "";

                findField.Text = "Введите наименование товара";
                findField.ForeColor = Color.Gray;

                deleteField.Text = "Введите ID расположения товара";
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
                countField.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
                adressField.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
                idSupplyField.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            }

            LoadSupplyBox();
        }

        private void DeleteField_Enter(object sender, EventArgs e)
        {
            if (deleteField.Text == "Введите ID расположения товара")
            {
                deleteField.Text = "";
                deleteField.ForeColor = Color.Black;
            }
        }

        private void DeleteField_Leave(object sender, EventArgs e)
        {
            if (deleteField.Text == "")
            {
                deleteField.Text = "Введите ID расположения товара";
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
            if (dataCheck.FieldInLP(productField.SelectedIndex, adressField.Text, countField.Text, idSupplyField.SelectedIndex))
                return;

            int countInProduct = Int32.Parse(dataLoad.ValueInDb("SELECT `count` FROM `product` WHERE `id_supply` =@valueInDB", idSupplyField.Text));

            int countInField = Int32.Parse(countField.Text);

            if (countInField > countInProduct)
            {
                MessageBox.Show("У вас не может хранится больше товара, чем имеется в наличии", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
            }

            int countInDGV = dataLoad.CountInLP(idSupplyField.Text) + Int32.Parse(countField.Text);

            if (countInDGV > countInProduct)
            {
                MessageBox.Show("У вас уже хранится информация о данном товаре и вы не можете добавить в эту таблицу большее количество товара, чем имеется в наличии", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
            }

            MySqlCommand commandAddData = new MySqlCommand("INSERT INTO `location_product` ( `product`, `address`,`count`, `id_supply`) VALUES (@product, @address, @count, @id_supply)", db.GetConnection());
            commandAddData.Parameters.Add("@product", MySqlDbType.VarChar).Value = productField.Text;
            commandAddData.Parameters.Add("@address", MySqlDbType.VarChar).Value = adressField.Text;
            commandAddData.Parameters.Add("@count", MySqlDbType.Int32).Value = countField.Text;
            commandAddData.Parameters.Add("@id_supply", MySqlDbType.Int32).Value = idSupplyField.Text;

            dataCheck.IsDataAdd(commandAddData, db);

            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataCheck.BeforeDelete(deleteField.Text, "Введите ID расположения товара"))
                return;
        
            dataDelete.FromDB("DELETE FROM `location_product` WHERE `location_product`.`id` = @id", deleteField.Text);

            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (dataCheck.BeforeUpdate(idField.Text))
                return;

            if (dataCheck.FieldInLP(productField.SelectedIndex, adressField.Text, countField.Text, idSupplyField.SelectedIndex))
                return;

            int countInProduct = Int32.Parse(dataLoad.ValueInDb("SELECT `count` FROM `product` WHERE `id_supply` =@valueInDB", idSupplyField.Text));

            int countInField = Int32.Parse(countField.Text);

            if (countInField > countInProduct)
            {
                MessageBox.Show("У вас не может хранится больше товара, чем имеется в наличии", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
            }

            int countInDGV = dataLoad.CountInLP(idSupplyField.Text);

            int countOld = Int32.Parse(dataLoad.ValueInDb("SELECT `count` FROM `location_product` WHERE `id` = @valueInDB", idField.Text));

            countInDGV = countInDGV - countOld + Int32.Parse(countField.Text);

            if (countInDGV > countInProduct)
            {
                MessageBox.Show("У вас уже хранится информация о данном товаре и вы не можете добавить в эту таблицу большее количество товара, чем имеется в наличии", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
             }
            
            MySqlCommand commandUpdateData = new MySqlCommand("UPDATE `location_product` SET  `product` = @product, `address` = @address, `count` = @count, `id_supply` = @supply WHERE `location_product`.`id` = @id;", db.GetConnection());
            commandUpdateData.Parameters.Add("@id", MySqlDbType.Int32).Value = idField.Text;
            commandUpdateData.Parameters.Add("@product", MySqlDbType.VarChar).Value = productField.Text;
            commandUpdateData.Parameters.Add("@address", MySqlDbType.VarChar).Value = adressField.Text;
            commandUpdateData.Parameters.Add("@count", MySqlDbType.Int32).Value = countField.Text;
            commandUpdateData.Parameters.Add("@supply", MySqlDbType.Int32).Value = idSupplyField.Text;

            dataCheck.IsDataUpdate(commandUpdateData, db);

            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            if (dataCheck.BeforeFind(findField.SelectedIndex, findField.Text, "Введите наименование товара", "Выберите из списка или введите наименование товара полностью"))
                return;
            dataGridView.Rows.Clear();

            foreach (string[] s in dataLoad.ForFind("SELECT * FROM `location_product` WHERE product = @valueInDB", findField.Text, 5))
                dataGridView.Rows.Add(s);

            findField.Text = "Введите наименование товара";
            findField.ForeColor = Color.Gray;
        }

        private void ShowallButton_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();

            LoadData();
        }

        private void ButtonExportExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = "Рабочий стол:";
            saveFileDialog.Title = "Сохранить как Excel файл";
            saveFileDialog.FileName = "Расположение товара";
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

        private void LoadFindField()
        {
            DataTable tableProduct = dataLoad.ComboBox("SELECT DISTINCT `product` FROM `location_product` ORDER BY `product`");

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

        private void IdSupplyBox_Click(object sender, EventArgs e)
        {
            if (dataCheck.DataInComboBox(productField.SelectedIndex, productField.Text, "Выберите или введите товар для которого хотите выбрать поставку"))
                return;

            LoadSupplyBox();
        }

        private void ProductBox_TextChanged(object sender, EventArgs e)
        {
            idSupplyField.Text = null;

            if (productField.SelectedIndex > 1)
                LoadSupplyBox();
        }
    }
}

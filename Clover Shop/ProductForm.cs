using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Clover_Shop
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();

            this.KeyPreview = true;

            LoadData();
        }

        DB db = new DB();

        DataLoad dataLoad = new DataLoad();

        DataCheck dataCheck = new DataCheck();

        DataDelete dataDelete = new DataDelete();

        private void LoadData()
        {
            foreach (string[] s in dataLoad.InDGV("SELECT * FROM `product` ORDER BY `id_supply`", 3))
                dataGridView.Rows.Add(s);

            findField.Text = "Введите наименование товара";
            findField.ForeColor = Color.Gray;

            LoadFindField();

            nameField.Text = "";
            countField.Text = "";
            idSupplyField.Text = "";

            this.ActiveControl = null;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            ButtonClose.ForeColor = Color.BlanchedAlmond;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
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

                idSupplyField.Text = "";
                nameField.Text = "";
                countField.Text = ""; 

                findField.Text = "Введите наименование товара";
                findField.ForeColor = Color.Gray;

                this.ActiveControl = null;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentCell.Value != null)
            {
                idSupplyField.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
                nameField.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
                countField.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
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

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            if (dataCheck.BeforeFind(findField.SelectedIndex, findField.Text, "Введите наименование товара", "Выберите из списка или введите наименование товара полностью"))
                return;
            dataGridView.Rows.Clear();

            foreach (string[] s in dataLoad.ForFind("SELECT * FROM `product` WHERE name = @valueInDB", findField.Text, 3))
                dataGridView.Rows.Add(s);

            findField.Text = "Введите наименование товара";
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
            saveFileDialog.FileName = "Товары";
            saveFileDialog.Filter = "Книга Excel | * .xlsx";

            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                Excel.Application ExcelApp = new Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns[1].ColumnWidth = 15;
                ExcelApp.Columns[2].ColumnWidth = 60;
                ExcelApp.Columns[3].ColumnWidth = 15;

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

        private void LoadFindField()
        {
            DataTable tableProduct = dataLoad.ComboBox("SELECT DISTINCT `name` FROM `product` ORDER BY `name`");

            findField.DataSource = tableProduct;
            findField.DisplayMember = "name";
            findField.ValueMember = "name";

            findField.Text = null;
            findField.Text = "Введите наименование товара";
        }
    }
}
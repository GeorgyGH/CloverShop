using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Clover_Shop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 23);

            this.KeyPreview = true;

            this.ActiveControl = null;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonClose_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.BlanchedAlmond;
        }

        private void ButtonClose_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Black;
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

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand commandLogin = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @userLogin AND `password` = @userPass", db.GetConnection());
            commandLogin.Parameters.Add("@userLogin", MySqlDbType.VarChar).Value = loginField.Text;
            commandLogin.Parameters.Add("@userPass", MySqlDbType.VarChar).Value = passField.Text;

            adapter.SelectCommand = commandLogin;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();

            }
            else
            {
                MessageBox.Show("Вы ввели неправильный логин или пароль", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }   
    }
}

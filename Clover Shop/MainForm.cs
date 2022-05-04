using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clover_Shop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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

        private void ButtonSupplier_Click(object sender, EventArgs e)
        {
            this.Hide();

            SupplierForm supplierForm = new SupplierForm();
            supplierForm.Show();

            Close();
        }

        private void ButtonProdcut_Click(object sender, EventArgs e)
        {
            this.Hide();

            ProductForm productForm = new ProductForm();
            productForm.Show();

            Close();
        }

        private void ButtonSupply_Click(object sender, EventArgs e)
        {
            this.Hide();

            SupplyForm supplyForm = new SupplyForm();
            supplyForm.Show();

            Close();
        }

        private void ButtonShipment_Click(object sender, EventArgs e)
        {
            this.Hide();

            ShipmentForm shipmentForm = new ShipmentForm();
            shipmentForm.Show();

            Close();
        }

        private void ButtonLocationProduct_Click(object sender, EventArgs e)
        {
            this.Hide();

            LocationProductForm locationProductForm = new LocationProductForm();
            locationProductForm.Show();

            Close();
        }
    }
}

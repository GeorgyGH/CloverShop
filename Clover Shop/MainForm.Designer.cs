namespace Clover_Shop
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.ButtonShipment = new System.Windows.Forms.Button();
            this.ButtonLocationProduct = new System.Windows.Forms.Button();
            this.ButtonProduct = new System.Windows.Forms.Button();
            this.ButtonSupply = new System.Windows.Forms.Button();
            this.ButtonSupplier = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonClose = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Linen;
            this.mainPanel.Controls.Add(this.ButtonShipment);
            this.mainPanel.Controls.Add(this.ButtonLocationProduct);
            this.mainPanel.Controls.Add(this.ButtonProduct);
            this.mainPanel.Controls.Add(this.ButtonSupply);
            this.mainPanel.Controls.Add(this.ButtonSupplier);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(355, 450);
            this.mainPanel.TabIndex = 2;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            // 
            // ButtonShipment
            // 
            this.ButtonShipment.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonShipment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonShipment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ButtonShipment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ButtonShipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonShipment.Location = new System.Drawing.Point(91, 343);
            this.ButtonShipment.Name = "ButtonShipment";
            this.ButtonShipment.Size = new System.Drawing.Size(175, 49);
            this.ButtonShipment.TabIndex = 9;
            this.ButtonShipment.TabStop = false;
            this.ButtonShipment.Text = "Отгрузки";
            this.ButtonShipment.UseVisualStyleBackColor = false;
            this.ButtonShipment.Click += new System.EventHandler(this.ButtonShipment_Click);
            // 
            // ButtonLocationProduct
            // 
            this.ButtonLocationProduct.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonLocationProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLocationProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ButtonLocationProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ButtonLocationProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLocationProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonLocationProduct.Location = new System.Drawing.Point(91, 277);
            this.ButtonLocationProduct.Name = "ButtonLocationProduct";
            this.ButtonLocationProduct.Size = new System.Drawing.Size(175, 49);
            this.ButtonLocationProduct.TabIndex = 8;
            this.ButtonLocationProduct.TabStop = false;
            this.ButtonLocationProduct.Text = "Расположение товара";
            this.ButtonLocationProduct.UseVisualStyleBackColor = false;
            this.ButtonLocationProduct.Click += new System.EventHandler(this.ButtonLocationProduct_Click);
            // 
            // ButtonProduct
            // 
            this.ButtonProduct.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ButtonProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ButtonProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonProduct.Location = new System.Drawing.Point(91, 209);
            this.ButtonProduct.Name = "ButtonProduct";
            this.ButtonProduct.Size = new System.Drawing.Size(175, 49);
            this.ButtonProduct.TabIndex = 7;
            this.ButtonProduct.TabStop = false;
            this.ButtonProduct.Text = "Товары";
            this.ButtonProduct.UseVisualStyleBackColor = false;
            this.ButtonProduct.Click += new System.EventHandler(this.ButtonProdcut_Click);
            // 
            // ButtonSupply
            // 
            this.ButtonSupply.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonSupply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSupply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ButtonSupply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ButtonSupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSupply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSupply.Location = new System.Drawing.Point(91, 139);
            this.ButtonSupply.Name = "ButtonSupply";
            this.ButtonSupply.Size = new System.Drawing.Size(175, 49);
            this.ButtonSupply.TabIndex = 6;
            this.ButtonSupply.TabStop = false;
            this.ButtonSupply.Text = "Поставки";
            this.ButtonSupply.UseVisualStyleBackColor = false;
            this.ButtonSupply.Click += new System.EventHandler(this.ButtonSupply_Click);
            // 
            // ButtonSupplier
            // 
            this.ButtonSupplier.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSupplier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ButtonSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ButtonSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSupplier.Location = new System.Drawing.Point(91, 69);
            this.ButtonSupplier.Name = "ButtonSupplier";
            this.ButtonSupplier.Size = new System.Drawing.Size(175, 49);
            this.ButtonSupplier.TabIndex = 5;
            this.ButtonSupplier.TabStop = false;
            this.ButtonSupplier.Text = "Поставщики";
            this.ButtonSupplier.UseVisualStyleBackColor = false;
            this.ButtonSupplier.Click += new System.EventHandler(this.ButtonSupplier_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Linen;
            this.panel2.Controls.Add(this.ButtonClose);
            this.panel2.Controls.Add(this.topPanel);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 47);
            this.panel2.TabIndex = 0;
            // 
            // ButtonClose
            // 
            this.ButtonClose.AutoSize = true;
            this.ButtonClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonClose.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonClose.Location = new System.Drawing.Point(339, 0);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(16, 15);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.Text = "X";
            this.ButtonClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            this.ButtonClose.MouseEnter += new System.EventHandler(this.ButtonClose_MouseEnter);
            this.ButtonClose.MouseLeave += new System.EventHandler(this.ButtonClose_MouseLeave);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.topPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(355, 47);
            this.topPanel.TabIndex = 0;
            this.topPanel.Text = "Clover Shop";
            this.topPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 450);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.mainPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button ButtonSupplier;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ButtonClose;
        private System.Windows.Forms.Label topPanel;
        private System.Windows.Forms.Button ButtonShipment;
        private System.Windows.Forms.Button ButtonLocationProduct;
        private System.Windows.Forms.Button ButtonProduct;
        private System.Windows.Forms.Button ButtonSupply;
    }
}
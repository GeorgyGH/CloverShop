namespace Clover_Shop
{
    partial class ShipmentForm
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
            this.findField = new System.Windows.Forms.ComboBox();
            this.ButtonExportExcel = new System.Windows.Forms.PictureBox();
            this.productField = new System.Windows.Forms.ComboBox();
            this.idUserField = new System.Windows.Forms.ComboBox();
            this.idSupplyField = new System.Windows.Forms.ComboBox();
            this.deleteField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idField = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ButtonShowAll = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonFind = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.countField = new System.Windows.Forms.TextBox();
            this.findBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonBack = new System.Windows.Forms.PictureBox();
            this.ButtonClose = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.findBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonBack)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Linen;
            this.mainPanel.Controls.Add(this.findField);
            this.mainPanel.Controls.Add(this.ButtonExportExcel);
            this.mainPanel.Controls.Add(this.productField);
            this.mainPanel.Controls.Add(this.idUserField);
            this.mainPanel.Controls.Add(this.idSupplyField);
            this.mainPanel.Controls.Add(this.deleteField);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.dateField);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.idField);
            this.mainPanel.Controls.Add(this.pictureBox1);
            this.mainPanel.Controls.Add(this.ButtonShowAll);
            this.mainPanel.Controls.Add(this.dataGridView);
            this.mainPanel.Controls.Add(this.ButtonFind);
            this.mainPanel.Controls.Add(this.ButtonSave);
            this.mainPanel.Controls.Add(this.ButtonDelete);
            this.mainPanel.Controls.Add(this.ButtonAdd);
            this.mainPanel.Controls.Add(this.countField);
            this.mainPanel.Controls.Add(this.findBox);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(476, 544);
            this.mainPanel.TabIndex = 3;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            // 
            // findField
            // 
            this.findField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.findField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.findField.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findField.FormattingEnabled = true;
            this.findField.Location = new System.Drawing.Point(58, 276);
            this.findField.Name = "findField";
            this.findField.Size = new System.Drawing.Size(246, 23);
            this.findField.TabIndex = 45;
            this.findField.Enter += new System.EventHandler(this.FindField_Enter);
            this.findField.Leave += new System.EventHandler(this.FindField_Leave);
            // 
            // ButtonExportExcel
            // 
            this.ButtonExportExcel.BackColor = System.Drawing.Color.Linen;
            this.ButtonExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonExportExcel.Image = global::Clover_Shop.Properties.Resources.excel;
            this.ButtonExportExcel.InitialImage = global::Clover_Shop.Properties.Resources.user;
            this.ButtonExportExcel.Location = new System.Drawing.Point(25, 214);
            this.ButtonExportExcel.Name = "ButtonExportExcel";
            this.ButtonExportExcel.Size = new System.Drawing.Size(27, 23);
            this.ButtonExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ButtonExportExcel.TabIndex = 44;
            this.ButtonExportExcel.TabStop = false;
            this.ButtonExportExcel.Click += new System.EventHandler(this.ButtonExportExcel_Click);
            // 
            // productField
            // 
            this.productField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.productField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.productField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.productField.FormattingEnabled = true;
            this.productField.Location = new System.Drawing.Point(115, 63);
            this.productField.Name = "productField";
            this.productField.Size = new System.Drawing.Size(308, 24);
            this.productField.TabIndex = 43;
            this.productField.TextChanged += new System.EventHandler(this.ProductBox_TextChanged);
            // 
            // idUserField
            // 
            this.idUserField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.idUserField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.idUserField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idUserField.FormattingEnabled = true;
            this.idUserField.Location = new System.Drawing.Point(115, 182);
            this.idUserField.Name = "idUserField";
            this.idUserField.Size = new System.Drawing.Size(306, 24);
            this.idUserField.TabIndex = 42;
            // 
            // idSupplyField
            // 
            this.idSupplyField.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.idSupplyField.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.idSupplyField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idSupplyField.FormattingEnabled = true;
            this.idSupplyField.Location = new System.Drawing.Point(117, 152);
            this.idSupplyField.Name = "idSupplyField";
            this.idSupplyField.Size = new System.Drawing.Size(306, 24);
            this.idSupplyField.TabIndex = 41;
            this.idSupplyField.Click += new System.EventHandler(this.SupplyBox_Click);
            // 
            // deleteField
            // 
            this.deleteField.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteField.Location = new System.Drawing.Point(58, 245);
            this.deleteField.Multiline = true;
            this.deleteField.Name = "deleteField";
            this.deleteField.Size = new System.Drawing.Size(246, 23);
            this.deleteField.TabIndex = 35;
            this.deleteField.Enter += new System.EventHandler(this.DeleteField_Enter);
            this.deleteField.Leave += new System.EventHandler(this.DeleteField_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "ID Работника:";
            // 
            // dateField
            // 
            this.dateField.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateField.Location = new System.Drawing.Point(116, 122);
            this.dateField.Multiline = true;
            this.dateField.Name = "dateField";
            this.dateField.Size = new System.Drawing.Size(306, 24);
            this.dateField.TabIndex = 38;
            this.dateField.Enter += new System.EventHandler(this.DateField_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(67, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Дата:";
            // 
            // idField
            // 
            this.idField.Location = new System.Drawing.Point(429, 67);
            this.idField.Name = "idField";
            this.idField.Size = new System.Drawing.Size(22, 20);
            this.idField.TabIndex = 36;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Linen;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Clover_Shop.Properties.Resources.delete;
            this.pictureBox1.InitialImage = global::Clover_Shop.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(25, 245);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // ButtonShowAll
            // 
            this.ButtonShowAll.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonShowAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonShowAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ButtonShowAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ButtonShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonShowAll.Location = new System.Drawing.Point(193, 212);
            this.ButtonShowAll.Name = "ButtonShowAll";
            this.ButtonShowAll.Size = new System.Drawing.Size(111, 25);
            this.ButtonShowAll.TabIndex = 33;
            this.ButtonShowAll.Text = "Показать всё";
            this.ButtonShowAll.UseVisualStyleBackColor = false;
            this.ButtonShowAll.Click += new System.EventHandler(this.ShowAllButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.Linen;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.adres,
            this.mail,
            this.Date,
            this.supply,
            this.IdUser});
            this.dataGridView.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView.Location = new System.Drawing.Point(0, 305);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(478, 236);
            this.dataGridView.TabIndex = 31;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Width = 25;
            // 
            // adres
            // 
            this.adres.HeaderText = "Товар";
            this.adres.Name = "adres";
            this.adres.Width = 140;
            // 
            // mail
            // 
            this.mail.HeaderText = "Количество";
            this.mail.Name = "mail";
            this.mail.Width = 70;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            this.Date.Width = 70;
            // 
            // supply
            // 
            this.supply.HeaderText = "ID поставки";
            this.supply.Name = "supply";
            this.supply.Width = 60;
            // 
            // IdUser
            // 
            this.IdUser.HeaderText = "ID работника";
            this.IdUser.Name = "IdUser";
            this.IdUser.Width = 70;
            // 
            // ButtonFind
            // 
            this.ButtonFind.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonFind.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ButtonFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ButtonFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonFind.Location = new System.Drawing.Point(310, 274);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(111, 25);
            this.ButtonFind.TabIndex = 30;
            this.ButtonFind.Text = "Найти";
            this.ButtonFind.UseVisualStyleBackColor = false;
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ButtonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSave.Location = new System.Drawing.Point(310, 212);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(111, 25);
            this.ButtonSave.TabIndex = 29;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = false;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ButtonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonDelete.Location = new System.Drawing.Point(310, 243);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(111, 25);
            this.ButtonDelete.TabIndex = 28;
            this.ButtonDelete.Text = "Удалить";
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ButtonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ButtonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonAdd.Location = new System.Drawing.Point(76, 212);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(111, 25);
            this.ButtonAdd.TabIndex = 27;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = false;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // countField
            // 
            this.countField.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countField.Location = new System.Drawing.Point(117, 93);
            this.countField.Multiline = true;
            this.countField.Name = "countField";
            this.countField.Size = new System.Drawing.Size(306, 24);
            this.countField.TabIndex = 25;
            // 
            // findBox
            // 
            this.findBox.BackColor = System.Drawing.Color.Linen;
            this.findBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.findBox.Image = global::Clover_Shop.Properties.Resources.find;
            this.findBox.InitialImage = global::Clover_Shop.Properties.Resources.user;
            this.findBox.Location = new System.Drawing.Point(25, 276);
            this.findBox.Name = "findBox";
            this.findBox.Size = new System.Drawing.Size(27, 23);
            this.findBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.findBox.TabIndex = 21;
            this.findBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(21, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Количество:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(57, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Товар:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(22, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "ID поставки:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Linen;
            this.panel2.Controls.Add(this.ButtonBack);
            this.panel2.Controls.Add(this.ButtonClose);
            this.panel2.Controls.Add(this.topPanel);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 47);
            this.panel2.TabIndex = 0;
            // 
            // ButtonBack
            // 
            this.ButtonBack.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonBack.Image = global::Clover_Shop.Properties.Resources.back;
            this.ButtonBack.InitialImage = global::Clover_Shop.Properties.Resources.user;
            this.ButtonBack.Location = new System.Drawing.Point(0, 0);
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(27, 24);
            this.ButtonBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ButtonBack.TabIndex = 5;
            this.ButtonBack.TabStop = false;
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.AutoSize = true;
            this.ButtonClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonClose.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonClose.Location = new System.Drawing.Point(460, 0);
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
            this.topPanel.Size = new System.Drawing.Size(476, 47);
            this.topPanel.TabIndex = 0;
            this.topPanel.Text = "Отгрузки";
            this.topPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            // 
            // ShipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 544);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShipmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShipmentForm";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SupplyForm_KeyUp);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.findBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ComboBox idUserField;
        private System.Windows.Forms.ComboBox idSupplyField;
        private System.Windows.Forms.TextBox deleteField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dateField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idField;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ButtonShowAll;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonFind;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.TextBox countField;
        private System.Windows.Forms.PictureBox findBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox ButtonBack;
        private System.Windows.Forms.Label ButtonClose;
        private System.Windows.Forms.Label topPanel;
        private System.Windows.Forms.ComboBox productField;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn adres;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn supply;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUser;
        private System.Windows.Forms.PictureBox ButtonExportExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ComboBox findField;
    }
}
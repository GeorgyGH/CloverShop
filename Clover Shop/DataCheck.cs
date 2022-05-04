using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Clover_Shop
{
    class DataCheck
    {
        DataLoad dataLoad = new DataLoad();

        public bool FieldInLP(int productFieldIndex, string addressFieldText, string countFieldText, int idSupplyFieldIndex)
        {
            if (productFieldIndex <= -1)
            {
                MessageBox.Show("Выберите из списка или введите наименование товара полностью", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (addressFieldText == "")
            {
                MessageBox.Show("Введите адрес расположения товара", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (countFieldText == "")
            {
                MessageBox.Show("Введите количество товара", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (idSupplyFieldIndex <= -1)
            {
                MessageBox.Show("Выберите из списка или введите id поставки полностью", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            int num;
            bool isNum = int.TryParse(countFieldText, out num);

            if (!isNum || Int32.Parse(countFieldText) <= 0)
            {
                MessageBox.Show("Введите корректное количество товара", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            return false;
        }

        public bool FieldInShipment(int productFieldIndex, string productFieldText, string countFieldText, string dateFieldText, int idSupplyFieldIndex, string idSupplyFieldText, int idUserFieldIndex)
        {
            string valueInSupply = dataLoad.ValueInDb("SELECT `product` FROM `supply` WHERE `id` = @valueInDB", idSupplyFieldText);

            if(productFieldText != valueInSupply)
            {
                if (productFieldIndex <= -1)
                {
                    MessageBox.Show("Выберите из списка или введите наименование товара полностью", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return true;
                }
            }

            if (countFieldText == "")
            {
                MessageBox.Show("Введите количество товара", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (dateFieldText == "")
            {
                MessageBox.Show("Введите дату отгрузки", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (idSupplyFieldIndex <= -1)
            {
                MessageBox.Show("Выберите из списка или введите id поставки полностью", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (idUserFieldIndex <= -1)
            {
                MessageBox.Show("Выберите из списка или введите ID работника осуществившего отгрузку полностью", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            int num;
            bool isNum = int.TryParse(countFieldText, out num);
            if (!isNum || Int32.Parse(countFieldText) <= 0)
            {
                MessageBox.Show("Введите корректное количество товара", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (dateFieldText.Length > 0)
            {
                try
                {
                    DateTime.Parse(dateFieldText);
                }
                catch (Exception)
                {
                    MessageBox.Show("Введите сущетсвующую дату в формате ДД.ММ.ГГГГ", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return true;
                }
            }

            return false;
        }

        public bool FieldInSupplier(string supplierFieldText, string addressFieldText, string mailFieldText)
        {
            if (supplierFieldText == "")
            {
                MessageBox.Show("Введите поставщика", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (addressFieldText == "")
            {
                MessageBox.Show("Введите адрес поставщика", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (mailFieldText == "")
            {
                MessageBox.Show("Введите почту поставщика", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            return false;
        }

        public bool FieldInSupply(int idSupplierFieldIndex, string productFieldText, string countFieldText, string dateFieldText, int idUserFieldIndex)
        {
            if (idSupplierFieldIndex <= -1)
            {
                MessageBox.Show("Выберите из списка или введите id поставщика полностью", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (productFieldText == "")
            {
                MessageBox.Show("Введите наименование товара", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (countFieldText == "")
            {
                MessageBox.Show("Введите количество товара", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (dateFieldText == "")
            {
                MessageBox.Show("Введите дату поставки", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }
            if (idUserFieldIndex <= -1)
            {
                MessageBox.Show("Выберите из списка или введите ID работника принявшего поставку полностью", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            int num;
            bool isNum = int.TryParse(countFieldText, out num);

            if (!isNum || Int32.Parse(countFieldText) <= 0)
            {
                MessageBox.Show("Введите корректное количество товара", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            if (dateFieldText.Length > 0)
            {
                try
                {
                    DateTime.Parse(dateFieldText);
                }
                catch (Exception)
                {
                    MessageBox.Show("Введите сущетсвующую дату в формате ДД.ММ.ГГГГ", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return true;
                }
            }

            return false;
        }

        public void IsDataAdd(MySqlCommand commandAddData, DB db)
        {
            db.OpenConnection();

            if (commandAddData.ExecuteNonQuery() == 1)
                MessageBox.Show("Данные были добавлены", "Добавление данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            else
                MessageBox.Show("Данные не были добавлены", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            db.CloseConnection();
        }

        public void IsDataUpdate(MySqlCommand updateCommand, DB db)
        {
            db.OpenConnection();

            if (updateCommand.ExecuteNonQuery() == 1)
                MessageBox.Show("Данные были обновлены", "Обновление данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            else

                MessageBox.Show("Данные не были обновлены", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            db.CloseConnection();
        }

        public bool BeforeDelete(string deleteFieldText, string TextInField)
        {
            if (deleteFieldText == "" || deleteFieldText == TextInField)
            {
                MessageBox.Show(TextInField, "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            int num;
            bool isNum = int.TryParse(deleteFieldText, out num);

            if (!isNum)
            {
                MessageBox.Show("Введите корректный ID", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            return false;
        }

        public bool BeforeFind(int searchFieldIndex, string searchFieldText, string defualtText, string errorText)
        {
            if (searchFieldIndex <= -1 || searchFieldText == null || searchFieldText == "" || searchFieldText == defualtText)
            {
                MessageBox.Show(errorText, "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            return false;
        }

        public bool BeforeUpdate(string idFieldText)
        {
            if (idFieldText == "")
            {
                MessageBox.Show("Выберите из таблицы строку в которой вы хотите поменять данные", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }
            return false;
        }

        public bool DataInComboBox(int fieldIndex, string fieldText, string errorText)
        {
            if (fieldIndex <= -1 || fieldText == null || fieldText == "")
            {
                MessageBox.Show(errorText, "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return true;
            }

            return false;
        }

        public string TextInCombobox(string textInField)
        {
            string text = null;

            if (textInField == null || textInField == "")
                return text = null;
            else
                return text = textInField;
        }

        public bool RowsInReader(string command, string valueInField, DB db)
        {
            MySqlCommand checkCount = new MySqlCommand(command, db.GetConnection());
            checkCount.Parameters.Add("@valueInDB", MySqlDbType.VarChar).Value = valueInField;

            db.OpenConnection();

            MySqlDataReader readerLocation = checkCount.ExecuteReader();

            if (readerLocation.HasRows)
            {
                readerLocation.Close();
                db.CloseConnection();

                return true;
            }

            readerLocation.Close();
            db.CloseConnection();

            return false;
        }
    }
}

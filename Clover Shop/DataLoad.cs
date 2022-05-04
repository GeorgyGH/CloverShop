using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Clover_Shop
{
    class DataLoad
    {
        DB db = new DB();

        public string ValueInDb(string command, string valueInField)
        {
            MySqlCommand checkValueInDB = new MySqlCommand(command, db.GetConnection());
            checkValueInDB.Parameters.Add("@valueInDB", MySqlDbType.VarChar).Value = valueInField;

            db.OpenConnection();

            string valueInDB = checkValueInDB.ExecuteScalar().ToString();

            db.CloseConnection();

            return valueInDB;
        }

        public int CountInLP(string idSupply)
        {
            MySqlCommand commandCheckCount = new MySqlCommand("SELECT `count` FROM `location_product` WHERE `id_supply` = @id", db.GetConnection());
            commandCheckCount.Parameters.Add("@id", MySqlDbType.VarChar).Value = idSupply;

            db.OpenConnection();

            MySqlDataReader reader = commandCheckCount.ExecuteReader();

            int countInDGV = 0;

            if (reader.HasRows)
            {
                reader.Close();

                MySqlDataAdapter adapterCount = new MySqlDataAdapter(commandCheckCount);

                db.OpenConnection();

                DataTable tableCount = new DataTable();

                adapterCount.Fill(tableCount);

                for (int i = 0; tableCount.Rows.Count > i; i++)
                {
                    countInDGV += Int32.Parse(tableCount.Rows[i][0].ToString());
                }
            }

            db.CloseConnection();

            return countInDGV;
        }

        public List<string[]> InDGV(string command, int numberRow)
        {

            MySqlCommand commandLoadData = new MySqlCommand(command, db.GetConnection());

            db.OpenConnection();

            MySqlDataReader readerLoadData = commandLoadData.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (readerLoadData.Read())
            {
                data.Add(new string[numberRow]);
                for (int i = 0; i < numberRow; i++)
                    data[data.Count - 1][i] = readerLoadData[i].ToString();

            }

            readerLoadData.Close();

            db.CloseConnection();

            return data;
        }

        public List<string[]> ForFind(string command, string valueInField, int numberColums)
        {

            MySqlCommand commandLoadData = new MySqlCommand(command, db.GetConnection());
            commandLoadData.Parameters.Add("@valueInDB", MySqlDbType.VarChar).Value = valueInField;

            db.OpenConnection();

            MySqlDataReader readerLoadData = commandLoadData.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (readerLoadData.Read())
            {
                data.Add(new string[numberColums]);
                for (int i = 0; i < numberColums; i++)
                    data[data.Count - 1][i] = readerLoadData[i].ToString();

            }

            readerLoadData.Close();

            db.CloseConnection();

            return data;
        }

        public DataTable ComboBox (string command)
        {
            MySqlCommand commandComboBox = new MySqlCommand(command, db.GetConnection());

            MySqlDataAdapter adapterComboBox = new MySqlDataAdapter(commandComboBox);

            db.OpenConnection();

            DataTable tableComboBox = new DataTable();

            adapterComboBox.Fill(tableComboBox);

            db.CloseConnection();

            return tableComboBox;
        }

        public DataTable ForIdSupplyBox (string command ,string textInField)
        {

            MySqlCommand commandForIdSupply = new MySqlCommand(command, db.GetConnection());
            commandForIdSupply.Parameters.Add("@product", MySqlDbType.VarChar).Value = textInField;

            MySqlDataAdapter adapterSupply = new MySqlDataAdapter(commandForIdSupply);

            db.OpenConnection();

            MySqlDataReader reader = commandForIdSupply.ExecuteReader();

            DataTable tableIdSupply = new DataTable();

            if (reader.HasRows)
            {
                reader.Close();

                adapterSupply.Fill(tableIdSupply);

                db.CloseConnection();
            }
            else
            {
                if (textInField != "" || textInField != null)
                    MessageBox.Show("Выберите из списка или введите наименование товара полностью", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                reader.Close();
                db.CloseConnection();
            }

            return tableIdSupply;
        }
    }
}


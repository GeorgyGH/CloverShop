using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Clover_Shop
{
    class DataDelete
    {
        DB db = new DB();

        public void FromDB (string command, string idField)
        {
            MySqlCommand commandDeleteData = new MySqlCommand(command, db.GetConnection());
            commandDeleteData.Parameters.Add("@id", MySqlDbType.Int32).Value = idField;

            db.OpenConnection();

            if (commandDeleteData.ExecuteNonQuery() == 1)
                MessageBox.Show("Данные были удалены", "Удаление данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            else
                MessageBox.Show("Данные не были удалены", "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            db.CloseConnection();
        }
    }
}

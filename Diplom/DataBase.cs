using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diplom
{
    internal class DataBase
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1J0PIJN;Initial Catalog=Diplom;Integrated Security=True;");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return connection;
        }

        public string StringCon()
        {
            return @"Data Source=DESKTOP-1J0PIJN;Initial Catalog=Diplom;Integrated Security=True;";
        }

        public SqlDataAdapter queryExecute(string query)
        {
            try
            {
                SqlConnection conn = new SqlConnection(StringCon());
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.ExecuteNonQuery();
                return adapter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                return null;
            }
        }
    }
}

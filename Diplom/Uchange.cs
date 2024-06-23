using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Uchange : Form
    {
        private DataBase dataBase = new DataBase();

        public Uchange()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            dataBase.openConnection(); // Открываем соединение с базой данных

            // Очищаем предыдущие элементы в комбобоксе
            comboBoxUsers.Items.Clear();

            // Загружаем имена пользователей из базы данных в комбобокс
            string query = "SELECT User_FIO FROM Users";
            SqlDataAdapter adapter = dataBase.queryExecute(query);

            if (adapter != null)
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    comboBoxUsers.Items.Add(row["User_FIO"].ToString());
                }
            }

            dataBase.closeConnection(); // Закрываем соединение с базой данных
        }

        private void btnMakeAdmin_Click(object sender, EventArgs e)
        {
            dataBase.openConnection(); // Открываем соединение с базой данных

            string selectedUser = comboBoxUsers.SelectedItem?.ToString();

            if (selectedUser != null)
            {
                // Находим ID пользователя по его имени
                string queryFindUserId = $"SELECT User_Id FROM Users WHERE User_FIO = '{selectedUser}'";
                SqlDataAdapter adapter = dataBase.queryExecute(queryFindUserId);

                if (adapter != null)
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        int userId = Convert.ToInt32(table.Rows[0]["User_Id"]);

                        // Обновляем роль пользователя на администратора
                        string queryMakeAdmin = $"UPDATE Users SET Role_Id = 2 WHERE User_Id = {userId}";
                        adapter = dataBase.queryExecute(queryMakeAdmin);

                        if (adapter != null)
                        {
                            MessageBox.Show($"Пользователь {selectedUser} теперь администратор.");
                            LoadUsers(); // Обновляем список пользователей
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Не удалось найти пользователя с именем {selectedUser}.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для изменения роли.");
            }

            dataBase.closeConnection(); // Закрываем соединение с базой данных
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            dataBase.openConnection(); // Открываем соединение с базой данных

            string selectedUser = comboBoxUsers.SelectedItem?.ToString();

            if (selectedUser != null)
            {
                // Находим ID пользователя по его имени
                string queryFindUserId = $"SELECT User_Id FROM Users WHERE User_FIO = '{selectedUser}'";
                SqlDataAdapter adapter = dataBase.queryExecute(queryFindUserId);

                if (adapter != null)
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        int userId = Convert.ToInt32(table.Rows[0]["User_Id"]);

                        // Удаляем пользователя из базы данных
                        string queryRemoveUser = $"DELETE FROM Users WHERE User_Id = {userId}";
                        adapter = dataBase.queryExecute(queryRemoveUser);

                        if (adapter != null)
                        {
                            MessageBox.Show($"Пользователь {selectedUser} удален из базы данных.");
                            LoadUsers(); // Обновляем список пользователей
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Не удалось найти пользователя с именем {selectedUser}.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для удаления.");
            }

            dataBase.closeConnection(); // Закрываем соединение с базой данных
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Choose choose = new Choose();
            this.Hide();
            choose.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

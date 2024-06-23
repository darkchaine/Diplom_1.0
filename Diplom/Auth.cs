using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Auth : Form
    {
        public static string UserName { get; private set; }
        private DataBase dataBase = new DataBase();

        public Auth()
        {
            InitializeComponent();
            guna2TextBox5.UseSystemPasswordChar = true;
            guna2TextBox4.UseSystemPasswordChar = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Load your form
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - возвращает байтовый массив
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // "x2" - преобразует байт в 16-ричное представление
                }
                return builder.ToString();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var User_FIO = guna2TextBox3.Text;
            var User_Phone = guna2TextBox2.Text;
            var User_Password = HashPassword(guna2TextBox4.Text); // Хешируем пароль
            var User_Login = guna2TextBox1.Text;
            int Role_Id = 1;

            // Проверка длины пароля
            if (guna2TextBox4.Text.Length < 8)
            {
                MessageBox.Show("Пароль должен быть не менее 8 символов.");
                return;
            }

            // Проверка формата номера телефона
            if (!Regex.IsMatch(User_Phone, @"^(?:\+7|8)\d{10}$"))
            {
                MessageBox.Show("Номер телефона должен начинаться с +7 или 8 и содержать 10 цифр после этого.");
                return;
            }

            string querystring = $"insert into Users(User_FIO, User_Phone, Role_Id, User_Login, User_Password) values ('{User_FIO}','{User_Phone}','{Role_Id}','{User_Login}','{User_Password}')";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы успешно зарегистрировали аккаунт!");

                // Очистка текстбоксов после успешной регистрации
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
                guna2TextBox3.Clear();
                guna2TextBox4.Clear();
            }
            else
            {
                MessageBox.Show("Ошибка, проверьте введенные данные");
            }
            dataBase.closeConnection();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var User = guna2TextBox8.Text;
            var Pass = HashPassword(guna2TextBox5.Text); // Хешируем введенный пароль

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"select User_FIO, Role_Id from Users where User_Login = '{User}' and User_Password = '{Pass}'";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                // Получаем ФИО пользователя из результата запроса
                UserName = table.Rows[0]["User_FIO"].ToString();

                int role = Convert.ToInt32(table.Rows[0]["Role_Id"]);
                switch (role)
                {
                    case 1:
                        MessageBox.Show("Вы успешно авторизировались!");
                        Main main = new Main();
                        main.Show();
                        this.Hide();
                        break;
                    case 2:
                        MessageBox.Show("Вы успешно авторизировались как администратор!");
                        Choose choose = new Choose();
                        choose.Show();
                        this.Hide();
                        break;
                    default:
                        MessageBox.Show("Неизвестная роль");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Логин или пароль неверны");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            guna2TextBox4.UseSystemPasswordChar = !guna2CheckBox1.Checked;
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            guna2TextBox5.UseSystemPasswordChar = !guna2CheckBox2.Checked;
        }
    }
}

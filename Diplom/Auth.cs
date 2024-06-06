using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Diplom
{
    public partial class Auth : Form
    {
        DataBase dataBase = new DataBase();
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

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            var User_FIO = guna2TextBox3.Text;
            var User_Phone = guna2TextBox2.Text;
            var User_Password = guna2TextBox4.Text;
            var User_Login = guna2TextBox1.Text;
            int Role_Id = 1;
            // int User_Id = 1;

            string querystring = $"insert into Users(User_FIO, User_Phone, Role_Id, User_Login, User_Password) values ('{User_FIO}','{User_Phone}','{Role_Id}','{User_Login}','{User_Password}')";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы успешно зарегистрировали аккаунт!");
            }
            else
            {
                MessageBox.Show("Ошибка, проверьте введеные данных");
            }
            dataBase.closeConnection();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            

            var User = guna2TextBox8.Text;
            var Pass = guna2TextBox5.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"select User_Login, User_Password, Role_Id from Users where User_Login = '{User}' and User_Password = '{Pass}'";

            SqlCommand command = new SqlCommand(query, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
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
                        MessageBox.Show("Вы успешно авторизировались как администратор");
                        Admin admin = new Admin();
                        admin.Show();
                        this.Hide();
                        break;

                    default:
                        MessageBox.Show("Неизвестная роль");
                        break;
                }
            }
            else {

                MessageBox.Show("Логин или пароль неверны");
            
            }

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                guna2TextBox4.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox4.UseSystemPasswordChar= true;
            }
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox2.Checked)
            {
                guna2TextBox5.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox5.UseSystemPasswordChar = true;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }                      
    }

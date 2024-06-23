using Guna.UI2.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Ncategory : Form
    {
        private DataBase dataBase = new DataBase();

        public Ncategory()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            // Добавляем элементы в ComboBox
            guna2ComboBox1.Items.Add("Доходы");
            guna2ComboBox1.Items.Add("Расходы");
            guna2ComboBox1.SelectedIndex = 0; // Устанавливаем начальное значение
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string categoryName = tbCategoryName.Text;
            string selectedType = guna2ComboBox1.SelectedItem.ToString();
            string query = "";

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Введите название категории.");
                return;
            }

            if (selectedType == "Доходы")
            {
                query = "INSERT INTO Pcategories (PCategory_Name) VALUES (@CategoryName)";
            }
            else if (selectedType == "Расходы")
            {
                query = "INSERT INTO Categories (Category_Name) VALUES (@CategoryName)";
            }

            using (SqlConnection connection = dataBase.getConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Категория успешно добавлена.");
                        tbCategoryName.Clear(); // Очистка текстбокса после добавления
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении категории: " + ex.Message);
                    }
                }
            }
            this.Close();
            Ncategory ncategory = new Ncategory();  
            ncategory.Show();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Choose choose = new Choose();
            choose.Show();
            this.Hide();
        }
    }
}

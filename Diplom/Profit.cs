using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diplom
{
    enum RowStateProfit
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Profit : Form
    {
        DataBase database = new DataBase();

        public Profit()
        {
            InitializeComponent();
            btnDelete.Click += btnDelete_Click;
            btnChange.Click += btnChange_Click;
            Profit_Load(this, EventArgs.Empty); // Для загрузки данных при открытии формы
        }

        private void CreateColumns()
        {
            guna2DataGridView1.Columns.Add("Profit_Id", "Номер дохода");
            guna2DataGridView1.Columns.Add("User_FIO", "ФИО пользователя");
            guna2DataGridView1.Columns.Add("PCategory_Name", "Категория дохода");
            guna2DataGridView1.Columns.Add("Profit_Summ", "Сумма дохода");
            var dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.Name = "Profit_Date";
            dateColumn.HeaderText = "Дата дохода";
            dateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";
            guna2DataGridView1.Columns.Add(dateColumn);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetDateTime(4).ToString("dd.MM.yyyy"));
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"SELECT * FROM Profit";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

                Tb_Cid.Text = row.Cells["Profit_Id"].Value?.ToString();
                Cb_UserFIO.SelectedItem = row.Cells["User_FIO"].Value?.ToString();
                Tb_Category.Text = row.Cells["PCategory_Name"].Value?.ToString();
                Tb_Summ.Text = row.Cells["Profit_Summ"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["Profit_Date"].Value?.ToString(), out DateTime date))
                {
                    DatePicker.Value = date;
                }
                else
                {
                    // Обработка случая, когда дата не может быть распознана
                }
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(guna2DataGridView1);
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"SELECT * FROM Profit WHERE Profit_Id LIKE '%{Tb_Search.Text}%' OR User_FIO IN (SELECT User_FIO FROM Users WHERE User_FIO LIKE '%{Tb_Search.Text}%') OR PCategory_Name LIKE '%{Tb_Search.Text}%' OR Profit_Summ LIKE '%{Tb_Search.Text}%' OR Profit_Date LIKE '%{Tb_Search.Text}%'";

            SqlCommand com = new SqlCommand(searchString, database.getConnection());
            database.openConnection();

            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();
        }

        private void deleteRow()
        {
            int index = guna2DataGridView1.CurrentCell.RowIndex;

            guna2DataGridView1.Rows[index].Visible = false;

            if (guna2DataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                guna2DataGridView1.Rows[index].Cells[5].Value = RowStateProfit.Deleted;
                return;
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void InitializeDataGridView()
        {
            guna2DataGridView1.ColumnHeadersHeight = 40; // Задайте необходимую высоту
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Cb_UserFIO.Text) || string.IsNullOrWhiteSpace(Tb_Category.Text) || string.IsNullOrWhiteSpace(Tb_Summ.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            string queryDeleteProfit = "DELETE FROM Profit WHERE User_FIO = @UserFIO AND PCategory_Name = @PCategoryName AND Profit_Summ = @ProfitSumm AND Profit_Date = @ProfitDate";

            using (SqlCommand command = new SqlCommand(queryDeleteProfit, database.getConnection()))
            {
                command.Parameters.AddWithValue("@UserFIO", Cb_UserFIO.Text);
                command.Parameters.AddWithValue("@PCategoryName", Tb_Category.Text);
                command.Parameters.AddWithValue("@ProfitSumm", Tb_Summ.Text);
                command.Parameters.AddWithValue("@ProfitDate", DatePicker.Value);

                try
                {
                    database.openConnection();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись успешно удалена");
                        RefreshDataGrid(guna2DataGridView1);
                    }
                    else
                    {
                        MessageBox.Show("Запись не найдена");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Cb_UserFIO.Text) || string.IsNullOrWhiteSpace(Tb_Category.Text) || string.IsNullOrWhiteSpace(Tb_Summ.Text) || string.IsNullOrWhiteSpace(Tb_Cid.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            string queryUpdateProfit = "UPDATE Profit SET User_FIO = @UserFIO, PCategory_Name = @PCategoryName, Profit_Summ = @ProfitSumm, Profit_Date = @ProfitDate WHERE Profit_Id = @ProfitId";

            using (SqlCommand command = new SqlCommand(queryUpdateProfit, database.getConnection()))
            {
                command.Parameters.AddWithValue("@ProfitId", Tb_Cid.Text);
                command.Parameters.AddWithValue("@UserFIO", Cb_UserFIO.Text);
                command.Parameters.AddWithValue("@PCategoryName", Tb_Category.Text);
                command.Parameters.AddWithValue("@ProfitSumm", Tb_Summ.Text);
                command.Parameters.AddWithValue("@ProfitDate", DatePicker.Value);

                try
                {
                    database.openConnection();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись успешно обновлена");
                        RefreshDataGrid(guna2DataGridView1);
                    }
                    else
                    {
                        MessageBox.Show("Запись не найдена");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении записи: " + ex.Message);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }

        private void FillUserFIOComboBox()
        {
            string queryUserFIO = "SELECT DISTINCT User_FIO FROM Users";

            using (SqlCommand command = new SqlCommand(queryUserFIO, database.getConnection()))
            {
                try
                {
                    database.openConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Cb_UserFIO.Items.Add(reader["User_FIO"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке ФИО пользователей: " + ex.Message);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }

        private void Profit_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(guna2DataGridView1);
            FillUserFIOComboBox();
            InitializeDataGridView();
            FillCategoryComboBox();
        }

        private void FillCategoryComboBox()
        {
            string queryCategories = "SELECT DISTINCT PCategory_Name FROM Pcategories";

            using (SqlCommand command = new SqlCommand(queryCategories, database.getConnection()))
            {
                try
                {
                    database.openConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Tb_Category.Items.Add(reader["PCategory_Name"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке категорий: " + ex.Message);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Cb_UserFIO.Text) || string.IsNullOrWhiteSpace(Tb_Category.Text) || string.IsNullOrWhiteSpace(Tb_Summ.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            string queryAddProfit = "INSERT INTO Profit (User_FIO, PCategory_Name, Profit_Summ, Profit_Date) VALUES (@UserFIO, @PCategoryName, @ProfitSumm, @ProfitDate)";

            using (SqlCommand command = new SqlCommand(queryAddProfit, database.getConnection()))
            {
                command.Parameters.AddWithValue("@UserFIO", Cb_UserFIO.Text);
                command.Parameters.AddWithValue("@PCategoryName", Tb_Category.Text);
                command.Parameters.AddWithValue("@ProfitSumm", Tb_Summ.Text);
                command.Parameters.AddWithValue("@ProfitDate", DatePicker.Value);

                try
                {
                    database.openConnection();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!");
                    RefreshDataGrid(guna2DataGridView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при создании записи: " + ex.Message);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }

        private void Tb_Search_TextChanged_1(object sender, EventArgs e)
        {
            Search(guna2DataGridView1);
        }
    }
}

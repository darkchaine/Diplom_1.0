using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diplom
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Costs : Form
    {
        DataBase database = new DataBase();

        public Costs()
        {
            InitializeComponent();
            btnDelete.Click += btnDelete_Click;
            btnChange.Click += btnChange_Click;
        }

        private void CreateColumns()
        {
            guna2DataGridView1.Columns.Add("Cost_Id", "Номер траты");
            guna2DataGridView1.Columns.Add("User_FIO", "ФИО пользователя");
            guna2DataGridView1.Columns.Add("Category_Name", "Категория траты");
            guna2DataGridView1.Columns.Add("Cost_Summ", "Сумма траты");
            var dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.Name = "Cost_Date";
            dateColumn.HeaderText = "Дата траты";
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
            string queryString = "SELECT * FROM Costs";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void main_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(guna2DataGridView1);
            FillCategoryComboBox();
            FillUserFIOComboBox();
            InitializeDataGridView();
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e) { }

        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

                Tb_Cid.Text = row.Cells["Cost_Id"].Value?.ToString();
                Cb_UserFIO.SelectedItem = row.Cells["User_FIO"].Value?.ToString();
                Tb_Category.Text = row.Cells["Category_Name"].Value?.ToString();
                Tb_Summ.Text = row.Cells["Cost_Summ"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["Cost_Date"].Value?.ToString(), out DateTime date))
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

        private void Btn_New_Click(object sender, EventArgs e)
        {
            Add_Cost add_Cost = new Add_Cost();
            add_Cost.Show();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"SELECT * FROM Costs WHERE Cost_Id LIKE '%{Tb_Search.Text}%' OR User_FIO IN (SELECT User_FIO FROM Users WHERE User_FIO LIKE '%{Tb_Search.Text}%') OR Category_Name LIKE '%{Tb_Search.Text}%' OR Cost_Summ LIKE '%{Tb_Search.Text}%' OR Cost_Date LIKE '%{Tb_Search.Text}%'";

            SqlCommand com = new SqlCommand(searchString, database.getConnection());
            database.openConnection();

            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();
        }

        private void Tb_Search_TextChanged(object sender, EventArgs e)
        {
            Search(guna2DataGridView1);
        }

        private void deleteRow()
        {
            int index = guna2DataGridView1.CurrentCell.RowIndex;

            guna2DataGridView1.Rows[index].Visible = false;

            if (guna2DataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                guna2DataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Cb_UserFIO.Text) || string.IsNullOrWhiteSpace(Tb_Category.Text) || string.IsNullOrWhiteSpace(Tb_Summ.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            string queryAddCost = "INSERT INTO Costs (User_FIO, Category_Name, Cost_Summ, Cost_Date) VALUES (@UserFIO, @CategoryName, @CostSumm, @CostDate)";

            using (SqlCommand command = new SqlCommand(queryAddCost, database.getConnection()))
            {
                command.Parameters.AddWithValue("@UserFIO", Cb_UserFIO.Text);
                command.Parameters.AddWithValue("@CategoryName", Tb_Category.Text);
                command.Parameters.AddWithValue("@CostSumm", Tb_Summ.Text);
                command.Parameters.AddWithValue("@CostDate", DatePicker.Value);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Cb_UserFIO.Text) || string.IsNullOrWhiteSpace(Tb_Category.Text) || string.IsNullOrWhiteSpace(Tb_Summ.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            string queryDeleteCost = "DELETE FROM Costs WHERE User_FIO = @UserFIO AND Category_Name = @CategoryName AND Cost_Summ = @CostSumm AND Cost_Date = @CostDate";

            using (SqlCommand command = new SqlCommand(queryDeleteCost, database.getConnection()))
            {
                command.Parameters.AddWithValue("@UserFIO", Cb_UserFIO.Text);
                command.Parameters.AddWithValue("@CategoryName", Tb_Category.Text);
                command.Parameters.AddWithValue("@CostSumm", Tb_Summ.Text);
                command.Parameters.AddWithValue("@CostDate", DatePicker.Value);

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

            string queryUpdateCost = "UPDATE Costs SET User_FIO = @UserFIO, Category_Name = @CategoryName, Cost_Summ = @CostSumm, Cost_Date = @CostDate WHERE Cost_Id = @CostId";

            using (SqlCommand command = new SqlCommand(queryUpdateCost, database.getConnection()))
            {
                command.Parameters.AddWithValue("@CostId", Tb_Cid.Text);
                command.Parameters.AddWithValue("@UserFIO", Cb_UserFIO.Text);
                command.Parameters.AddWithValue("@CategoryName", Tb_Category.Text);
                command.Parameters.AddWithValue("@CostSumm", Tb_Summ.Text);
                command.Parameters.AddWithValue("@CostDate", DatePicker.Value);

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

        private void FillCategoryComboBox()
        {
            string queryCategories = "SELECT Category_Name FROM categories";

            using (SqlCommand command = new SqlCommand(queryCategories, database.getConnection()))
            {
                try
                {
                    database.openConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Tb_Category.Items.Add(reader["Category_Name"].ToString());
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

        private void FillUserFIOComboBox()
        {
            string queryUsers = "SELECT User_FIO FROM Users";

            using (SqlCommand command = new SqlCommand(queryUsers, database.getConnection()))
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
                    MessageBox.Show("Ошибка при загрузке пользователей: " + ex.Message);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }
    }
}

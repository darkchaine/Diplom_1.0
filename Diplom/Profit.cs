using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        int selectedRow;

        public Profit()
        {
            InitializeComponent();
            btnDelete.Click += btnDelete_Click;
            btnChange.Click += btnChange_Click;
        }

        private void CreateColumns()
        {
            guna2DataGridView1.Columns.Add("Profit_Id", "Номер дохода");
            guna2DataGridView1.Columns.Add("User_Id", "Номер пользователя");
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
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetInt32(3), record.GetDateTime(4).ToString("dd.MM.yyyy"));
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from Profit";

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
                Tb_Uid.Text = row.Cells["User_Id"].Value?.ToString();
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

        /*  private void Btn_New_Click(object sender, EventArgs e)
          {
              Add_Profit add_Profit = new Add_Profit();
              add_Profit.Show();
          } */

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Profit where concat (PCategory_Name,Profit_Summ,Profit_Date) like '%" + Tb_Search.Text + "%'";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Tb_Uid.Text) || string.IsNullOrWhiteSpace(Tb_Category.Text) || string.IsNullOrWhiteSpace(Tb_Summ.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            string queryAddProfit = "INSERT INTO Profit (User_Id, PCategory_Name, Profit_Summ, Profit_Date) VALUES (@UserId, @PCategoryName, @ProfitSumm, @ProfitDate)";

            using (SqlCommand command = new SqlCommand(queryAddProfit, database.getConnection()))
            {
                command.Parameters.AddWithValue("@UserId", Tb_Uid.Text);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Tb_Uid.Text) || string.IsNullOrWhiteSpace(Tb_Category.Text) || string.IsNullOrWhiteSpace(Tb_Summ.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            string queryDeleteProfit = "DELETE FROM Profit WHERE User_Id = @UserId AND PCategory_Name = @PCategoryName AND Profit_Summ = @ProfitSumm AND Profit_Date = @ProfitDate";

            using (SqlCommand command = new SqlCommand(queryDeleteProfit, database.getConnection()))
            {
                command.Parameters.AddWithValue("@UserId", Tb_Uid.Text);
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
            if (string.IsNullOrWhiteSpace(Tb_Uid.Text) || string.IsNullOrWhiteSpace(Tb_Category.Text) || string.IsNullOrWhiteSpace(Tb_Summ.Text) || string.IsNullOrWhiteSpace(Tb_Cid.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            string queryUpdateProfit = "UPDATE Profit SET User_Id = @UserId, PCategory_Name = @PCategoryName, Profit_Summ = @ProfitSumm, Profit_Date = @ProfitDate WHERE Profit_Id = @ProfitId";

            using (SqlCommand command = new SqlCommand(queryUpdateProfit, database.getConnection()))
            {
                command.Parameters.AddWithValue("@ProfitId", Tb_Cid.Text);
                command.Parameters.AddWithValue("@UserId", Tb_Uid.Text);
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

        private void FillCategoryComboBox()
        {
            string queryCategories = "SELECT PCategory_Name FROM Pcategories";

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

        private void Profit_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(guna2DataGridView1);
            FillCategoryComboBox();
            InitializeDataGridView();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

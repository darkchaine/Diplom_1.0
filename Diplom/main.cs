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
    public partial class Main : Form
    {
        DataBase database = new DataBase();
        public Main()
        {
            InitializeComponent();
            UpdateTotalCostsLabel();
        }
        private void UpdateTotalCostsLabel()
        {
            decimal totalCosts = GetMonthlyTotalCosts();
            labelTotalCosts.Text = $"Сумма всех трат за этот месяц: {totalCosts:C}";
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }
        private decimal GetMonthlyTotalCosts()
        {
            decimal total = 0;
            string query = "SELECT SUM(Cost_Summ) FROM Costs WHERE MONTH(Cost_Date) = @CurrentMonth AND YEAR(Cost_Date) = @CurrentYear";

            using (SqlCommand command = new SqlCommand(query, database.getConnection()))
            {
                command.Parameters.AddWithValue("@CurrentMonth", DateTime.Now.Month);
                command.Parameters.AddWithValue("@CurrentYear", DateTime.Now.Year);

                try
                {
                    database.openConnection();
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        total = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при вычислении суммы трат: " + ex.Message);
                }
                finally
                {
                    database.closeConnection();
                }
            }

            return total;
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profit costs = new Profit();
            costs.Show();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Costs costs = new Costs();
            costs.Show();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

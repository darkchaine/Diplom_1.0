using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Main : Form
    {
        DataBase database = new DataBase();

        public Main()
        {
            InitializeComponent();
            labelUserName.Text = "Добро пожаловать, " + Auth.UserName;
            LoadMonths();
            UpdateTotalsForCurrentMonth();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Cb_Month.SelectedIndexChanged += Cb_Month_SelectedIndexChanged;
        }

        private void LoadMonths()
        {
            string query = "SELECT Month_Id, Month_Name FROM Month";

            using (SqlCommand command = new SqlCommand(query, database.getConnection()))
            {
                try
                {
                    database.openConnection();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int monthId = reader.GetInt32(0);
                        string monthName = reader.GetString(1);
                        Cb_Month.Items.Add(new ComboBoxItem(monthName, monthId));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке месяцев: " + ex.Message);
                }
                finally
                {
                    database.closeConnection();
                }
            }
        }

        private void UpdateTotalsForCurrentMonth()
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            UpdateTotalCostsLabel(currentMonth, currentYear);
            UpdateIncomeTotalLabel(currentMonth, currentYear);
        }

        private void UpdateTotalsForSelectedMonth()
        {
            if (Cb_Month.SelectedItem is ComboBoxItem selectedMonth)
            {
                int selectedMonthId = selectedMonth.Value;
                int currentYear = DateTime.Now.Year;

                UpdateTotalCostsLabel(selectedMonthId, currentYear);
                UpdateIncomeTotalLabel(selectedMonthId, currentYear);
            }
        }

        private void UpdateTotalCostsLabel(int month, int year)
        {
            decimal totalCosts = GetMonthlyTotalCosts(month, year);
            labelTotalCosts.Text = $"Сумма всех трат за выбранный месяц: {totalCosts:C}";
        }

        private void UpdateIncomeTotalLabel(int month, int year)
        {
            decimal totalIncome = GetMonthlyTotalIncome(month, year);
            totalprofit.Text = $"Сумма доходов за выбранный месяц: {totalIncome:C}";
        }

        private decimal GetMonthlyTotalCosts(int month, int year)
        {
            decimal total = 0;
            string query = "SELECT SUM(Cost_Summ) FROM Costs WHERE MONTH(Cost_Date) = @Month AND YEAR(Cost_Date) = @Year";

            using (SqlCommand command = new SqlCommand(query, database.getConnection()))
            {
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);

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

        private decimal GetMonthlyTotalIncome(int month, int year)
        {
            decimal total = 0;
            string query = "SELECT SUM(Profit_Summ) FROM Profit WHERE MONTH(Profit_Date) = @Month AND YEAR(Profit_Date) = @Year";

            using (SqlCommand command = new SqlCommand(query, database.getConnection()))
            {
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);

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
                    MessageBox.Show("Ошибка при подсчете суммы доходов: " + ex.Message);
                }
                finally
                {
                    database.closeConnection();
                }
            }

            return total;
        }

        private void Cb_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalsForSelectedMonth();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profit profit = new Profit();
            profit.Show();
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

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}

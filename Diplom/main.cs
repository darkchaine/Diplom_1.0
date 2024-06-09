using Guna.UI2.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
namespace Diplom
{
    public partial class Main : Form
    {
        DataBase database = new DataBase();

        public Main()
        {
            InitializeComponent();
            lblBalance.Text = "Добро пожаловать, " + Auth.UserName;
            LoadMonths();
            UpdateTotalsForCurrentMonth();
            AdjustLabelProperties();
        }
        private void AdjustLabelProperties()
        {
    
            // Установка выравнивания текста
            lblBalance.TextAlign = ContentAlignment.MiddleLeft;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Cb_Month.SelectedIndexChanged += Cb_Month_SelectedIndexChanged;
            decimal balance = CalculateTotalBalance(DateTime.Now.Month, DateTime.Now.Year);
            lblBalance.Text = $"Баланс: {balance:C}";

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
            decimal balance = CalculateTotalBalance(currentMonth, currentYear);
            lblBalance.Text = $"Баланс: {balance:C}";
        }

        private void UpdateTotalsForSelectedMonth()
        {
            if (Cb_Month.SelectedItem is ComboBoxItem selectedMonth)
            {
                int selectedMonthId = selectedMonth.Value;
                int currentYear = DateTime.Now.Year;

                UpdateTotalCostsLabel(selectedMonthId, currentYear);
                UpdateIncomeTotalLabel(selectedMonthId, currentYear);
                decimal balance = CalculateTotalBalance(selectedMonthId, currentYear);
                lblBalance.Text = $"Баланс: {balance:C}";
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

        private decimal CalculateTotalBalance(int month, int year)
        {
            decimal totalProfit = 0;
            decimal totalCosts = 0;

            string profitQuery = "SELECT SUM(Profit_Summ) FROM Profit WHERE MONTH(Profit_Date) = @Month AND YEAR(Profit_Date) = @Year";
            string costsQuery = "SELECT SUM(Cost_Summ) FROM Costs WHERE MONTH(Cost_Date) = @Month AND YEAR(Cost_Date) = @Year";

            using (SqlCommand profitCommand = new SqlCommand(profitQuery, database.getConnection()))
            using (SqlCommand costsCommand = new SqlCommand(costsQuery, database.getConnection()))
            {
                profitCommand.Parameters.AddWithValue("@Month", month);
                profitCommand.Parameters.AddWithValue("@Year", year);
                costsCommand.Parameters.AddWithValue("@Month", month);
                costsCommand.Parameters.AddWithValue("@Year", year);

                try
                {
                    database.openConnection();

                    // Получение общего дохода
                    var profitResult = profitCommand.ExecuteScalar();
                    if (profitResult != DBNull.Value)
                    {
                        totalProfit = Convert.ToDecimal(profitResult);
                    }

                    // Получение общего расхода
                    var costsResult = costsCommand.ExecuteScalar();
                    if (costsResult != DBNull.Value)
                    {
                        totalCosts = Convert.ToDecimal(costsResult);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при расчете баланса: " + ex.Message);
                }
                finally
                {
                    database.closeConnection();
                }
            }

            return totalProfit - totalCosts;
        }
    }
}

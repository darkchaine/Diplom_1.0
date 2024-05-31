using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Diplom
{
    public partial class Add_Cost : Form
    {
        DataBase database = new DataBase();
        public Add_Cost()
        {
            InitializeComponent();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            database.openConnection();

            var uid =  Tb_Uid.Text;
            var category = Tb_Category.Text;
            int summ;
            var date = DatePicker.Value;

            if (int.TryParse(Tb_Summ.Text, out summ))
            {
                var addQuery = "INSERT INTO Costs (User_Id,Category_Name, Cost_Summ, Cost_Date) VALUES (@uid, @category, @summ, @date)";

                using (var command = new SqlCommand(addQuery, database.getConnection()))
                {
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@summ", summ);
                    command.Parameters.AddWithValue("@date", date);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Трата создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Сумма должна быть целым числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            database.closeConnection();
        }

        private void Add_Cost_Load(object sender, EventArgs e)
        {

        }
    }
}
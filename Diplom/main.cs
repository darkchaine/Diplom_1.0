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
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class main : Form
    {
        DataBase database = new DataBase();

        int selectedRow;

        public main()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {
            guna2DataGridView1.Columns.Add("Cost_Id", "Номер траты");
            guna2DataGridView1.Columns.Add("User_Id", "Номер пользователя");
            guna2DataGridView1.Columns.Add("Category_Name", "Категория траты");
            guna2DataGridView1.Columns.Add("Cost_Summ", "Сумма траты");
            guna2DataGridView1.Columns.Add("Cost_Date", "Дата траты");
            guna2DataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1),record.GetString(2), record.GetInt32(3), record.GetDateTime(4), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from Costs";

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
        }


        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }



        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (selectedRow >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[selectedRow];

                // Убедитесь, что индексы столбцов правильные
                if (row.Cells[0].Value != null)
                {
                    Tb_Cid.Text = row.Cells[0].Value.ToString(); // Первая ячейка
                }
                if (row.Cells[1].Value != null)
                {
                    Tb_Uid.Text = row.Cells[1].Value.ToString(); // Вторая ячейка
                }
                if (row.Cells[2].Value != null)
                {
                    Tb_Category.Text = row.Cells[2].Value.ToString(); // Третья ячейка
                }

                if (row.Cells[3].Value != null)
                {
                    Tb_Summ.Text = row.Cells[3].Value.ToString(); // Четвертая ячейка
                }

                if (row.Cells[4].Value != null && row.Cells[4].Value is DateTime)
                {
                    DatePicker.Value = (DateTime)row.Cells[4].Value; // Пятая ячейка
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

            string searchString = $"select * from Costs where concat (Category_Name,Cost_Summ,Cost_Date) like '%" + Tb_Search.Text + "%'";
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

        private void Update()
        {
            database.openConnection();

            for(int index = 0; index < guna2DataGridView1.Rows.Count; index++)
            {

                var rowState = (RowState)guna2DataGridView1.Rows[index].Cells[5].Value;


                if (rowState == RowState.Existed)
                    continue;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(guna2DataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuerry = $"delete from Costs where Cost_Id = '{id}'";
                    var command = new SqlCommand(deleteQuerry, database.getConnection());
                    command.ExecuteNonQuery();  
                }

            }
            database.closeConnection(); 
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Update();
        }
    }
}

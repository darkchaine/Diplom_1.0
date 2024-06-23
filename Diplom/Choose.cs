using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Choose : Form
    {
        public Choose()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Ncategory ncategory = new Ncategory();      
            ncategory.Show();
            this.Hide();    
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

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Uchange uchange = new Uchange();
            uchange.Show(); 
            this.Hide();
        }
    }
}

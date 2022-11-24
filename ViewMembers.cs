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
using work_shop;

namespace GYM

{
    public partial class ViewMembers : Form
    {
        public ViewMembers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BFCS\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from MemberTb1";
            SqlDataAdapter sda= new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder =   new SqlCommandBuilder();

            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource =  ds.Tables[0];
            Con.Close();

        }
        private void ViewMembers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide(); 

        }
        private void filterByName()
        {
            Con.Open();
            string query = "select * from MemberTb1 where MName='" + SearchMember.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();

            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filterByName();
        }
    }
}

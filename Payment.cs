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
namespace work_shop
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BFCS\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Mname from MemberTb1", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mname", typeof(string));
            dt.Load(rdr);
            NameCb.ValueMember = "Mname";
            NameCb.DataSource = dt;
            Con.Close();


        }
        private void filterByName()
        {
            Con.Open();
            string query = "select * from PaymentTb1 where PMember='"+SearchName.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();

            var ds = new DataSet();
            sda.Fill(ds);
            PaymentDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void populate()
        {
            Con.Open();
            string query = "select * from PaymentTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();

            var ds = new DataSet();
            sda.Fill(ds);
            PaymentDGV.DataSource = ds.Tables[0];
            Con.Close();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            //NameTb.Text = "";
            AmountTb.Text ="";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            FillName();
            populate();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            if (NameCb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                string payperiode = Periode.Value.Month.ToString() + Periode.Value.Year.ToString();
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PaymentTb1 where PMember='" + NameCb.SelectedValue.ToString() + "'and PMonth='" + payperiode + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Already Paid For This Month ");
                }
                else
                {
                    string query = "insert into PaymentTb1 values('" + payperiode + "','" + NameCb.SelectedValue.ToString() + "'," + AmountTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Paid Successfully");
                }
                Con.Close();
                populate();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filterByName();
            SearchName.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}

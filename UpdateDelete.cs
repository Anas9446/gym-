using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work_shop
{
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }

        private const int V = 0;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BFCS\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from MemberTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder =  new SqlCommandBuilder();

            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            populate();

        }
        int Key=0;
        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Key = Convert.ToInt32(MemberSDGV.SelectedRows[0].Cells[0].Value.ToString());
            NameTb.Text = MemberSDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = MemberSDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenderCb.Text = MemberSDGV.SelectedRows[0].Cells[3].Value.ToString();
            AgeTb.Text = MemberSDGV.SelectedRows[0].Cells[4].Value.ToString();
            AmountTb.Text = MemberSDGV.SelectedRows[0].Cells[5].Value.ToString();
            TimingCB.Text = MemberSDGV.SelectedRows[0].Cells[6].Value.ToString();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            NameTb.Text  = "";
            AgeTb.Text = "";
            PhoneTb.Text = "";
            TimingCB.Text = "";
            AmountTb.Text = "";
            GenderCb.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Key == 0)
            {
                MessageBox.Show("Select The Member To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Delete from MemberTd1 where MId=" + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Successfully Added");

                    Con.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                             


            }
                
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Key == 0  || NameTb.Text == "" || AgeTb.Text  == "" || AmountTb.Text=="" || GenderCb.Text =="" ||TimingCB.Text=="" )

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update MemberTb1 set MName='" + NameTb + "',MPhone='" + PhoneTb.Text + "',MGen='" + GenderCb.Text + "',MAge=" + AgeTb.Text + ",MAmount=" + AmountTb.Text + "MTiming='" + TimingCB.Text + "'where MId="+Key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Updated Successfully");

                    Con.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }



            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MemberSDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Key = Convert.ToInt32(MemberSDGV.SelectedRows[0].Cells[0].Value.ToString());
            NameTb.Text = MemberSDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = MemberSDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenderCb.Text = MemberSDGV.SelectedRows[0].Cells[3].Value.ToString();
            AgeTb.Text = MemberSDGV.SelectedRows[0].Cells[4].Value.ToString();
            AmountTb.Text = MemberSDGV.SelectedRows[0].Cells[5].Value.ToString();
            TimingCB.Text = MemberSDGV.SelectedRows[0].Cells[6].Value.ToString();
        }
    }
}

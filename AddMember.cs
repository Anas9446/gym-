using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System. Data.SqlClient;
namespace work_shop
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }
  SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BFCS\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void AddMember_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || AmountTb.Text == "" || AgeTb.Text == "") 
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    String query = "insert into MemberTb1 values('" + NameTb.Text + "','" + PhoneTb.Text + "', '" + GenderCb.SelectedItem.ToString() + "'," + AgeTb.Text + "," + AmountTb.Text + ",'" + TimingCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Successfully Added");
                    
                    Con.Close();
                    AmountTb.Text = "";
                    AgeTb.Text = "";
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderCb.Text = "";
                    TimingCb.Text = "";

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            AmountTb.Text = "";
            AgeTb.Text = "";
            NameTb.Text = "";
            PhoneTb.Text = "";
            GenderCb.Text = "";
            TimingCb.Text = "";
        }

        private void GenderCd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

    }
}

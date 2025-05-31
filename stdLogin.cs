using Project_Management_system.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Project_Management_system
{
    public partial class stdLogin : Form
    {
        public stdLogin()
        {
            InitializeComponent();
        }

        

        
        private void txtname_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == "Enter Your Name")
            {
                txtname.Text = "";
                txtname.ForeColor = Color.Black;
            }
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                txtname.Text = "Enter Your Name";
                txtname.ForeColor = Color.Gray;
            }
        }

        private void txtcnic_Enter(object sender, EventArgs e)
        {
            if (txtcnic.Text == "Enter Your CNIC")
            {
                txtcnic.Text = "";
                txtcnic.ForeColor = Color.Black;
            }
        }

        private void txtcnic_Leave(object sender, EventArgs e)
        {
            if (txtcnic.Text == "")
            {
                txtcnic.Text = "Enter Your CNIC";
                txtcnic.ForeColor = Color.Gray;
            }
        }
        private void txtroll_TextChanged(object sender, EventArgs e)
        {
            if (txtname.Text == "" || txtname.Text == "Enter Your Name")
            {
                Tick.Visible = false;
                cross.Visible = false;
                return;
            }

            if (Regex.IsMatch(txtname.Text, @"^[a-zA-Z]+$"))
            {
                Tick.Visible = true;
                cross.Visible = false;
            }
            else
            {
                Tick.Visible = false;
                cross.Visible = true;
            }
        }

        private void txtcnic_TextChanged(object sender, EventArgs e)
        {
            if (txtcnic.Text == "" || txtcnic.Text == "Enter Your CNIC")
            {
                tick1.Visible = false;
                cross1.Visible = false;
                return;
            }

            if (Regex.IsMatch(txtcnic.Text, @"^\d+$"))
            {
                tick1.Visible = true;
                cross1.Visible = false;
            }
            else
            {
                tick1.Visible = false;
                cross1.Visible = true;
            }
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            //Required field
            if (txtname.Text == "" || txtname.Text == "Enter Your Name" || txtcnic.Text == "" || txtcnic.Text == "Enter Your CNIC")
            {
                MessageBox.Show("Please fill all required fields", "Message");
                return;
            }
            //Name field
            if (!Regex.IsMatch(txtname.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please Enter Name using Alphabet", "Message");
                return;
            }
            //Age field
            if (!Regex.IsMatch(txtcnic.Text, @"^\d+$"))
            {
                MessageBox.Show("Please Enter CNIC in digits", "Message");
                return;
            }


            SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=C:\\Users\\Abdullah\\Desktop\\Visual Prog\\Project_Management_system\\Admin\\stddb.mdf;Integrated Security = True");
            //Command
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHere  Name= '" + txtname.Text + "' AND CNIC = '" + txtcnic.Text + "'", con);

            //Adopter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable
            DataTable dt = new DataTable();

            //Fill
            da.Fill(dt);
            //if
            if (dt.Rows.Count > 0)
            {
                Dashboard d = new Dashboard();
                d.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Name or CNIC is incorrect", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnregister_Click(object sender, EventArgs e)
        {
            stdRegister s = new stdRegister();
            s.ShowDialog();
            this.Close();
            this.Hide();
            
        }

        private void btnadlogin_Click(object sender, EventArgs e)
        {
            Login2 login = new Login2();
            login.ShowDialog();
            this.Close();
            this.Hide();
            
        }

        private void stdLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

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

namespace Project_Management_system.Admin
{
    public partial class Login2 : Form
    {
        public Login2()
        {
            InitializeComponent();
        }

        private void ogin2_Load(object sender, EventArgs e)
        {

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

        private void txtpasskey_Enter(object sender, EventArgs e)
        {
            if (txtpasskey.Text == "Enter Passkey")
            {
                txtpasskey.Text = "";
                txtpasskey.ForeColor = Color.Black;
            }
        }

        private void txtpasskey_Leave(object sender, EventArgs e)
        {
            if (txtpasskey.Text == "")
            {
                txtpasskey.Text = "Enter Passkey";
                txtpasskey.ForeColor = Color.Gray;
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
            if (txtpasskey.Text == "" || txtpasskey.Text == "Enter Passkey")
            {
                tick1.Visible = false;
                cross1.Visible = false;
                return;
            }

            if (Regex.IsMatch(txtpasskey.Text, @"^\d+$"))
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
            if (txtname.Text == "" || txtname.Text == "Enter Your Name" || txtpasskey.Text == "" || txtpasskey.Text == "Enter Passkey")
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
            if (!Regex.IsMatch(txtpasskey.Text, @"^\d+$"))
            {
                MessageBox.Show("Please Enter Pass Key in digits", "Message");
                return;
            }


            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Abdullah\\Desktop\\Visual Prog\\Project_Management_system\\Admin\\admindb.mdf\";Integrated Security=True");
            //Command
            SqlCommand cmd = new SqlCommand("SELECT * FROM Admin WHere Name= '" + txtname.Text + "' AND Passkey = '" + txtpasskey.Text + "'", con);

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
                MessageBox.Show("Name or Passkey is incorrect", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnregister_Click(object sender, EventArgs e)
        {
            Admin_Register s = new Admin_Register();
            s.ShowDialog();
            this.Close();
            this.Hide();

        }

        
        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

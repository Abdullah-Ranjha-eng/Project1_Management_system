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

namespace Project_Management_system
{
    public partial class stdRegister : Form
    {
        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=C:\\Users\\Abdullah\\Desktop\\Visual Prog\\Project_Management_system\\Admin\\stddb.mdf;Integrated Security = True");

        public stdRegister()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            SqlCommand cmd = new SqlCommand($"Select Id,Name,CNIC,Email,Phone,Semester,Department From Student Where CNIC = {txtcnic.Text}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void txtname_TextChanged_1(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                tick1.Visible = false;
                cross1.Visible = false;
                return;
            }

            if (Regex.IsMatch(txtname.Text, @"^[a-zA-Z]+$"))
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

        private void txtcnic_TextChanged_1(object sender, EventArgs e)
        {
            if (txtcnic.Text == "")
            {
                tick2.Visible = false;
                cross2.Visible = false;
                return;
            }

            if (Regex.IsMatch(txtcnic.Text, @"^\d+$"))
            {
                tick2.Visible = true;
                cross2.Visible = false;
            }
            else
            {
                tick2.Visible = false;
                cross2.Visible = true;
            }
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            if (txtemail.Text == "")
            {
                tick3.Visible = false;
                cross3.Visible = false;
                return;
            }

            if (Regex.IsMatch(txtemail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                tick3.Visible = true;
                cross3.Visible = false;
            }
            else
            {
                tick3.Visible = false;
                cross3.Visible = true;
            }
        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {
            if (txtphone.Text == "")
            {
                tick4.Visible = false;
                cross4.Visible = false;
                return;
            }

            if (Regex.IsMatch(txtphone.Text, @"^\d+$"))
            {
                tick4.Visible = true;
                cross4.Visible = false;
            }
            else
            {
                tick4.Visible = false;
                cross4.Visible = true;
            }
        }

        private void cmbsemester_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbsemester.Text == "")
            {
                tick5.Visible = false;
                cross5.Visible = false;
                return;
            }

            if (cmbsemester.Text == "1st" || cmbsemester.Text == "2nd" || cmbsemester.Text == "3rd" || cmbsemester.SelectedItem == "4th" || cmbsemester.Text == "5th" || cmbsemester.Text == "6th" || cmbsemester.Text == "7th" || cmbsemester.Text == "8th")
            {
                tick5.Visible = true;
                cross5.Visible = false;
            }
            else
            {
                tick5.Visible = false;
                cross5.Visible = true;
            }
        }
        private void cmbdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbdepartment.Text == "")
            {
                tick6.Visible = false;
                cross6.Visible = false;
                return;
            }

            if (cmbdepartment.Text == "SE" || cmbdepartment.Text == "CS" || cmbdepartment.Text == "AI" || cmbdepartment.Text == "IT"  )
            {
                tick6.Visible = true;
                cross6.Visible = false;
            }
            else
            {
                tick6.Visible = false;
                cross6.Visible = true;
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            //Required field
            if (txtname.Text == "" || txtcnic.Text == "" || txtemail.Text == "" || txtphone.Text == "")
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
            //Gender field
            if (!Regex.IsMatch(txtemail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Please Enter correct Email", "Message");
                return;
            }
            //Phone field
            if (!Regex.IsMatch(txtphone.Text, @"^\d+$"))
            {
                MessageBox.Show("Please Enter Phone NO using digits", "Message");
                return;
            }


            //connection
            SqlCommand cmd = new SqlCommand("INSERT INTO Student VALUES('" + txtname.Text + "','" + txtcnic.Text + "','" + txtemail.Text + "','" + txtphone.Text + "','" + cmbsemester.SelectedItem + "','" + cmbdepartment.SelectedItem + "')", con);
            //openning connection
            con.Open();
            //Execute connection
            cmd.ExecuteNonQuery();
            //closing connection
            con.Close();
            LoadData();

            MessageBox.Show("You are Registered successfully", "Message");

            stdLogin s = new stdLogin();
            s.ShowDialog();
            this.Hide();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

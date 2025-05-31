using Microsoft.VisualBasic.ApplicationServices;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Project_Management_system.Admin
{
    public partial class Student_management : Form
    {
        SqlConnection con = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=C:\\Users\\Abdullah\\Desktop\\Visual Prog\\Project_Management_system\\Admin\\stddb.mdf;Integrated Security = True");
        public Student_management()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            SqlCommand cmd = new SqlCommand("Select * From Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void txtname_TextChanged(object sender, EventArgs e)
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

        private void txtcnic_TextChanged(object sender, EventArgs e)
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

        private void cmbsemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsemester.Text == "")
            {
                tick5.Visible = false;
                cross5.Visible = false;
                return;
            }

            if (cmbsemester.Text == "1st" || cmbsemester.Text == "2nd" || cmbsemester.Text == "3rd" || cmbsemester.Text == "4th" || cmbsemester.Text == "5th" || cmbsemester.Text == "6th" || cmbsemester.Text == "7th" || cmbsemester.Text == "8th")
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

            if (cmbdepartment.Text == "SE" || cmbdepartment.Text == "CS" || cmbdepartment.Text == "AI" || cmbdepartment.Text == "IT")
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
        private void btnadd_Click(object sender, EventArgs e)
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
            //CNIC field
            if (!Regex.IsMatch(txtcnic.Text, @"^\d+$"))
            {
                MessageBox.Show("Please Enter CNIC in digits", "Message");
                return;
            }
            //Email field
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
            MessageBox.Show("You are Registered successfully", "Message");


            //connection
            SqlCommand cmd = new SqlCommand("INSERT INTO Student VALUES('" + txtname.Text + "','" + txtcnic.Text + "','" + txtemail.Text + "','" + txtphone.Text + "','" + cmbsemester.SelectedItem + "','" + cmbdepartment.SelectedItem + "')", con);
            //openning connection
            con.Open();
            //Execute connection
            cmd.ExecuteNonQuery();
            //closing connection
            con.Close();
            LoadData();

            txtname.Text = "";
            txtcnic.Text = "";
            txtemail.Text = "";
            txtphone.Text = "";
            cmbsemester.Text = "";
            cmbdepartment.Text = "";

            txtid.Text = "";
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text) || string.IsNullOrEmpty(txtid.Text))
            {
                MessageBox.Show("Enter a valid ID to delete item", "Warning");
                return;
            }

            SqlCommand cmd = new SqlCommand($"Select * From Student WHERE Id = {txtid.Text}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count < 1)
            {
                MessageBox.Show($"No record found for ID {txtid.Text}", "Warning");
                return;
            }

            txtname.Text = dt.Rows[0][1].ToString();
            txtcnic.Text = dt.Rows[0][2].ToString();
            txtemail.Text = dt.Rows[0][3].ToString();
            txtphone.Text = dt.Rows[0][4].ToString();
            cmbsemester.SelectedItem = dt.Rows[0][5].ToString();
            cmbdepartment.SelectedItem = dt.Rows[0][6].ToString();

            txtid.Enabled = false;
            btnadd.Enabled = false;

            btnedit.Visible = false;
            btnupdate.Visible = true;

            btndelete.Enabled = false;
            btnview.Enabled = false;

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtid.Text) || string.IsNullOrWhiteSpace(txtid.Text))
            {
                MessageBox.Show("Enter a valid ID to delete item", "Warning");
                return;
            }
            SqlCommand cmd = new SqlCommand($"Select * From Student WHERE Id = {txtid.Text}", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count < 1 )
            {
                MessageBox.Show($"No record found for ID {txtid.Text}", "Warning");
                return;
            }

            var response = MessageBox.Show("Are you sure you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (response == DialogResult.Yes)
            {
                cmd = new SqlCommand($"DELETE FROM Student Where Id = {txtid.Text}", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data is deleted successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadData();
                txtid.Text = "";
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"Update Student SET Name = '{txtname.Text}',CNIC = '{txtcnic.Text}',Email = '{txtemail.Text}',Phone = '{txtphone.Text}',Semester = '{cmbsemester.SelectedItem}', Department = '{cmbdepartment.SelectedItem}' Where Id = {txtid.Text}", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data is Updated successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            LoadData();

            txtname.Text = "";
            txtcnic.Text = "";
            txtemail.Text = "";
            txtphone.Text = "";
            cmbsemester.Text = "";
            cmbdepartment.Text = "";

            txtid.Text = "";

            txtid.Enabled = true;
            btnadd.Enabled = true;

            btnedit.Visible = true;
            btnupdate.Visible = false;

            btndelete.Enabled = true;
            btnview.Enabled = true;
        }

        private void Student_management_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.ShowDialog();
            this.Close();
            this.Hide();
        }
    }
}

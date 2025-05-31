using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Management_system
{
    public partial class Splashscreen : Form
    {
        int progress = 0;
        public Splashscreen()
        {
            InitializeComponent();
            timer1.Interval = 20;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progress++;
            if (progress >= 100)
            {
                timer1.Stop();
                this.Close();
            }
            guna2ProgressBar1.Value = progress;
            label3.Text = progress.ToString() + "%";
        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

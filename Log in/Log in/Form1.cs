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


namespace Log_in
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username, user_password;

            username = tex_username.Text;
            user_password = tex_password.Text;

            if (username == "Admin" && user_password == "Skills@123")
            {

                home frm2 = new home();
                frm2.Show();
                this.Hide();
               

                MessageBox.Show("Login Successful", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {
                MessageBox.Show("Login Details are wrong Faild", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_clear_Click(object sender, EventArgs e)
        {

            tex_username.Clear();
            tex_password.Clear();

            tex_username.Focus();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure, Do you want exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

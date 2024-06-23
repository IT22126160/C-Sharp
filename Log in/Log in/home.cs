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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=BANUKA\\MSSQLSERVER01;Initial Catalog=Student;Integrated Security=True");
        private object selectedRecordId;

        private void home_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (first_name.Text != "" && last_name.Text != "" && date.Text != "" && g_male.Text != "" && g_female.Text != "" && address.Text != "" && email.Text != "" && m_num.Text != "" && h_num.Text != "" && p_name.Text != "" && nic.Text != "" && c_num.Text != "")
                {
                    connection.Open();
                    string gender = "Male";
                    if (g_female.Checked)
                    {
                        gender = "Female";
                    }



                    string insertQuery = @"INSERT INTO [dbo].[Register] 
                                          ([RegNo], [First Name], [Last Name], [dateOfBirth], [gender], [address], [email], [mobilePhone], [homePhone], [parentName], [nic], [contactNo])
                                          VALUES (@reg, @first_name, @last_name, @date, @gender, @address, @email, @m_num, @h_num, @p_name, @nic, @c_num)";

                    SqlCommand cmd = new SqlCommand(insertQuery, connection);

                    cmd.Parameters.AddWithValue("@reg", reg.Text);
                    cmd.Parameters.AddWithValue("@first_name", first_name.Text);
                    cmd.Parameters.AddWithValue("@last_name", last_name.Text);
                    cmd.Parameters.AddWithValue("@date", date.Value);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@address", address.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@m_num", m_num.Text);
                    cmd.Parameters.AddWithValue("@h_num", h_num.Text);
                    cmd.Parameters.AddWithValue("@p_name", p_name.Text);
                    cmd.Parameters.AddWithValue("@nic", nic.Text);
                    cmd.Parameters.AddWithValue("@c_num", c_num.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registration successful!");


                }
                else
                {
                    MessageBox.Show("Please fill in all the required fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            first_name.Clear();
            last_name.Clear();
            address.Clear();
            email.Clear();
            m_num.Clear();
            h_num.Clear();
            p_name.Clear();
            nic.Clear();
            c_num.Clear();



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (first_name.Text != "" && last_name.Text != "" && date.Text != "" && g_male.Text != "" && g_female.Text != "" && address.Text != "" && email.Text != "" && m_num.Text != "" && h_num.Text != "" && p_name.Text != "" && nic.Text != "" && c_num.Text != "")
                {
                    connection.Open();
                    string gender = g_male.Checked ? "Male" : "Female";

                    string updateQuery = @"UPDATE [dbo].[Register] SET 
                                   [First Name] = @first_name, [Last Name] = @last_name, [dateOfBirth] = @date, [gender] = @gender, [address] = @address, [email] = @email, [mobilePhone] = @m_num, [homePhone] = @h_num, [parentName] = @p_name, [nic] = @nic, [contactNo] = @c_num 
                                   WHERE [RegNo] = @reg";

                    SqlCommand cmd = new SqlCommand(updateQuery, connection);

                    cmd.Parameters.AddWithValue("@reg", reg.Text);
                    cmd.Parameters.AddWithValue("@first_name", first_name.Text);
                    cmd.Parameters.AddWithValue("@last_name", last_name.Text);
                    cmd.Parameters.AddWithValue("@date", date.Value);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@address", address.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@m_num", m_num.Text);
                    cmd.Parameters.AddWithValue("@h_num", h_num.Text);
                    cmd.Parameters.AddWithValue("@p_name", p_name.Text);
                    cmd.Parameters.AddWithValue("@nic", nic.Text);
                    cmd.Parameters.AddWithValue("@c_num", c_num.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Update successful!");
                }
                else
                {
                    MessageBox.Show("Please fill in all the required fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                this.Close();

                Login Form2 = new Login();
                Form2.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(reg.Text))
                {
                    connection.Open();

                    string deleteQuery = @"DELETE FROM [dbo].[Register] WHERE [RegNo] = @reg";

                    SqlCommand cmd = new SqlCommand(deleteQuery, connection);

                    cmd.Parameters.AddWithValue("@reg", reg.Text);
                    cmd.ExecuteNonQuery();

                    DialogResult res;
                    res = MessageBox.Show("Are you sure, Do you want Delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    MessageBox.Show("Deleted successfully!");
                }
                else
                {
                    MessageBox.Show("Please provide a registration number to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
    



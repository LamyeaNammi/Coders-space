using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Coders_Space
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetpasswordBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string emailToReset = textBoxEmail.Text;

                if (IsEmailExist(emailToReset))
                {
                    ResetPassword resetPassword = new ResetPassword(emailToReset);
                    resetPassword.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email not found. Please enter a valid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsEmailExist(string email)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-T839SP3\SQLEXPRESS;Initial Catalog=CSDB;Integrated Security=True"))
            {
                string query = "SELECT COUNT(*) FROM USERS WHERE EMAIL = @Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);

                con.Open();

                int count = (int)cmd.ExecuteScalar();

                con.Close();

                return count > 0;
            }
        }
    }
}

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
using System.Configuration;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coders_Space
{
    public partial class Registration : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Registration()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dobDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void registrationBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int nextID;
                //int contact = 1234567890;
                int maxID = GetMaxIDFromDatabase();
                nextID = maxID + 1;
                string formattedDOB = DateTimePickerDOB.Value.ToString("yyyy-MM-dd");
                string role = "REGULAR_USER";
                SqlConnection con = new SqlConnection(cs);
                string query = "Insert into USERS (ID,NAME,CONTACT_NO,EMAIL,DOB,GENDER,PHOTO,PASSWORD, ROLE) values(@ID,@NAME,@CONTACT_NO,@EMAIL,@DOB,@GENDER,@PHOTO,@PASSWORD,@ROLE)";
                SqlCommand cnn = new SqlCommand(query, con);

                con.Open();

                cnn.Parameters.AddWithValue("@ID", nextID);
                cnn.Parameters.AddWithValue("@NAME", textBoxName.Text);
                cnn.Parameters.AddWithValue("@CONTACT_NO", textBoxContact.Text);

                cnn.Parameters.AddWithValue("@EMAIL", textBoxEmail.Text);

                cnn.Parameters.AddWithValue("@DOB", formattedDOB);
                cnn.Parameters.AddWithValue("@GENDER", comboBoxGender.Text);

                cnn.Parameters.AddWithValue("@PHOTO", SavePhoto());

                cnn.Parameters.AddWithValue("@PASSWORD", textBoxEPassword.Text);
                cnn.Parameters.AddWithValue("@ROLE", role);

                cnn.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Registration Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Login login = new Login();
                login.ShowDialog();
                //this.Hide();
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private int GetMaxIDFromDatabase()
        {
            int maxID = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT MAX(ID) FROM USERS";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }

                con.Close();
            }

            return maxID;
        }


        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "ALL IMAGE FILE (*.*) | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(ofd.FileName);
            }
        }
    }
}

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

namespace App_Gym
{
    public partial class changepass : Form
    {
        public changepass()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        string constr = @"Data Source=LATRONGANH\SQLEXPRESS;Initial Catalog=GMSDataBase;Integrated Security=True";

        string username = ForgotPasswordPage.to;

        private void closebox_Click(object sender, EventArgs e)
        {
            ForgotPasswordPage fpp = new ForgotPasswordPage();
            this.Hide();
            fpp.Show();
        }

        private void changepassbtn_Click(object sender, EventArgs e)
        {
            if (passtextbox.Text == confirmtextbox.Text)
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Update Accounts Set UserType =@UserType, UserName =@UserName, UserEmailID =@UserEmailID, UserPassword =@UserPassword Where UserEmailID ='" + username + "'  ", con);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@UserType", UserType.Text);
                cmd.Parameters.AddWithValue("@UserName", UserNameTextbox.Text);
                cmd.Parameters.AddWithValue("@UserEmailID", EmailTextbox.Text);
                cmd.Parameters.AddWithValue("@UserPassword", confirmtextbox.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Password Updated Successfully, Please login with your new credentials", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginPage lp = new LoginPage();
                this.Hide();
                lp.Show();
            }
            else
            {
                MessageBox.Show("Passwords do not match", "validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changepass_Load(object sender, EventArgs e)
        {
            getdetails();
            EmailTextbox.Text = username;
        }
        private void getdetails()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select UserType, UserName, UserEmailID, UserPassword from Accounts Where UserEmailID = '" + username + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                UserType.Text = sdr.GetValue(0).ToString();
                UserNameTextbox.Text = sdr.GetValue(1).ToString();
                EmailTextbox.Text = sdr.GetValue(2).ToString();
            }
            con.Close();
        }

        private void dragpanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

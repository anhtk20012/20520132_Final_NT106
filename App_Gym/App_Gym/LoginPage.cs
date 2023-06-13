using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Gym
{
    public partial class LoginPage : Form
    {

        public LoginPage()
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
        
        private void LoginPage_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        public static string User;
        public static string usertype;
        private void btn_login_Click(object sender, EventArgs e)
        {
            User = UserNameTextBox.Text;
            usertype = UserTypeBox.Text;

            if (UserNameTextBox.Text == string.Empty || PasswordTextBox.Text == string.Empty)
            {
                MessageBox.Show("All Fields Are Required", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {   
                SqlConnection con = new SqlConnection(constr);

                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Accounts Where UserName = '" + UserNameTextBox.Text + "' And UserPassword = '" + PasswordTextBox.Text + "' And UserType = '" + UserTypeBox.Text + "' ", con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlDataAdapter sda1 = new SqlDataAdapter("Select UserType from Accounts Where UserName = '" + UserNameTextBox.Text + "' And UserPassword = '" + PasswordTextBox.Text + "'", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    if (dt1.Rows[0][0].ToString() == "Admin")
                    {
                        this.Hide();
                        MainPage main = new MainPage();
                        main.Show();
                    }
                    if (dt1.Rows[0][0].ToString() == "User")
                    {
                        this.Hide();
                        MainPage foruser = new MainPage();
                        foruser.Show();
                    }
                    MessageBox.Show("Welcome " + User, "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Incorrect UserName Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void lb_forget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordPage fpp = new ForgotPasswordPage();
            fpp.Show();
            this.Hide();
        }

        private void LoginPage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LoginPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

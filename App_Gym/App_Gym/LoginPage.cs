using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace App_Gym
{
    public partial class LoginPage : Form
    {
        class myData
        {
            public int UserId { get; set; }
            public string UserType { get; set; }
            public string UserName { get; set; }
            public string UserEmailID { get; set; }
            public string UserPassword { get; set; }
        }

        private const string BaseUrl = "https://localhost:7046/api/Accounts";
        private HttpClient httpClient;
        public LoginPage()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

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
        public static string Email;
        public static int id;
        private async void btn_login_Click(object sender, EventArgs e)
        {
            User = UserNameTextBox.Text;
            usertype = UserTypeBox.Text;
            
            if (UserNameTextBox.Text == string.Empty || PasswordTextBox.Text == string.Empty)
            {
                MessageBox.Show("All Fields Are Required", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    var response = await httpClient.GetAsync(BaseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                        var check = 0;
                        foreach (var item in data)
                        {
                            if (item.UserName == UserNameTextBox.Text && item.UserPassword == PasswordTextBox.Text && item.UserType == UserTypeBox.Text)
                            {
                                if (item.UserType == "Admin")
                                {
                                    check = 1;
                                    Email = item.UserEmailID;
                                    id = item.UserId;
                                    this.Hide();
                                    MainPage main = new MainPage();
                                    main.Show();
                                }
                                if (item.UserType == "User" || item.UserType == "Trainer")
                                {
                                    check = 1;
                                    Email = item.UserEmailID;
                                    id = item.UserId;
                                    this.Hide();
                                    MainPage foruser = new MainPage();
                                    foruser.Show();
                                }
                                MessageBox.Show("Welcome " + User, "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        if (check == 0)
                        {
                            MessageBox.Show("Incorrect UserName Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Request failed with status code: " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

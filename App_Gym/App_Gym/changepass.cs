using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App_Gym
{
    public partial class changepass : Form
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
        public changepass()
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

        string username = ForgotPasswordPage.to;

        private void closebox_Click(object sender, EventArgs e)
        {
            ForgotPasswordPage fpp = new ForgotPasswordPage();
            this.Hide();
            fpp.Show();
        }

        private async void changepassbtn_Click(object sender, EventArgs e)
        {

            if (passtextbox.Text == confirmtextbox.Text)
            {
                int id_change = 0;
                try
                {
                    string apiUrl = BaseUrl;
                    var response = await httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                        foreach (var item in data)
                        {
                            if (item.UserEmailID == EmailTextbox.Text)
                            {
                                id_change = item.UserId;
                            }    
                        }    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                var requestData = new myData()
                {
                    UserId = id_change,
                    UserType = UserType.Text,
                    UserName = UserNameTextbox.Text,
                    UserEmailID = EmailTextbox.Text,
                    UserPassword = confirmtextbox.Text,
                };
                try
                {
                    string apiUrl = BaseUrl + "/" + id_change;
                    string jsonData = JsonConvert.SerializeObject(requestData);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Password Updated Successfully, Please login with your new credentials", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoginPage lp = new LoginPage();
                        this.Hide();
                        lp.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
        private async void getdetails()
        {
            try
            {
                var response = await httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                    foreach (var item in data)
                    {
                        if (username == item.UserEmailID)
                        {
                            UserType.Text = item.UserType;
                            UserNameTextbox.Text = item.UserName;
                            EmailTextbox.Text = item.UserEmailID;
                        }    
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

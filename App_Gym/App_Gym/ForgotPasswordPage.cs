using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Threading;

namespace App_Gym
{

    public partial class ForgotPasswordPage : Form
    {
        class myData
        {
            public int UserId { get; set; }
            public string UserType { get; set; }
            public string UserName { get; set; }
            public string UserEmailID { get; set; }
            public string UserPassword { get; set; }
        }
        class myData_send
        {
            public string GymEmailID { get; set; }
            public string Password { get; set; }
            public string GymName { get; set; }
        }

        private const string BaseUrl = "https://localhost:7046/api/Accounts";
        private const string BaseUrl_send = "https://localhost:7046/api/GymDetails";

        private HttpClient httpClient;
        public ForgotPasswordPage()
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

        private void closebox_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage lp = new LoginPage();
            lp.Show();
        }

        private void ForgotPasswordPage_Load(object sender, EventArgs e)
        {
            getgymdetails();
        }

        string emailid;
        string password;
        string gymname;
        string OTPCode;

        private async void getgymdetails()
        {
            try
            {
                var response = await httpClient.GetAsync(BaseUrl_send);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<myData_send[]>(responseData);
                    foreach (var item in data)
                    {
                        emailid = item.GymEmailID;
                        password = item.Password;
                        gymname = item.GymName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string to;
        public static string Type;
        private int checki = -1;
        private void check_i()
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string responseData = client.DownloadString(BaseUrl);
                    var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                    foreach (var item in data)
                    {
                        if (EmailTextbox.Text == item.UserEmailID)
                        {
                            checki = 1;
                        }
                    }
                    if (checki == -1) checki = 0;
                }
                catch (Exception ex)
                {
                    checki = 0;
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SendOtpBtn_Click(object sender, EventArgs e)
        {
            check_i();
            while (true)
            {
                if (checki == 1 || checki == 0) break;
            }    
            if (checki > 0)
            {
                try
                {
                    to = EmailTextbox.Text;
                    Random rand = new Random();
                    OTPCode = (rand.Next(999999)).ToString();
                    SmtpClient client = new SmtpClient()
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential()
                        {
                            UserName = emailid,
                            Password = password
                        }
                    };
                    MailAddress fromEmail = new MailAddress(emailid, gymname);
                    MailAddress ToEmail = new MailAddress(EmailTextbox.Text, "Dear User");
                    MailMessage Message = new MailMessage()
                    {
                        From = fromEmail,
                        Subject = "Password Recovery OTP Code",
                        Body = "Please Enter this OTP Code to recover your password " + "Your OTP Code = " + OTPCode
                    };
                    Message.To.Add(ToEmail);
                    client.SendCompleted += Client_SendCompleted;
                    client.SendMailAsync(Message);
                    //MessageBox.Show("OTP Sent Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Email ID is Not Registered, Please Contact your Admin", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                MessageBox.Show("OTP Sent Successful");
            }
        }

        private void VerifyOTPBtn_Click(object sender, EventArgs e)
        {
            if (OTPCode == (OTPTextbox.Text).ToString())
            {
                to = EmailTextbox.Text;
                changepass cp = new changepass();
                this.Hide();
                cp.Show();
                MessageBox.Show("OTP Code Verified", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid OTP Code, Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Head_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

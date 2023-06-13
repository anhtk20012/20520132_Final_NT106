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

namespace App_Gym
{
    public partial class ForgotPasswordPage : Form
    {
        public ForgotPasswordPage()
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

        private void getgymdetails()
        {
            SqlConnection con = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand("Select GymEmailID, Password, GymName from GymDetails", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                emailid = sdr.GetValue(0).ToString();
                password = sdr.GetValue(1).ToString();
                gymname = sdr.GetValue(2).ToString();
            }
            con.Close();
        }

        public static string to; 
        public static string Type;

        private void SendOtpBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            to = EmailTextbox.Text;
            Random rand = new Random();
            OTPCode = (rand.Next(999999)).ToString();
            SqlCommand cmd = new SqlCommand("Select * from Accounts Where UserEmailID = '" + EmailTextbox.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i > 0)
            {
                try
                {
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

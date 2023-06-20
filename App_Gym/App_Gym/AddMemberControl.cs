using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_Gym.Properties;
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace App_Gym
{
    public partial class AddMemberControl : UserControl
    {
        class myData
        {
            public int memberid { get; set; }
            public string membername { get; set; }
            public string fathername { get; set; }
            public string gender { get; set; }
            public int age { get; set; }
            public string phoneNo { get; set; }
            public string Emailid { get; set; }
            public string Address { get; set; }
            public DateTime joiningDate { get; set; }
            public DateTime renewaldate { get; set; }
            public string membershiptype { get; set; }
            public int feepaid { get; set; }
            public string timings { get; set; }
            public byte[] photo { get; set; }
        }

        class myData1
        {
            public int UserId { get; set; }
            public string UserType { get; set; }
            public string UserName { get; set; }
            public string UserEmailID { get; set; }
            public string UserPassword { get; set; }
        }

        class myData2
        {
            public string GymEmailID { get; set; }
            public string Password { get; set; }
            public string GymName { get; set; }
        }
        private bool checkphone;
        private bool checkmail;
        private const string BaseUrl = "https://localhost:7046/api/MemberTables";
        private const string BaseUrl1 = "https://localhost:7046/api/Accounts";
        private const string BaseUrl2 = "https://localhost:7046/api/GymDetails";
        private HttpClient httpClient;
        public AddMemberControl()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private void AddMemberControl_Load(object sender, EventArgs e)
        {
            getemailinfo();
        }

        private async void Addmemberbutton_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                bool create_account = false;
                var requestData = new myData()
                {
                    memberid = 0,
                    membername = fullnametxtbox.Text,
                    fathername = fathernametxtbox.Text,
                    gender = genderbox.Text,
                    age = Int32.Parse(dobbox.Text),
                    phoneNo = phonebox.Text,
                    Emailid = Emailbox.Text,
                    Address = AddressBox.Text,
                    joiningDate = todaysDatepicker.Value,
                    renewaldate = renewalDatepicker.Value,
                    membershiptype = Membershipbox.Text,
                    feepaid = Int32.Parse(feebox.Text),
                    timings = GymTimingBox.Text,
                    photo = savephoto()
                };
                try
                {
                    string apiUrl = BaseUrl;
                    string jsonData = JsonConvert.SerializeObject(requestData);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("successfully added");
                        create_account = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (create_account == true)
                {
                    var requestData1 = new myData1()
                    {
                        UserId = 0,
                        UserType = "User",
                        UserName = Emailbox.Text,
                        UserEmailID = Emailbox.Text,
                        UserPassword = "gymapp1234",
                    };
                    try
                    {
                        string apiUrl = BaseUrl1;
                        string jsonData = JsonConvert.SerializeObject(requestData1);
                        HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            SendGreetings();
                            resetboxes();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }    
            }
        }
        private void SendGreetings()
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
                MailAddress ToEmail = new MailAddress(Emailbox.Text, fullnametxtbox.Text);
                MailMessage Message = new MailMessage()
                {
                    From = fromEmail,
                    Subject = gymname + " - THANKS YOU FOR JOINING OUR GYM",
                    Body = "HELLO " + fullnametxtbox.Text + " THANK YOU FOR JOINING WITH US, YOUR PLAN DETAILS ARE, JOINED ON " + todaysDatepicker.Text + " AND YOUR RENEWAL DATE IS " + renewalDatepicker.Text + " AND FEE PAID = " + feebox.Text + " REGARDS " + gymname + " ; Account: Email ; Password: gymapp1234"
                };
                Message.To.Add(ToEmail);
                client.SendCompleted += Client_SendCompleted;
                client.SendMailAsync(Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show("A Mail has Sent Successfully to the user");
            }
        }

        public void resetboxes()
        {
            fullnametxtbox.Clear();
            fathernametxtbox.Clear();
            Emailbox.Clear();
            dobbox.Clear();
            phonebox.Clear();
            AddressBox.Clear();
            feebox.Clear();
            genderbox.SelectedIndex = -1;
            Membershipbox.SelectedIndex = -1;
            profilepicbox.Image = null;
            profilepicbox.Image = Resources.user;
            PicLabel.Visible = true;
            todaysDatepicker.Value = DateTime.Now;
            renewalDatepicker.Value = DateTime.Now;
            GymTimingBox.SelectedIndex = -1;

            fullnametxtbox.Focus();
        }

        string emailid;
        string password;
        string gymname;
        

        private async void getemailinfo()
        {
            try
            {
                var response = await httpClient.GetAsync(BaseUrl2);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<myData2[]>(responseData);
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

        private void clearallbtn_Click(object sender, EventArgs e)
        {
            resetboxes();
        }

        private void profilepicbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Profile Picture";
            ofd.Filter = "Image file(*.png; *.jpg; *.gif)|*.png; *.jpg; *.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                profilepicbox.Image = new Bitmap(ofd.FileName);
                PicLabel.Visible = false;
            }
        }
        private byte[] savephoto()
        {
            MemoryStream ms = new MemoryStream();
            profilepicbox.Image.Save(ms, profilepicbox.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void Membershipbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Membershipbox.SelectedIndex == 0)
            {
                renewalDatepicker.Value = todaysDatepicker.Value.AddDays(30);
            }
            if (Membershipbox.SelectedIndex == 1)
            {
                renewalDatepicker.Value = todaysDatepicker.Value.AddDays(90);
            }
            if (Membershipbox.SelectedIndex == 2)
            {
                renewalDatepicker.Value = todaysDatepicker.Value.AddDays(160);
            }
            if (Membershipbox.SelectedIndex == 3)
            {
                renewalDatepicker.Value = todaysDatepicker.Value.AddDays(365);
            }
        }

        private void fullnametxtbox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }
        
        private async void check_phone()
        {
            checkphone = true;
            try
            {
                var response = await httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                    foreach (var item in data)
                    {
                        if (item.phoneNo == phonebox.Text)
                        {
                            MessageBox.Show("Phone Number = " + phonebox.Text + " found in records", "Duplicate Record Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Emailbox.BackColor = Color.LightPink;
                            Emailbox.Focus();
                            checkphone = false;
                            return;
                        }    
                    }
                }
                phonebox.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkphone = false;
            }           
        }
        
        private async void check_mail()
        {
            checkmail = true;
            try
            {
                var response = await httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                    foreach (var item in data)
                    {
                        if (item.Emailid == Emailbox.Text)
                        {
                            MessageBox.Show("Email ID = " + Emailbox.Text + " found in records", "Duplicate Record Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Emailbox.BackColor = Color.LightPink;
                            Emailbox.Focus();
                            checkmail = false;
                            return;
                        }
                    }
                }
                Emailbox.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkmail = false;
            }
        }
        private bool isValid()
        {
            string mailpattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string phonenregex = "^[0-9]{10}";
            string ageregex = "^[0-9]{2}";

            if (fullnametxtbox.Text == "")
            {
                fullnametxtbox.BackColor = Color.LightPink;
                fullnametxtbox.Focus();
                MessageBox.Show("FullName field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                fullnametxtbox.BackColor = Color.White;
            }

            if (fathernametxtbox.Text == "")
            {
                fathernametxtbox.BackColor = Color.LightPink;
                fathernametxtbox.Focus();
                MessageBox.Show("FatherName field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                fathernametxtbox.BackColor = Color.White;
            }

            if (genderbox.SelectedIndex == -1)
            {
                genderbox.BackColor = Color.LightPink;
                genderbox.Focus();
                MessageBox.Show("Please select your gender", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            else
            {
                genderbox.BackColor = Color.White;
            }

            if (phonebox.Text == "")
            {
                phonebox.BackColor = Color.LightPink;
                phonebox.Focus();
                MessageBox.Show("Phone No field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(phonebox.Text, phonenregex) == false)
            {
                phonebox.BackColor = Color.LightPink;
                phonebox.Focus();
                MessageBox.Show("invalid PhoneNumber Formatting", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                check_phone();
                if (checkphone == false) return false;
            }

            if (Emailbox.Text == "")
            {
                Emailbox.BackColor = Color.LightPink;
                Emailbox.Focus();
                MessageBox.Show("Email Field Cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(Emailbox.Text, mailpattern) == false)
            {
                Emailbox.BackColor = Color.LightPink;
                Emailbox.Focus();
                MessageBox.Show("Email ID is badly formatted", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                check_mail();
                if (checkmail == false) return checkmail;
            }

            if (AddressBox.Text == "")
            {
                AddressBox.BackColor = Color.LightPink;
                AddressBox.Focus();
                MessageBox.Show("Address field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                AddressBox.BackColor = Color.White;
            }

            if (dobbox.Text == "")
            {
                dobbox.BackColor = Color.LightPink;
                dobbox.Focus();
                MessageBox.Show("Age field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(dobbox.Text, ageregex) == false)
            {
                dobbox.BackColor = Color.LightPink;
                dobbox.Focus();
                MessageBox.Show("Age should be in numbers only", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                dobbox.BackColor = Color.White;
            }

            if (feebox.Text == "")
            {
                feebox.BackColor = Color.LightPink;
                dobbox.Focus();
                MessageBox.Show("fees field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(feebox.Text, ageregex) == false)
            {
                feebox.BackColor = Color.LightPink;
                feebox.Focus();
                MessageBox.Show("fees should be in numbers only", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                feebox.BackColor = Color.White;
            }

            if (Membershipbox.SelectedIndex == -1)
            {
                Membershipbox.BackColor = Color.LightPink;
                Membershipbox.Focus();
                MessageBox.Show("Please Select your MemberShip Type", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            else
            {
                Membershipbox.BackColor = Color.White;
            }

            if (todaysDatepicker.Value == renewalDatepicker.Value || renewalDatepicker.Value == todaysDatepicker.Value)
            {
                todaysDatepicker.Focus();
                MessageBox.Show("Todays date cannot be same as renewal date", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (renewalDatepicker.Value == todaysDatepicker.Value)
            {
                renewalDatepicker.Focus();
                MessageBox.Show("renewal date cannot be same as current date", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (PicLabel.Visible == true)
            {
                MessageBox.Show("A profile pic is required for the registration", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}

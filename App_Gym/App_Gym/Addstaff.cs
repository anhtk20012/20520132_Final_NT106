using App_Gym.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Gym
{
    public partial class Addstaff : UserControl
    {
        class myData
        {
            public int staffid { get; set; }
            public string staffname { get; set; }
            public string fathername { get; set; }
            public string gender { get; set; }
            public int age { get; set; }
            public string phoneNo { get; set; }
            public string Emailid { get; set; }
            public string Address { get; set; }
            public DateTime joiningDate { get; set; }
            public string staffdesignation { get; set; }
            public int salary { get; set; }
            public string shifttime { get; set; }
            public string IDtype { get; set; }
            public string IDProof { get; set; }
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

        private HttpClient httpClient;
        public Addstaff()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }
        private bool checkphone;
        private bool checkproof;
        private const string BaseUrl = "https://localhost:7046/api/StaffTables";
        private const string BaseUrl1 = "https://localhost:7046/api/Accounts";
        private const string BaseUrl2 = "https://localhost:7046/api/GymDetails";

        private async void Addmemberbutton_Click(object sender, EventArgs e)
        {

            if (IsValid())
            {
                bool create_account = false;
                var requestData = new myData()
                {
                    staffid = 0,
                    staffname = StaffNameBox.Text,
                    fathername = StaffFatherName.Text,
                    gender = genderbox.Text,
                    age = Int32.Parse(StaffAgeBox.Text),
                    phoneNo = StaffPhoneNo.Text,
                    Emailid = StaffEmailID.Text,
                    Address = StaffAddressBox.Text,
                    joiningDate = staffjoinedDate.Value,
                    staffdesignation = StaffDesigBox.Text,
                    salary = Int32.Parse(StaffSalary.Text),
                    shifttime = ShiftTimeBox.Text,
                    IDtype = IDTypeBox.Text,
                    IDProof = StaffIdentityProof.Text,
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
                        UserType = "Trainer",
                        UserName = StaffEmailID.Text,
                        UserEmailID = StaffEmailID.Text,
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
                            ClearAll();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void clearallbtn_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void StaffIdentityProof_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (StaffIdentityProof.Text == "Enter your Driving licence No" || StaffIdentityProof.Text == "Enter your Voter Id" || StaffIdentityProof.Text == "Enter your Passport No" || StaffIdentityProof.Text == "Enter your Adhaar No")
            {
                StaffIdentityProof.Text = "";
                StaffIdentityProof.ForeColor = Color.Black;
            }
            return;
        }

        private void StaffNameBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }

        private void ClearAll()
        {
            UserProfileImage.Image = null;
            UserProfileImage.Image = Resources.user;
            PicLabel.Visible = true;

            StaffNameBox.Clear();
            StaffPhoneNo.Clear();
            staffjoinedDate.Value = DateTime.Now;
            StaffFatherName.Clear();
            StaffEmailID.Clear();
            StaffAddressBox.Clear();
            genderbox.SelectedIndex = -1;
            StaffSalary.Clear();
            StaffAgeBox.Clear();
            StaffDesigBox.SelectedIndex = -1;
            StaffIdentityProof.Clear();
            ShiftTimeBox.SelectedIndex = -1;
            IDTypeBox.SelectedIndex = -1;

            StaffNameBox.Focus();
        }

        private void UserProfileImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Staff Profile Picture";
            ofd.Filter = "Image file(*.png; *.jpg; *.gif)|*.png; *.jpg; *.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                UserProfileImage.Image = new Bitmap(ofd.FileName);
                PicLabel.Visible = false;
            }
        }
        private byte[] savephoto()
        {
            MemoryStream ms = new MemoryStream();
            UserProfileImage.Image.Save(ms, UserProfileImage.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void IDTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IDTypeBox.SelectedIndex == 0)
            {
                StaffIdentityProof.Text = "Enter your Driving licence No";
                return;
            }
            if (IDTypeBox.SelectedIndex == 1)
            {
                StaffIdentityProof.Text = "Enter your Voter Id";
                return;
            }
            if (IDTypeBox.SelectedIndex == 2)
            {
                StaffIdentityProof.Text = "Enter your Passport No";
                return;
            }
            if (IDTypeBox.SelectedIndex == 3)
            {
                StaffIdentityProof.Text = "Enter your Adhaar No";
                return;
            }
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
                        if (item.phoneNo == StaffPhoneNo.Text)
                        {
                            MessageBox.Show("Phone Number = " + StaffPhoneNo.Text + " found in records", "Duplicate Record Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            StaffPhoneNo.BackColor = Color.LightPink;
                            StaffPhoneNo.Focus();
                            checkphone = false;
                            return;
                        }
                    }
                }
                StaffPhoneNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkphone = false;
            }
        }
        private async void check_proof()
        {
            checkproof = true;
            try
            {
                var response = await httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                    foreach (var item in data)
                    {
                        if (item.IDProof == StaffIdentityProof.Text)
                        {
                            MessageBox.Show("IDProof = " + StaffIdentityProof.Text + " found in records", "Duplicate Record Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            StaffIdentityProof.BackColor = Color.LightPink;
                            StaffIdentityProof.Focus();
                            checkproof = false;
                            return;
                        }
                    }
                }
                StaffIdentityProof.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkproof = false;
            }
        }
        private bool IsValid()
        {
            string mailpattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string phonenregex = "^[0-9]{10}";
            string ageregex = "^[0-9]{2}";

            if (StaffNameBox.Text == "")
            {
                StaffNameBox.BackColor = Color.LightPink;
                StaffNameBox.Focus();
                MessageBox.Show("Name cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                StaffNameBox.BackColor = Color.White;
            }

            if (StaffFatherName.Text == "")
            {
                StaffFatherName.BackColor = Color.LightPink;
                StaffFatherName.Focus();
                MessageBox.Show("Father Name cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                StaffFatherName.BackColor = Color.White;
            }

            if (StaffEmailID.Text == "")
            {
                StaffEmailID.BackColor = Color.LightPink;
                StaffEmailID.Focus();
                MessageBox.Show("Email ID cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } 
            else if (Regex.IsMatch(StaffEmailID.Text, mailpattern) == false)
            {
                StaffEmailID.BackColor = Color.LightPink;
                StaffEmailID.Focus();
                MessageBox.Show("Email ID cannot be in numerical format", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                StaffEmailID.BackColor = Color.White;
            }

            if (StaffPhoneNo.Text == "")
            {
                StaffPhoneNo.BackColor = Color.LightPink;
                StaffPhoneNo.Focus();
                MessageBox.Show("Phone No cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(StaffPhoneNo.Text, phonenregex) == false)
            {
                StaffPhoneNo.BackColor = Color.LightPink;
                StaffPhoneNo.Focus();
                MessageBox.Show("Phone No should be in numerical format", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                check_phone();
                if (checkphone == false) return false;   
            }

            if (StaffAddressBox.Text == "")
            {
                StaffAddressBox.BackColor = Color.LightPink;
                StaffAddressBox.Focus();
                MessageBox.Show("Address cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                StaffAddressBox.BackColor = Color.White;
            }

            if (genderbox.SelectedIndex == -1)
            {
                genderbox.BackColor = Color.LightPink;
                genderbox.Focus();
                MessageBox.Show("Gender cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                genderbox.BackColor = Color.White;
            }

            if (StaffSalary.Text == "")
            {
                StaffSalary.BackColor = Color.LightPink;
                StaffSalary.Focus();
                MessageBox.Show("Staff Salary cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(StaffSalary.Text, ageregex) == false)
            {
                StaffSalary.BackColor = Color.LightPink;
                StaffSalary.Focus();
                MessageBox.Show("Salary should be in numerical format", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                StaffSalary.BackColor = Color.White;
            }

            if (StaffAgeBox.Text == "")
            {
                StaffAgeBox.BackColor = Color.LightPink;
                StaffAgeBox.Focus();
                MessageBox.Show("Age cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(StaffPhoneNo.Text, ageregex) == false)
            {
                StaffAgeBox.BackColor = Color.LightPink;
                StaffAgeBox.Focus();
                MessageBox.Show("Age should be in numerical format", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                StaffAgeBox.BackColor = Color.White;
            }

            if (ShiftTimeBox.SelectedIndex == -1)
            {
                ShiftTimeBox.BackColor = Color.LightPink;
                ShiftTimeBox.Focus();
                MessageBox.Show("Shift Timings cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                ShiftTimeBox.BackColor = Color.White;
            }

            if (StaffDesigBox.SelectedIndex == -1)
            {
                StaffDesigBox.BackColor = Color.LightPink;
                StaffDesigBox.Focus();
                MessageBox.Show("Gender cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                StaffDesigBox.BackColor = Color.White;
            }

            if (IDTypeBox.SelectedIndex == -1)
            {
                IDTypeBox.BackColor = Color.LightPink;
                IDTypeBox.Focus();
                MessageBox.Show("ID Type cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                IDTypeBox.BackColor = Color.White;
            }

            if (StaffIdentityProof.Text == "")
            {
                StaffIdentityProof.BackColor = Color.LightPink;
                StaffIdentityProof.Focus();
                MessageBox.Show("ID Proof No cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                check_proof();
                if (checkproof == false) return checkproof;
            }

            if (PicLabel.Visible == true)
            {
                MessageBox.Show("Please select a profile picture0", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}

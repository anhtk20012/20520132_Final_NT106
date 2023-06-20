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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App_Gym
{
    public partial class ViewMembers : UserControl
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
        private const string BaseUrl = "https://localhost:7046/api/MemberTables";
        private const string BaseUrl1 = "https://localhost:7046/api/Accounts";
        string usertype = LoginPage.usertype;
        string username = LoginPage.User;
        string useremail = LoginPage.Email;
        int userid = LoginPage.id;
        private HttpClient httpClient;
        public ViewMembers()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        
        private async void removebtn_Click(object sender, EventArgs e)
        {
            bool check_remove = false;
            if (isValid())
            {
                try
                {
                    string apiUrl = BaseUrl + "/" + Int32.Parse(MemberID.Text);
                    var response = await httpClient.DeleteAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        check_remove = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (check_remove)
                {
                    try
                    {
                        string apiUrl = BaseUrl1;
                        var response = await httpClient.GetAsync(apiUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync();
                            var data = JsonConvert.DeserializeObject<List<myData1>>(responseData);
                            string emailchange;
                            int idchange = -1;
                            foreach (var item in data)
                            {
                                if (EmailID.Text == item.UserEmailID)
                                {
                                    emailchange = item.UserEmailID;
                                    idchange = item.UserId;
                                }
                            }
                            string apiUrl1 = BaseUrl1 + "/" + idchange;
                            var response1 = await httpClient.DeleteAsync(apiUrl1);
                            if (response1.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Member Reocrd Deleted Successfully", "Delete Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clear();
                                resetsearchboxes();
                                GetMembersData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void updatebtn_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                bool check_update = false;
                string maillchange = "";
                try
                {
                    string apiUrl = BaseUrl + "/" + MemberID.Text;
                    var response = await httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<myData>(responseData);
                        maillchange = data.Emailid;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                var requestData = new myData()
                {
                    memberid = Int32.Parse(MemberID.Text),
                    membername = MemberName.Text,
                    fathername = FatherName.Text,
                    gender = genderbox.Text,
                    age = Int32.Parse(Age.Text),
                    phoneNo = PhoneNo.Text,
                    Emailid = EmailID.Text,
                    Address = AddressBox.Text,
                    joiningDate = todaysDatepicker.Value,
                    renewaldate = renewalDatepicker.Value,
                    membershiptype = Membershipbox.Text,
                    feepaid = Int32.Parse(Feebox.Text),
                    timings = GymTimingBox.Text,
                    photo = savephoto()
                };
                try
                {
                    string apiUrl = BaseUrl + "/" + MemberID.Text;
                    string jsonData = JsonConvert.SerializeObject(requestData);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        check_update = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (check_update)
                {
                    try
                    {
                        string apiUrl = BaseUrl1;
                        var response = await httpClient.GetAsync(apiUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync();
                            var data = JsonConvert.DeserializeObject <List<myData1>>(responseData);
                            myData1 requestData1 = null;
                            foreach (var item in data)
                            {
                                if (maillchange == item.UserEmailID && "User" == item.UserType)
                                {
                                    requestData1 = new myData1()
                                    {
                                        UserId = item.UserId,
                                        UserType = item.UserType,
                                        UserName = item.UserName,
                                        UserEmailID = EmailID.Text,
                                        UserPassword = item.UserPassword,
                                    };
                                }    
                            }
                            string apiUrl1 = BaseUrl1 + "/" + requestData1.UserId;
                            string jsonData = JsonConvert.SerializeObject(requestData1);
                            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                            var response1 = await httpClient.PutAsync(apiUrl1, content);
                            if (response1.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Member Details Updated Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                resetsearchboxes();
                                clear();
                                GetMembersData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Refreshbox_Click(object sender, EventArgs e)
        {
            GetMembersData();
            clear();
            resetsearchboxes();
        }

        private async void SearchByPhoneBtn_Click(object sender, EventArgs e)
        {
            if (SearchByPhoneTextbox.Text == "Search by PhoneNo" || SearchByPhoneTextbox.Text == string.Empty)
            {
                MessageBox.Show("Please enter Member's Phone.No to Search");
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
                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("MemberID", typeof(int));
                        dataTable.Columns.Add("Membername", typeof(string));
                        dataTable.Columns.Add("FatherName", typeof(string));
                        dataTable.Columns.Add("Gender", typeof(string));
                        dataTable.Columns.Add("Age", typeof(int));
                        dataTable.Columns.Add("PhoneNo", typeof(string));
                        dataTable.Columns.Add("EmailID", typeof(string));
                        dataTable.Columns.Add("Address", typeof(string));
                        dataTable.Columns.Add("JoiningDate", typeof(DateTime));
                        dataTable.Columns.Add("RenewalDate", typeof(DateTime));
                        dataTable.Columns.Add("MemberShipType", typeof(string));
                        dataTable.Columns.Add("FeePaid", typeof(int));
                        dataTable.Columns.Add("Timings", typeof(string));
                        dataTable.Columns.Add("Photo", typeof(byte[]));
                        foreach (var item in data)
                        {
                            if (item.phoneNo == SearchByPhoneTextbox.Text)
                            {
                                DataRow row = dataTable.NewRow();
                                row["MemberID"] = item.memberid;
                                row["Membername"] = item.membername;
                                row["FatherName"] = item.fathername;
                                row["Gender"] = item.gender;
                                row["Age"] = item.age;
                                row["PhoneNo"] = item.phoneNo;
                                row["EmailID"] = item.Emailid;
                                row["Address"] = item.Address;
                                row["JoiningDate"] = item.joiningDate;
                                row["RenewalDate"] = item.renewaldate;
                                row["MemberShipType"] = item.membershiptype;
                                row["FeePaid"] = item.feepaid;
                                row["Timings"] = item.timings;
                                row["Photo"] = item.photo;
                                dataTable.Rows.Add(row);
                            }
                        }
                        MembersDataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void SearchByIdBtn_Click(object sender, EventArgs e)
        {
            if (SearchByIDTextbox.Text == "Search by ID" || SearchByIDTextbox.Text == string.Empty)
            {
                MessageBox.Show("Please enter Member ID to Search");
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
                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("MemberID", typeof(int));
                        dataTable.Columns.Add("Membername", typeof(string));
                        dataTable.Columns.Add("FatherName", typeof(string));
                        dataTable.Columns.Add("Gender", typeof(string));
                        dataTable.Columns.Add("Age", typeof(int));
                        dataTable.Columns.Add("PhoneNo", typeof(string));
                        dataTable.Columns.Add("EmailID", typeof(string));
                        dataTable.Columns.Add("Address", typeof(string));
                        dataTable.Columns.Add("JoiningDate", typeof(DateTime));
                        dataTable.Columns.Add("RenewalDate", typeof(DateTime));
                        dataTable.Columns.Add("MemberShipType", typeof(string));
                        dataTable.Columns.Add("FeePaid", typeof(int));
                        dataTable.Columns.Add("Timings", typeof(string));
                        dataTable.Columns.Add("Photo", typeof(byte[]));
                        foreach (var item in data)
                        {
                            if (item.memberid == Int32.Parse(SearchByIDTextbox.Text))
                            {
                                DataRow row = dataTable.NewRow();
                                row["MemberID"] = item.memberid;
                                row["Membername"] = item.membername;
                                row["FatherName"] = item.fathername;
                                row["Gender"] = item.gender;
                                row["Age"] = item.age;
                                row["PhoneNo"] = item.phoneNo;
                                row["EmailID"] = item.Emailid;
                                row["Address"] = item.Address;
                                row["JoiningDate"] = item.joiningDate;
                                row["RenewalDate"] = item.renewaldate;
                                row["MemberShipType"] = item.membershiptype;
                                row["FeePaid"] = item.feepaid;
                                row["Timings"] = item.timings;
                                row["Photo"] = item.photo;
                                dataTable.Rows.Add(row);
                            }
                        }
                        MembersDataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UserProfileImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Profile Picture";
            ofd.Filter = "Image file(*.png; *.jpg; *.gif)|*.png; *.jpg; *.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                UserProfileImage.Image = new Bitmap(ofd.FileName);
            }
        }
        private byte[] savephoto()
        {
            MemoryStream ms = new MemoryStream();
            UserProfileImage.Image.Save(ms, UserProfileImage.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void SearchByIDTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchByIDTextbox.Text == "Search by ID")
            {
                SearchByIDTextbox.Text = "";
                SearchByIDTextbox.ForeColor = Color.Black;
            }
        }

        private void SearchByPhoneTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchByPhoneTextbox.Text == "Search by PhoneNo")
            {
                SearchByPhoneTextbox.Text = "";
                SearchByPhoneTextbox.ForeColor = Color.Black;
            }
        }
        private void resetsearchboxes()
        {
            SearchByIDTextbox.Clear();
            SearchByIDTextbox.Text = "Search by ID";
            SearchByIDTextbox.ForeColor = Color.DarkGray;

            SearchByPhoneTextbox.Clear();
            SearchByPhoneTextbox.Text = "Search by PhoneNo";
            SearchByPhoneTextbox.ForeColor = Color.DarkGray;
        }
        private bool isValid()
        {
            string mailpattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string phonenregex = "^[0-9]{10}";
            string ageregex = "^[0-9]{2}";

            if (MemberName.Text == "")
            {
                MemberName.BackColor = Color.LightPink;
                MemberName.Focus();
                MessageBox.Show("Name field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                MemberName.BackColor = Color.White;
            }

            if (FatherName.Text == "")
            {
                FatherName.BackColor = Color.LightPink;
                FatherName.Focus();
                MessageBox.Show("FatherName field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                FatherName.BackColor = Color.White;
            }

            if (EmailID.Text == "")
            {
                EmailID.BackColor = Color.LightPink;
                EmailID.Focus();
                MessageBox.Show("Email Field Cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(EmailID.Text, mailpattern) == false)
            {
                EmailID.BackColor = Color.LightPink;
                EmailID.Focus();
                MessageBox.Show("Email ID is badly formatted", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                EmailID.BackColor = Color.White;
            }

            if (Age.Text == "")
            {
                Age.BackColor = Color.LightPink;
                Age.Focus();
                MessageBox.Show("Age field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(Age.Text, ageregex) == false)
            {
                Age.BackColor = Color.LightPink;
                Age.Focus();
                MessageBox.Show("Age should be in numbers only", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                Age.BackColor = Color.White;
            }

            if (Feebox.Text == "")
            {
                Feebox.BackColor = Color.LightPink;
                Feebox.Focus();
                MessageBox.Show("Fees field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(Feebox.Text, ageregex) == false)
            {
                Feebox.BackColor = Color.LightPink;
                Feebox.Focus();
                MessageBox.Show("Fees should be in numbers only", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                Feebox.BackColor = Color.White;
            }

            if (PhoneNo.Text == "")
            {
                PhoneNo.BackColor = Color.LightPink;
                PhoneNo.Focus();
                MessageBox.Show("Phone No field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(PhoneNo.Text, phonenregex) == false)
            {
                PhoneNo.BackColor = Color.LightPink;
                PhoneNo.Focus();
                MessageBox.Show("invalid PhoneNumber Formatting", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                PhoneNo.BackColor = Color.White;
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

            if (GymTimingBox.SelectedIndex == -1)
            {
                GymTimingBox.BackColor = Color.LightPink;
                GymTimingBox.Focus();
                MessageBox.Show("Please select gym timings", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            else
            {
                GymTimingBox.BackColor = Color.White;
            }    


            return true;
        }
        private void clear()
        {
            MemberID.Clear();
            MemberName.Clear();
            FatherName.Clear();
            genderbox.SelectedIndex = -1;
            Age.Clear();
            PhoneNo.Clear();
            EmailID.Clear();
            AddressBox.Clear();
            todaysDatepicker.Value = DateTime.Now;
            renewalDatepicker.Value = DateTime.Now;
            Membershipbox.SelectedIndex = -1;
            Feebox.Clear();
            GymTimingBox.SelectedIndex = -1;
            UserProfileImage.Image = Resources.user;
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


        private void ViewMembers_Load(object sender, EventArgs e)
        {
            if (usertype == "Admin")
            {
                updatebtn.Enabled = true;
                removebtn.Enabled = true;
            }    
            else
            {
                updatebtn.Enabled = false;
                removebtn.Enabled = false;
            }    
            GetMembersData();
            MembersDataGridView.BorderStyle = BorderStyle.None;
            MembersDataGridView.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DAE0E2");
            MembersDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            MembersDataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2F363F");
            MembersDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            MembersDataGridView.BackgroundColor = ColorTranslator.FromHtml("#EAF0F1");

            MembersDataGridView.EnableHeadersVisualStyles = false;
            MembersDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            MembersDataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2F363F");
            MembersDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        private async void GetMembersData()
        {
            if (usertype == "Admin" || usertype == "Trainer")
            {
                try
                {
                    var response = await httpClient.GetAsync(BaseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("MemberID", typeof(int));
                        dataTable.Columns.Add("Membername", typeof(string));
                        dataTable.Columns.Add("FatherName", typeof(string));
                        dataTable.Columns.Add("Gender", typeof(string));
                        dataTable.Columns.Add("Age", typeof(int));
                        dataTable.Columns.Add("PhoneNo", typeof(string));
                        dataTable.Columns.Add("EmailID", typeof(string));
                        dataTable.Columns.Add("Address", typeof(string));
                        dataTable.Columns.Add("JoiningDate", typeof(DateTime));
                        dataTable.Columns.Add("RenewalDate", typeof(DateTime));
                        dataTable.Columns.Add("MemberShipType", typeof(string));
                        dataTable.Columns.Add("FeePaid", typeof(int));
                        dataTable.Columns.Add("Timings", typeof(string));
                        dataTable.Columns.Add("Photo", typeof(byte[]));
                        decimal Total = 0;
                        foreach (var item in data)
                        {
                            DataRow row = dataTable.NewRow();
                            row["MemberID"] = item.memberid;
                            row["Membername"] = item.membername;
                            row["FatherName"] = item.fathername;
                            row["Gender"] = item.gender;
                            row["Age"] = item.age;
                            row["PhoneNo"] = item.phoneNo;
                            row["EmailID"] = item.Emailid;
                            row["Address"] = item.Address;
                            row["JoiningDate"] = item.joiningDate;
                            row["RenewalDate"] = item.renewaldate;
                            row["MemberShipType"] = item.membershiptype;
                            row["FeePaid"] = item.feepaid;
                            row["Timings"] = item.timings;
                            row["Photo"] = item.photo;
                            dataTable.Rows.Add(row);
                            Total += Convert.ToDecimal(item.feepaid);
                        }
                        totallabel.Text = "$" + Total.ToString();
                        totalmemberslabel.Text = data.Count.ToString();
                        MembersDataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
            if (usertype == "User")
            {
                try
                {
                    var response = await httpClient.GetAsync(BaseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("MemberID", typeof(int));
                        dataTable.Columns.Add("Membername", typeof(string));
                        dataTable.Columns.Add("FatherName", typeof(string));
                        dataTable.Columns.Add("Gender", typeof(string));
                        dataTable.Columns.Add("Age", typeof(int));
                        dataTable.Columns.Add("PhoneNo", typeof(string));
                        dataTable.Columns.Add("EmailID", typeof(string));
                        dataTable.Columns.Add("Address", typeof(string));
                        dataTable.Columns.Add("JoiningDate", typeof(DateTime));
                        dataTable.Columns.Add("RenewalDate", typeof(DateTime));
                        dataTable.Columns.Add("MemberShipType", typeof(string));
                        dataTable.Columns.Add("FeePaid", typeof(int));
                        dataTable.Columns.Add("Timings", typeof(string));
                        dataTable.Columns.Add("Photo", typeof(byte[]));
                        decimal Total = 0;
                        foreach (var item in data)
                        {
                            if (item.Emailid == useremail)
                            {
                                DataRow row = dataTable.NewRow();
                                row["MemberID"] = item.memberid;
                                row["Membername"] = item.membername;
                                row["FatherName"] = item.fathername;
                                row["Gender"] = item.gender;
                                row["Age"] = item.age;
                                row["PhoneNo"] = item.phoneNo;
                                row["EmailID"] = item.Emailid;
                                row["Address"] = item.Address;
                                row["JoiningDate"] = item.joiningDate;
                                row["RenewalDate"] = item.renewaldate;
                                row["MemberShipType"] = item.membershiptype;
                                row["FeePaid"] = item.feepaid;
                                row["Timings"] = item.timings;
                                row["Photo"] = item.photo;
                                dataTable.Rows.Add(row);
                                Total += Convert.ToDecimal(item.feepaid);
                            }    
                        }
                        totallabel.Text = "$" + Total.ToString();
                        totalmemberslabel.Text = "1";
                        MembersDataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void MemberName_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }

        private void MembersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.MembersDataGridView.Rows[e.RowIndex];

                MemberID.Text = row.Cells["MemberID"].Value.ToString();
                MemberName.Text = row.Cells["Membername"].Value.ToString();
                FatherName.Text = row.Cells["FatherName"].Value.ToString();
                genderbox.Text = row.Cells["Gender"].Value.ToString();
                Age.Text = row.Cells["Age"].Value.ToString();
                PhoneNo.Text = row.Cells["PhoneNo"].Value.ToString();
                EmailID.Text = row.Cells["EmailID"].Value.ToString();
                AddressBox.Text = row.Cells["Address"].Value.ToString();
                todaysDatepicker.Text = row.Cells["JoiningDate"].Value.ToString();
                renewalDatepicker.Text = row.Cells["RenewalDate"].Value.ToString();
                Membershipbox.Text = row.Cells["MemberShipType"].Value.ToString();
                Feebox.Text = row.Cells["FeePaid"].Value.ToString();
                GymTimingBox.Text = row.Cells["Timings"].Value.ToString();
                var data = (Byte[])(row.Cells["Photo"].Value);
                var stream = new MemoryStream(data);
                UserProfileImage.Image = Image.FromStream(stream);

            }
        }
    }
}

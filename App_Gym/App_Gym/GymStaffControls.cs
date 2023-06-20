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
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App_Gym
{
    public partial class GymStaffControls : UserControl
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

        private const string BaseUrl = "https://localhost:7046/api/StaffTables";
        private const string BaseUrl1 = "https://localhost:7046/api/Accounts";
        private HttpClient httpClient;
        public GymStaffControls()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }
        string usertype = LoginPage.usertype;
        string useremail = LoginPage.Email;
        private void GymStaffControls_Load(object sender, EventArgs e)
        {
            if (usertype == "Admin")
            {
                button1.Enabled = true;
                RemoveStaffbtn.Enabled = true;
            }   
            else
            {
                button1.Enabled = false;
                RemoveStaffbtn.Enabled = false;
            }    
            GetStaffDetails();
            StaffDataGridView.BorderStyle = BorderStyle.None;
            StaffDataGridView.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DAE0E2");
            StaffDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            StaffDataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2F363F");
            StaffDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            StaffDataGridView.BackgroundColor = ColorTranslator.FromHtml("#EAF0F1");

            StaffDataGridView.EnableHeadersVisualStyles = false;
            StaffDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            StaffDataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2F363F");
            StaffDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text == "Search by ID Proof")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void SearchByIDTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchByIDTextbox.Text == "Search by Name")
            {
                SearchByIDTextbox.Text = "";
                SearchByIDTextbox.ForeColor = Color.Black;
            }
        }

        private async void SearchByIdentity_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search by ID Proof" || textBox1.Text == "")
            {
                MessageBox.Show("Please enter identity proof to Search");
                return;
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
                        dataTable.Columns.Add("StaffID", typeof(int));
                        dataTable.Columns.Add("StaffName", typeof(string));
                        dataTable.Columns.Add("FatherName", typeof(string));
                        dataTable.Columns.Add("Gender", typeof(string));
                        dataTable.Columns.Add("Age", typeof(int));
                        dataTable.Columns.Add("PhoneNo", typeof(string));
                        dataTable.Columns.Add("EmailID", typeof(string));
                        dataTable.Columns.Add("Address", typeof(string));
                        dataTable.Columns.Add("JoiningDate", typeof(DateTime));
                        dataTable.Columns.Add("StaffDesignation", typeof(string));
                        dataTable.Columns.Add("Salary", typeof(int));
                        dataTable.Columns.Add("ShiftTime", typeof(string));
                        dataTable.Columns.Add("IDType", typeof(string));
                        dataTable.Columns.Add("IDProof", typeof(string));
                        dataTable.Columns.Add("Photo", typeof(byte[]));
                        foreach (var item in data)
                        {
                            if (item.staffid == Int32.Parse(textBox1.Text))
                            {
                                DataRow row = dataTable.NewRow();
                                row["StaffID"] = item.staffid;
                                row["StaffName"] = item.staffname;
                                row["FatherName"] = item.fathername;
                                row["Gender"] = item.gender;
                                row["Age"] = item.age;
                                row["PhoneNo"] = item.phoneNo;
                                row["EmailID"] = item.Emailid;
                                row["Address"] = item.Address;
                                row["JoiningDate"] = item.joiningDate;
                                row["StaffDesignation"] = item.staffdesignation;
                                row["Salary"] = item.salary;
                                row["ShiftTime"] = item.shifttime;
                                row["IDType"] = item.IDtype;
                                row["IDProof"] = item.IDProof;
                                row["Photo"] = item.photo;
                                dataTable.Rows.Add(row);
                            }
                        }
                        StaffDataGridView.DataSource = dataTable;
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
            if (SearchByIDTextbox.Text == "Search by Name" || SearchByIDTextbox.Text == "")
            {
                MessageBox.Show("Please enter a Name to Search");
                return;
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
                        dataTable.Columns.Add("StaffID", typeof(int));
                        dataTable.Columns.Add("StaffName", typeof(string));
                        dataTable.Columns.Add("FatherName", typeof(string));
                        dataTable.Columns.Add("Gender", typeof(string));
                        dataTable.Columns.Add("Age", typeof(int));
                        dataTable.Columns.Add("PhoneNo", typeof(string));
                        dataTable.Columns.Add("EmailID", typeof(string));
                        dataTable.Columns.Add("Address", typeof(string));
                        dataTable.Columns.Add("JoiningDate", typeof(DateTime));
                        dataTable.Columns.Add("StaffDesignation", typeof(string));
                        dataTable.Columns.Add("Salary", typeof(int));
                        dataTable.Columns.Add("ShiftTime", typeof(string));
                        dataTable.Columns.Add("IDType", typeof(string));
                        dataTable.Columns.Add("IDProof", typeof(string));
                        dataTable.Columns.Add("Photo", typeof(byte[]));
                        foreach (var item in data)
                        {
                            if (item.staffname == SearchByIDTextbox.Text)
                            {
                                DataRow row = dataTable.NewRow();
                                row["StaffID"] = item.staffid;
                                row["StaffName"] = item.staffname;
                                row["FatherName"] = item.fathername;
                                row["Gender"] = item.gender;
                                row["Age"] = item.age;
                                row["PhoneNo"] = item.phoneNo;
                                row["EmailID"] = item.Emailid;
                                row["Address"] = item.Address;
                                row["JoiningDate"] = item.joiningDate;
                                row["StaffDesignation"] = item.staffdesignation;
                                row["Salary"] = item.salary;
                                row["ShiftTime"] = item.shifttime;
                                row["IDType"] = item.IDtype;
                                row["IDProof"] = item.IDProof;
                                row["Photo"] = item.photo;
                                dataTable.Rows.Add(row);
                            }
                        }
                        StaffDataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool isvalid()
        {
            if (StaffNameBox.Text == "")
            {
                StaffNameBox.BackColor = Color.LightPink;
                StaffNameBox.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (StaffFatherName.Text == "")
            {
                StaffFatherName.BackColor = Color.LightPink;
                StaffFatherName.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (StaffEmailID.Text == "")
            {
                StaffEmailID.BackColor = Color.LightPink;
                StaffEmailID.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (StaffPhoneNo.Text == "")
            {
                StaffPhoneNo.BackColor = Color.LightPink;
                StaffPhoneNo.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (StaffAddressBox.Text == "")
            {
                StaffAddressBox.BackColor = Color.LightPink;
                StaffAddressBox.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (genderbox.SelectedIndex == -1)
            {
                genderbox.BackColor = Color.LightPink;
                genderbox.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (salarybox.Text == "")
            {
                salarybox.BackColor = Color.LightPink;
                salarybox.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (StaffAgeBox.Text == "")
            {
                StaffAgeBox.BackColor = Color.LightPink;
                StaffAgeBox.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (ShiftTimeBox.SelectedIndex == -1)
            {
                ShiftTimeBox.BackColor = Color.LightPink;
                ShiftTimeBox.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (StaffDesigBox.SelectedIndex == -1)
            {
                StaffDesigBox.BackColor = Color.LightPink;
                StaffDesigBox.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (IDTypeBox.SelectedIndex == -1)
            {
                IDTypeBox.BackColor = Color.LightPink;
                IDTypeBox.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (StaffIdentityProof.Text == "")
            {
                StaffIdentityProof.BackColor = Color.LightPink;
                StaffIdentityProof.Focus();
                MessageBox.Show("Cannot update empty fields", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void ResetAll()
        {
            StaffIDBox.Clear();
            StaffNameBox.Clear();
            StaffPhoneNo.Clear();
            staffjoinedDate.Value = DateTime.Now;
            StaffFatherName.Clear();
            StaffEmailID.Clear();
            StaffAddressBox.Clear();
            genderbox.SelectedIndex = -1;
            salarybox.Clear();
            StaffAgeBox.Clear();
            ShiftTimeBox.SelectedIndex = -1;
            StaffDesigBox.SelectedIndex = -1;
            IDTypeBox.SelectedIndex = -1;
            StaffIdentityProof.Clear();
            UserProfileImage.Image = Resources.user;
        }
        private void resetsearchboxes()
        {
            SearchByIDTextbox.Clear();
            SearchByIDTextbox.Text = "Search by Name";
            SearchByIDTextbox.ForeColor = Color.DarkGray;

            textBox1.Clear();
            textBox1.Text = "Search by ID Proof";
            textBox1.ForeColor = Color.DarkGray;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                bool check_update = false;
                string maillchange = "";
                try
                {
                    string apiUrl = BaseUrl + "/" + StaffIDBox.Text;
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
                    staffid = Int32.Parse(StaffIDBox.Text),
                    staffname = StaffNameBox.Text,
                    fathername = genderbox.Text,
                    gender = StaffAgeBox.Text,
                    age = Int32.Parse(StaffAgeBox.Text),
                    phoneNo = StaffPhoneNo.Text,
                    Emailid = StaffEmailID.Text,
                    Address = StaffAddressBox.Text,
                    joiningDate = staffjoinedDate.Value,
                    staffdesignation = StaffDesigBox.Text,
                    salary = Int32.Parse(salarybox.Text),
                    shifttime = ShiftTimeBox.Text,
                    IDtype = IDTypeBox.Text,
                    IDProof = StaffIdentityProof.Text,
                    photo = savephoto()
                };
                try
                {
                    string apiUrl = BaseUrl + "/" + StaffIDBox.Text;
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
                            var data = JsonConvert.DeserializeObject<List<myData1>>(responseData);
                            myData1 requestData1 = null;
                            foreach (var item in data)
                            {
                                if (maillchange == item.UserEmailID && "Trainer" == item.UserType)
                                {
                                    requestData1 = new myData1()
                                    {
                                        UserId = item.UserId,
                                        UserType = item.UserType,
                                        UserName = item.UserName,
                                        UserEmailID = StaffEmailID.Text,
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
                                MessageBox.Show("Staff Details Updated Successfully", "Saved Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GetStaffDetails();
                                resetsearchboxes();
                                ResetAll();
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

        private async void RemoveStaffbtn_Click(object sender, EventArgs e)
        {
            bool check_remove = false;
            if (isvalid())
            {
                try
                {
                    string apiUrl = BaseUrl + "/" + Int32.Parse(StaffIDBox.Text);
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
                                if (StaffEmailID.Text == item.UserEmailID)
                                {
                                    emailchange = item.UserEmailID;
                                    idchange = item.UserId;
                                }
                            }
                            string apiUrl1 = BaseUrl1 + "/" + idchange;
                            var response1 = await httpClient.DeleteAsync(apiUrl1);
                            if (response1.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Staff Reocrd Deleted Successfully", "Delete Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GetStaffDetails();
                                resetsearchboxes();
                                ResetAll();
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
        private async void GetStaffDetails()
        {
            if (usertype == "Admin" || usertype == "Trainer")
            {
                StaffAddressBox.Multiline = true;
                StaffAddressBox.UseSystemPasswordChar = false;
                salarybox.UseSystemPasswordChar = false;
                StaffIdentityProof.UseSystemPasswordChar = false;
            }
            if (usertype == "User")
            {
                StaffAddressBox.Multiline = false;
                StaffAddressBox.UseSystemPasswordChar = true;
                salarybox.UseSystemPasswordChar = true;
                StaffIdentityProof.UseSystemPasswordChar = true;
            }
            try
            {
                var response = await httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("StaffID", typeof(int));
                    dataTable.Columns.Add("StaffName", typeof(string));
                    dataTable.Columns.Add("FatherName", typeof(string));
                    dataTable.Columns.Add("Gender", typeof(string));
                    dataTable.Columns.Add("Age", typeof(int));
                    dataTable.Columns.Add("PhoneNo", typeof(string));
                    dataTable.Columns.Add("EmailID", typeof(string));
                    dataTable.Columns.Add("Address", typeof(string));
                    dataTable.Columns.Add("JoiningDate", typeof(DateTime));
                    dataTable.Columns.Add("StaffDesignation", typeof(string));
                    dataTable.Columns.Add("Salary", typeof(int));
                    dataTable.Columns.Add("ShiftTime", typeof(string));
                    dataTable.Columns.Add("IDType", typeof(string));
                    dataTable.Columns.Add("IDProof", typeof(string));
                    dataTable.Columns.Add("Photo", typeof(byte[]));
                    decimal Total = 0;
                    foreach (var item in data)
                    {
                        DataRow row = dataTable.NewRow();
                        row["StaffID"] = item.staffid;
                        row["StaffName"] = item.staffname;
                        row["FatherName"] = item.fathername;
                        row["Gender"] = item.gender;
                        row["Age"] = item.age;
                        row["PhoneNo"] = item.phoneNo;
                        row["EmailID"] = item.Emailid;
                        row["Address"] = item.Address;
                        row["JoiningDate"] = item.joiningDate;
                        row["StaffDesignation"] = item.staffdesignation;
                        row["Salary"] = item.salary;
                        row["ShiftTime"] = item.shifttime;
                        row["IDType"] = item.IDtype;
                        row["IDProof"] = item.IDProof;
                        row["Photo"] = item.photo;
                        dataTable.Rows.Add(row);
                        Total += Convert.ToDecimal(item.salary);
                    }
                    totallabel.Text = "$" + Total.ToString();
                    totalmemberslabel.Text = data.Count.ToString();
                    StaffDataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StaffDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.StaffDataGridView.Rows[e.RowIndex];

                StaffIDBox.Text = row.Cells["StaffID"].Value.ToString();
                StaffNameBox.Text = row.Cells["StaffName"].Value.ToString();
                StaffFatherName.Text = row.Cells["FatherName"].Value.ToString();
                genderbox.Text = row.Cells["Gender"].Value.ToString();
                StaffAgeBox.Text = row.Cells["Age"].Value.ToString();
                StaffPhoneNo.Text = row.Cells["PhoneNo"].Value.ToString();
                StaffEmailID.Text = row.Cells["EmailID"].Value.ToString();
                StaffAddressBox.Text = row.Cells["Address"].Value.ToString();
                staffjoinedDate.Text = row.Cells["JoiningDate"].Value.ToString();
                StaffDesigBox.Text = row.Cells["StaffDesignation"].Value.ToString();
                salarybox.Text = row.Cells["Salary"].Value.ToString();
                ShiftTimeBox.Text = row.Cells["ShiftTime"].Value.ToString();
                IDTypeBox.Text = row.Cells["IDType"].Value.ToString();
                StaffIdentityProof.Text = row.Cells["IDProof"].Value.ToString();
                var data = (Byte[])(row.Cells["Photo"].Value);
                var stream = new MemoryStream(data);
                UserProfileImage.Image = Image.FromStream(stream);

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

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            ResetAll();
            resetsearchboxes();
            GetStaffDetails();
        }

        private void StaffNameBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }
    }
}

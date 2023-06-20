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
using System.Xml;

namespace App_Gym
{
    public partial class UserSetting : Form
    {
        class myData
        {
            public int UserId { get; set; }
            public string UserType { get; set; }
            public string UserName { get; set; }
            public string UserEmailID { get; set; }
            public string UserPassword { get; set; }
        }
        class myData1
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
        class myData2
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
        private const string BaseUrl = "https://localhost:7046/api/Accounts";
        private const string BaseUrl1 = "https://localhost:7046/api/MemberTables";
        private const string BaseUrl2 = "https://localhost:7046/api/StaffTables";
        string username = LoginPage.User;
        string useremail = LoginPage.Email;
        private HttpClient httpClient;

        public UserSetting()
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

        private bool IsValid()
        {
            if (NewPassTextBox.Text == string.Empty || ConfirmPassTextBox.Text == string.Empty)
            {
                MessageBox.Show("Password Fields Cannot Be Empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (NewPassTextBox.Text != ConfirmPassTextBox.Text)
            {
                MessageBox.Show("Passwords does not match", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (UserTypeBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the user type", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (EmailIDTextBox.Text == string.Empty)
            {
                MessageBox.Show("UserName Field Cannot Be Empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (UserNameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Email Field Cannot Be Empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private async void EditBtn_Click(object sender, EventArgs e)
        {
            bool check_update = false;
            if (IsValid())
            {
                var requestData = new myData()
                {
                    UserId = Int32.Parse(textBox1.Text),
                    UserType = UserTypeBox.Text,
                    UserName = UserNameTextBox.Text,
                    UserEmailID = EmailIDTextBox.Text,
                    UserPassword = ConfirmPassTextBox.Text,
                };
                try
                {
                    string apiUrl = BaseUrl + "/" + requestData.UserId;
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
                        if (UserTypeBox.Text == "User")
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
                                    if (useremail == item.Emailid)
                                    {
                                        requestData1 = new myData1()
                                        {
                                            memberid = item.memberid,
                                            membername = item.membername,
                                            fathername = item.fathername,
                                            gender = item.gender,
                                            age = item.age,
                                            phoneNo = item.phoneNo,
                                            Emailid = EmailIDTextBox.Text,
                                            Address = item.Address,
                                            joiningDate = item.joiningDate,
                                            renewaldate = item.renewaldate,
                                            membershiptype = item.membershiptype,
                                            feepaid = item.feepaid,
                                            timings = item.timings,
                                            photo = item.photo
                                        };
                                    }
                                }
                                string apiUrl1 = BaseUrl1 + "/" + requestData1.memberid;
                                string jsonData = JsonConvert.SerializeObject(requestData1);
                                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                                var response1 = await httpClient.PutAsync(apiUrl1, content);
                                if (response1.IsSuccessStatusCode)
                                {
                                        MessageBox.Show("User Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        clearall();
                                        this.Hide();
                                        LoginPage lp = new LoginPage();
                                        lp.Show();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (UserTypeBox.Text == "Trainer")
                        {
                            try
                            {
                                string apiUrl = BaseUrl2;
                                var response = await httpClient.GetAsync(apiUrl);
                                if (response.IsSuccessStatusCode)
                                {
                                    var responseData = await response.Content.ReadAsStringAsync();
                                    var data = JsonConvert.DeserializeObject<List<myData2>>(responseData);
                                    myData2 requestData1 = null;
                                    foreach (var item in data)
                                    {
                                        if (useremail == item.Emailid)
                                        {
                                            requestData1 = new myData2()
                                            {
                                                staffid = item.staffid,
                                                staffname = item.staffname,
                                                fathername = item.fathername,
                                                gender = item.gender,
                                                age = item.age,
                                                phoneNo = item.phoneNo,
                                                Emailid = EmailIDTextBox.Text,
                                                Address = item.Address,
                                                joiningDate = item.joiningDate,
                                                staffdesignation = item.staffdesignation,
                                                salary = item.salary,
                                                shifttime = item.shifttime,
                                                IDtype = item.IDtype,
                                                IDProof = item.IDProof,
                                                photo = item.photo
                                            };
                                        }
                                    }
                                    string apiUrl1 = BaseUrl2 + "/" + requestData1.staffid;
                                    string jsonData = JsonConvert.SerializeObject(requestData1);
                                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                                    var response1 = await httpClient.PutAsync(apiUrl1, content);
                                    if (response1.IsSuccessStatusCode)
                                    {
                                        MessageBox.Show("Trainer Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        clearall();
                                        this.Hide();
                                        LoginPage lp = new LoginPage();
                                        lp.Show();
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
        }


        private void AdminControlPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void clearall()
        {
            textBox1.Clear();
            UserNameTextBox.Clear();
            EmailIDTextBox.Clear();
            NewPassTextBox.Clear();
            ConfirmPassTextBox.Clear();
            UserTypeBox.SelectedIndex = -1;
        }


        private void GetAccountsDetails(List<myData> data)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("UserId", typeof(int));
            dataTable.Columns.Add("UserType", typeof(string));
            dataTable.Columns.Add("UserName", typeof(string));
            dataTable.Columns.Add("UserEmailID", typeof(string));
            dataTable.Columns.Add("UserPassword", typeof(string));
            foreach (var item in data)
            {
                if (username == item.UserName)
                {
                    DataRow row = dataTable.NewRow();
                    row["UserId"] = item.UserId;
                    row["UserType"] = item.UserType;
                    row["UserName"] = item.UserName;
                    row["UserEmailID"] = item.UserEmailID;
                    row["UserPassword"] = item.UserPassword;
                    dataTable.Rows.Add(row);
                }    
            }
            AccountsDataGridView.DataSource = dataTable;
        }

        private async void UserSetting_Load(object sender, EventArgs e)
        {
            try
            {
                var response = await httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                    GetAccountsDetails(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UserTypeBox.Enabled = false;
            textBox1.ReadOnly = true;
            AccountsDataGridView.BorderStyle = BorderStyle.None;
            AccountsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DAE0E2");
            AccountsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            AccountsDataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2F363F");
            AccountsDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            AccountsDataGridView.BackgroundColor = ColorTranslator.FromHtml("#EAF0F1");

            AccountsDataGridView.EnableHeadersVisualStyles = false;
            AccountsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            AccountsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2F363F");
            AccountsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage mainPage = new MainPage();
            mainPage.Show();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            UserNameTextBox.Clear();
            EmailIDTextBox.Clear();
            NewPassTextBox.Clear();
            ConfirmPassTextBox.Clear();
            UserTypeBox.SelectedIndex = -1;
        }

        private void AccountsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.AccountsDataGridView.Rows[e.RowIndex];

                textBox1.Text = row.Cells["UserID"].Value.ToString();
                UserTypeBox.Text = row.Cells["UserType"].Value.ToString();
                UserNameTextBox.Text = row.Cells["UserName"].Value.ToString();
                EmailIDTextBox.Text = row.Cells["UserEmailID"].Value.ToString();
                NewPassTextBox.Text = row.Cells["UserPassword"].Value.ToString();
                ConfirmPassTextBox.Text = row.Cells["UserPassword"].Value.ToString();

            }
        }
    }
}

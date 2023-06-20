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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace App_Gym
{
    public partial class AdminSettings : Form
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
        private const string BaseUrl_send = "https://localhost:7046/api/GymDetails";
        string useremail = LoginPage.Email;
        private HttpClient httpClient;
        public AdminSettings()
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
            string maillchange = "";
            try
            {
                string apiUrl = BaseUrl + "/" + textBox1.Text;
                var response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<myData>(responseData);
                    maillchange = data.UserEmailID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        if (UserTypeBox.Text == "Admin")
                        {
                            MessageBox.Show("Admin Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            check_update = false;
                        }
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
                                    if (maillchange == item.Emailid)
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
                                    if (maillchange == item.Emailid)
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
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                try
                {
                    var response = await httpClient.GetAsync(BaseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                        GetAccountsDetails(data);
                        clearall();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            bool check_remove = false;
            if (IsValid())
            {
                try
                {
                    string apiUrl = BaseUrl + "/" + Int32.Parse(textBox1.Text);
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
                    if (UserTypeBox.Text == "User")
                    {
                        try
                        {
                            string apiUrl = BaseUrl1;
                            var response = await httpClient.GetAsync(apiUrl);
                            if (response.IsSuccessStatusCode)
                            {
                                var responseData = await response.Content.ReadAsStringAsync();
                                var data = JsonConvert.DeserializeObject<List<myData1>>(responseData);
                                int idchange = -1;
                                foreach (var item in data)
                                {
                                    if (item.Emailid == EmailIDTextBox.Text)
                                    {
                                        idchange = item.memberid;
                                    }
                                }
                                string apiUrl1 = BaseUrl1 + "/" + idchange;
                                var response1 = await httpClient.DeleteAsync(apiUrl1);
                                if (response1.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("User Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
                                int idchange = -1;
                                foreach (var item in data)
                                {
                                    if (item.Emailid == EmailIDTextBox.Text)
                                    {
                                        idchange = item.staffid;
                                    }
                                }
                                string apiUrl1 = BaseUrl2 + "/" + idchange;
                                var response1 = await httpClient.DeleteAsync(apiUrl1);
                                if (response1.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Trainer Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                try
                {
                    var response = await httpClient.GetAsync(BaseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<myData>>(responseData);

                        GetAccountsDetails(data);
                        clearall();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Select User to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (emailtextbox.Text == string.Empty || emailpasstextbox.Text == string.Empty || gymnametextbox.Text == string.Empty)
            {
                MessageBox.Show("Cannot Save Empty Values, This may result in dataloss", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var requestData = new myData_send()
                {
                    GymEmailID = emailtextbox.Text,
                    Password = emailpasstextbox.Text,
                    GymName = UserNameTextBox.Text,
                };

                try
                {
                    string apiUrl = BaseUrl_send + "/" + requestData.GymEmailID;
                    string jsonData = JsonConvert.SerializeObject(requestData);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Gym Details Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loaddetails();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage mainPage = new MainPage();
            mainPage.Show();
        }

        private void AdminControlPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private async void AdminSettings_Load(object sender, EventArgs e)
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

            textBox1.ReadOnly = true;
            UserTypeBox.Enabled = true;
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
            loaddetails();
        }

        private async void loaddetails()
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
                        EmailLabel.Text = emailtextbox.Text = item.GymEmailID;
                        PasswordLabel.Text = emailpasstextbox.Text = item.Password;
                        NameLabel.Text = gymnametextbox.Text = item.GymName;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                DataRow row = dataTable.NewRow();
                row["UserId"] = item.UserId;
                row["UserType"] = item.UserType;
                row["UserName"] = item.UserName;
                row["UserEmailID"] = item.UserEmailID;
                row["UserPassword"] = item.UserPassword;
                dataTable.Rows.Add(row);
            }
            AccountsDataGridView.DataSource = dataTable;
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

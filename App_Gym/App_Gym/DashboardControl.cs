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

namespace App_Gym
{
    public partial class DashboardControl : UserControl
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
        class myData2
        {
            public int EquipmentID { get; set; }
            public string EquipmentName { get; set; }
            public string EquipmentType { get; set; }
            public string EquipmentQuantity { get; set; }
            public string EquipmentWeight { get; set; }
            public string EquipmentCost { get; set; }
            public DateTime PurchasedDate { get; set; }
        }

        private const string BaseUrl = "https://localhost:7046/api/MemberTables";
        private const string BaseUrl1 = "https://localhost:7046/api/StaffTables";
        private const string BaseUrl2 = "https://localhost:7046/api/EquipmentTables";
        private HttpClient httpClient;
        public DashboardControl()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private void RefreshDashBoard_Click(object sender, EventArgs e)
        {
            totalclients();
            totalclientsFee();
            totalstaff();
            totalequipments();
            loadExpiryingAccounts();
            loadExpiredAccounts();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            totalclients();
            totalclientsFee();
            totalstaff();
            totalequipments();
            loadExpiryingAccounts();
            loadExpiredAccounts();
            datagridviewstyle();
        }

        private void datagridviewstyle()
        {
            ExpiryDates.BorderStyle = BorderStyle.None;
            ExpiryDates.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DAE0E2");
            ExpiryDates.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ExpiryDates.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2F363F");
            ExpiryDates.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            ExpiryDates.BackgroundColor = ColorTranslator.FromHtml("#EAF0F1");

            ExpiryDates.EnableHeadersVisualStyles = false;
            ExpiryDates.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ExpiryDates.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2F363F");
            ExpiryDates.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            ExpiredAccountsList.BorderStyle = BorderStyle.None;
            ExpiredAccountsList.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DAE0E2");
            ExpiredAccountsList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ExpiredAccountsList.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2F363F");
            ExpiredAccountsList.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            ExpiredAccountsList.BackgroundColor = ColorTranslator.FromHtml("#EAF0F1");

            ExpiredAccountsList.EnableHeadersVisualStyles = false;
            ExpiredAccountsList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ExpiredAccountsList.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2F363F");
            ExpiredAccountsList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        string username = LoginPage.User;
        string usertype = LoginPage.usertype;
        
        private async void totalclientsFee()
        {
            if (usertype == "Admin")
            {
                clientfeepanel.Visible = true;
                try
                {
                    var response = await httpClient.GetAsync(BaseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                        decimal Total = 0;
                        foreach (var item in data)
                        {
                            Total += Convert.ToDecimal(item.feepaid);
                        }    
                        TotalEarnedLabel.Text = "$" + Total.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }   
            if (usertype == "User" || usertype == "Trainer")
            {
                clientfeepanel.Visible = false;
            }    
            
        }

        private async void totalclients()
        {
            try
            {
                var response = await httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<myData>>(responseData); 
                    totalclientslabel.Text = data.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private async void totalstaff()
        {
            try
            {
                var response = await httpClient.GetAsync(BaseUrl1);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                    totalstafflabel.Text = data.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        private async void totalequipments()
        {
            try
            {
                var response = await httpClient.GetAsync(BaseUrl2);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                    totalequiplabel.Text = data.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void loadExpiryingAccounts()
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
                    dataTable.Columns.Add("JoiningDate", typeof(DateTime));
                    dataTable.Columns.Add("RenewalDate", typeof(DateTime));
                    DateTime date1 = DateTime.Now;
                    DateTime date2 = DateTime.Now.AddDays(7);
                    foreach (var item in data)
                    {
                        if (item.renewaldate >= date1 && item.renewaldate <= date2)
                        {
                            DataRow row = dataTable.NewRow();
                            row["MemberID"] = item.memberid;
                            row["Membername"] = item.membername;
                            row["JoiningDate"] = item.joiningDate;
                            row["RenewalDate"] = item.renewaldate;
                            dataTable.Rows.Add(row);
                        }
                    }
                    ExpiryDates.DataSource = dataTable;
                }
            }   
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void loadExpiredAccounts()
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
                    dataTable.Columns.Add("JoiningDate", typeof(DateTime));
                    dataTable.Columns.Add("RenewalDate", typeof(DateTime));
                    DateTime date1 = DateTime.Now.AddDays(-1);
                    DateTime date2 = DateTime.Now;
                    foreach (var item in data)
                    {
                        if (item.renewaldate >= date1 && item.renewaldate <= date2)
                        {
                            DataRow row = dataTable.NewRow();
                            row["MemberID"] = item.memberid;
                            row["Membername"] = item.membername;
                            row["JoiningDate"] = item.joiningDate;
                            row["RenewalDate"] = item.renewaldate;
                            dataTable.Rows.Add(row);
                        }
                    }
                    ExpiredAccountsList.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

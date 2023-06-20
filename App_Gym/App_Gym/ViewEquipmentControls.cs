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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Gym
{
    public partial class ViewEquipmentControls : UserControl
    {
        class myData
        {
            public int EquipmentID { get; set; }
            public string EquipmentName { get; set; }
            public string EquipmentType { get; set; }
            public string EquipmentQuantity { get; set; }
            public string EquipmentWeight { get; set; }
            public string EquipmentCost { get; set; }
            public DateTime PurchasedDate { get; set; }
        }
        private const string BaseUrl = "https://localhost:7046/api/EquipmentTables";
        private HttpClient httpClient;

        public ViewEquipmentControls()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }
        string characterpattern = @"^[a-zA-Z]+$";
        string phonenregex = "^[0-9]{1}";

        string usertype = LoginPage.usertype;
        private void ViewEquipmentControls_Load(object sender, EventArgs e)
        {
            if (usertype == "Admin")
            {
                DeleteBtn.Enabled = true;
                Updatebtn.Enabled = true;
            }
            else
            {
                DeleteBtn.Enabled = false;
                Updatebtn.Enabled = false;
            }    
            GetEquipmentData();
            EquipmentDataGridView.BorderStyle = BorderStyle.None;
            EquipmentDataGridView.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DAE0E2");
            EquipmentDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            EquipmentDataGridView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2F363F");
            EquipmentDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            EquipmentDataGridView.BackgroundColor = ColorTranslator.FromHtml("#EAF0F1");

            EquipmentDataGridView.EnableHeadersVisualStyles = false;
            EquipmentDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            EquipmentDataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2F363F");
            EquipmentDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetEquipmentData();
            clearall();
            resetsearchboxes();
        }

        private async void searchbynameBtn_Click(object sender, EventArgs e)
        {
            if (SearchbyEquipName.Text == "Search by Name" || SearchbyEquipName.Text == "")
            {
                MessageBox.Show("Please enter a Name to search", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Regex.IsMatch(SearchbyEquipName.Text, characterpattern) == false)
            {
                MessageBox.Show("Should Be In Characters", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        dataTable.Columns.Add("EquipmentID", typeof(int));
                        dataTable.Columns.Add("EquipmentName", typeof(string));
                        dataTable.Columns.Add("EquipmentType", typeof(string));
                        dataTable.Columns.Add("EquipmentQuantity", typeof(string));
                        dataTable.Columns.Add("EquipmentWeight", typeof(string));
                        dataTable.Columns.Add("EquipmentCost", typeof(string));
                        dataTable.Columns.Add("PurchasedDate", typeof(DateTime));

                        foreach (var item in data)
                        {
                            if (SearchbyEquipName.Text == item.EquipmentName)
                            {
                                DataRow row = dataTable.NewRow();
                                row["EquipmentID"] = item.EquipmentID;
                                row["EquipmentName"] = item.EquipmentName;
                                row["EquipmentType"] = item.EquipmentType;
                                row["EquipmentQuantity"] = item.EquipmentQuantity;
                                row["EquipmentWeight"] = item.EquipmentWeight;
                                row["EquipmentCost"] = item.EquipmentCost;
                                row["PurchasedDate"] = item.PurchasedDate;
                                dataTable.Rows.Add(row);
                            }
                        }
                        EquipmentDataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void SearchbyIdBtn_Click(object sender, EventArgs e)
        {
            if (SearchbyID.Text == "Search by ID" || SearchbyID.Text == "")
            {
                MessageBox.Show("Please enter a ID to search", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Regex.IsMatch(SearchbyID.Text, characterpattern) == true)
            {
                MessageBox.Show("Should Be In Numberical format", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        dataTable.Columns.Add("EquipmentID", typeof(int));
                        dataTable.Columns.Add("EquipmentName", typeof(string));
                        dataTable.Columns.Add("EquipmentType", typeof(string));
                        dataTable.Columns.Add("EquipmentQuantity", typeof(string));
                        dataTable.Columns.Add("EquipmentWeight", typeof(string));
                        dataTable.Columns.Add("EquipmentCost", typeof(string));
                        dataTable.Columns.Add("PurchasedDate", typeof(DateTime));

                        foreach (var item in data)
                        {
                            if (Int32.Parse(SearchbyID.Text) == item.EquipmentID)
                            {
                                DataRow row = dataTable.NewRow();
                                row["EquipmentID"] = item.EquipmentID;
                                row["EquipmentName"] = item.EquipmentName;
                                row["EquipmentType"] = item.EquipmentType;
                                row["EquipmentQuantity"] = item.EquipmentQuantity;
                                row["EquipmentWeight"] = item.EquipmentWeight;
                                row["EquipmentCost"] = item.EquipmentCost;
                                row["PurchasedDate"] = item.PurchasedDate;
                                dataTable.Rows.Add(row);
                            }
                        }
                        EquipmentDataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void Updatebtn_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                var requestData = new myData()
                {
                    EquipmentID = Int32.Parse(EquipID.Text),
                    EquipmentName = EquipName.Text,
                    EquipmentType = EquipmentTypeBox.Text,
                    EquipmentQuantity = EquipQuantityBox.Text,
                    EquipmentWeight = EquipWeightBox.Text,
                    EquipmentCost = EquipCostbox.Text,
                    PurchasedDate = PurchasedPicked.Value,

                };
                try
                {
                    string apiUrl = BaseUrl + "/" + requestData.EquipmentID;
                    string jsonData = JsonConvert.SerializeObject(requestData);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearall();
                        GetEquipmentData();
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
            if (isValid())
            {
                try
                {
                    string apiUrl = BaseUrl + "/" + Int32.Parse(EquipID.Text);
                    var response = await httpClient.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Successfully deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearall();
                        GetEquipmentData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }
        private async void GetEquipmentData()
        {
            try
            {
                var response = await httpClient.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<myData>>(responseData);
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("EquipmentID", typeof(int));
                    dataTable.Columns.Add("EquipmentName", typeof(string));
                    dataTable.Columns.Add("EquipmentType", typeof(string));
                    dataTable.Columns.Add("EquipmentQuantity", typeof(string));
                    dataTable.Columns.Add("EquipmentWeight", typeof(string));
                    dataTable.Columns.Add("EquipmentCost", typeof(string));
                    dataTable.Columns.Add("PurchasedDate", typeof(DateTime));
                    decimal Total = 0;
                    foreach (var item in data)
                    { 
                        DataRow row = dataTable.NewRow();
                        row["EquipmentID"] = item.EquipmentID;
                        row["EquipmentName"] = item.EquipmentName;
                        row["EquipmentType"] = item.EquipmentType;
                        row["EquipmentQuantity"] = item.EquipmentQuantity;
                        row["EquipmentWeight"] = item.EquipmentWeight;
                        row["EquipmentCost"] = item.EquipmentCost;
                        row["PurchasedDate"] = item.PurchasedDate;
                        dataTable.Rows.Add(row);
                        Total += Convert.ToDecimal(item.EquipmentCost);
                    }
                    totalspentlabel.Text = Total.ToString();
                    totalequiplabel.Text = data.Count.ToString();
                    EquipmentDataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchbyID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchbyID.Text == "Search by ID")
            {
                SearchbyID.Text = "";
                SearchbyID.ForeColor = Color.Black;
            }
        }

        private void SearchbyEquipName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchbyEquipName.Text == "Search by Name")
            {
                SearchbyEquipName.Text = "";
                SearchbyEquipName.ForeColor = Color.Black;
            }
        }
        private void resetsearchboxes()
        {
            SearchbyID.Clear();
            SearchbyID.Text = "Search by ID";
            SearchbyID.ForeColor = Color.DarkGray;

            SearchbyEquipName.Clear();
            SearchbyEquipName.Text = "Search by Name";
            SearchbyEquipName.ForeColor = Color.DarkGray;
        }
        private void clearall()
        {
            EquipID.Clear();
            EquipName.Clear();
            EquipmentTypeBox.SelectedIndex = -1;
            EquipWeightBox.Clear();
            EquipCostbox.Clear();
            EquipQuantityBox.Clear();
            PurchasedPicked.Value = DateTime.Now;
        }
        private bool isValid()
        {

            if (EquipName.Text == string.Empty)
            {
                MessageBox.Show("Fields cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;

            }
            else if (Regex.IsMatch(EquipName.Text, characterpattern) == false)
            {
                MessageBox.Show("Name field cannot be Symbols or numbers", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }


            if (EquipmentTypeBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select equipment type", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }


            if (EquipQuantityBox.Text == string.Empty)
            {
                MessageBox.Show("Fields cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }
            else if (Regex.IsMatch(EquipQuantityBox.Text, phonenregex) == false)
            {
                MessageBox.Show("Equipment Quantity cannot be in characters", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }


            if (Regex.IsMatch(EquipWeightBox.Text, phonenregex) == false)
            {
                MessageBox.Show("Equipment Weights cannot be in characters", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }


            if (EquipCostbox.Text == string.Empty)
            {
                MessageBox.Show("Fields cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;

            }
            else if (Regex.IsMatch(EquipCostbox.Text, phonenregex) == false)
            {
                MessageBox.Show("Equipment Cost cannot be in characters", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            return true;
        }

        private void EquipmentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EquipID.Text = EquipmentDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            EquipName.Text = EquipmentDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            EquipmentTypeBox.Text = EquipmentDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            EquipWeightBox.Text = EquipmentDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            EquipCostbox.Text = EquipmentDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            EquipQuantityBox.Text = EquipmentDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            PurchasedPicked.Text = EquipmentDataGridView.SelectedRows[0].Cells[6].Value.ToString();
        }
    }
}

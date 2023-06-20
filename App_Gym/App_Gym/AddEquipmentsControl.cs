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
    public partial class AddEquipmentsControl : UserControl
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
        public AddEquipmentsControl()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void AddEquipmentButton_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                var requestData = new myData()
                {
                    EquipmentID = 0,
                    EquipmentName = EquipmentNameTextbox.Text,
                    EquipmentType = EquipmentTypeBox.Text,
                    EquipmentQuantity = EquipmentQuantityTextbox.Text,
                    EquipmentWeight = EquipmentWeightTextbox.Text,
                    EquipmentCost = EquipmentCostTextbox.Text,
                    PurchasedDate = dateTimePicker1.Value
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
                        resetboxes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void resetboxes()
        {
            EquipmentNameTextbox.Clear();
            EquipmentTypeBox.SelectedIndex = -1;
            EquipmentQuantityTextbox.Clear();
            EquipmentWeightTextbox.Clear();
            EquipmentCostTextbox.Clear();
            dateTimePicker1.Value = DateTime.Now;
            EquipmentNameTextbox.Focus();
        }

        private void EquipmentQuantityTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Equipment Quantity should be in numerical format only", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void EquipmentWeightTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Equipment weights should be in numberical format", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void AddEquipmentsControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Equipment cost should be in numerical format", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void EquipmentNameTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }

        private bool isValid()
        {
            if (EquipmentNameTextbox.Text == string.Empty)
            {
                EquipmentNameTextbox.BackColor = Color.LightPink;
                EquipmentNameTextbox.Focus();

                MessageBox.Show("Name is a required field", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;

            }

            if (EquipmentTypeBox.SelectedIndex == -1)
            {
                EquipmentTypeBox.Focus();
                EquipmentTypeBox.BackColor = Color.LightPink;

                MessageBox.Show("Please select equipment type", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }


            if (EquipmentQuantityTextbox.Text == string.Empty)
            {
                EquipmentQuantityTextbox.Focus();
                EquipmentQuantityTextbox.BackColor = Color.LightPink;

                MessageBox.Show("Equipment Quantity is a required field", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }


            if (EquipmentCostTextbox.Text == string.Empty)
            {
                EquipmentCostTextbox.Focus();
                EquipmentCostTextbox.BackColor = Color.LightPink;

                MessageBox.Show("Equipment cost is a required field", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;

            }

            return true;

        }

        private void clearallbtn_Click(object sender, EventArgs e)
        {
            resetboxes();
        }
    }
}

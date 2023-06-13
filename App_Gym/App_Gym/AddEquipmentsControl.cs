using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Gym
{
    public partial class AddEquipmentsControl : UserControl
    {
        public AddEquipmentsControl()
        {
            InitializeComponent();
        }
        string constr = @"Data Source=LATRONGANH\SQLEXPRESS;Initial Catalog=GMSDataBase;Integrated Security=True";

        private void AddEquipmentButton_Click(object sender, EventArgs e)
        {
            if (isValid())
            {

                SqlConnection con = new SqlConnection(constr);

                SqlCommand cmd = new SqlCommand("Insert into EquipmentTable Values(@EquipmentName, @EquipmentType, @EquipmentQuantity, @EquipmentWeight, @EquipmentCost, @PurchasedDate)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@EquipmentName", EquipmentNameTextbox.Text);
                cmd.Parameters.AddWithValue("@EquipmentType", EquipmentTypeBox.Text);
                cmd.Parameters.AddWithValue("@EquipmentQuantity", EquipmentQuantityTextbox.Text);
                cmd.Parameters.AddWithValue("@EquipmentWeight", EquipmentWeightTextbox.Text);
                cmd.Parameters.AddWithValue("@EquipmentCost", EquipmentCostTextbox.Text);
                cmd.Parameters.AddWithValue("@PurchasedDate", dateTimePicker1.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("success");
                resetboxes();
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

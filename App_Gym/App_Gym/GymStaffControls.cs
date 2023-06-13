using App_Gym.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Gym
{
    public partial class GymStaffControls : UserControl
    {
        public GymStaffControls()
        {
            InitializeComponent();
        }
        string constr = @"Data Source=LATRONGANH\SQLEXPRESS;Initial Catalog=GMSDataBase;Integrated Security=True";

        private void GymStaffControls_Load(object sender, EventArgs e)
        {
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

        private void SearchByIdentity_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search by ID Proof" || textBox1.Text == "")
            {
                MessageBox.Show("Please enter identity proof to Search");
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from StaffTable Where IDProof LIKE '%" + textBox1.Text + "%'", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                DataTable dtstaff = new DataTable();
                dtstaff.Load(sdr);
                con.Close();
                StaffDataGridView.DataSource = dtstaff;
            }
        }

        private void SearchByIdBtn_Click(object sender, EventArgs e)
        {
            if (SearchByIDTextbox.Text == "Search by Name" || SearchByIDTextbox.Text == "")
            {
                MessageBox.Show("Please enter a Name to Search");
                return;
            }
            else
            {

                SqlConnection con = new SqlConnection(constr);

                SqlCommand cmd = new SqlCommand("Select * from StaffTable Where StaffName LIKE '%" + SearchByIDTextbox.Text + "%'", con);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                DataTable dtstaff = new DataTable();
                dtstaff.Load(sdr);
                con.Close();
                StaffDataGridView.DataSource = dtstaff;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Update StaffTable set StaffName = @staffname, FatherName = @fathername, Gender = @gender, Age = @age, PhoneNo = @phoneNo, EmailID = @Emailid, Address = @Address, JoiningDate = @joiningDate, StaffDesignation = @staffdesignation, Salary = @salary, ShiftTime = @shifttime, IDType = @IDtype, IDProof = @IDProof, Photo = @photo Where StaffId = @staffid", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@staffname", StaffNameBox.Text);
                cmd.Parameters.AddWithValue("@fathername", StaffFatherName.Text);
                cmd.Parameters.AddWithValue("@gender", genderbox.Text);
                cmd.Parameters.AddWithValue("@age", StaffAgeBox.Text);
                cmd.Parameters.AddWithValue("@phoneNo", StaffPhoneNo.Text);
                cmd.Parameters.AddWithValue("@Emailid", StaffEmailID.Text);
                cmd.Parameters.AddWithValue("@Address", StaffAddressBox.Text);
                cmd.Parameters.AddWithValue("@joiningDate", staffjoinedDate.Value);
                cmd.Parameters.AddWithValue("@staffdesignation", StaffDesigBox.Text);
                cmd.Parameters.AddWithValue("@salary", salarybox.Text);
                cmd.Parameters.AddWithValue("@shifttime", ShiftTimeBox.Text);
                cmd.Parameters.AddWithValue("@IDtype", IDTypeBox.Text);
                cmd.Parameters.AddWithValue("@IDProof", StaffIdentityProof.Text);
                cmd.Parameters.AddWithValue("@photo", savephoto());
                cmd.Parameters.AddWithValue("staffid", StaffIDBox.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Staff Details Updated Successfully", "Saved Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStaffDetails();
                resetsearchboxes();
                ResetAll();


            }
        }

        private void RemoveStaffbtn_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Delete From StaffTable Where StaffID = @staffid", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@staffid", StaffIDBox.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Staff Reocrd Deleted Successfully", "Delete Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStaffDetails();
                resetsearchboxes();
                ResetAll();
            }
        }
        private void GetStaffDetails()
        {

            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select * from StaffTable", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dtstaff = new DataTable();
            dtstaff.Load(sdr);
            con.Close();
            StaffDataGridView.DataSource = dtstaff;

            decimal Total = 0;

            for (int i = 0; i < StaffDataGridView.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(StaffDataGridView.Rows[i].Cells["Salary"].Value);
            }
            totallabel.Text = Total.ToString();


            string sql = "Select * from StaffTable";

            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            StaffDataGridView.DataSource = ds.Tables[0];

            totalmemberslabel.Text = ds.Tables[0].Rows.Count.ToString();
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

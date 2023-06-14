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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Gym
{
    public partial class Addstaff : UserControl
    {
        public Addstaff()
        {
            InitializeComponent();
        }
        string constr = @"Data Source=LATRONGANH\SQLEXPRESS;Initial Catalog=GMSDataBase;Integrated Security=True";

        private void Addmemberbutton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                SqlConnection con = new SqlConnection(constr);

                SqlCommand cmd = new SqlCommand("Insert into StaffTable Values(@staffname, @fathername, @gender, @age, @phoneNo, @Emailid, @Address, @joiningDate, @staffdesignation, @salary, @shifttime, @IDtype, @IDProof, @photo)", con);

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
                cmd.Parameters.AddWithValue("@salary", StaffSalary.Text);
                cmd.Parameters.AddWithValue("@shifttime", ShiftTimeBox.Text);
                cmd.Parameters.AddWithValue("@IDtype", IDTypeBox.Text);
                cmd.Parameters.AddWithValue("@IDProof", StaffIdentityProof.Text);
                cmd.Parameters.AddWithValue("@photo", savephoto());

                SqlCommand create_cmd = new SqlCommand("Insert into Accounts Values(@UserType, @UserName, @UserEmailID, @UserPassword)", con);

                create_cmd.CommandType = CommandType.Text;
                create_cmd.Parameters.AddWithValue("@UserType", "Trainer");
                create_cmd.Parameters.AddWithValue("@UserName", StaffEmailID.Text);
                create_cmd.Parameters.AddWithValue("@UserEmailID", StaffEmailID.Text);
                create_cmd.Parameters.AddWithValue("@UserPassword", "gymapp1234");

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("successfully added");
                ClearAll();


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
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from StaffTable Where PhoneNo = '" + StaffPhoneNo.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("PhoneNumber = " + StaffPhoneNo.Text + " found in records", "Duplicate Record Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    StaffPhoneNo.BackColor = Color.LightPink;
                    StaffPhoneNo.Focus();
                    return false;
                }
                else
                {
                    StaffPhoneNo.BackColor = Color.White;
                }    
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
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from StaffTable Where IDProof = '" + StaffIdentityProof.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("IDProof = " + StaffIdentityProof.Text + " found in records", "Duplicate Record Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    StaffIdentityProof.BackColor = Color.LightPink;
                    StaffIdentityProof.Focus();
                    return false;
                }
                else
                {
                    StaffIdentityProof.BackColor = Color.White;
                }
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

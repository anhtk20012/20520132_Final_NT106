using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_Gym.Properties;

namespace App_Gym
{
    public partial class AddMemberControl : UserControl
    {
        public AddMemberControl()
        {
            InitializeComponent();
        }

        string constr = @"Data Source=LATRONGANH\SQLEXPRESS;Initial Catalog=GMSDataBase;Integrated Security=True";
        

        private void AddMemberControl_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            getemailinfo();
        }

        private void Addmemberbutton_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                try
                {
                    SqlConnection con = new SqlConnection(constr);
                    SqlCommand cmd = new SqlCommand("Insert into MemberTable Values(@Membername, @fathername, @gender, @age, @phoneNo, @Emailid, @Address, @joiningDate, @renewaldate, @membershiptype, @feepaid, @timings, @photo)", con);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Membername", fullnametxtbox.Text);
                    cmd.Parameters.AddWithValue("@fathername", fathernametxtbox.Text);
                    cmd.Parameters.AddWithValue("@gender", genderbox.Text);
                    cmd.Parameters.AddWithValue("@age", dobbox.Text);
                    cmd.Parameters.AddWithValue("@phoneNo", phonebox.Text);
                    cmd.Parameters.AddWithValue("@Emailid", Emailbox.Text);
                    cmd.Parameters.AddWithValue("@Address", AddressBox.Text);
                    cmd.Parameters.AddWithValue("@joiningDate", todaysDatepicker.Value);
                    cmd.Parameters.AddWithValue("@renewaldate", renewalDatepicker.Value);
                    cmd.Parameters.AddWithValue("@membershiptype", Membershipbox.Text);
                    cmd.Parameters.AddWithValue("@feepaid", feebox.Text);
                    cmd.Parameters.AddWithValue("@timings", GymTimingBox.Text);
                    cmd.Parameters.AddWithValue("@photo", savephoto());

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    SendGreetings();
                    MessageBox.Show("user info saved successfully");
                    resetboxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void SendGreetings()
        {
            try
            {
                SmtpClient client = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential()
                    {
                        UserName = emailid,
                        Password = password
                    }
                };
                MailAddress fromEmail = new MailAddress(emailid, gymname);
                MailAddress ToEmail = new MailAddress(Emailbox.Text, fullnametxtbox.Text);
                MailMessage Message = new MailMessage()
                {
                    From = fromEmail, 
                    Subject = gymname + " - THANKS YOU FOR JOINING OUR GYM",
                    Body = "HELLO " + fullnametxtbox.Text + " THANK YOU FOR JOINING WITH US, YOUR PLAN DETAILS ARE, JOINED ON " + todaysDatepicker.Text + " AND YOUR RENEWAL DATE IS " + renewalDatepicker.Text + " AND FEE PAID = " + feebox.Text + " REGARDS " + gymname
                };
                Message.To.Add(ToEmail);
                client.SendCompleted += Client_SendCompleted;
                client.SendMailAsync(Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                MessageBox.Show("A Mail has Sent Successfully to the user");
            }
        }

        public void resetboxes()
        {
            fullnametxtbox.Clear();
            fathernametxtbox.Clear();
            Emailbox.Clear();
            dobbox.Clear();
            phonebox.Clear();
            AddressBox.Clear();
            feebox.Clear();
            genderbox.SelectedIndex = -1;
            Membershipbox.SelectedIndex = -1;
            profilepicbox.Image = null;
            profilepicbox.Image = Resources.user;
            PicLabel.Visible = true;
            todaysDatepicker.Value = DateTime.Now;
            renewalDatepicker.Value = DateTime.Now;
            GymTimingBox.SelectedIndex = -1;

            fullnametxtbox.Focus();
        }

        string emailid;
        string password;
        string gymname;

        private void getemailinfo()
        {
            SqlConnection con = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand("Select GymEmailID, Password, GymName from GymDetails", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                emailid = sdr.GetValue(0).ToString();
                password = sdr.GetValue(1).ToString();
                gymname = sdr.GetValue(2).ToString();
            }
            con.Close();
        }

        private void clearallbtn_Click(object sender, EventArgs e)
        {
            resetboxes();
        }

        private void profilepicbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Profile Picture";
            ofd.Filter = "Image file(*.png; *.jpg; *.gif)|*.png; *.jpg; *.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                profilepicbox.Image = new Bitmap(ofd.FileName);
                PicLabel.Visible = false;
            }
        }
        private byte[] savephoto()
        {
            MemoryStream ms = new MemoryStream();
            profilepicbox.Image.Save(ms, profilepicbox.Image.RawFormat);
            return ms.GetBuffer();
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

        private void fullnametxtbox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.BackColor = Color.White;
        }

        private bool isValid()
        {
            string mailpattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string phonenregex = "^[0-9]{10}";
            string ageregex = "^[0-9]{2}";

            if (fullnametxtbox.Text == "")
            {
                fullnametxtbox.BackColor = Color.LightPink;
                fullnametxtbox.Focus();
                MessageBox.Show("FullName field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                fullnametxtbox.BackColor = Color.White;
            }

            if (fathernametxtbox.Text == "")
            {
                fathernametxtbox.BackColor = Color.LightPink;
                fathernametxtbox.Focus();
                MessageBox.Show("FatherName field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                fathernametxtbox.BackColor = Color.White;
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

            if (phonebox.Text == "")
            {
                phonebox.BackColor = Color.LightPink;
                phonebox.Focus();
                MessageBox.Show("Phone No field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(phonebox.Text, phonenregex) == false)
            {
                phonebox.BackColor = Color.LightPink;
                phonebox.Focus();
                MessageBox.Show("invalid PhoneNumber Formatting", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from MemberTable Where PhoneNo = '" + phonebox.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("Phone Number = " + phonebox.Text + " found in records", "Duplicate Record Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Emailbox.BackColor = Color.LightPink;
                    Emailbox.Focus();
                    return false;
                }
                else
                {
                    phonebox.BackColor = Color.White;
                }    
            }

            if (Emailbox.Text == "")
            {
                Emailbox.BackColor = Color.LightPink;
                Emailbox.Focus();
                MessageBox.Show("Email Field Cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(Emailbox.Text, mailpattern) == false)
            {
                Emailbox.BackColor = Color.LightPink;
                Emailbox.Focus();
                MessageBox.Show("Email ID is badly formatted", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Select * from MemberTable Where EmailID = '" + Emailbox.Text + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("Email ID = " + Emailbox.Text + " found in records", "Duplicate Record Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Emailbox.BackColor = Color.LightPink;
                    Emailbox.Focus();
                    return false;
                }
                else
                {
                    Emailbox.BackColor = Color.White;
                }    
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

            if (dobbox.Text == "")
            {
                dobbox.BackColor = Color.LightPink;
                dobbox.Focus();
                MessageBox.Show("Age field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(dobbox.Text, ageregex) == false)
            {
                dobbox.BackColor = Color.LightPink;
                dobbox.Focus();
                MessageBox.Show("Age should be in numbers only", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                dobbox.BackColor = Color.White;
            }

            if (feebox.Text == "")
            {
                feebox.BackColor = Color.LightPink;
                dobbox.Focus();
                MessageBox.Show("fees field cannot be empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Regex.IsMatch(feebox.Text, ageregex) == false)
            {
                feebox.BackColor = Color.LightPink;
                feebox.Focus();
                MessageBox.Show("fees should be in numbers only", "validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                feebox.BackColor = Color.White;
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

            if (PicLabel.Visible == true)
            {
                MessageBox.Show("A profile pic is required for the registration", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}

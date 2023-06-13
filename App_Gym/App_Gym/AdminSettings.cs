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
    public partial class AdminSettings : Form
    {
        public AdminSettings()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        string constr = @"Data Source=LATRONGANH\SQLEXPRESS;Initial Catalog=GMSDataBase;Integrated Security=True";

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

        private bool issingle()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select * from Accounts Where UserEmailID = '" + EmailIDTextBox.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i > 0)
            {
                MessageBox.Show("A Member Is Already Registerd with this Email ID");
                return false;
            }

            return true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (IsValid() && issingle())
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Insert into Accounts Values(@UserType, @UserName, @UserEmailID, @UserPassword)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserType", UserTypeBox.Text);
                cmd.Parameters.AddWithValue("@UserName", UserNameTextBox.Text);
                cmd.Parameters.AddWithValue("@UserEmailID", EmailIDTextBox.Text);
                cmd.Parameters.AddWithValue("@UserPassword", ConfirmPassTextBox.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User Added Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAccountsDetails();
                clearall();



            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Update Accounts Set UserType =@UserType, UserName =@UserName, UserEmailID =@UserEmailID, UserPassword =@UserPassword Where UserId =@UserId", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("UserId", textBox1.Text);
                cmd.Parameters.AddWithValue("UserType", UserTypeBox.Text);
                cmd.Parameters.AddWithValue("@UserName", UserNameTextBox.Text);
                cmd.Parameters.AddWithValue("@UserEmailID", EmailIDTextBox.Text);
                cmd.Parameters.AddWithValue("@UserPassword", ConfirmPassTextBox.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAccountsDetails();
                clearall();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Delete From  Accounts Where UserID = @id", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", textBox1.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAccountsDetails();
                clearall();
            }
            else
            {
                MessageBox.Show("Please Select User to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (emailtextbox.Text == string.Empty || emailpasstextbox.Text == string.Empty || gymnametextbox.Text == string.Empty)
            {
                MessageBox.Show("Cannot Save Empty Values, This may result in dataloss", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand("Update GymDetails set GymEmailID = @id, Password = @NewPass, GymName = @newName Where GymEMailID = @id", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", emailtextbox.Text);
                cmd.Parameters.AddWithValue("@NewPass", emailpasstextbox.Text);
                cmd.Parameters.AddWithValue("@newName", gymnametextbox.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                loaddetails();
                MessageBox.Show("Gym Details Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
        }

        private void AdminControlPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void AdminSettings_Load(object sender, EventArgs e)
        {
            GetAccountsDetails();
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

        private void loaddetails()
        {

            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select GymEmailID, Password, GymName from GymDetails", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                emailtextbox.Text = sdr.GetValue(0).ToString();
                emailpasstextbox.Text = sdr.GetValue(1).ToString();
                gymnametextbox.Text = sdr.GetValue(2).ToString();
            }
            con.Close();

            EmailLabel.Text = emailtextbox.Text;
            PasswordLabel.Text = emailpasstextbox.Text;
            NameLabel.Text = gymnametextbox.Text;
        }

        private void GetAccountsDetails()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select * from Accounts", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dtstaff = new DataTable();
            dtstaff.Load(sdr);
            con.Close();
            AccountsDataGridView.DataSource = dtstaff;
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

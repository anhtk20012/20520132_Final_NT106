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
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
        }
        string constr = @"Data Source=LATRONGANH\SQLEXPRESS;Initial Catalog=GMSDataBase;Integrated Security=True";
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
        private void totalclientsFee()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select * from MemberTable", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dtclients = new DataTable();
            dtclients.Load(sdr);
            con.Close();
            EarningsDGV.DataSource = dtclients;

            decimal Total = 0;

            for (int i = 0; i < EarningsDGV.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(EarningsDGV.Rows[i].Cells["FeePaid"].Value);
            }


            TotalEarnedLabel.Text = "$" + Total.ToString();
        }

        //get total clients number
        private void totalclients()
        {
            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from MemberTable";

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            totalclientsDGV.DataSource = ds.Tables[0];

            totalclientslabel.Text = ds.Tables[0].Rows.Count.ToString();
        }
        // get total staff numbers
        private void totalstaff()
        {
            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from StaffTable";

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            totalstaffDGV.DataSource = ds.Tables[0];

            totalstafflabel.Text = ds.Tables[0].Rows.Count.ToString();
        }
        // get total equipments data
        private void totalequipments()
        {
            SqlConnection con = new SqlConnection(constr);
            string sql = "Select * from EquipmentTable";

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            TotalequipmentsDGV.DataSource = ds.Tables[0];

            totalequiplabel.Text = ds.Tables[0].Rows.Count.ToString();
        }
        private void loadExpiryingAccounts()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select MemberID, Membername, JoiningDate, RenewalDate from MemberTable Where RenewalDate Between '" + dateTime.Value.AddDays(1).ToString("MM/dd/yyyy") + "' And '" + dateTime.Value.AddDays(8).ToString("MM/dd/yyyy") + "' ", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dtclients = new DataTable();
            dtclients.Load(sdr);
            con.Close();
            ExpiryDates.DataSource = dtclients;
        }

        string yesterday = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");

        private void loadExpiredAccounts()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Select MemberID, Membername, JoiningDate, RenewalDate from MemberTable Where RenewalDate Between '" + yesterday + "' And '" + dateTime.Value.AddDays(1).ToString("MM/dd/yyyy") + "' ", con);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dtclients = new DataTable();
            dtclients.Load(sdr);
            con.Close();
            ExpiredAccountsList.DataSource = dtclients;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

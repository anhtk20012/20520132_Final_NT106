using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Gym
{
    public partial class MainPage : Form
    {
        private AddEquipmentsControl addEquipmentsControl1;
        private AddMemberControl addMemberControl1;
        private DashboardControl dashboardControl1;
        private GymStaffControls gymStaffControls1;
        private ViewEquipmentControls viewEquipmentControls1;
        private ViewMembers viewMembers1;
        private Addstaff addstaff1;
        public MainPage()
        {
            InitializeComponent();
            dashboardControl1 = new DashboardControl();
            Addview(dashboardControl1);
            dashboardbtn.BackColor = ColorTranslator.FromHtml("#E8290B");
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        string username = LoginPage.User;
        string usertype = LoginPage.usertype;

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (usertype == "Admin")
            {
                AdminSettings ads = new AdminSettings();
                ads.Show();
            }
            else if (usertype == "User")
            {
                MessageBox.Show("Only Admins Can Login this page, Please Login As Admin", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage lp = new LoginPage();
            lp.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            namelabel.Text = "Welcome back " + username;
        }

        private void dragpanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void dashboardbtn_Click(object sender, EventArgs e)
        {
            reset_bg();
            dashboardbtn.BackColor = ColorTranslator.FromHtml("#E8290B");
            Addview(dashboardControl1);
            NavTitle.Text = "DashBoard";
        }

        private void addmembersbtn_Click(object sender, EventArgs e)
        {
            addMemberControl1 = new AddMemberControl();
            reset_bg();
            addmembersbtn.BackColor = ColorTranslator.FromHtml("#E8290B");
            Addview(addMemberControl1);
            NavTitle.Text = "Add Members";
        }

        private void AddEquipmentsbtn_Click(object sender, EventArgs e)
        {
            addEquipmentsControl1 = new AddEquipmentsControl();
            reset_bg();
            AddEquipmentsbtn.BackColor = ColorTranslator.FromHtml("#E8290B");
            Addview(addEquipmentsControl1);
            NavTitle.Text = "Add Equipments";
        }

        private void ViewMembersBtn_Click(object sender, EventArgs e)
        {
            viewMembers1 = new ViewMembers();
            reset_bg();
            ViewMembersBtn.BackColor = ColorTranslator.FromHtml("#E8290B");
            Addview(viewMembers1);
            NavTitle.Text = "View Members";
        }

        private void ViewEquipmentBtn_Click(object sender, EventArgs e)
        {
            viewEquipmentControls1 = new ViewEquipmentControls();
            reset_bg();
            ViewEquipmentBtn.BackColor = ColorTranslator.FromHtml("#E8290B");
            Addview(viewEquipmentControls1);
            NavTitle.Text = "View Equipments";
        }

        private void GymStaffRecord_Click(object sender, EventArgs e)
        {
            gymStaffControls1 = new GymStaffControls();
            reset_bg();
            GymStaffRecord.BackColor = ColorTranslator.FromHtml("#E8290B");
            Addview(gymStaffControls1);
            NavTitle.Text = "Gym Staff";
        }

        private void RemoveMemberBtn_Click(object sender, EventArgs e)
        {
            addstaff1 = new Addstaff();
            reset_bg();
            RemoveMemberBtn.BackColor = ColorTranslator.FromHtml("#E8290B");
            Addview(addstaff1);
            NavTitle.Text = "Add Staff";
        }
        private void Addview(UserControl f)
        {
            this.gr_main.Controls.Clear();
            f.Dock = DockStyle.Fill;
            this.gr_main.Controls.Add(f);
            f.Show();
        }
        private void reset_bg()
        {
            dashboardbtn.BackColor = Color.Transparent;
            RemoveMemberBtn.BackColor = Color.Transparent;
            GymStaffRecord.BackColor = Color.Transparent;
            ViewEquipmentBtn.BackColor = Color.Transparent;
            ViewMembersBtn.BackColor = Color.Transparent;
            AddEquipmentsbtn.BackColor = Color.Transparent;
            addmembersbtn.BackColor = Color.Transparent;
        }

        private void gr_main_Enter(object sender, EventArgs e)
        {

        }
    }
}

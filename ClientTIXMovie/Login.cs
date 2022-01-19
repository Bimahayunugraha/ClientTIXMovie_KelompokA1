using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTIXMovie
{
    public partial class Login : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Login()
        {
            InitializeComponent();
            Init_Data();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        public static string Username = "";

        private void buttonVisiblePass_Click(object sender, EventArgs e)
        {
            if (tbxPass.PasswordChar == '*')
            {
                buttonHidePass.BringToFront();
                tbxPass.PasswordChar = '\0';
            }
        }

        private void buttonHidePass_Click(object sender, EventArgs e)
        {
            if (tbxPass.PasswordChar == '\0')
            {
                buttonVisiblePass.BringToFront();
                tbxPass.PasswordChar = '*';
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPass.Text;

            string role = service.Login(username, password);

            if (role == "Admin")
            {
                Save_Data();
                Film adminDashboard = new Film();
                this.Hide();
                adminDashboard.Show();
            }
            else if (role == "AdminBioskop")
            {
                Save_Data();
                AdminBioskopDashboard adminBioskopDashboard = new AdminBioskopDashboard();
                this.Hide();
                adminBioskopDashboard.Show();
            }
            else if (role == "User")
            {
                Save_Data();
                Username = tbxUsername.Text;
                UserDashboard userDashboard = new UserDashboard();
                this.Hide();
                userDashboard.Show();
            }
            else
            {
                MessageBox.Show("Username dan password invalid, Silahkan menghubungi admin");
                tbxUsername.Clear();
                tbxPass.Clear();
            }
        }

        private void txtSignUp_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void Init_Data()
        {
            //Membuat fungsi jika data pada Uname tidak bernilai kosong
            if (Properties.Settings.Default.UName != string.Empty)
            {
                //Membuat fungsi jika data Remme bernilai yes
                if (Properties.Settings.Default.Remme == "yes")
                {
                    //Set untuk data tbxUsername dan tbxPass yang nanti akan disimpan pada Visual Studio
                    tbxUsername.Text = Properties.Settings.Default.UName;
                    tbxPass.Text = Properties.Settings.Default.UPassword;

                    //Jika cbxRemember di centang dengan nilai benar
                    cbxRemember.Checked = true;
                }
                else
                {
                    //Hanya untuk menyimpan data tbxUsername pada Visual Studio
                    tbxUsername.Text = Properties.Settings.Default.UName;
                }
            }
        }

        private void Save_Data()
        {
            //Fungsi jika cbxRemember di centang
            if (cbxRemember.Checked)
            {
                //Set untuk menyimpan data dari Username dan Password pada Visual Studio
                Properties.Settings.Default.UName = tbxUsername.Text;
                Properties.Settings.Default.UPassword = tbxPass.Text;
                Properties.Settings.Default.Remme = "yes";
                Properties.Settings.Default.Save();
            }
            else
            {
                //Set untuk tidak menyimpan data dari Username dan Password pada Visual Studio
                //Jika di uncentang pada cbxRemember
                Properties.Settings.Default.UName = tbxUsername.Text;
                Properties.Settings.Default.UPassword = "";
                Properties.Settings.Default.Remme = "no";
                Properties.Settings.Default.Save();
            }
        }
    }
}

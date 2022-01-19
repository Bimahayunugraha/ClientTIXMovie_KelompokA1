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
    public partial class Register : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Register()
        {
            InitializeComponent();
            tbxID.Visible = false;
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            tbxName.Clear();
            tbxEmail.Clear();
            tbxPhone.Clear();
            tbxPass2.Clear();
            cbxRole.SelectedItem = null;

            tbxName.Focus();
            buttonRegister.Enabled = false;
        }

        private void buttonVisiblePass_Click(object sender, EventArgs e)
        {
            if (tbxPass2.PasswordChar == '*')
            {
                buttonHidePass.BringToFront();
                tbxPass2.PasswordChar = '\0';
            }
        }

        private void buttonHidePass_Click(object sender, EventArgs e)
        {
            if (tbxPass2.PasswordChar == '\0')
            {
                buttonVisiblePass.BringToFront();
                tbxPass2.PasswordChar = '*';
            }
        }

        private void buttonVisiblePass2_Click(object sender, EventArgs e)
        {
            if (tbxConfirmPass.PasswordChar == '*')
            {
                buttonHidePass2.BringToFront();
                tbxConfirmPass.PasswordChar = '\0';
            }
        }

        private void buttonHidePass2_Click(object sender, EventArgs e)
        {
            if (tbxConfirmPass.PasswordChar == '\0')
            {
                buttonVisiblePass2.BringToFront();
                tbxConfirmPass.PasswordChar = '*';
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = tbxName.Text;
            string email = tbxEmail.Text;
            string phone = tbxPhone.Text;
            string password = tbxPass2.Text;
            string role = cbxRole.Text;
            string a = service.Register(username, email, phone, password, role);

            if (tbxName.Text == "" || tbxEmail.Text == "" || tbxPhone.Text == "" || tbxPass2.Text == "" || cbxRole.Text == "")
            {
                MessageBox.Show("All data must be fill", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tbxPass2.Text == tbxConfirmPass.Text)
            {
                MessageBox.Show("Success added data", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            else
            {
                MessageBox.Show("Password does not matches, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbxPass2.Text = ""; //Membuat tbxPass2 menjadi kosong
                tbxConfirmPass.Text = ""; //Membuat tbxConfirmPass menjadi kosong
                tbxPass2.Focus(); //Fungsi untuk focus menginput data pada tbxPass2
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login(); //Deklarasi Form UserLogin
            login.Show(); //Untuk menampilkan Form UserLogin
            this.Hide(); //Untuk hide form Register
        }

        private void cbxTermCondi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTermCondi.Checked)
            {
                buttonRegister.Enabled = true;
            }
            else
            {
                //Fungsi jika pada cbxTermCondi tidak di centang maka buttonRegister akan di disable
                buttonRegister.Enabled = false;
            }
        }
    }
}

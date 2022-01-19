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
    public partial class AdminBioskopDashboard : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public AdminBioskopDashboard()
        {
            InitializeComponent();
            DisplayData();
        }

        private void AdminBioskopDashboard_Load(object sender, EventArgs e)
        {

        }

        private void labelLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        public void DisplayData()
        {
            var List = service.DataTransaksi();
            dgvTransaction.DataSource = List;
        }
    }
}

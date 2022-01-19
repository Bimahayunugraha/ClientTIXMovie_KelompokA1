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
    public partial class AdminDashboard : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public AdminDashboard()
        {
            InitializeComponent();
            DisplayData();
            tbxID.Enabled = false;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        

        public void DisplayData()
        {
            var List = service.DataTransaksi();
            dgvTransaksi.DataSource = List;
        }

        private void labelBooksCat_Click(object sender, EventArgs e)
        {
            Film film = new Film();
            film.Show();
            this.Hide();
        }

        private void labelLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dgvTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxCustomer.Text = Convert.ToString(dgvTransaksi.Rows[e.RowIndex].Cells[3].Value);
            cbxstatus.SelectedItem = Convert.ToString(dgvTransaksi.Rows[e.RowIndex].Cells[12].Value);

            tbxCustomer.Enabled = false;
            tbxID.Enabled = false;
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;

            buttonSave.Enabled = false;
            tbxID.Enabled = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int IDTransaksi = Convert.ToInt32(tbxID.Text);
            string Status = cbxstatus.Text;

            var a = service.edittransaksitiket(IDTransaksi, Status);
            MessageBox.Show("Data berhasil diedit", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string NamaCustomer = tbxCustomer.Text;

            DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data ini", "Hapus data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string a = service.deletefilm(NamaCustomer); // Mengambil return value servis
                MessageBox.Show("Data berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DisplayData();
            }
        }

        public void Clear()
        {
            tbxID.Clear();


            buttonSave.Enabled = true;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;

            tbxID.Enabled = true;
        }
    }
}

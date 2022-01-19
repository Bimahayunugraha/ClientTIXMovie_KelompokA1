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
    public partial class Film : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Film()
        {
            InitializeComponent();
            DisplayData();
            tbxID.Visible = false;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void Film_Load(object sender, EventArgs e)
        {

        }

        

        public void DisplayData()
        {
            var List = service.DataFilm();
            dgvFilm.DataSource = List;
        }

        public void Clear()
        {
            tbxID.Clear();
            tbxJudulFilm.Clear();
            tbxDeskripsi.Clear();
            tbxHarga.Clear();


            buttonSave.Enabled = true;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;

            tbxID.Enabled = true;
        }

        private void labelDash_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
        }

        private void labelLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide(); 
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string JudulFilm = tbxJudulFilm.Text;
            string Deskripsi = tbxDeskripsi.Text;
            string Harga = tbxHarga.Text;
            string a = service.film(JudulFilm, Deskripsi, Harga);

            if (tbxJudulFilm.Text == "" || tbxDeskripsi.Text == "" || tbxHarga.Text == "")
            {
                MessageBox.Show("Semua data harus diisi!!!");
            }
            else
            {
                MessageBox.Show("Sukses menambahkan data", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Refresh();
                DisplayData();

            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxID.Text);
            string Harga = tbxHarga.Text;

            var a = service.editfilm(id, Harga);
            MessageBox.Show(a);
            DisplayData();
            Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string JudulFilm = tbxJudulFilm.Text;

            DialogResult dialogResult = MessageBox.Show("Apakah anda yakin ingin menghapus data ini", "Hapus data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string a = service.deletefilm(JudulFilm); // Mengambil return value servis
                MessageBox.Show("Data berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DisplayData();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvFilm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxID.Text = Convert.ToString(dgvFilm.Rows[e.RowIndex].Cells[0].Value);
            tbxJudulFilm.Text = Convert.ToString(dgvFilm.Rows[e.RowIndex].Cells[1].Value);
            tbxDeskripsi.Text = Convert.ToString(dgvFilm.Rows[e.RowIndex].Cells[2].Value);
            tbxHarga.Text = Convert.ToString(dgvFilm.Rows[e.RowIndex].Cells[3].Value);

            tbxJudulFilm.Enabled = false;
            tbxID.Enabled = false;
            tbxDeskripsi.Enabled = false;

            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;

            buttonSave.Enabled = false;
            tbxID.Enabled = false;
        }
    }
}

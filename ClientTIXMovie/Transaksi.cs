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
    public partial class Transaksi : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Transaksi()
        {
            InitializeComponent();
            DisplayData();
        }

        private void Transaksi_Load(object sender, EventArgs e)
        {

        }

       

        public void DisplayData()
        {
            var List = service.DataFilm();
            dgvDaftarFilm.DataSource = List;
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            int IDFilm = Convert.ToInt32(cbxFilm.Text);
            string Bioskop = cbxbioskop.Text;
            string NamaCustomer = tbxcustomer.Text;
            string Phone = tbxtelepon.Text;
            int Studio = Convert.ToInt32(cbxstudio.Text);
            string Tanggal = cbxtanggal.Text;
            string JamTayang = cbxjam.Text;
            string Row = cbxrow.Text;
            string Seat = cbxseat.Text;
            string Harga = tbxharga.Text;
            string Total = tbxtotal.Text;
            string Status = cbxstatus.Text;

            var a = service.transaksitiket(IDFilm, Bioskop, NamaCustomer, Phone, Studio, Tanggal, JamTayang, Row, Seat, Harga, Total, Status);
            MessageBox.Show("Transaksi berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //Untuk memindahkan data pesan tiket ke detail tiket
            film1.Text = cbxFilm.Text;
            bioskop1.Text = cbxbioskop.Text;
            studio1.Text = cbxstudio.Text;
            tanggal1.Text = cbxtanggal.Text;
            jam1.Text = cbxjam.Text;
            row1.Text = cbxrow.Text;
            seat1.Text = cbxseat.Text;
            harga1.Text = tbxharga.Text;
            film2.Text = cbxFilm.Text;
            bioskop2.Text = cbxbioskop.Text;
            studio2.Text = cbxstudio.Text;
            tanggal2.Text = cbxtanggal.Text;
            jam2.Text = cbxjam.Text;
            row2.Text = cbxrow.Text;
            seat2.Text = cbxseat.Text;
            harga2.Text = tbxharga.Text;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            UserDashboard userDashboard = new UserDashboard();
            userDashboard.Show();
            this.Hide();
        }
    }
}

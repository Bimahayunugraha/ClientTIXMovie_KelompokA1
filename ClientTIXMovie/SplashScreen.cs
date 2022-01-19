using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTIXMovie
{
    public partial class SplashScreen : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int RightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public SplashScreen()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            MyProgressBar.Value = 0;
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            MyProgressBar.Value += 1;
            MyProgressBar.Text = MyProgressBar.Value.ToString() + "%";

            //Membuat Fungsi jika bar sudah mencapai 100%, maka loading timer akan berhenti
            //Kemudian akan masuk secara otomatis ke Form UserLogin
            if (MyProgressBar.Value == 100)
            {
                timer1.Enabled = false;
                Login ul = new Login(); //Deklarasi Form UserLogin
                ul.Show(); //Untuk menampilkan Form UserLogin
                this.Hide(); //Untuk hide form SplashScreen
            }
        }
    }
}

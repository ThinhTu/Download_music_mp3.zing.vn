using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap ScrenCapter()
        {
            //tạo mới 1 size mới với get size của màn hình chính
            Size s = Screen.PrimaryScreen.Bounds.Size;
            
            //tạo một bitmap để lưu trữ ảnh
            Bitmap bm = new Bitmap(s.Width,s.Height);

            //tạo đối tượng graphic mới 
            Graphics g = Graphics.FromImage(bm);

            //lưu đối tượng graphic vào bitmap 
            g.CopyFromScreen(0,0,0,0,s);

            return bm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = ScrenCapter();
        }
    }
}

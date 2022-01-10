using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Tetris_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PictureBox pb1 = new PictureBox();
            pb1.Image = ResizeImage(Image.FromFile(" C:\\Users\\Benjamin\\Pictures\\tetris.jpg"), new Size(100 * 3, 200 * 3));
            pb1.Location = new Point(0, 0);
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(pb1);
        }
        private Image ResizeImage(Image img, Size size)
        {
            return (Image)(new Bitmap(img, size));
        }
        private void button_Play(object sender, EventArgs e)
        {

            Form3 obj1 = new Form3();
            obj1.Show();
            this.Hide();

        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 obj1 = new Form2();
            obj1.Show();
            this.Hide();
        }
    }
}

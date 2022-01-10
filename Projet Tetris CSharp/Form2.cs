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
    public partial class Form2 : Form
    {
        TrackBar tc1;
        public Form2()
        {
            InitializeComponent();

        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1();
            obj1.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}

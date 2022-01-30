using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class tuto : Form
    {
        public tuto()
        {
            InitializeComponent();
            PictureBox pb1 = new PictureBox();
            pb1.Image = ResizeImage(Image.FromFile(AssetsPath + @"tuto.png"), new Size(804, 664));
            pb1.Location = new Point(0, 0);
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(pb1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Options obj1 = new Options();
            obj1.Show();
            this.Close();
        }

        private void tuto_Load(object sender, EventArgs e)
        {

        }
        private Image ResizeImage(Image img, Size size)
        {
            return (Image)(new Bitmap(img, size));
        }

        private string AssetsPath = findAssetsPath();
        private static string findAssetsPath()
        {
            string[] folders = Path.GetDirectoryName(Application.ExecutablePath).Split('\\');
            return String.Join(@"\", folders.Take(folders.Length - 3)) + @"\assets\";
        }
    }
}

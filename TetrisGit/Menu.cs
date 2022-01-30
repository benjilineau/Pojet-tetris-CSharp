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
using TetrisGit;

namespace Tetris
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            PictureBox pb1 = new PictureBox();
            pb1.Image = ResizeImage(Image.FromFile(AssetsPath + @"tetris.jpg"), new Size(720, 480));
            pb1.Location = new Point(0, 0);
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(pb1);
        }

        private string AssetsPath = findAssetsPath();
        private static string findAssetsPath()
        {
            string[] folders = Path.GetDirectoryName(Application.ExecutablePath).Split('\\');
            return String.Join(@"\", folders.Take(folders.Length - 3)) + @"\assets\";
        }

        private Image ResizeImage(Image img, Size size)
        {
            return (Image)(new Bitmap(img, size));
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            firstGame obj1 = new firstGame();
            obj1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Options obj1 = new Options();
            obj1.Show();
            this.Hide();
        }
    }
}

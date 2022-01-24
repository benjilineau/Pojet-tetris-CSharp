using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris;

namespace TetrisGit
{
    public partial class gameOver : Form
    {
        public gameOver(int score)
        {
            InitializeComponent();
            label1.Text = "Score: " + score.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1();
            obj1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tetris.Menu obj1 = new Tetris.Menu();
            obj1.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

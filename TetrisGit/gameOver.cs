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

namespace Tetris
{
    public partial class gameOver : Form
    {
        int bestScore = 0;
        public gameOver(int score, int BestScore)
        {
            InitializeComponent();
            bestScore = BestScore;
            label1.Text = "Score: " + score.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1(bestScore);
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

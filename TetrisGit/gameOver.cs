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
        Dictionary<string, string> command;
        public gameOver(int score, int BestScore, Dictionary<string, string> C)
        {
            InitializeComponent();
            command = C;
            bestScore = BestScore;
            label1.Text = "Score: " + score.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1(bestScore, command);
            obj1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tetris.Menu obj1 = new Tetris.Menu(command);
            obj1.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gameOver_Load(object sender, EventArgs e)
        {

        }
    }
}

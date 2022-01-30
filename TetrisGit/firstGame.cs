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
    public partial class firstGame : Form
    {
        Dictionary<string, string> command;
        public firstGame(Dictionary<string, string> C)
        {
            InitializeComponent();
            command = C;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj1 = new Form1(0, command);
            obj1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tuto obj1 = new tuto(command);
            obj1.Show();
            this.Close();
        }

        private void firstGame_Load(object sender, EventArgs e)
        {

        }
    }
}

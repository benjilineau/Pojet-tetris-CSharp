using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Pause : Form
    {
        Dictionary<string, string> command;
        public Pause(Dictionary<string, string> C)
        {
            InitializeComponent();
            command = C;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Options obj1 = new Options(command);
            obj1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Pause_Load(object sender, EventArgs e)
        {

        }
    }
}

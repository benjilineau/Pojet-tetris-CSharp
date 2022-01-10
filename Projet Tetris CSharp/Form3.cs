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
    public partial class Form3 : Form
    {
        private int _ticks;
        public Form3()
        {
            InitializeComponent();
            timer1.Start();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Benjamin\Downloads\tetris.wav");
            player.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            this.label2.Text = _ticks.ToString();
            this.Text = "Le meilleur tetris de tout les temps";
            if (_ticks == 10)
            {
                this.label2.Text = "Ah batard tu es chaud";
                timer1.Stop();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Text(object sender, EventArgs e)
        {
            label2.Text = _ticks.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

            
        

        }
    }
}

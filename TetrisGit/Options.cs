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
    public partial class Options : Form
    {

        Dictionary<string, string> command;
        WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
        public Options(Dictionary<string, string> C)
        {
            InitializeComponent();

            command = C;

            trackBar1.Value=5;
            wmp.settings.volume=5;
            label3.Text = "Volume = " + trackBar1.Value.ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        { 
            wmp.settings.volume = trackBar1.Value;
            label3.Text = "Volume = " + trackBar1.Value.ToString();

        }

        private void Options_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Controler obj = new Controler(command);
            obj.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            tuto obj1 = new tuto(command);
            obj1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

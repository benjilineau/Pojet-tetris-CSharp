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


        WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
        public Options()
        {
            InitializeComponent();
            trackBar1.Value=5;
            wmp.settings.volume=5;
            label2.Text = trackBar1.Value.ToString();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Menu obj1 = new Menu();
            obj1.Show();
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        { 
            wmp.settings.volume = trackBar1.Value;
            label2.Text = trackBar1.Value.ToString();

        }

        private void Options_Load(object sender, EventArgs e)
        {

        }
    }
}

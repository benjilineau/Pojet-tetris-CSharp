using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace Tetris
{
    public partial class Controler : Form
    {
        Dictionary<string, string> command;
        public Controler(Dictionary<string, string> C)
        {
            InitializeComponent();
            command = C;

            textBox1.Text = command["TLeft"].ToString();
            textBox2.Text = command["TRight"].ToString();
            textBox3.Text = command["Left"].ToString();
            textBox4.Text = command["Right"].ToString();
            textBox5.Text = command["Down"].ToString();

        }

        private void Controler_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            command["TLeft"] = Compare(textBox1.Text.ToUpper());
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            command["TRight"] = Compare(textBox2.Text.ToUpper());

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            command["Left"] = Compare(textBox3.Text.ToUpper());

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            command["Right"] = Compare(textBox4.Text.ToUpper());

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            command["Down"] = Compare(textBox5.Text.ToUpper());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string Compare(string key)
        {
            if(string.Equals(key, "up", StringComparison.OrdinalIgnoreCase))
            {
                return "Up";
            }
            else if (string.Equals(key, "down", StringComparison.OrdinalIgnoreCase))
            {
                return "Down";
            }
            else if (string.Equals(key, "right", StringComparison.OrdinalIgnoreCase))
            {
                return "Right";
            }
            else if (string.Equals(key, "left", StringComparison.OrdinalIgnoreCase))
            {
                return "Left";
            }
            else if (key.Length>1)
            {
                return key[0].ToString();
            }
            return key;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    static class Program
    {
       
        [STAThread]
        static void Main()
        {
            Dictionary<string, string> command = new Dictionary<string, string>();

            command["Left"] = "Q";
            command["TLeft"] = "A";
            command["Down"] = "S";
            command["TRight"] = "E";
            command["Right"] = "D";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu(command));
        }
    }
}

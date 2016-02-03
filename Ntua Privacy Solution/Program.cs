using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ntua_Privacy_Solution
{
    static class Program
    {
        //εναρξη προγραμματος
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

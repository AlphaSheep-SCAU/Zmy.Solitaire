﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmy.Solitaire
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FirstForm());
            //Application.Run(new Solitaire());
            //Application.Run(new VictoryForm(Difficulty.Difficult,SwitchNumber.One,"10:10"));
            //Application.Run(new LoseForm(Difficulty.Difficult,SwitchNumber.One));
        }
    }
}

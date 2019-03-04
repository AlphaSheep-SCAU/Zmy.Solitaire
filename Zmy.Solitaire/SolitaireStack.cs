using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zmy.Solitaire.customComponent;

namespace Zmy.Solitaire
{
    public class SolitaireStack<T> : Stack<T>
    {
        public string Code { get; set; }
        public Panel FormPanel { get; set; }

        public SolitaireStack(string code,Panel formPanel)
        {
            Code = code;
            FormPanel = formPanel;
        }

        public override string ToString()
        {
            return Code;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmy.Solitaire
{
    public partial class VictoryForm : Form
    {
        private string difficulty;
        private string time;

        public VictoryForm()
        {
            InitializeComponent();
        }

        public VictoryForm(string difficulty, string time)
        {
            this.difficulty = difficulty;
            this.time = time;
            InitializeComponent();
        }

        private void setText()
        {
            labelDifficulty.Text += difficulty;
            labelTime.Text += time;
        }

        private void VictoryForm_Load(object sender, EventArgs e)
        {
            setText();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

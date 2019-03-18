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
        private Difficulty difficulty;
        private string time;

        public VictoryForm()
        {
            InitializeComponent();
        }

        public VictoryForm(Difficulty difficulty, string time)
        {
            this.difficulty = difficulty;
            if(time.IndexOf(':') == 1)
                this.time = "0" + time;
            else
                this.time = time;
            InitializeComponent();
        }

        private void VictoryForm_Load(object sender, EventArgs e)
        {
            panelMain.BackColor = Color.FromArgb(12, 57, 115);
            panelMFill.BackColor = Color.FromArgb(12, 57, 115);
            panelTitle.BackColor = Color.FromArgb(31, 180, 231);
            panelTime.BackColor = Color.FromArgb(26, 69, 106);
            buttonNewGame.Location = SolitrireUtil.HorizontalVerticalCenter(buttonNewGame, panelMainButtom);
            labelWhatDifficulty.Text = 
                difficulty == Difficulty.Difficult ? "困难" : 
                difficulty == Difficulty.Medium ? "中等" : 
                difficulty == Difficulty.Easy ? "简单" : "随机";
            labelWhatTime.Text = time;
        }

        private void panelMFill_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                panelMFill.ClientRectangle,
                Color.White, 2, ButtonBorderStyle.Solid,
                Color.White, 2, ButtonBorderStyle.Solid,
                Color.White, 2, ButtonBorderStyle.Solid,
                Color.White, 0, ButtonBorderStyle.Solid);
        }

        private void panelLeftFill_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                panelLeftFill.ClientRectangle,
                Color.White, 0, ButtonBorderStyle.Solid,
                Color.White, 0, ButtonBorderStyle.Solid,
                Color.White, 2, ButtonBorderStyle.Solid,
                Color.White, 0, ButtonBorderStyle.Solid);
        }

        private void panelRightFill_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                panelLeftFill.ClientRectangle,
                Color.White, 2, ButtonBorderStyle.Solid,
                Color.White, 0, ButtonBorderStyle.Solid,
                Color.White, 0, ButtonBorderStyle.Solid,
                Color.White, 0, ButtonBorderStyle.Solid);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                panelMain.ClientRectangle,
                Color.White, 0, ButtonBorderStyle.Solid,
                Color.White, 0, ButtonBorderStyle.Solid,
                Color.White, 0, ButtonBorderStyle.Solid,
                Color.White, 2, ButtonBorderStyle.Solid);
        }

        private void buttonNewGame_MouseEnter(object sender, EventArgs e)
        {
            buttonNewGame.BackgroundImage = Properties.Resources.buttonbg2;
        }

        private void buttonNewGame_MouseLeave(object sender, EventArgs e)
        {
            buttonNewGame.BackgroundImage = Properties.Resources.buttonbg1;
        }

        private void buttonNewGame_MouseDown(object sender, MouseEventArgs e)
        {
            buttonNewGame.BackgroundImage = Properties.Resources.buttonbg3;
        }

        private void buttonNewGame_MouseUp(object sender, MouseEventArgs e)
        {
            buttonNewGame.BackgroundImage = Properties.Resources.buttonbg1;
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.DarkRed;
            buttonExit.ForeColor = Color.White;
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.FromArgb(31, 180, 231);
            buttonExit.ForeColor = Color.Black;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

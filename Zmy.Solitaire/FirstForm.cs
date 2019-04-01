using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmy.Solitaire
{
    public enum SwitchNumber
    {
        One = 1,
        Three = 3
    }

    public enum Difficulty
    {
        Easy = 0,
        Medium = 1,
        Difficult = 2,
        Random = 3
    }

    public partial class FirstForm : Form
    {
        private Panel[] arrayPanelDifficulty;
        private PictureBox[] arrayPictureBox;
        private SwitchNumber switchNumber;
        private Difficulty difficulty;
        private Point curLocation;

        public FirstForm()
        {
            InitializeComponent();
        }

        private void FirstForm_Load(object sender, EventArgs e)
        {
            arrayPanelDifficulty = new Panel[4];
            arrayPictureBox = new PictureBox[4];
            LoadControl2Array();

            switchNumber = SwitchNumber.One;
            difficulty = Difficulty.Easy;

            panelMFill.BackColor = Color.FromArgb(12, 57, 115);
            panelMain.BackColor = Color.FromArgb(12, 57, 115);
            panelTitle.BackColor = Color.FromArgb(31, 180, 231);
            panelSwitchOne.BackColor = Color.FromArgb(31, 180, 231);
            panelSwitchThree.BackColor = Color.FromArgb(1, 21, 37);
            panelEasy.BackColor = Color.FromArgb(31, 180, 231);
            panelMedium.BackColor = Color.FromArgb(1, 21, 37);
            panelDifficult.BackColor = Color.FromArgb(1, 21, 37);
            panelRandom.BackColor = Color.FromArgb(1, 21, 37);
            buttonStartGame.Location = SolitaireUtil.HorizontalVerticalCenter(buttonStartGame, panelMainButtom);
            labelChoose.Location = SolitaireUtil.HorizontalVerticalCenter(labelChoose, panelLabelChoose);
        }

        private void LoadControl2Array()
        {
            arrayPanelDifficulty[0] = panelEasy;
            arrayPanelDifficulty[1] = panelMedium;
            arrayPanelDifficulty[2] = panelDifficult;
            arrayPanelDifficulty[3] = panelRandom;

            arrayPictureBox[0] = pictureBox1;
            arrayPictureBox[1] = pictureBox2;
            arrayPictureBox[2] = pictureBox3;
            arrayPictureBox[3] = pictureBox4;

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

        private void buttonStartGame_MouseEnter(object sender, EventArgs e)
        {
            buttonStartGame.BackgroundImage = Properties.Resources.buttonbg2;
        }

        private void buttonStartGame_MouseLeave(object sender, EventArgs e)
        {
            buttonStartGame.BackgroundImage = Properties.Resources.buttonbg1;
        }

        private void buttonStartGame_MouseDown(object sender, MouseEventArgs e)
        {
            buttonStartGame.BackgroundImage = Properties.Resources.buttonbg3;
        }

        private void buttonStartGame_MouseUp(object sender, MouseEventArgs e)
        {
            buttonStartGame.BackgroundImage = Properties.Resources.buttonbg1;
        }

        #region buttonExit
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
            Close();
        }
        #endregion

        private void panelLine_Paint(object sender, PaintEventArgs e)
        {
            Graphics p = panelLine.CreateGraphics();
            p.DrawLine(new Pen(Color.FromArgb(31, 180, 231), 1), 
                new Point(0, panelLine.Height / 2), 
                new Point(panelLine.Width, panelLine.Height / 2));
        }

        private void panel_MouseEnter(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            if ((string)p.Tag == "1")
                return;
            p.BackColor = Color.FromArgb(15, 93, 126);
        }

        private void panel_MouseLeave(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            if ((string)p.Tag == "1")
                return;
            p.BackColor = Color.FromArgb(1, 21, 37);
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel p = sender as Panel;
            if ((string)p.Tag == "1")
                return;
            if(p.Name == "panelSwitchOne")
            {
                p.Tag = "1";
                panelSwitchThree.Tag = "0";
                p.BackColor = Color.FromArgb(31, 180, 231);
                panelSwitchThree.BackColor = Color.FromArgb(1, 21, 37);
                pictureBox1.BackgroundImage = Properties.Resources.choose;
                pictureBox2.BackgroundImage = Properties.Resources.unchoose;
                switchNumber = SwitchNumber.One;
            }
            else
            {
                p.Tag = "1";
                panelSwitchOne.Tag = "0";
                p.BackColor = Color.FromArgb(31, 180, 231);
                panelSwitchOne.BackColor = Color.FromArgb(1, 21, 37);
                pictureBox1.BackgroundImage = Properties.Resources.unchoose;
                pictureBox2.BackgroundImage = Properties.Resources.choose;
                switchNumber = SwitchNumber.Three;
            }
        }

        private void panelDifficult_MouseClick(object sender, MouseEventArgs e)
        {
            Panel p = sender as Panel;
            if ((string)p.Tag == "1")
                return;
            p.Tag = "1";
            p.BackColor = Color.FromArgb(31, 180, 231);
            for(int i = 0; i < p.Controls.Count; i++)
            {
                if(p.Controls[i] is PictureBox)
                {
                    p.Controls[i].BackgroundImage = Properties.Resources.choose;
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (arrayPanelDifficulty[i].Name == p.Name)
                {
                    difficulty = (Difficulty)i;
                    continue;
                }
                arrayPanelDifficulty[i].Tag = "0";
                arrayPanelDifficulty[i].BackColor = Color.FromArgb(1, 21, 37);
                for (int j = 0; j < arrayPanelDifficulty[i].Controls.Count; j++)
                {
                    if (arrayPanelDifficulty[i].Controls[j] is PictureBox)
                    {
                        arrayPanelDifficulty[i].Controls[j].BackgroundImage = Properties.Resources.unchoose;
                        break;
                    }
                }
            }
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            Solitaire s = new Solitaire(switchNumber,difficulty);
            Hide();
            if(s.ShowDialog() == DialogResult.Cancel)
            {
                Show();
            }
        }

        private void panelLFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelRFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            curLocation = new Point(e.X, e.Y);
        }

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Location = new Point(Location.X + e.X - curLocation.X, Location.Y + e.Y - curLocation.Y);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmy.Solitaire.customComponent
{
    /// <summary>
    /// 卡牌花色：1-黑桃，2-红心，3-梅花，4-方块
    /// </summary>
    public enum Suit
    {
        Spade = 0,
        Heart = 1,
        Club = 2,
        Diamond = 3
    }
    /// <summary>
    /// 卡牌点数
    /// </summary>
    public enum Number
    {
        Ace = 0,
        Two = 1,
        Three = 2,
        Four = 3,
        Five = 4,
        Six = 5,
        Seven = 6,
        Eight = 7,
        Nine = 8,
        Ten = 9,
        Jack = 10,
        Queen = 11,
        King = 12
    }
    public partial class Card : UserControl
    {
        private bool isMoving;
        private int curX;
        private int curY;
        private bool isShow;
        public bool IsShow
        {
            get
            {
                return isShow;
            }
            set
            {
                isShow = value;
                if (isShow)
                {
                    panelTop.Visible = true;
                    //panelButtom.Visible = true;
                }
                else
                {
                    panelTop.Visible = false;
                    panelButtom.Visible = false;
                }
            }
        }
        public Suit CardSuit { get; set; }
        public Number CardNumber { get; set; }
        public int PanelTopHeight { get; set; }
        public Point LastLocation { get; set; }
        public Stack<Card> CurContainer { get; set; }


        public Card()
        {
            InitializeComponent();
            isMoving = false;
            AllowDrop = true;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cardSuit">卡牌花色：1-黑桃，2-红心，3-梅花，4-方块</param>
        /// <param name="cardNumber">卡牌点数</param>
        public Card(Suit cardSuit,Number cardNumber)
        {
            InitializeComponent();
            AllowDrop = true;

            CardSuit = cardSuit;
            SetSuitImage(CardSuit);

            CardNumber = cardNumber;
            labelNumberLeft.Text = ConvertNumber2String(cardNumber);
            labelNumberRight.Text = labelNumberLeft.Text;

            IsShow = false;
            isMoving = false;
            PanelTopHeight = panelTop.Height;
            LastLocation = Location;

            AddEvent(this);
        }

        private void AddEvent(Control c)
        {
            foreach (Control control in c.Controls)
            {
                if(control is Panel)
                {
                    AddEvent(control);
                }
                control.MouseDown += Card_MouseDown;
                control.MouseMove += Card_MouseMove;
                control.MouseUp += Card_MouseUp;
            }
        }

        //用于卡牌点数转换卡牌字符串
        private string ConvertNumber2String(Number cnum)
        {
            int num = (int)cnum;
            switch (num)
            {
                case 0: return "A";
                case 10: return "J";
                case 11: return "Q";
                case 12: return "K";
                default:
                    return (num + 1).ToString();
            }
        }

        //用于设置卡牌的花色图片
        private void SetSuitImage(Suit csuit)
        {
            int suit = (int)csuit;
            switch (suit)
            {
                case 0:
                    pictureBoxLeft.Image = Properties.Resources.spade_24px;
                    pictureBoxRight.Image = Properties.Resources.spade_24px;
                    break;
                case 1:
                    pictureBoxLeft.Image = Properties.Resources.heart_24px;
                    pictureBoxRight.Image = Properties.Resources.heart_24px;
                    break;
                case 2:
                    pictureBoxLeft.Image = Properties.Resources.club_24px;
                    pictureBoxRight.Image = Properties.Resources.club_24px;
                    break;
                case 3:
                    pictureBoxLeft.Image = Properties.Resources.diamond_24px;
                    pictureBoxRight.Image = Properties.Resources.diamond_24px;
                    break;
                default:
                    break;
            }
        }

        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            LastLocation = Location;
            if (e.Button == MouseButtons.Left && isShow)
            {
                this.BringToFront();
                Point t = new Point(e.X, e.Y);
                t = PointToScreen(t);
                curX = t.X;
                curY = t.Y;
                isMoving = true;
            }

        }

        private void Card_MouseUp(object sender, MouseEventArgs e)
        {
            //取消移动
            isMoving = false;
            //控制纸牌的显示
            if (e.Button == MouseButtons.Left
                && !IsShow && CurContainer is Stack<Card>
                && (CurContainer as Stack<Card>).Peek() == this)
            {
                IsShow = true;
                //CurContainer.Pop();
            }
        }

        private void Card_MouseMove(object sender, MouseEventArgs e)
        {
            Point t = new Point(e.X, e.Y);
            t = PointToScreen(t);
            if (isMoving)
            {
                int newX = t.X - curX;
                int newY = t.Y - curY;
                Point newPoint = new Point(Location.X + newX, Location.Y + newY);
                Location = newPoint;
                curX = t.X;
                curY = t.Y;
            }
        }

        private void HideOrShowAllPanel(Control c, bool hs)
        {
            foreach (Control control in c.Controls)
            {
                if(control.Name == "panelMenu" || control.Name == "panelFunction")
                {
                    continue;
                }
                if (control is Panel)
                {
                    if (hs)
                    {
                        control.Visible = false;
                    }
                    else
                    {
                        control.Visible = true;
                    }
                    HideOrShowAllPanel(control, hs);
                }
            }
        }

        private void Card_Load(object sender, EventArgs e)
        {
            
        }
    }
}

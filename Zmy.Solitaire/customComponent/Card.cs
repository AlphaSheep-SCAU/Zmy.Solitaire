using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Threading;

namespace Zmy.Solitaire.customComponent
{
    /// <summary>
    /// 卡牌花色：0-黑桃，1-红心，2-梅花，3-方块, -1-重置
    /// </summary>
    public enum Suit
    {
        Spade = 0,
        Heart = 1,
        Club = 2,
        Diamond = 3,
        Reset = -1,
        Finish = -2
    }

    /// <summary>
    /// 卡牌点数
    /// </summary>
    public enum Number
    {
        Finish = -2,
        Reset = -1,
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

    /// <summary>
    /// 卡牌颜色
    /// </summary>
    public enum Color
    {
        Black = 0,
        Red = 1
    }

    public partial class Card : UserControl
    {
        private bool isMoving;
        public int curX;
        public int curY;
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
                    panelMiddle.Visible = true;
                    panelButtom.Visible = true;
                    //if (CardSuit != Suit.Reset && CardSuit != Suit.Finish)
                    //    BackgroundImage = Properties.Resources.blank_radius;
                }
                else
                {
                    panelTop.Visible = false;
                    panelMiddle.Visible = false;
                    panelButtom.Visible = false;
                    //if(CardSuit != Suit.Reset && CardSuit != Suit.Finish)
                    //    BackgroundImage = Properties.Resources.cardbackground_radius;
                }
            }
        }
        public Suit CardSuit { get; set; }
        public Number CardNumber { get; set; }
        public Color CardColor { get; set; }
        //public int PanelTopHeight { get; set; }
        public Point LastLocation { get; set; }
        public SolitaireStack<Card> CurContainer { get; set; }
        public List<Card> cardList;
        public Point thread_t { get; set; }
        public delegate void d(Point newPoint);

        /// <summary>
        /// 默认构造函数
        /// </summary>
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

            CardSuit = cardSuit;
            CardColor = (CardSuit == Suit.Spade || CardSuit == Suit.Club) ? Color.Black : Color.Red;
            SetSuitImage(CardSuit);

            CardNumber = cardNumber;

            IsShow = false;
            isMoving = false;
            //PanelTopHeight = panelTop.Height;
            LastLocation = Location;
            cardList = new List<Card>();

            //this.DoubleBuffered = true;
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);//禁止擦除背景
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }


        private void Card_Load(object sender, EventArgs e)
        {
            labelNumberLeft.Text = ConvertNumber2String(CardNumber);
            labelNumberRight.Text = labelNumberLeft.Text;
            AddEvent(this);

        }

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x0014)//禁止清除背景消息
        //        return;
        //    base.WndProc(ref m);
        //}

        /// <summary>
        /// 解决卡顿
        /// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var parms = base.CreateParams;
        //        parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN 
        //        return parms;
        //    }
        //}

        /// <summary>
        /// 用于外部类往卡牌添加MouseUp事件
        /// </summary>
        /// <param name="c">需要添加事件的卡牌</param>
        /// <param name="e">需要添加的MouseUp事件</param>
        public void AddMouseUp(Control c, MouseEventHandler e)
        {
            if (CardSuit == Suit.Reset || CardSuit == Suit.Finish)
                return;
            c.MouseUp += e;
            foreach (Control control in c.Controls)
            {
                if (control is Panel)
                {
                    AddMouseUp(control, e);
                }
                control.MouseUp += e;
                Console.WriteLine(control.Name);
            }
        }

        /// <summary>
        /// 用于初始化卡牌时添加事件
        /// </summary>
        /// <param name="c">this</param>
        private void AddEvent(Control c)
        {
            if (CardSuit == Suit.Finish || CardSuit == Suit.Reset)
                return;
            c.MouseDown += Card_MouseDown;
            c.MouseMove += Card_MouseMove;
            c.MouseUp += Card_MouseUp;
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

        /// <summary>
        /// 用于卡牌点数转换卡牌字符串
        /// </summary>
        /// <param name="cnum">卡牌的点数</param>
        /// <returns></returns>
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

        /// <summary>
        /// 用于设置卡牌的花色图片
        /// </summary>
        /// <param name="csuit">卡牌的花色</param>
        private void SetSuitImage(Suit csuit)
        {
            int suit = (int)csuit;
            switch (suit)
            {
                case 0:
                    pictureBoxLeft.Image = Properties.Resources.spade_24px;
                    pictureBoxRight.Image = Properties.Resources.spade_24px;
                    pictureBoxMiddle.Image = Properties.Resources.spade_48px;
                    break;
                case 1:
                    pictureBoxLeft.Image = Properties.Resources.heart_24px;
                    pictureBoxRight.Image = Properties.Resources.heart_24px;
                    pictureBoxMiddle.Image = Properties.Resources.heart_48px;
                    labelNumberLeft.ForeColor = System.Drawing.Color.DarkRed;
                    labelNumberRight.ForeColor = System.Drawing.Color.DarkRed;
                    break;
                case 2:
                    pictureBoxLeft.Image = Properties.Resources.club_24px;
                    pictureBoxRight.Image = Properties.Resources.club_24px;
                    pictureBoxMiddle.Image = Properties.Resources.club_48px;
                    break;
                case 3:
                    pictureBoxLeft.Image = Properties.Resources.diamond_24px;
                    pictureBoxRight.Image = Properties.Resources.diamond_24px;
                    pictureBoxMiddle.Image = Properties.Resources.diamond_48px;
                    labelNumberLeft.ForeColor = System.Drawing.Color.DarkRed;
                    labelNumberRight.ForeColor = System.Drawing.Color.DarkRed;
                    break;
                case -1:
                    BackgroundImage = Properties.Resources.reset_card;
                    BackColor = System.Drawing.Color.Transparent;
                    break;
                case -2:
                    BackColor = System.Drawing.Color.Transparent;
                    //BackgroundImage = Properties.Resources.finish_card;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 卡牌的MouseDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            cardList.Clear();
            for(int i = 0; i < CurContainer.Count; i++)
            {
                Card[] arrCard = CurContainer.ToArray();
                if(arrCard[i] == this)
                {
                    cardList.Add(arrCard[i]);
                    break;
                }
                else
                {
                    cardList.Add(arrCard[i]);
                }
            }

            if (!SolitrireRule.IsCanMoveMul(cardList))
            {
                cardList.Clear();
                return;
            }

            foreach (Card card in cardList)
            {
                card.LastLocation = card.Location;
                if (e.Button == MouseButtons.Left && isShow)
                {
                    //this.BringToFront();
                    Point t = new Point(e.X, e.Y);
                    t = PointToScreen(t);
                    card.curX = t.X;
                    card.curY = t.Y;
                    isMoving = true;
                }
            }

            for(int i = cardList.Count -1;i >= 0; i--)
            {
                //cardList[i].BackColor = System.Drawing.Color.Aqua;
                cardList[i].BringToFront();
            }
        }

        /// <summary>
        /// 卡牌的MouseUp事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card_MouseUp(object sender, MouseEventArgs e)
        {
            //取消移动
            isMoving = false;
            //cardList.Clear();
            //控制纸牌的显示
            if (e.Button == MouseButtons.Left
                && !IsShow && CurContainer is Stack<Card>
                && (CurContainer as Stack<Card>).Peek() == this)
            {
                IsShow = true;
                //CurContainer.Pop();
            }
        }

        /// <summary>
        /// 卡牌的MouseMove事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Card_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving && cardList.Count > 0)
            {
                Point t = new Point(e.X, e.Y);
                t = PointToScreen(t);
                foreach (Card card in cardList)
                {
                    int newX = t.X - card.curX;
                    int newY = t.Y - card.curY;
                    Point newPoint = new Point(card.Location.X + newX, card.Location.Y + newY);
                    card.Location = newPoint;
                    card.curX = t.X;
                    card.curY = t.Y;
                }
            }
        }

        /// <summary>
        /// 隐藏或者展示所有的Panel，用于翻牌
        /// </summary>
        /// <param name="c">需要翻牌的卡牌</param>
        /// <param name="hs">隐藏或展示：true：隐藏，false：展示</param>
        private void HideOrShowAllPanel(Control c, bool hs)
        {
            foreach (Control control in c.Controls)
            {
                if (control.Name == "panelMenu" || control.Name == "panelFunction")
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

        private void Card_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

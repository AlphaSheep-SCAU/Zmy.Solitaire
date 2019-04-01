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
        public Image CardImage { get; set; }
        public Image CardImageRotate { get; set; }
        public Point LastLocation { get; set; }
        public SolitaireStack<Card> CurContainer { get; set; }
        public List<Card> cardList;
        private System.Drawing.Color borderColor;
        private int borderSize;

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

            CardNumber = cardNumber;
            CardSuit = cardSuit;
            CardColor = (CardSuit == Suit.Spade || CardSuit == Suit.Club) ? Color.Black : Color.Red;
            CardImage = CardSuit == Suit.Spade ? Properties.Resources.spade_48px : 
                CardSuit == Suit.Heart ? Properties.Resources.heart_48px : 
                CardSuit == Suit.Club ? Properties.Resources.club_48px : Properties.Resources.diamond_48px;
            CardImageRotate = CardImage.Clone() as Image;
            CardImageRotate.RotateFlip(RotateFlipType.Rotate180FlipX);
            SetSuitImage(CardSuit);
            SetMiddlePicture();

            borderColor = System.Drawing.Color.FromArgb(211, 212, 211);
            borderSize = 1;
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
            //rotateLabel.Text = labelNumberLeft.Text;
            rotateLabel.RText = labelNumberLeft.Text == "10" ? "10" : " " + labelNumberLeft.Text;
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
                //Console.WriteLine(control.Name);
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
            pictureBoxLeft.Image = CardImage;
            pictureBoxRight.Image = CardImageRotate;
            if (CardColor == Color.Red)
            {
                labelNumberLeft.ForeColor = System.Drawing.Color.DarkRed;
                rotateLabel.ForeColor = System.Drawing.Color.DarkRed;
            }
            int suit = (int)csuit;
            switch (suit)
            {
                case -1:
                    BackgroundImage = Properties.Resources.reset_card;
                    BackColor = System.Drawing.Color.Transparent;
                    break;
                case -2:
                    BackColor = System.Drawing.Color.Transparent;
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

            if (!SolitaireRule.IsCanMoveMul(cardList))
            {
                cardList.Clear();
                return;
            }

            foreach (Card card in cardList)
            {
                card.LastLocation = card.Location;
                if (e.Button == MouseButtons.Left && isShow)
                {
                    Point t = new Point(e.X, e.Y);
                    t = PointToScreen(t);
                    card.curX = t.X;
                    card.curY = t.Y;
                    isMoving = true;
                }
            }

            for(int i = cardList.Count - 1;i >= 0; i--)
            {
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
                    card.Location = new Point(card.Location.X + newX, card.Location.Y + newY);
                    //card.Location = newPoint;
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

        private void SetMiddlePicture()
        {
            if (CardNumber == Number.Ace)
                SetMiddlePictureOne();
            else if (CardNumber == Number.Two)
                SetMiddlePictureTwo();
            else if (CardNumber == Number.Three)
                SetMiddlePictureThree();
            else if (CardNumber == Number.Four)
                SetMiddlePictureFour();
            else if (CardNumber == Number.Five)
                SetMiddlePictureFive();
            else if (CardNumber == Number.Six)
                SetMiddlePictureSix();
            else if (CardNumber == Number.Seven)
                SetMiddlePictureSeven();
            else if (CardNumber == Number.Eight)
                SetMiddlePictureEight();
            else if (CardNumber == Number.Nine)
                SetMiddlePictureNine(false);
            else if (CardNumber == Number.Ten)
                SetMiddlePictureTen();
            else if (CardNumber == Number.Jack)
                SetMiddlePictureJack();
            else if (CardNumber == Number.Queen)
                SetMiddlePictureQueen();
            else if (CardNumber == Number.King)
                SetMiddlePictureKing();
        }   

        private void SetMiddlePictureOne()
        {
            pictureBoxMiddle.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxMiddle.Image = CardImage;
        }

        private void SetMiddlePictureTwo()
        {
            PictureBox pb1 = GeneratePictureBox();
            PictureBox pb2 = GeneratePictureBox();
            pb1.Location = new Point(pb1.Location.X, 10);
            pb2.Location = new Point(pb2.Location.X, 105);
            pb1.Location = SolitaireUtil.HorizontalCenter(pb1, panelMiddle);
            pb2.Location = SolitaireUtil.HorizontalCenter(pb2, panelMiddle);
            pb1.Image = CardImage;
            pb2.Image = CardImageRotate;
            panelMiddle.Controls.Add(pb1);
            panelMiddle.Controls.Add(pb2);
            pictureBoxMiddle.SendToBack();
        }

        private void SetMiddlePictureThree()
        {
            SetMiddlePictureTwo();
            PictureBox pb = GeneratePictureBox();
            pb.Location = SolitaireUtil.HorizontalVerticalCenter(pb, panelMiddle);
            pb.Image = CardImage;
            panelMiddle.Controls.Add(pb);
            pictureBoxMiddle.SendToBack();
        }

        private void SetMiddlePictureFour()
        {
            PictureBox pb1 = GeneratePictureBox();
            PictureBox pb2 = GeneratePictureBox();
            PictureBox pb3 = GeneratePictureBox();
            PictureBox pb4 = GeneratePictureBox();
            pb1.Location = new Point(0, 15);
            pb2.Location = new Point(pictureBoxMiddle.Width - 22, 15);
            pb3.Location = new Point(0, 100);
            pb4.Location = new Point(pictureBoxMiddle.Width - 22, 100);
            pb1.Image = pb2.Image = CardImage;
            pb3.Image = pb4.Image = CardImageRotate;
            panelMiddle.Controls.Add(pb1);
            panelMiddle.Controls.Add(pb2);
            panelMiddle.Controls.Add(pb3);
            panelMiddle.Controls.Add(pb4);
            pictureBoxMiddle.SendToBack();
        }

        private void SetMiddlePictureFive()
        {
            SetMiddlePictureFour();
            PictureBox pb = GeneratePictureBox();
            pb.Location = SolitaireUtil.HorizontalVerticalCenter(pb, panelMiddle);
            pb.Image = CardImage;
            panelMiddle.Controls.Add(pb);
            pictureBoxMiddle.SendToBack();
        }

        private void SetMiddlePictureSix()
        {
            SetMiddlePictureFour();
            PictureBox pb1 = GeneratePictureBox();
            PictureBox pb2 = GeneratePictureBox();
            pb1.Location = SolitaireUtil.VerticalCenter(pb1, panelMiddle);
            pb1.Location = new Point(0, pb1.Location.Y);
            pb2.Location = new Point(pictureBoxMiddle.Width - 24, pb1.Location.Y);
            pb1.Image = pb2.Image = CardImage;
            panelMiddle.Controls.Add(pb1);
            panelMiddle.Controls.Add(pb2);
            pictureBoxMiddle.SendToBack();
        }

        private void SetMiddlePictureSeven()
        {
            SetMiddlePictureSix();
            PictureBox pb = GeneratePictureBox();
            pb.Location = SolitaireUtil.HorizontalVerticalCenter(pb, panelMiddle);
            pb.Location = new Point(pb.Location.X, (pb.Location.Y - 15) / 2 + 15);
            pb.Image = CardImage;
            pb.BringToFront();
            panelMiddle.Controls.Add(pb);
            pictureBoxMiddle.SendToBack();
        }

        private void SetMiddlePictureEight()
        {
            SetMiddlePictureSeven();
            PictureBox pb = GeneratePictureBox();
            pb.Location = SolitaireUtil.HorizontalVerticalCenter(pb, panelMiddle);
            pb.Location = new Point(pb.Location.X, (100 + (pb.Location.Y / 2)) / 2 + 15);
            pb.Image = CardImageRotate;
            pb.BringToFront();
            panelMiddle.Controls.Add(pb);
            pictureBoxMiddle.SendToBack();
        }

        private void SetMiddlePictureNine(bool isTen)
        {
            if (!isTen)
            {
                PictureBox pb5 = GeneratePictureBox();
                pb5.Location = SolitaireUtil.HorizontalVerticalCenter(pb5, panelMiddle);
                pb5.Image = CardImage;
                pb5.BringToFront();
                panelMiddle.Controls.Add(pb5);
            }
            SetMiddlePictureFour();
            PictureBox pb1 = GeneratePictureBox();
            PictureBox pb2 = GeneratePictureBox();
            PictureBox pb3 = GeneratePictureBox();
            PictureBox pb4 = GeneratePictureBox();
            pb1.Location = new Point(0, 28 + 15);
            pb2.Location = new Point(pictureBoxMiddle.Width - 22, 28 + 15);
            pb3.Location = new Point(0, 100 - 28);
            pb4.Location = new Point(pictureBoxMiddle.Width - 22, 100 - 28);
            pb1.Image = pb2.Image = CardImage;
            pb3.Image = pb4.Image = CardImageRotate;
            pb1.SendToBack();
            pb2.SendToBack();
            pb3.SendToBack();
            pb4.SendToBack();
            panelMiddle.Controls.Add(pb1);
            panelMiddle.Controls.Add(pb2);
            panelMiddle.Controls.Add(pb3);
            panelMiddle.Controls.Add(pb4);
            pictureBoxMiddle.SendToBack();
        }

        private void SetMiddlePictureTen()
        {
            PictureBox pb1 = GeneratePictureBox();
            PictureBox pb2 = GeneratePictureBox();
            pb1.Location = pb2.Location = SolitaireUtil.HorizontalCenter(pb1, panelMiddle);
            pb1.Location = new Point(pb1.Location.X, (100 - 28 - 28 - 15) / 2 + 15);
            pb2.Location = new Point(pb1.Location.X, (100 + ((100 - 28) / 2)) / 2 + 15);
            pb1.Image = CardImage;
            pb2.Image = CardImageRotate;
            pb1.BringToFront();
            pb2.BringToFront();
            panelMiddle.Controls.Add(pb1);
            panelMiddle.Controls.Add(pb2);
            SetMiddlePictureNine(true);
            pictureBoxMiddle.SendToBack();
        }

        private void SetMiddlePictureJack()
        {
            pictureBoxMiddle.Image = CardSuit == Suit.Spade ? 
                Properties.Resources.spadeJack : CardSuit == Suit.Heart ? 
                Properties.Resources.heartJack : CardSuit == Suit.Club ? 
                Properties.Resources.clubJack : Properties.Resources.diamondJack;
        }

        private void SetMiddlePictureQueen()
        {
            pictureBoxMiddle.Image = CardSuit == Suit.Spade ?
                Properties.Resources.spadeQueen : CardSuit == Suit.Heart ?
                Properties.Resources.heartQueen : CardSuit == Suit.Club ?
                Properties.Resources.clubQueen : Properties.Resources.diamondQueen;
        }

        private void SetMiddlePictureKing()
        {
            pictureBoxMiddle.Image = CardSuit == Suit.Spade ?
                Properties.Resources.spadeKing : CardSuit == Suit.Heart ?
                Properties.Resources.heartKing : CardSuit == Suit.Club ?
                Properties.Resources.clubKing : Properties.Resources.diamondKing;
        }

        private PictureBox GeneratePictureBox()
        {
            PictureBox pb = new PictureBox();
            pb.Height = pb.Width = 22;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.BackColor = System.Drawing.Color.Transparent;
            return pb;
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            //if (!isShow)
            //    return;
            if (CardSuit == Suit.Reset)
                return;
            Panel t = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics,
                t.ClientRectangle,
                borderColor, borderSize, ButtonBorderStyle.Solid,
                borderColor, borderSize, ButtonBorderStyle.Solid,
                System.Drawing.Color.Gray, 0, ButtonBorderStyle.None,
                borderColor, borderSize, ButtonBorderStyle.Solid);
        }

        private void pictureBoxMiddle_Paint(object sender, PaintEventArgs e)
        {
            //if (!isShow)
            //    return;
            if (CardSuit == Suit.Reset)
                return;
            ControlPaint.DrawBorder(e.Graphics,
                pictureBoxMiddle.ClientRectangle,
                System.Drawing.Color.Gray, 0, ButtonBorderStyle.None,
                borderColor, borderSize, ButtonBorderStyle.Solid,
                System.Drawing.Color.Gray, 0, ButtonBorderStyle.None,
                borderColor, borderSize, ButtonBorderStyle.Solid);
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            if (CardSuit == Suit.Reset)
                return;
            ControlPaint.DrawBorder(e.Graphics,
                ClientRectangle,
                borderColor, borderSize, ButtonBorderStyle.Solid,
                borderColor, borderSize, ButtonBorderStyle.Solid,
                borderColor, borderSize, ButtonBorderStyle.Solid,
                borderColor, borderSize, ButtonBorderStyle.Solid);
        }

        public void ChangeBorderColor()
        {
            if(borderSize == 1)
            {
                //borderColor = System.Drawing.Color.FromArgb(248, 252, 185);
                borderColor = System.Drawing.Color.OrangeRed;
                borderSize = 3;
            }
            else
            {
                borderColor = System.Drawing.Color.FromArgb(211, 212, 211);
                borderSize = 1;
            }
            Invalidate();
            Update();
        }

        private void panelButtom_Paint(object sender, PaintEventArgs e)
        {
            if (CardSuit == Suit.Reset)
                return;
            Panel t = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics,
                t.ClientRectangle,
                borderColor, 0, ButtonBorderStyle.None,
                borderColor, borderSize, ButtonBorderStyle.Solid,
                borderColor, borderSize, ButtonBorderStyle.Solid,
                borderColor, borderSize, ButtonBorderStyle.Solid);
        }
    }
}

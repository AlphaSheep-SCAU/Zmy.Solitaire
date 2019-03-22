using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zmy.Solitaire.customComponent;

namespace Zmy.Solitaire
{
    public partial class Solitaire : Form
    {
        public Card[] listCard;
        private Panel[] panelMiddleCard;
        private Panel[] panelFinishedCard;
        private SolitaireStack<Card>[] stackMiddleCard;
        private SolitaireStack<Card>[] stackFinishedCard;
        private SolitaireStack<Card> stackRandomCard;
        private SolitaireStack<Card> stackRandomShowCard;
        private WatchForm wf;
        private Stack<PlayerStep> step;
        private readonly int betweenLength;
        private readonly int leftLength;
        private Label labelTime;
        private int timer_second;
        private int timer_minute;
        private bool isTimerOn;
        public int TimerSecond
        {
            get
            {
                return timer_second;
            }
            set
            {
                timer_second = value;
                labelTime.Text = TimerMinute.ToString() + ":";
                labelTime.Text += TimerSecond > 9 ? TimerSecond.ToString() : "0" + TimerSecond.ToString();
            }
        }
        public int TimerMinute
        {
            get
            {
                return timer_minute;
            }
            set
            {
                timer_minute = value;
                labelTime.Text = TimerMinute.ToString() + ":";
                labelTime.Text += TimerSecond > 9 ? TimerSecond.ToString() : "0" + TimerSecond.ToString();
            }
        }

        private Difficulty difficult;
        private SwitchNumber switchNumber;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Solitaire()
        {
            betweenLength = 24;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);//禁止擦除背景
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        public Solitaire(SwitchNumber switchNumber, Difficulty difficult)
        {
            this.switchNumber = switchNumber;
            this.difficult = difficult;
            betweenLength = 35;
            leftLength = 24;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);//禁止擦除背景
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        /// <summary>
        /// 加载时函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Salitrire_Load(object sender, EventArgs e)
        {
            InitVariable();

            InitGame();

            SolitrireUtil.HideOrShowAllPanel(this, true);

            Card finishCard = new Card(Suit.Finish, Number.Finish);
            finishCard.BackgroundImage = Properties.Resources.finish_spade;
            finishCard.Location = LocatePoint(panelFinishedCardSpade);
            Controls.Add(finishCard);

            finishCard = new Card(Suit.Finish, Number.Finish);
            finishCard.BackgroundImage = Properties.Resources.finish_heart;
            finishCard.Location = LocatePoint(panelFinishedCardHeart);
            Controls.Add(finishCard);

            finishCard = new Card(Suit.Finish, Number.Finish);
            finishCard.BackgroundImage = Properties.Resources.finish_club;
            finishCard.Location = LocatePoint(panelFinishedCardClub);
            Controls.Add(finishCard);

            finishCard = new Card(Suit.Finish, Number.Finish);
            finishCard.BackgroundImage = Properties.Resources.finish_diamond;
            finishCard.Location = LocatePoint(panelFinishedCardDiamond);
            Controls.Add(finishCard);

            panelMenu.BackColor = System.Drawing.Color.FromArgb(50, System.Drawing.Color.Black);

            //生成撤销按钮
            Button btnUndo = new Button();
            btnUndo.Text = "撤销";
            btnUndo.MouseClick += BtnUndo_MouseClick;
            btnUndo.Location = new Point(0, 15);
            panelMenu.Controls.Add(btnUndo);

            //生成保存牌局按钮
            Button btnSaveGame = new Button();
            btnSaveGame.Text = "保存牌局";
            btnSaveGame.MouseClick += btnSaveGame_MouseClick;
            btnSaveGame.Location = new Point(100, 15);
            panelMenu.Controls.Add(btnSaveGame);

            //生成计时器
            labelTime = new Label();
            labelTime.Text = timer_minute.ToString() + ":";
            labelTime.Text += timer_second > 9 ? timer_second.ToString() : "0" + timer_second.ToString();
            labelTime.Location = new Point(200, 25);
            labelTime.BackColor = System.Drawing.Color.Transparent;
            panelMenu.Controls.Add(labelTime);

            wf = new WatchForm(stackMiddleCard, stackRandomCard, stackRandomShowCard, stackFinishedCard,step);
            wf.Show();
        }



        /// <summary>
        /// 解决卡顿
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014)//禁止清除背景消息
                return;
            base.WndProc(ref m);
        }

        private void InitVariable()
        {
            listCard = new Card[52];

            panelMiddleCard = new Panel[7];
            stackMiddleCard = new SolitaireStack<Card>[7];
            LoadMiddleCard();

            for (int i = 0; i < 7; i++)
                stackMiddleCard[i] = new SolitaireStack<Card>("M" + (i + 1).ToString(), panelMiddleCard[i]);

            panelFinishedCard = new Panel[4];
            LoadTopCard();

            stackFinishedCard = new SolitaireStack<Card>[4];
            for (int i = 0; i < 4; i++)
                stackFinishedCard[i] = new SolitaireStack<Card>("F" + (i + 1).ToString(), panelFinishedCard[i]);

            stackRandomCard = new SolitaireStack<Card>("Random", panelRandomCard);
            stackRandomShowCard = new SolitaireStack<Card>("RandomShow", panelOpenRandomCard);

            step = new Stack<PlayerStep>();

            timer_minute = 0;
            timer_second = 0;
            isTimerOn = false;

        }

        private void InitGame()
        {
            listCard = SolitrireRule.GenerateCard(listCard, Mouse_Up_Card);

            //listCard = SolitrireRule.RandomShuffle(listCard);
            listCard = SolitrireUtil.ReadXml(Mouse_Up_Card);

            InitCardLocation();
        }

        /// <summary>
        /// 发牌
        /// </summary>
        private void InitCardLocation() 
        {
            int i = 0;
            for(int num = 1; num <= 7; num++)
            {
                for(int count = 1; count <= num; count++)
                {
                    stackMiddleCard[num - 1].Push(listCard[i]);
                    listCard[i].Location = LocatePoint(panelMiddleCard[num - 1], stackMiddleCard[num - 1]);
                    listCard[i].CurContainer = stackMiddleCard[num - 1];
                    if (count == num)
                        listCard[i].IsShow = true;
                    i++;
                }
            }

            //放入一张随机牌堆重置的牌
            Card resetCard = new Card(Suit.Reset, Number.Reset);
            resetCard.Location = LocatePoint(panelRandomCard);
            resetCard.CurContainer = stackRandomCard;
            stackRandomCard.Push(resetCard);
            resetCard.MouseClick += RandomCard_MouseClick;
            resetCard.SendToBack();

            for (int j = 51 ; j >= i; j--)
            {
                stackRandomCard.Push(listCard[j]);
                listCard[j].Location = LocatePoint(panelRandomCard);
                listCard[j].CurContainer = stackRandomCard;
            }
            for (int j = 27; j >= 0; j--)
                Controls.Add(listCard[j]);
            for (int j = 28; j < 52; j++)
                Controls.Add(listCard[j]);
            Controls.Add(resetCard);
            //return resetCard;
        }

        /// <summary>
        /// 将中间区域的容器加载进一个数组中
        /// </summary>
        private void LoadMiddleCard()
        {
            panelMiddleCard[0] = panelMiddleCard1;
            panelMiddleCard[1] = panelMiddleCard2;
            panelMiddleCard[2] = panelMiddleCard3;
            panelMiddleCard[3] = panelMiddleCard4;
            panelMiddleCard[4] = panelMiddleCard5;
            panelMiddleCard[5] = panelMiddleCard6;
            panelMiddleCard[6] = panelMiddleCard7;
        }

        /// <summary>
        /// 将完成卡牌的容器加载进一个数组中
        /// </summary>
        private void LoadTopCard()
        {
            panelFinishedCard[0] = panelFinishedCardSpade;
            panelFinishedCard[1] = panelFinishedCardHeart;
            panelFinishedCard[2] = panelFinishedCardClub;
            panelFinishedCard[3] = panelFinishedCardDiamond;
        }

        /// <summary>
        /// 定位panel的位置
        /// </summary>
        /// <param name="panel">需要放入的panel的位置</param>
        /// <returns></returns>
        private Point LocatePoint(Panel panel)
        {
            return new Point(panel.Location.X, panel.Location.Y + panelMenu.Height);
        }

        /// <summary>
        /// 定位panel的位置
        /// </summary>
        /// <param name="panel">需要放入的panel的位置</param>
        /// <param name="stack">卡牌的所属栈</param>
        /// <returns></returns>
        private Point LocatePoint(Panel panel, Stack<Card> stack)
        {
            return new Point(panel.Location.X, panel.Location.Y + panelMenu.Height + stack.Count * betweenLength);
        }

        /// <summary>
        /// 卡牌的MouseUp事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Up_Card(object sender, MouseEventArgs e)
        {
            if (sender == null)
                return;
            if (!isTimerOn)
            {
                //timer.Enabled = true;
                isTimerOn = true;
                timer.Start();
            }
            //获取卡牌节点
            while (sender != null && !(sender is Card))
            {
                sender = (sender as Control).Parent;
            }
            Card c = sender as Card;
            //如果是在随机牌堆上，则展示牌
            if (e.Button == MouseButtons.Left && c.CurContainer == stackRandomCard)
            {
                if(switchNumber == SwitchNumber.One)
                {
                    //翻一张
                    c.CurContainer.Pop();
                    c.CurContainer = stackRandomShowCard;
                    stackRandomShowCard.Push(c);
                    c.Location = LocatePoint(panelOpenRandomCard);
                    c.BringToFront();

                    PlayerStep ps = new PlayerStep(c, null, stackRandomCard, stackRandomShowCard, false);
                    step.Push(ps);

                    WatchFormLoad();
                    return;
                }
                else
                {
                    //翻三张
                    if(stackRandomShowCard.Count > 0)
                    {
                        Card[] ts = stackRandomShowCard.ToArray();
                        ts[1].BringToFront();
                        ts[1].Location = LocatePoint(panelOpenRandomCard);
                        ts[0].BringToFront();
                        ts[0].Location = LocatePoint(panelOpenRandomCard);
                    }

                    Card[] t = new Card[3];
                    t[0] = c.CurContainer.Pop();
                    t[1] = c.CurContainer.Pop();
                    t[2] = c.CurContainer.Pop();
                    for(int i = 0; i < 3; i++)
                    {
                        t[i].IsShow = true;
                        t[i].CurContainer = stackRandomShowCard;
                        stackRandomShowCard.Push(t[i]);
                        t[i].Location = LocatePoint(panelOpenRandomCard);
                        t[i].Location = new Point(t[i].Location.X + leftLength * i, t[i].Location.Y);
                        t[i].BringToFront();
                    }

                    PlayerStep ps = new PlayerStep(null, t.ToList(), stackRandomCard, stackRandomShowCard, false);
                    step.Push(ps);

                    WatchFormLoad();
                    return;
                }
            }
            #region 右键事件
            if (e.Button == MouseButtons.Right && c.IsShow && c.CurContainer.Peek() == c)
            {
                //判断是否可以移动到完成牌堆
                if(SolitrireRule.IsCanMove2Finished(c, stackFinishedCard))
                {
                    bool isShowNext = false;
                    int si = SolitrireRule.Move2FinishedIndex(c);
                    SolitaireStack<Card> ts = c.CurContainer;

                    MoveFinishedCard(c, si, out isShowNext);

                    if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                        PushLeft();

                    PlayerStep ps = new PlayerStep(c, null, ts, stackFinishedCard[si], isShowNext);
                    step.Push(ps);

                    isWinGame();

                }
                WatchFormLoad();
                return;
            }
            #endregion

            #region 判断移动完的卡牌后的位置
            #region 中间区域牌堆
            for (int i = 0; i < panelMiddleCard.Length; i++)
            {
                //不与自身的栈作比较
                if(c.CurContainer == stackMiddleCard[i])
                {
                    continue;
                }
                //判断与那个Panel相交
                bool isIntersected = SolitrireUtil.IsIntersected(c, panelMiddleCard[i]);
                if (isIntersected && stackMiddleCard[i].Count > 0)
                {
                    //判断是否跟这个Panel的最前端的牌相交
                    isIntersected = SolitrireUtil.IsIntersected(c, stackMiddleCard[i].Peek());
                    //若相交，则移动牌（组）
                    if (isIntersected && SolitrireRule.IsCanMove2Middle(c,stackMiddleCard[i]))
                    {
                        List<Card> t = new List<Card>();
                        for(int ii = c.cardList.Count - 1; ii >= 0; ii--)
                            t.Add(c.cardList[ii]);
                        bool isShowNext = false;
                        SolitaireStack<Card> ts = c.CurContainer;

                        MoveCard(c.cardList, i, out isShowNext);

                        if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                            PushLeft();

                        PlayerStep ps = new PlayerStep(null, t, ts, stackMiddleCard[i], isShowNext);
                        step.Push(ps);

                        c.cardList.Clear();
                        WatchFormLoad();
                        return;
                    }
                }
                //若与Panel相交且该Panel没有牌，则判断是否为K
                else if (e.Button != MouseButtons.Right && isIntersected && stackMiddleCard[i].Count == 0)
                {
                    //若是K，则可以移动
                    if(SolitrireRule.IsCanMove2Middle(c,stackMiddleCard[i]))
                    {
                        List<Card> t = new List<Card>();
                        for (int ii = c.cardList.Count - 1; ii >= 0; ii--)
                            t.Add(c.cardList[ii]);

                        bool isShowNext = false;
                        SolitaireStack<Card> ts = c.CurContainer;

                        MoveCard(c.cardList, i, out isShowNext);

                        if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                            PushLeft();

                        PlayerStep ps = new PlayerStep(null, t, ts, stackMiddleCard[i], isShowNext);
                        step.Push(ps);
                        c.cardList.Clear();
                        WatchFormLoad();
                        return;
                    }
                }
            }
            #endregion

            #region 完成区域牌堆
            for (int i = 0; i < panelFinishedCard.Length; i++)
            {
                //不允许多张牌移动
                if(c.cardList.Count > 1)
                {
                    break;
                }
                //不与自身的栈作比较
                if (c.CurContainer == stackFinishedCard[i])
                {
                    continue;
                }
                //如果完成牌堆不为空
                if (stackFinishedCard[i].Count > 0) 
                {
                    //判断移动的卡牌是否与该牌堆相交
                    bool isIntersected = SolitrireUtil.IsIntersected(c, stackFinishedCard[i].Peek());
                    //如果相交，则移动卡牌
                    if (isIntersected)
                    {
                        if (i == 0 && c.CardSuit == Suit.Spade)
                        {
                            bool isShowNext = false;
                            SolitaireStack<Card> ts = c.CurContainer;

                            MoveFinishedCard(c, i, out isShowNext);

                            if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                                PushLeft();

                            PlayerStep ps = new PlayerStep(c, null, ts, stackFinishedCard[i], isShowNext);
                            step.Push(ps);

                            isWinGame();

                            WatchFormLoad();
                            return;
                        }
                        else if (i == 1 && c.CardSuit == Suit.Heart)
                        {
                            bool isShowNext = false;
                            SolitaireStack<Card> ts = c.CurContainer;

                            MoveFinishedCard(c, i, out isShowNext);

                            if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                                PushLeft();

                            PlayerStep ps = new PlayerStep(c, null, ts, stackFinishedCard[i], isShowNext);
                            step.Push(ps);

                            isWinGame();


                            WatchFormLoad();
                            return;
                        }
                        else if (i == 2 && c.CardSuit == Suit.Club)
                        {
                            bool isShowNext = false;
                            SolitaireStack<Card> ts = c.CurContainer;

                            MoveFinishedCard(c, i, out isShowNext);

                            if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                                PushLeft();

                            PlayerStep ps = new PlayerStep(c, null, ts, stackFinishedCard[i], isShowNext);
                            step.Push(ps);

                            isWinGame();

                            WatchFormLoad();
                            return;
                        }
                        else if (i == 3 && c.CardSuit == Suit.Diamond)
                        {
                            bool isShowNext = false;
                            SolitaireStack<Card> ts = c.CurContainer;

                            MoveFinishedCard(c, i, out isShowNext);

                            if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                                PushLeft();

                            PlayerStep ps = new PlayerStep(c, null, ts, stackFinishedCard[i], isShowNext);
                            step.Push(ps);

                            isWinGame();


                            WatchFormLoad();
                            return;
                        }
                    }
                }
                //如果完成牌堆是空的
                else
                {
                    //判断是否与牌堆相交
                    bool isIntersected = SolitrireUtil.IsIntersected(c, panelFinishedCard[i]);
                    //如果相交，且点数为A，则可以移动
                    if (isIntersected)
                    {
                        if (i == 0 && c.CardSuit == Suit.Spade && c.CardNumber == Number.Ace)
                        {
                            bool isShowNext = false;
                            SolitaireStack<Card> ts = c.CurContainer;

                            MoveFinishedCard(c, i, out isShowNext);

                            if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                                PushLeft();

                            PlayerStep ps = new PlayerStep(c, null, ts, stackFinishedCard[i], isShowNext);
                            step.Push(ps);

                            WatchFormLoad();
                            return;
                        }
                        else if (i == 1 && c.CardSuit == Suit.Heart && c.CardNumber == Number.Ace)
                        {
                            bool isShowNext = false;
                            SolitaireStack<Card> ts = c.CurContainer;

                            MoveFinishedCard(c, i, out isShowNext);

                            if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                                PushLeft();

                            PlayerStep ps = new PlayerStep(c, null, ts, stackFinishedCard[i], isShowNext);
                            step.Push(ps);

                            WatchFormLoad();
                            return;
                        }
                        else if (i == 2 && c.CardSuit == Suit.Club && c.CardNumber == Number.Ace)
                        {
                            bool isShowNext = false;
                            SolitaireStack<Card> ts = c.CurContainer;

                            MoveFinishedCard(c, i, out isShowNext);

                            if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                                PushLeft();

                            PlayerStep ps = new PlayerStep(c, null, ts, stackFinishedCard[i], isShowNext);
                            step.Push(ps);

                            WatchFormLoad();
                            return;
                        }
                        else if (i == 3 && c.CardSuit == Suit.Diamond && c.CardNumber == Number.Ace)
                        {
                            bool isShowNext = false;
                            SolitaireStack<Card> ts = c.CurContainer;

                            MoveFinishedCard(c, i, out isShowNext);

                            if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                                PushLeft();

                            PlayerStep ps = new PlayerStep(c, null, ts, stackFinishedCard[i], isShowNext);
                            step.Push(ps);

                            WatchFormLoad();
                            return;
                        }
                    }
                }
            }
            #endregion
            //若都不相交，则返回原来位置
            foreach (Card cc in c.cardList)
                cc.Location = cc.LastLocation;
            c.cardList.Clear();
            #endregion
        }

        /// <summary>
        /// 随机牌堆重新堆放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomCard_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;
            if (!isTimerOn)
            {
                //timer.Enabled = true;
                isTimerOn = true;
                timer.Start();
            }
            if (stackRandomShowCard.Count <= 0)
                return;
            if(e.Button == MouseButtons.Left)
            {
                List<Card> li = stackRandomShowCard.ToList();

                while (stackRandomShowCard.Count > 0)
                {
                    Card card = stackRandomShowCard.Pop();
                    stackRandomCard.Push(card);
                    card.CurContainer = stackRandomCard;
                    card.Location = LocatePoint(panelRandomCard);
                    card.IsShow = false;
                    card.BringToFront();
                }
                PlayerStep ps = new PlayerStep(null, li, stackRandomShowCard, stackRandomCard, false);
                step.Push(ps);
                
                WatchFormLoad();
            }
        }

        /// <summary>
        /// 移动卡牌函数
        /// </summary>
        /// <param name="c">需要移动的卡牌</param>
        /// <param name="stackIndex">移动到栈的索引</param>
        private void MoveCard(List<Card> card, int stackIndex, out bool isShowNext)
        {
            isShowNext = false;
            card.Reverse();
            foreach (Card c in card)
            {
                c.CurContainer.Pop();
                stackMiddleCard[stackIndex].Push(c);
                c.Location = LocatePoint(panelMiddleCard[stackIndex], stackMiddleCard[stackIndex]);
                isShowNext = c.CurContainer.Count > 0 ? !c.CurContainer.Peek().IsShow : false;
                if (c.CurContainer.Count > 0)
                    c.CurContainer.Peek().IsShow = true;
                c.CurContainer = stackMiddleCard[stackIndex];
                c.LastLocation = c.Location;
            }
        }

        /// <summary>
        /// 移动完成卡牌
        /// </summary>
        /// <param name="card">需要移动的卡牌</param>
        /// <param name="index">移动到栈的索引</param>
        private void MoveFinishedCard(Card card, int index, out bool isShowNext)
        {
            card.CurContainer.Pop();
            stackFinishedCard[index].Push(card);
            card.Location = LocatePoint(panelFinishedCard[index]);

            isShowNext = card.CurContainer.Count > 0 ? !card.CurContainer.Peek().IsShow : false;

            if (card.CurContainer.Count > 0)
                card.CurContainer.Peek().IsShow = true;
            card.BringToFront();
            card.CurContainer = stackFinishedCard[index];
            card.LastLocation = card.Location;
        }

        /// <summary>
        /// 更新watchform
        /// </summary>
        private void WatchFormLoad()
        {
            wf.stackMiddleCard = new Stack<Card>[7];
            for(int i = 0; i < 7; i++)
            {
                wf.stackMiddleCard[i] = new Stack<Card>(stackMiddleCard[i].ToArray());
            }
            wf.stackFinishedCard = new Stack<Card>[4];
            for(int i = 0; i < 4; i++)
            {
                wf.stackFinishedCard[i] = new Stack<Card>(stackFinishedCard[i].ToArray());
            }
            wf.stackRandomCard = new Stack<Card>(stackRandomCard.ToArray());
            wf.stackRandomShowCard = new Stack<Card>(stackRandomShowCard.ToArray());
            wf.stackPlayerStep = new Stack<PlayerStep>(step.ToArray());
            wf.LoadForm();
        }

        private void BtnUndo_MouseClick(object sender, MouseEventArgs e)
        {
            if (step.Count == 0)
                return;
            PlayerStep ps = step.Pop();
            if (ps.DestinationStack.ToString() == "RandomShow")
            {
                if (ps.DragCard != null)
                {
                    ps.DragCard.CurContainer.Pop();
                    ps.DragCard.CurContainer = stackRandomCard;
                    stackRandomCard.Push(ps.DragCard);
                    ps.DragCard.Location = LocatePoint(panelRandomCard);
                    ps.DragCard.IsShow = false;
                    ps.DragCard.BringToFront();
                }
                else
                {
                    for(int i = ps.DragCards.Count - 1; i >= 0 ; i--)
                    {
                        Card c = ps.DragCards[i];
                        c.CurContainer.Pop();
                        ps.DragCardStack.Push(c);
                        c.CurContainer = ps.DragCardStack;
                        c.Location = LocatePoint(panelRandomCard);
                        c.IsShow = false;
                        c.BringToFront();
                    }
                    if (ps.DestinationStack.Count > 0)
                    {
                        Card[] t = ps.DestinationStack.ToArray();
                        t[0].Location = new Point(t[0].Location.X + 24 * 2, t[0].Location.Y);
                        t[1].Location = new Point(t[1].Location.X + 24, t[1].Location.Y);
                    }
                }
            }
            else if(ps.DestinationStack.ToString() == "Random")
            {
                if(ps.DragCards != null)
                {
                    ps.DragCards.Reverse();
                    for (int i = 0; i < ps.DragCards.Count; i++)
                    {
                        Card c = ps.DragCards[i];
                        c.CurContainer.Pop();
                        ps.DragCardStack.Push(c);
                        c.CurContainer = ps.DragCardStack;
                        c.Location = LocatePoint(ps.DragCardStack.FormPanel);
                        c.IsShow = true;
                        c.BringToFront();
                    }
                    if(switchNumber == SwitchNumber.Three)
                    {
                        ps.DragCards[ps.DragCards.Count - 1].Location = 
                            new Point(ps.DragCards[ps.DragCards.Count - 1].Location.X + 2 * leftLength, 
                            ps.DragCards[ps.DragCards.Count - 1].Location.Y);
                        ps.DragCards[ps.DragCards.Count - 2].Location =
                            new Point(ps.DragCards[ps.DragCards.Count - 2].Location.X + leftLength,
                            ps.DragCards[ps.DragCards.Count - 2].Location.Y);
                    }
                    
                }
            }
            else if (ps.DestinationStack.ToString()[0] == 'F')
            {
                if (ps.DragCard != null)
                {
                    if (ps.IsShowNext)
                    {
                        ps.DragCardStack.Peek().IsShow = false;
                    }
                    ps.DragCard.CurContainer.Pop();
                    ps.DragCard.CurContainer = ps.DragCardStack;
                    ps.DragCardStack.Push(ps.DragCard);
                    if(ps.DragCardStack.ToString() == "RandomShow")
                    {
                        if(switchNumber == SwitchNumber.One)
                            ps.DragCard.Location = LocatePoint(panelOpenRandomCard);
                        else
                        {
                            if(ps.DragCardStack.Count > 3)
                            {
                                Card[] t = ps.DragCardStack.ToArray();
                                t[2].Location = new Point(t[2].Location.X - leftLength, t[2].Location.Y);
                                t[1].Location = new Point(t[1].Location.X - leftLength, t[1].Location.Y);
                                ps.DragCard.Location = LocatePoint(panelOpenRandomCard);
                                ps.DragCard.Location = new Point(ps.DragCard.Location.X + 2 * leftLength, ps.DragCard.Location.Y);
                            }
                            else if(ps.DragCardStack.Count == 3)
                            {
                                ps.DragCard.Location = LocatePoint(panelOpenRandomCard);
                                ps.DragCard.Location = new Point(ps.DragCard.Location.X + 2 * leftLength, ps.DragCard.Location.Y);
                            }
                            else if (ps.DragCardStack.Count == 2)
                            {
                                ps.DragCard.Location = LocatePoint(panelOpenRandomCard);
                                ps.DragCard.Location = new Point(ps.DragCard.Location.X + leftLength, ps.DragCard.Location.Y);
                            }
                            else
                            {
                                ps.DragCard.Location = LocatePoint(panelOpenRandomCard);
                            }
                        }
                    }
                    else
                    {
                        ps.DragCard.Location = LocatePoint(ps.DragCardStack.FormPanel,ps.DragCardStack);
                    }
                    ps.DragCard.BringToFront();
                }
            }
            else if(ps.DestinationStack.ToString()[0] == 'M')
            {
                if(ps.DragCards != null)
                {
                    if (ps.IsShowNext)
                    {
                        ps.DragCardStack.Peek().IsShow = false;
                    }
                    //ps.DragCards.Reverse();
                    for(int i = 0; i < ps.DragCards.Count; i++)
                    {
                        Card c = ps.DragCards[i];
                        c.CurContainer.Pop();
                        ps.DragCardStack.Push(c);
                        c.CurContainer = ps.DragCardStack;
                        if(ps.DragCardStack.ToString()[0] == 'F' )
                        {
                            c.Location = LocatePoint(ps.DragCardStack.FormPanel);
                        }
                        else if(ps.DragCardStack.ToString() == "RandomShow")
                        {
                            if (switchNumber == SwitchNumber.One)
                                c.Location = LocatePoint(panelOpenRandomCard);
                            else
                            {
                                if (ps.DragCardStack.Count > 3)
                                {
                                    Card[] t = ps.DragCardStack.ToArray();
                                    t[2].Location = new Point(t[2].Location.X - leftLength, t[2].Location.Y);
                                    t[1].Location = new Point(t[1].Location.X - leftLength, t[1].Location.Y);
                                    c.Location = LocatePoint(panelOpenRandomCard);
                                    c.Location = new Point(c.Location.X + 2 * leftLength, c.Location.Y);
                                }
                                else if (ps.DragCardStack.Count == 3)
                                {
                                    c.Location = LocatePoint(panelOpenRandomCard);
                                    c.Location = new Point(c.Location.X + 2 * leftLength, c.Location.Y);
                                }
                                else if (ps.DragCardStack.Count == 2)
                                {
                                    c.Location = LocatePoint(panelOpenRandomCard);
                                    c.Location = new Point(c.Location.X + leftLength, c.Location.Y);
                                }
                                else
                                {
                                    c.Location = LocatePoint(panelOpenRandomCard);
                                }
                            }
                        }
                        else
                        {
                            c.Location = LocatePoint(ps.DragCardStack.FormPanel, ps.DragCardStack);
                        }
                        c.IsShow = true;
                        c.BringToFront();
                    }
                }
            }
            WatchFormLoad();
        }

        private void btnSaveGame_MouseClick(object sender, MouseEventArgs e)
        {
            SolitrireUtil.SaveGameXML(listCard);
            MessageBox.Show("save successfully");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimerSecond++;
            if(TimerSecond >= 60)
            {
                TimerSecond = TimerSecond % 60;
                TimerMinute++;
            }
            //labelTime.Text = timer_minute.ToString() + ":";
            //labelTime.Text += timer_sencond > 9 ? timer_sencond.ToString() : "0" + timer_sencond.ToString();
        }

        private void isWinGame()
        {
            if (SolitrireRule.IsWin(stackFinishedCard))
            {
                //timer.Enabled = false;
                timer.Stop();
                VictoryForm vf = new VictoryForm(difficult, labelTime.Text);

                DialogResult re = vf.ShowDialog();
                if (re == DialogResult.Cancel)
                    Close();
                else if(re == DialogResult.OK)
                {
                    ClearGame();
                    InitGame();
                }
                WatchFormLoad();
            }
        }
        
        private void ClearGame()
        {
            for (int i = 0; i < listCard.Length; i++)
                listCard[i].Dispose();
            stackRandomCard.Pop().Dispose();
            for (int i = 0; i < 4; i++)
                stackFinishedCard[i].Clear();
            for(int i = 0; i < 7; i++)
                stackMiddleCard[i].Clear();
            stackRandomCard.Clear();
            stackRandomShowCard.Clear();
            TimerMinute = 0;
            TimerSecond = 0;
            isTimerOn = false;
        }

        private void Solitrire_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            wf.Close();
        }

        private void PushLeft()
        {
            Card[] tt = stackRandomShowCard.ToArray();
            tt[0].Location = new Point(tt[0].Location.X + leftLength, tt[0].Location.Y);
            tt[1].Location = new Point(tt[1].Location.X + leftLength, tt[1].Location.Y);
        }
    }
}

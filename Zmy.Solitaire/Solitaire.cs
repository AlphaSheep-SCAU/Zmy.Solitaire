using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        #region 字段和属性
        public Card[] listCard;
        private Panel[] panelMiddleCard;
        private Panel[] panelFinishedCard;
        private SolitaireStack<Card>[] stackMiddleCard;
        private SolitaireStack<Card>[] stackFinishedCard;
        private SolitaireStack<Card> stackRandomCard;
        private SolitaireStack<Card> stackRandomShowCard;
        private List<SolitaireTips> listTips;
        private SolitaireTips curTips;
        private int tipIndex;
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
        private bool hasChangeColor;
        private bool hasChangeRandomColor;
        private PictureBox picureBoxTips;
        private Difficulty difficult;
        private SwitchNumber switchNumber;
        private string strSrc;
        private string name;
        private Button btnUndo;
        private Button btnSaveGame;
        private Button btnRemake;
        private Button btnTips;
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public Solitaire()
        {
            betweenLength = 24;
            leftLength = 24;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);//禁止擦除背景
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="switchNumber"></param>
        /// <param name="difficult"></param>
        public Solitaire(SwitchNumber switchNumber, Difficulty difficult)
        {
            this.switchNumber = switchNumber;
            this.difficult = difficult;
            betweenLength = 35;
            leftLength = 24;
            tipIndex = 0;
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

            SolitaireUtil.HideOrShowAllPanel(this, true);

            InitSolitaireLayout();

            wf = new WatchForm(stackMiddleCard, stackRandomCard, stackRandomShowCard, stackFinishedCard,step);
            wf.Show();

            FindTips();
        }

        /// <summary>
        /// 重开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemake_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("确定要重开游戏吗？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearGame();
                name = DateTime.Now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "");
                SolitaireUtil.SaveGameXML(listCard, name);
                string str = @"../../save/" + name + ".xml";
                listCard = SolitaireUtil.ReadXml(str, Mouse_Up_Card);
                InitCardLocation();
                File.Delete(str);
            }
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

        /// <summary>
        /// 解决卡顿
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014)//禁止清除背景消息
                return;
            base.WndProc(ref m);
        }

        /// <summary>
        /// 初始化变量
        /// </summary>
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

            listTips = new List<SolitaireTips>();

            picureBoxTips = new PictureBox();
            picureBoxTips.SizeMode = PictureBoxSizeMode.StretchImage;
            picureBoxTips.Height = 150;
            picureBoxTips.Width = 110;
            picureBoxTips.BackColor = System.Drawing.Color.Transparent;
            picureBoxTips.Image = Properties.Resources.finish_card;

            step = new Stack<PlayerStep>();

            strSrc = "";

            curTips = null;
            hasChangeColor = false;
            hasChangeRandomColor = false;

            timer_minute = 0;
            timer_second = 0;
            isTimerOn = false;

        }

        /// <summary>
        /// 初始化布局
        /// </summary>
        private void InitSolitaireLayout()
        {
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

            //放入一张随机牌堆重置牌
            Card resetCard = new Card(Suit.Reset, Number.Reset);
            resetCard.Location = LocatePoint(panelRandomCard);
            resetCard.MouseClick += RandomCard_MouseClick;
            Controls.Add(resetCard);
            resetCard.SendToBack();

            //生成撤销按钮
            btnUndo = new Button();
            btnUndo.Text = "撤销";
            btnUndo.MouseClick += BtnUndo_MouseClick;
            panelMenu.Controls.Add(btnUndo);

            //生成保存牌局按钮
            btnSaveGame = new Button();
            btnSaveGame.Text = "保存牌局";
            btnSaveGame.MouseClick += btnSaveGame_MouseClick;
            panelMenu.Controls.Add(btnSaveGame);

            //生成重新开始按钮
            btnRemake = new Button();
            btnRemake.Text = "重新开始";
            btnRemake.MouseClick += BtnRemake_MouseClick;
            panelMenu.Controls.Add(btnRemake);

            //生成提示按钮
            btnTips = new Button();
            btnTips.Text = "提示";
            btnTips.MouseClick += BtnTips_MouseClick;
            panelMenu.Controls.Add(btnTips);

            initButtonLayout(btnTips);
            initButtonLayout(btnRemake);
            initButtonLayout(btnSaveGame);
            initButtonLayout(btnUndo);

            Label labelTextd = new Label();
            labelTextd.Text = "难度 ";
            labelTextd.BackColor = System.Drawing.Color.Transparent;
            labelTextd.Dock = DockStyle.Right;
            labelTextd.TextAlign = ContentAlignment.MiddleRight;
            panelMenu.Controls.Add(labelTextd);

            Label labelDifficult = new Label();
            labelDifficult.Text = 
                difficult == Difficulty.Difficult ? "困难" :
                difficult == Difficulty.Medium ? "中等" :
                difficult == Difficulty.Easy ? "简单" : "随机";
            labelDifficult.Dock = DockStyle.Right;
            labelDifficult.BackColor = System.Drawing.Color.Transparent;
            labelDifficult.TextAlign = ContentAlignment.MiddleLeft;
            panelMenu.Controls.Add(labelDifficult);

            Label labelText = new Label();
            labelText.Text = "时间 ";
            labelText.BackColor = System.Drawing.Color.Transparent;
            labelText.Dock = DockStyle.Right;
            labelText.TextAlign = ContentAlignment.MiddleRight;
            panelMenu.Controls.Add(labelText);

            //生成计时器
            labelTime = new Label();
            labelTime.Text = timer_minute.ToString() + ":";
            labelTime.Text += timer_second > 9 ? timer_second.ToString() : "0" + timer_second.ToString();
            //labelTime.Location = new Point(400, SolitaireUtil.VerticalCenter(labelTime, panelMenu).Y);
            labelTime.Dock = DockStyle.Right;
            labelTime.BackColor = System.Drawing.Color.Transparent;
            labelTime.TextAlign = ContentAlignment.MiddleLeft;
            panelMenu.Controls.Add(labelTime);
        }

        /// <summary>
        /// 初始化按钮布局
        /// </summary>
        /// <param name="btn"></param>
        private void initButtonLayout(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            btn.ForeColor = System.Drawing.Color.White;
            btn.Dock = DockStyle.Left;
            btn.MouseDown += Btn_MouseDown;
            btn.MouseUp += Btn_MouseUp;
        }

        /// <summary>
        /// 按钮的mouseup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseUp(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = System.Drawing.Color.White;
        }

        /// <summary>
        /// 按钮的mousedown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseDown(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = System.Drawing.Color.Black;
        }

        /// <summary>
        /// 初始化游戏参数
        /// </summary>
        private void InitGame()
        {
            listCard = SolitaireRule.GenerateCard(listCard, Mouse_Up_Card);

            SetDifficulty();
            //listCard = SolitaireUtil.ReadXml(@"../../testshuffle/test.xml", Mouse_Up_Card);
            InitCardLocation();
        }

        /// <summary>
        /// 设置难度
        /// </summary>
        private void SetDifficulty()
        {
            if(difficult == Difficulty.Random)
            {
                listCard = SolitaireRule.RandomShuffle(listCard);
                return;
            }
            strSrc = @"../../difficulty/";
            strSrc += switchNumber == SwitchNumber.One ? @"switchone/" : "switchthree/";
            strSrc += difficult == Difficulty.Easy ? @"easy/" : difficult == Difficulty.Medium ? @"medium/" : @"difficult/";
            Random r = new Random();
            strSrc += r.Next(1, 6).ToString();
            strSrc += @".xml";
            listCard = SolitaireUtil.ReadXml(strSrc, Mouse_Up_Card);
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
            for (int j = 51 ; j >= i; j--)
            {
                stackRandomCard.Push(listCard[j]);
                listCard[j].Location = LocatePoint(panelRandomCard);
                listCard[j].CurContainer = stackRandomCard;
            }
            for (int j = 27; j >= 0; j--)
                Controls.Add(listCard[j]);
            for (int j = 51; j >=28 ; j--)
            {
                Controls.Add(listCard[j]);
                listCard[j].BringToFront();
            }
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
            //return new Point(panel.Location.X, panel.Location.Y);

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
            if (hasChangeColor)
            {
                ChangeBorderColor();
                hasChangeColor = false;
            }
            Card c = sender as Card;
            //如果是在随机牌堆上，则展示牌
            if (e.Button == MouseButtons.Left && c.CurContainer == stackRandomCard)
            {
                if (hasChangeRandomColor)
                {
                    stackRandomCard.Peek().ChangeBorderColor();
                    hasChangeRandomColor = false;
                }
                if (switchNumber == SwitchNumber.One)
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
                    FindTips();
                    return;
                }
                else
                {
                    //翻三张
                    int len = c.CurContainer.Count >= 3 ? 3 : c.CurContainer.Count;
                    if (stackRandomShowCard.Count > 0)
                    {
                        Card[] ts = stackRandomShowCard.ToArray();
                        for (int i = 0; i < ts.Length; i++)
                        {
                            ts[i].BringToFront();
                            ts[i].Location = LocatePoint(panelOpenRandomCard);
                        }
                    }

                    List<Card> t = new List<Card>();
                    Stack<Card> tsa = c.CurContainer;
                    for(int i = 0; i < len; i++)
                    {
                        t.Add(tsa.Pop());
                        t[i].IsShow = true;
                        t[i].CurContainer = stackRandomShowCard;
                        stackRandomShowCard.Push(t[i]);
                        t[i].Location = LocatePoint(panelOpenRandomCard);
                        t[i].Location = new Point(t[i].Location.X + leftLength * i, t[i].Location.Y);
                        t[i].BringToFront();
                    }

                    PlayerStep ps = new PlayerStep(null, t, stackRandomCard, stackRandomShowCard, false);
                    step.Push(ps);

                    FindTips();
                    WatchFormLoad();
                    return;
                }
            }
            #region 右键事件
            if (e.Button == MouseButtons.Right && c.IsShow && c.CurContainer.Peek() == c)
            {
                //判断是否可以移动到完成牌堆
                if(SolitaireRule.IsCanMove2Finished(c, stackFinishedCard))
                {
                    bool isShowNext = false;
                    int si = SolitaireRule.Move2FinishedIndex(c);
                    SolitaireStack<Card> ts = c.CurContainer;

                    MoveFinishedCard(c, si, out isShowNext);

                    if (switchNumber == SwitchNumber.Three && ts == stackRandomShowCard && stackRandomShowCard.Count >= 3)
                        PushLeft();

                    PlayerStep ps = new PlayerStep(c, null, ts, stackFinishedCard[si], isShowNext);
                    step.Push(ps);

                    isWinGame();

                }
                FindTips();
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
                bool isIntersected = SolitaireUtil.IsIntersected(c, panelMiddleCard[i]);
                if (isIntersected && stackMiddleCard[i].Count > 0)
                {
                    //判断是否跟这个Panel的最前端的牌相交
                    isIntersected = SolitaireUtil.IsIntersected(c, stackMiddleCard[i].Peek());
                    //若相交，则移动牌（组）
                    if (isIntersected && SolitaireRule.IsCanMove2Middle(c,stackMiddleCard[i]))
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
                        FindTips();
                        WatchFormLoad();
                        return;
                    }
                }
                //若与Panel相交且该Panel没有牌，则判断是否为K
                else if (e.Button != MouseButtons.Right && isIntersected && stackMiddleCard[i].Count == 0)
                {
                    //若是K，则可以移动
                    if(SolitaireRule.IsCanMove2Middle(c,stackMiddleCard[i]))
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
                        FindTips();
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
                    bool isIntersected = SolitaireUtil.IsIntersected(c, stackFinishedCard[i].Peek());
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

                            FindTips();
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

                            FindTips();

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
                            FindTips();

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

                            FindTips();

                            WatchFormLoad();
                            return;
                        }
                    }
                }
                //如果完成牌堆是空的
                else
                {
                    //判断是否与牌堆相交
                    bool isIntersected = SolitaireUtil.IsIntersected(c, panelFinishedCard[i]);
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
                            FindTips();

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
                            FindTips();

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
                            FindTips();

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
                            FindTips();

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
            
            if (e.Button == MouseButtons.Left)
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
                FindTips();
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

        /// <summary>
        /// 撤销按钮点击方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUndo_MouseClick(object sender, MouseEventArgs e)
        {
            if (hasChangeColor)
            {
                ChangeBorderColor();
                hasChangeColor = false;
            }
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
                        //c.SendToBack();
                    }
                    if (ps.DestinationStack.Count > 0)
                    {
                        Card[] t = ps.DestinationStack.ToArray();
                        for(int i = 0; i < t.Length; i++)
                        {
                            int j = i == 0 ? 2 : i == 1 ? 1 : i == 2 ? 0 : 0;
                            t[i].Location = new Point(t[i].Location.X + leftLength * j, t[i].Location.Y);
                            t[i].SendToBack();
                        }
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
            FindTips();
        }

        /// <summary>
        /// 保存本牌局按钮点击方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveGame_MouseClick(object sender, MouseEventArgs e)
        {
            name = DateTime.Now.ToString().Replace("/", "").Replace(" ","").Replace(":","");
            SolitaireUtil.SaveGameXML(listCard, name);
            MessageBox.Show("save successfully");
        }

        /// <summary>
        /// 计时器方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 判断是否获胜并作获胜处理
        /// </summary>
        private void isWinGame()
        {
            if (SolitaireRule.IsWin(stackFinishedCard))
            {
                //timer.Enabled = false;
                timer.Stop();
                VictoryForm vf = new VictoryForm(difficult, switchNumber, labelTime.Text);

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
        
        /// <summary>
        /// 清除游戏参数
        /// </summary>
        private void ClearGame()
        {
            for (int i = 0; i < listCard.Length; i++)
                listCard[i].Dispose();
            for (int i = 0; i < 4; i++)
                stackFinishedCard[i].Clear();
            for(int i = 0; i < 7; i++)
                stackMiddleCard[i].Clear();
            stackRandomCard.Clear();
            stackRandomShowCard.Clear();
            TimerMinute = 0;
            TimerSecond = 0;
            isTimerOn = false;
            timer.Enabled = false;
        } 

        /// <summary>
        /// 获取提示
        /// </summary>
        private void FindTips()
        {
            tipIndex = 0;
            listTips.Clear();
            if (stackRandomShowCard.Count > 0)
            {
                //遍历随机牌看是否有可以上去完成牌堆
                Card c = stackRandomShowCard.Peek();
                if (SolitaireRule.IsCanMove2Finished(c, stackFinishedCard))
                {
                    int index = c.CardSuit == Suit.Spade ? 0 : c.CardSuit == Suit.Heart ? 1 : c.CardSuit == Suit.Club ? 2 : 3;
                    SolitaireTips st = new SolitaireTips(c, stackFinishedCard[index]);
                    listTips.Add(st);
                }
                for(int i = 0; i < 7; i++)
                {
                    if (SolitaireRule.IsCanMove2Middle(c, stackMiddleCard[i]))
                    {
                        SolitaireTips st = new SolitaireTips(c, stackMiddleCard[i]);
                        listTips.Add(st);
                    }
                }
            }
            for(int i = 0; i < 7; i++)
            {
                if(stackMiddleCard[i].Count > 0)
                {
                    List<Card> cardList = new List<Card>();
                    Card[] cardArray = stackMiddleCard[i].ToArray();
                    for (int j = 0; j < stackMiddleCard[i].Count; j++)
                    {
                        if (!cardArray[j].IsShow)
                        {
                            break;
                        }
                        cardList.Add(cardArray[j]);
                        if(j == 0)
                        {
                            //单张能否去完成牌堆
                            Card c = stackMiddleCard[i].Peek();
                            if (SolitaireRule.IsCanMove2Finished(c, stackFinishedCard))
                            {
                                int index = c.CardSuit == Suit.Spade ? 0 : c.CardSuit == Suit.Heart ? 1 : c.CardSuit == Suit.Club ? 2 : 3;
                                SolitaireTips st = new SolitaireTips(c, stackFinishedCard[index]);
                                listTips.Add(st);
                            }
                            //单张能否去其他中间牌堆
                            for(int k = 0; k < 7; k++)
                            {
                                if (SolitaireRule.IsCanMove2Middle(c, stackMiddleCard[k]))
                                {
                                    SolitaireTips st = new SolitaireTips(c, stackMiddleCard[k]);
                                    listTips.Add(st);
                                }
                            }
                            continue;
                        }
                        //多张
                        if (SolitaireRule.IsCanMoveMul(cardList))
                        {
                            Card c = cardList[cardList.Count - 1];
                            //多张能否去其他中间牌堆
                            for(int k = 0; k < 7; k++)
                            {
                                if (SolitaireRule.IsCanMove2Middle(c, stackMiddleCard[k]))
                                {
                                    SolitaireTips st = new SolitaireTips(cardList, stackMiddleCard[k]);
                                    listTips.Add(st);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 提示按钮点击方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTips_MouseClick(object sender, MouseEventArgs e)
        {
            //FindTips();
            if (hasChangeColor)
            {
                ChangeBorderColor();
                hasChangeColor = false;
            }
            if (hasChangeRandomColor)
            {
                if(stackRandomCard.Count > 0)
                    stackRandomCard.Peek().ChangeBorderColor();
                else
                    Controls.Remove(picureBoxTips);
                hasChangeRandomColor = false;
            }
            if (tipIndex == listTips.Count)
            {
                tipIndex = 0;// tipIndex % listTips.Count;
                if(stackRandomCard.Count > 0)
                {
                    stackRandomCard.Peek().ChangeBorderColor();
                }
                else
                {
                    picureBoxTips.Location = LocatePoint(panelRandomCard);
                    picureBoxTips.Location = new Point(picureBoxTips.Location.X - 5, picureBoxTips.Location.Y - 5);
                    Controls.Add(picureBoxTips);
                    picureBoxTips.SendToBack();
                }
                hasChangeRandomColor = true;
                return;
            }
            if (listTips.Count == 0)
            {
                if (!hasChangeRandomColor)
                {
                    stackRandomCard.Peek().ChangeBorderColor();
                    hasChangeRandomColor = true;
                }
                return;
            }

            curTips = listTips[tipIndex];

            ChangeBorderColor();

            tipIndex++;
            //tipIndex = (tipIndex + 1) % listTips.Count;
            
        }

        /// <summary>
        /// 改变卡牌边框,用于提示
        /// </summary>
        private void ChangeBorderColor()
        {
            if (curTips.ObjectCardArray != null)
            {
                for (int i = 0; i < curTips.ObjectCardArray.Count; i++)
                {
                    curTips.ObjectCardArray[i].ChangeBorderColor();
                }
            }
            else
            {
                curTips.SingleCard.ChangeBorderColor();
            }

            if (curTips.ObjectStack.Count <= 0)
            {
                if (hasChangeColor)
                {
                    Controls.Remove(picureBoxTips);
                    return;
                }
                string code = curTips.ObjectStack.Code;
                if (code[0] == 'F')
                {
                    picureBoxTips.Location = code[1] == '1' ? 
                        LocatePoint(panelFinishedCardSpade) : code[1] == '2' ? 
                        LocatePoint(panelFinishedCardHeart) : code[1] == '3' ? 
                        LocatePoint(panelFinishedCardClub) : LocatePoint(panelFinishedCardDiamond);
                    picureBoxTips.Location = new Point(picureBoxTips.Location.X - 5, picureBoxTips.Location.Y - 5);
                }
                else if (code[0] == 'M')
                {
                    picureBoxTips.Location = code[1] == '1' ?
                        LocatePoint(panelMiddleCard1, stackMiddleCard[0]) : code[1] == '2' ?
                        LocatePoint(panelMiddleCard2, stackMiddleCard[1]) : code[1] == '3' ?
                        LocatePoint(panelMiddleCard3, stackMiddleCard[2]) : code[1] == '4' ?
                        LocatePoint(panelMiddleCard4, stackMiddleCard[3]) : code[1] == '5' ?
                        LocatePoint(panelMiddleCard5, stackMiddleCard[4]) : code[1] == '6' ?
                        LocatePoint(panelMiddleCard6, stackMiddleCard[5]) : LocatePoint(panelMiddleCard7, stackMiddleCard[6]);
                    picureBoxTips.Location = new Point(picureBoxTips.Location.X, picureBoxTips.Location.Y + betweenLength);
                }
                Controls.Add(picureBoxTips);
                picureBoxTips.SendToBack();
            }
            else
                curTips.ObjectStack.Peek().ChangeBorderColor();
            hasChangeColor = true;
        }

        /// <summary>
        /// 翻三张算法
        /// </summary>
        private void PushLeft()
        {
            Card[] tt = stackRandomShowCard.ToArray();
            if (tt.Length <= 2)
                return;
            for (int i = 1; i >= 0; i--)
            {
                tt[i].Location = new Point(tt[i].Location.X + leftLength, tt[i].Location.Y);
                tt[i].BringToFront();
            }
        }

        /// <summary>
        /// 窗口关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Solitrire_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            wf.Close();
        }

    }
}

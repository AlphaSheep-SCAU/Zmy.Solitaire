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
    public partial class Salitrire : Form
    {
        public Card[] listCard;
        private Panel[] panelMiddleCard;
        private Panel[] panelFinishedCard;
        private Stack<Card>[] stackMiddleCard;
        private Stack<Card>[] stackFinishedCard;
        private Stack<Card> stackRandomCard;
        private Stack<Card> stackRandomShowCard;
        private WatchForm wf;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Salitrire()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载时函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Salitrire_Load(object sender, EventArgs e)
        {
            listCard = new Card[52];

            panelMiddleCard = new Panel[7];
            stackMiddleCard = new Stack<Card>[7];
            for (int i = 0; i < 7; i++)
            {
                stackMiddleCard[i] = new Stack<Card>();
            }

            panelFinishedCard = new Panel[4];
            stackFinishedCard = new Stack<Card>[4];
            for (int i = 0; i < 4; i++)
            {
                stackFinishedCard[i] = new Stack<Card>();
            }

            stackRandomCard = new Stack<Card>();
            stackRandomShowCard = new Stack<Card>();

            LoadMiddleCard();

            LoadTopCard();

            //GenerateCard();
            listCard = SalitrireRule.GenerateCard(Mouse_Up_Card);

            //Shuffle();
            listCard = SalitrireRule.RandomShuffle(listCard);

            Card resetCard = InitCardLocation();

            SalitrireUtil.HideOrShowAllPanel(this, true);

            for (int i = 27; i >= 0; i--)
            {
                Controls.Add(listCard[i]);
            }
            for (int i = 28; i < 52; i++)
            {
                Controls.Add(listCard[i]);
            }
            Controls.Add(resetCard);

            wf = new WatchForm(stackMiddleCard, stackRandomCard, stackRandomShowCard, stackFinishedCard);
            wf.Show();
        }

        /// <summary>
        /// 生成52张卡牌
        /// </summary>
        //private void GenerateCard()
        //{
        //    int i = 0;
        //    foreach(Suit s in Enum.GetValues(typeof(Suit)))
        //    {
        //        if (s == Suit.Reset)
        //            continue;
        //        foreach(Number n in Enum.GetValues(typeof(Number)))
        //        {
        //            if (n == Number.Reset)
        //                continue;
        //            Card tCard = new Card(s, n);
        //            tCard.MouseUp += Mouse_Up_Card;
        //            tCard.AddMouseUp(tCard, Mouse_Up_Card);
        //            listCard[i++] = tCard;
        //        }
        //    }
        //}

        /// <summary>
        /// 随机洗牌算法
        /// </summary>
        //private void Shuffle()
        //{
        //    Random r = new Random();
        //    for(int i = 0; i < 52 ; i++)
        //    {
        //        int randomNum = r.Next(0, 52);
        //        Card t = listCard[i];
        //        listCard[i] = listCard[randomNum];
        //        listCard[randomNum] = t;
        //    }
        //}

        /// <summary>
        /// 发牌
        /// </summary>
        private Card InitCardLocation()
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
            Card resetCard = new Card(Suit.Reset,Number.Reset);
            resetCard.Location = LocatePoint(panelRandomCard);
            resetCard.BackgroundImage = Properties.Resources.club_24px;
            resetCard.CurContainer = stackRandomCard;
            stackRandomCard.Push(resetCard);
            resetCard.MouseClick += RandomCard_MouseClick;
            for (int j = 51 ; j >= i; j--)
            {
                stackRandomCard.Push(listCard[j]);
                listCard[j].Location = LocatePoint(panelRandomCard);
                listCard[j].CurContainer = stackRandomCard;
            }
            return resetCard;
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
            return new Point(panel.Location.X, panel.Location.Y + panelMenu.Height + stack.Count * stack.Peek().PanelTopHeight);
        }

        
        /// <summary>
        /// 卡牌的MouseUp事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Up_Card(object sender, MouseEventArgs e)
        {
            //获取卡牌节点
            while(!(sender is Card))
            {
                sender = (sender as Control).Parent;
            }
            Card c = sender as Card;
            //如果是在随机牌堆上，则展示牌
            if (e.Button == MouseButtons.Left && c.CurContainer == stackRandomCard)
            {
                c.CurContainer.Pop();
                c.CurContainer = stackRandomShowCard;
                stackRandomShowCard.Push(c);
                c.Location = LocatePoint(panelOpenRandomCard);
                c.BringToFront();
                WatchFormLoad();
                return;
            }
            #region 右键事件
            if (e.Button == MouseButtons.Right && c.IsShow && c.CurContainer.Peek() == c)
            {
                switch (c.CardSuit)
                {
                    case Suit.Spade:
                        MoveFinishedCard(c, 0);
                        break;
                    case Suit.Heart:
                        MoveFinishedCard(c, 1);
                        break;
                    case Suit.Club:
                        MoveFinishedCard(c, 2);
                        break;
                    case Suit.Diamond:
                        MoveFinishedCard(c, 3);
                        break;
                    default:
                        break;
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
                bool isIntersected = SalitrireUtil.IsIntersected(c, panelMiddleCard[i]);
                if (isIntersected && stackMiddleCard[i].Count > 0)
                {
                    //判断是否跟这个Panel的最前端的牌相交
                    isIntersected = SalitrireUtil.IsIntersected(c, stackMiddleCard[i].Peek());
                    //若相交，则移动牌（组）
                    if (isIntersected)
                    {
                        MoveCard(c.cardList, i);
                        c.cardList.Clear();
                        WatchFormLoad();
                        return;
                    }
                }
                //若与Panel相交且该Panel没有牌，则判断是否为K
                else if (isIntersected && stackMiddleCard[i].Count == 0)
                {
                    //若是K，则可以移动
                    if(c.CardNumber == Number.King)
                    {
                        MoveCard(c.cardList, i);
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
                    bool isIntersected = SalitrireUtil.IsIntersected(c, stackFinishedCard[i].Peek());
                    //如果相交，则移动卡牌
                    if (isIntersected)
                    {
                        if (i == 0 && c.CardSuit == Suit.Spade)
                        {
                            MoveFinishedCard(c, i);
                            WatchFormLoad();
                            return;
                        }
                        else if (i == 1 && c.CardSuit == Suit.Heart)
                        {
                            MoveFinishedCard(c, i);
                            WatchFormLoad();
                            return;
                        }
                        else if (i == 2 && c.CardSuit == Suit.Club)
                        {
                            MoveFinishedCard(c, i);
                            WatchFormLoad();
                            return;
                        }
                        else if (i == 3 && c.CardSuit == Suit.Diamond)
                        {
                            MoveFinishedCard(c, i);
                            WatchFormLoad();
                            return;
                        }
                    }
                }
                //如果完成牌堆是空的
                else
                {
                    //判断是否与牌堆相交
                    bool isIntersected = SalitrireUtil.IsIntersected(c, panelFinishedCard[i]);
                    //如果相交，且点数为A，则可以移动
                    if (isIntersected)
                    {
                        if (i == 0 && c.CardSuit == Suit.Spade && c.CardNumber == Number.Ace)
                        {
                            MoveFinishedCard(c, i);
                            WatchFormLoad();
                            return;
                        }
                        else if (i == 1 && c.CardSuit == Suit.Heart && c.CardNumber == Number.Ace)
                        {
                            MoveFinishedCard(c, i);
                            WatchFormLoad();
                            return;
                        }
                        else if (i == 2 && c.CardSuit == Suit.Club && c.CardNumber == Number.Ace)
                        {
                            MoveFinishedCard(c, i);
                            WatchFormLoad();
                            return;
                        }
                        else if (i == 3 && c.CardSuit == Suit.Diamond && c.CardNumber == Number.Ace)
                        {
                            MoveFinishedCard(c, i);
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
            if(e.Button == MouseButtons.Left)
            {
                while (stackRandomShowCard.Count > 0)
                {
                    Card card = stackRandomShowCard.Pop();
                    stackRandomCard.Push(card);
                    card.CurContainer = stackRandomCard;
                    card.Location = LocatePoint(panelRandomCard);
                    card.IsShow = false;
                    card.BringToFront();
                }
                WatchFormLoad();
            }
        }

        /// <summary>
        /// 移动卡牌函数
        /// </summary>
        /// <param name="c">需要移动的卡牌</param>
        /// <param name="stackIndex">移动到栈的索引</param>
        private void MoveCard(List<Card> card, int stackIndex)
        {
            card.Reverse();
            foreach (Card c in card)
            {
                c.CurContainer.Pop();
                stackMiddleCard[stackIndex].Push(c);
                c.Location = LocatePoint(panelMiddleCard[stackIndex], stackMiddleCard[stackIndex]);
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
        private void MoveFinishedCard(Card card, int index)
        {
            card.CurContainer.Pop();
            stackFinishedCard[index].Push(card);
            card.Location = LocatePoint(panelFinishedCard[index]);
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
            wf.LoadForm();
        }

    }
}

﻿using System;
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
        private Stack<Card>[] stackMiddleCard;
        private Stack<Card> stackRandomCard;
        private Stack<Card> stackRandomShowCard;
        private WatchForm wf;
        public Salitrire()
        {
            InitializeComponent();

            listCard = new Card[52];
            panelMiddleCard = new Panel[7];
            stackMiddleCard = new Stack<Card>[7];
            for(int i = 0; i < 7; i++)
            {
                stackMiddleCard[i] = new Stack<Card>();
            }
            stackRandomCard = new Stack<Card>();
            stackRandomShowCard = new Stack<Card>();

            LoadMiddleCard();

            GenerateCard();

            Shuffle();

            Card resetCard = InitCardLocation();

            HideOrShowAllPanel(this, true);

            for (int i = 27; i >= 0; i--) 
            {
                Controls.Add(listCard[i]);
            }
            for(int i = 28; i < 52; i++)
            {
                Controls.Add(listCard[i]);
            }
            Controls.Add(resetCard);

            wf = new WatchForm(stackMiddleCard,stackRandomCard,stackRandomShowCard);
            wf.Show();
        }

        /// <summary>
        /// 生成52张卡牌
        /// </summary>
        private void GenerateCard()
        {
            int i = 0;
            foreach(Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach(Number n in Enum.GetValues(typeof(Number)))
                {
                    Card tCard = new Card(s, n);
                    tCard.MouseUp += Mouse_Up_Card;
                    listCard[i++] = tCard;
                }
            }
        }

        /// <summary>
        /// 随机洗牌算法
        /// </summary>
        private void Shuffle()
        {
            Random r = new Random();
            for(int i = 0; i < 52 ; i++)
            {
                int randomNum = r.Next(0, 52);
                Card t = listCard[i];
                listCard[i] = listCard[randomNum];
                listCard[randomNum] = t;
            }
        }

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
            Card resetCard = new Card(Suit.Club,Number.King);
            resetCard.Location = LocatePoint(panelRandomCard);
            resetCard.BackgroundImage = Properties.Resources.club_24px;
            resetCard.CurContainer = stackRandomCard;
            stackRandomCard.Push(resetCard);
            //resetCard.MouseClick += Mouse_Click_Card;
            resetCard.MouseClick += RandomCard_MouseClick;
            //stackRandomCard.Push(resetCard);
            for (int j = 51 ; j >= i; j--)
            {
                stackRandomCard.Push(listCard[j]);
                listCard[j].Location = LocatePoint(panelRandomCard);
                listCard[j].CurContainer = stackRandomCard;
                //listCard[j].MouseClick += Mouse_Click_Card;
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
        /// 隐藏或展示除了菜单容器的其他容器
        /// </summary>
        /// <param name="c">容器的父容器</param>
        /// <param name="hs">true为隐藏，false为展示</param>
        private void HideOrShowAllPanel(Control c, bool hs)
        {
            foreach (Control control in c.Controls)
            {
                if(control.Name == "panelMenu")
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

        private void Mouse_Up_Card(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (sender as Card).CurContainer == stackRandomCard)
            {
                Card s = sender as Card;
                s.CurContainer.Pop();
                s.CurContainer = stackRandomShowCard;
                stackRandomShowCard.Push(s);
                s.Location = LocatePoint(panelOpenRandomCard);
                s.BringToFront();
                WatchFormLoad();
                return;
            }
            Card c = sender as Card;
            for (int i = 0; i < panelMiddleCard.Length; i++)
            {
                if(c.CurContainer == stackMiddleCard[i])
                {
                    continue;
                }
                bool isIntersected = SalitrireUtil.IsIntersected(c, panelMiddleCard[i]);
                if (isIntersected && stackMiddleCard[i].Count > 0)
                {
                    isIntersected = SalitrireUtil.IsIntersected(c, stackMiddleCard[i].Peek());
                    if (isIntersected)
                    {
                        MoveCard(c, i);
                        WatchFormLoad();
                        return;
                    }
                    else
                    {
                        c.Location = c.LastLocation;
                    }
                }
                else if(isIntersected && stackMiddleCard[i].Count == 0)
                {
                    if(c.CardNumber == Number.King)
                    {
                        MoveCard(c, i);
                        WatchFormLoad();
                        return;
                    }
                }
            }
            c.Location = c.LastLocation;
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

        private void MoveCard(Card c, int stackIndex)
        {
            c.CurContainer.Pop();
            stackMiddleCard[stackIndex].Push(c);
            c.Location = LocatePoint(panelMiddleCard[stackIndex], stackMiddleCard[stackIndex]);
            if(c.CurContainer.Count > 0)
                c.CurContainer.Peek().IsShow = true;
            c.CurContainer = stackMiddleCard[stackIndex];
            c.LastLocation = c.Location;
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
            wf.stackRandomCard = new Stack<Card>(stackRandomCard.ToArray());
            wf.stackRandomShowCard = new Stack<Card>(stackRandomShowCard.ToArray());
            wf.LoadForm();
        }
    }
}

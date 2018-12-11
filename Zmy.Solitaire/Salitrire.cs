using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private Queue<Card> queueRandomCard;
        private Stack<Card> stackRandomShowCard;

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
            queueRandomCard = new Queue<Card>();
            stackRandomShowCard = new Stack<Card>();

            LoadMiddleCard();

            GenerateCard();

            Shuffle();

            InitCardLocation();

            HideOrShowAllPanel(this, true);

            for (int i = 27; i >= 0; i--) 
            {
                Controls.Add(listCard[i]);
            }

            for(int i = 28; i < 52; i++)
            {
                Controls.Add(listCard[i]);
            }
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
            for (int j = 51; j >= 28; j--)
            {
                queueRandomCard.Enqueue(listCard[i++]);
                listCard[j].Location = LocatePoint(panelRandomCard);
                listCard[j].CurContainer = queueRandomCard;
                listCard[j].MouseClick += Mouse_Click_Card;
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

        private void Mouse_Click_Card(object sender, MouseEventArgs e)
        {
            Card s = sender as Card;
            s.CurContainer = stackRandomShowCard;
            stackRandomShowCard.Push(s);
            s.Location = LocatePoint(panelOpenRandomCard);
            s.BringToFront();
        }

        private void panelRandomCard_MouseClick(object sender, MouseEventArgs e)
        {
            for(int i = 0; i < stackRandomShowCard.Count; i++)
            {
                Card card = stackRandomShowCard.Pop();
                queueRandomCard.Enqueue(card);
                card.Location = LocatePoint(panelRandomCard);
                card.IsShow = false;
                card.BringToFront();
            }
        }
    }
}

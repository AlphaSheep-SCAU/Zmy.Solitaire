using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zmy.Solitaire.customComponent;

namespace Zmy.Solitaire
{
    class SolitrireRule
    {
        /// <summary>
        /// 生成52张卡牌
        /// </summary>
        public static Card[] GenerateCard(Card[] listCard, MouseEventHandler Mouse_Up_Card)
        {
            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                if (s == Suit.Reset || s == Suit.Finish)
                    continue;
                foreach (Number n in Enum.GetValues(typeof(Number)))
                {
                    if (n == Number.Reset || n == Number.Finish)
                        continue;
                    Card tCard = new Card(s, n);
                    //tCard.MouseUp += Mouse_Up_Card;
                    tCard.AddMouseUp(tCard, Mouse_Up_Card);
                    listCard[i++] = tCard;
                }
            }
            return listCard;
        }

        /// <summary>
        /// 随机洗牌算法
        /// </summary>
        public static Card[] RandomShuffle(Card[] listCard)
        {
            Random r = new Random();
            for (int i = 0; i < 52; i++)
            {
                int randomNum = r.Next(0, 52);
                Card t = listCard[i];
                listCard[i] = listCard[randomNum];
                listCard[randomNum] = t;
            }

            return listCard;
        }

        /// <summary>
        /// 测试洗牌算法
        /// </summary>
        public static Card[] TestShuffle(Card[] listCard)
        {
            
            return listCard;
        }

        /// <summary>
        /// 判断卡牌是否符合移动到完成牌堆的规则
        /// </summary>
        /// <param name="c">移动的卡牌</param>
        /// <param name="finishedStack">完成牌堆的数组</param>
        /// <returns></returns>
        public static bool IsCanMove2Finished(Card c, Stack<Card>[] finishedStack)
        {
            int index = c.CardSuit == Suit.Spade ? 0 : c.CardSuit == Suit.Heart ? 1 : c.CardSuit == Suit.Club ? 2 : 3;
            //判断完成牌堆是否为空
            if (finishedStack[index].Count == 0)
                return c.CardNumber == Number.Ace;
            else
                return c.CardNumber == finishedStack[index].Peek().CardNumber + 1;
        }

        /// <summary>
        /// 获取卡牌可以移动到完成牌堆的索引：黑桃：0，红心：1，梅花：2，方块：3
        /// </summary>
        /// <param name="c">移动的卡牌</param>
        /// <returns></returns>
        public static int Move2FinishedIndex(Card c)
        {
            switch (c.CardSuit)
            {
                case Suit.Spade:
                    return 0;
                case Suit.Heart:
                    return 1;
                case Suit.Club:
                    return 2;
                case Suit.Diamond:
                    return 3;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// 判断卡牌是否可以移动到中间牌堆
        /// </summary>
        /// <param name="c">移动的卡牌</param>
        /// <param name="stack">移动到的牌堆</param>
        /// <returns></returns>
        public static bool IsCanMove2Middle(Card c, Stack<Card> stack)
        {
            if (stack.Count == 0)
                return c.CardNumber == Number.King;
            if (stack.Peek().CardNumber == Number.Ace)
                return false;
            return (c.CardNumber == stack.Peek().CardNumber - 1 && c.CardColor != stack.Peek().CardColor);
        }

        /// <summary>
        /// 判断是否游戏胜利
        /// </summary>
        /// <param name="finishedStack">完成牌堆的数组</param>
        /// <returns></returns>
        public static bool IsWin(Stack<Card>[] finishedStack)
        {
            return (finishedStack[0].Count == 13 && finishedStack[1].Count == 13 && finishedStack[2].Count == 13 && finishedStack[3].Count == 13);
        }

        /// <summary>
        /// 判断是否可以移动几张
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns></returns>
        public static bool IsCanMoveMul(List<Card> cardList)
        {
            bool flag = true;
            for(int i = 0; i < cardList.Count - 1; i++)
            {
                if(cardList[i + 1].CardNumber - cardList[i].CardNumber != 1)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zmy.Solitaire.customComponent;

namespace Zmy.Solitaire
{
    public class SalitrireRule
    {
        /// <summary>
        /// 生成52张卡牌
        /// </summary>
        public static Card[] GenerateCard(MouseEventHandler Mouse_Up_Card)
        {
            int i = 0;
            Card[] listCard = new Card[52];
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                if (s == Suit.Reset)
                    continue;
                foreach (Number n in Enum.GetValues(typeof(Number)))
                {
                    if (n == Number.Reset)
                        continue;
                    Card tCard = new Card(s, n);
                    tCard.MouseUp += Mouse_Up_Card;
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
            for (int i = 0; i < listCard.Length; i++)
            {
                int randomNum = r.Next(0, 52);
                Card t = listCard[i];
                listCard[i] = listCard[randomNum];
                listCard[randomNum] = t;
            }
            return listCard;
        }
    }
}

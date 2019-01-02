using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zmy.Solitaire.customComponent;


namespace Zmy.Solitaire
{
    class SalitrireUtil
    {
        /// <summary>
        /// 判断卡牌与容器是否相交
        /// </summary>
        /// <param name="card"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool IsIntersected(Card card, Panel p)
        {
            Point pLeftUp = p.Location;
            Point pRightDown = new Point(pLeftUp.X + p.Size.Width, pLeftUp.Y + p.Size.Height);

            Point cLeftUp = card.Location;
            Point cRightDown = new Point(cLeftUp.X + card.Size.Width, cLeftUp.Y + card.Size.Height);

            int minx = Math.Max(pLeftUp.X, cLeftUp.X);
            int miny = Math.Max(pLeftUp.Y, cLeftUp.Y);
            int maxx = Math.Min(pRightDown.X, cRightDown.X);
            int maxy = Math.Min(pRightDown.Y, cRightDown.Y);

            if (minx < maxx && miny < maxy)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断卡牌之间是否相交
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool IsIntersected(Card c1, Card c2)
        {
            Point c2LeftUp = c2.Location;
            Point c2RightDown = new Point(c2LeftUp.X + c2.Size.Width, c2LeftUp.Y + c2.Size.Height);

            Point c1LeftUp = c1.Location;
            Point c1RightDown = new Point(c1LeftUp.X + c1.Size.Width, c1LeftUp.Y + c1.Size.Height);

            int minx = Math.Max(c2LeftUp.X, c1LeftUp.X);
            int miny = Math.Max(c2LeftUp.Y, c1LeftUp.Y);
            int maxx = Math.Min(c2RightDown.X, c1RightDown.X);
            int maxy = Math.Min(c2RightDown.Y, c1RightDown.Y);

            if (minx < maxx && miny < maxy)
                return true;
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Zmy.Solitaire.customComponent;


namespace Zmy.Solitaire
{
    class SolitaireUtil
    {
        /// <summary>
        /// 判断卡牌与容器是否相交
        /// </summary>
        /// <param name="card"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool IsIntersected(Card card, Panel p)
        {
            if (card == null || p == null)
                return false;
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
            if (c1 == null || c2 == null)
                return false;
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

        /// <summary>
        /// 隐藏或展示除了菜单容器的其他容器
        /// </summary>
        /// <param name="c">容器的父容器</param>
        /// <param name="hs">true为隐藏，false为展示</param>
        public static void HideOrShowAllPanel(Control c, bool hs)
        {
            foreach (Control control in c.Controls)
            {
                if (control.Name == "panelMenu")
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

        /// <summary>
        /// 根据XML文件生成牌组
        /// </summary>
        /// <param name="Mouse_Up_Card">鼠标施放事件</param>
        /// <returns></returns>
        public static Card[] ReadXml(string src, MouseEventHandler Mouse_Up_Card)
        {
            Card[] listCard = new Card[52];
            XmlDocument doc = new XmlDocument();
            doc.Load(src);
            XmlNode root = doc.SelectSingleNode("solitaire");

            listCard = ReadXmlCard(root, listCard, "middle1");
            listCard = ReadXmlCard(root, listCard, "middle2");
            listCard = ReadXmlCard(root, listCard, "middle3");
            listCard = ReadXmlCard(root, listCard, "middle4");
            listCard = ReadXmlCard(root, listCard, "middle5");
            listCard = ReadXmlCard(root, listCard, "middle6");
            listCard = ReadXmlCard(root, listCard, "middle7");
            listCard = ReadXmlCard(root, listCard, "random");

            listCard = AddEvent(listCard, Mouse_Up_Card);

            return listCard;
        }

        /// <summary>
        /// 跟住xml的代码生成不同的card
        /// </summary>
        /// <param name="code">xml代码</param>
        /// <returns></returns>
        private static Card GetWhichCard(string code)
        {
            switch (code)
            {
                case "SA": return new Card(Suit.Spade, Number.Ace);
                case "S2": return new Card(Suit.Spade, Number.Two);
                case "S3": return new Card(Suit.Spade, Number.Three);
                case "S4": return new Card(Suit.Spade, Number.Four);
                case "S5": return new Card(Suit.Spade, Number.Five);
                case "S6": return new Card(Suit.Spade, Number.Six);
                case "S7": return new Card(Suit.Spade, Number.Seven);
                case "S8": return new Card(Suit.Spade, Number.Eight);
                case "S9": return new Card(Suit.Spade, Number.Nine);
                case "S10": return new Card(Suit.Spade, Number.Ten);
                case "SJ": return new Card(Suit.Spade, Number.Jack);
                case "SQ": return new Card(Suit.Spade, Number.Queen);
                case "SK": return new Card(Suit.Spade, Number.King);

                case "HA": return new Card(Suit.Heart, Number.Ace);
                case "H2": return new Card(Suit.Heart, Number.Two);
                case "H3": return new Card(Suit.Heart, Number.Three);
                case "H4": return new Card(Suit.Heart, Number.Four);
                case "H5": return new Card(Suit.Heart, Number.Five);
                case "H6": return new Card(Suit.Heart, Number.Six);
                case "H7": return new Card(Suit.Heart, Number.Seven);
                case "H8": return new Card(Suit.Heart, Number.Eight);
                case "H9": return new Card(Suit.Heart, Number.Nine);
                case "H10": return new Card(Suit.Heart, Number.Ten);
                case "HJ": return new Card(Suit.Heart, Number.Jack);
                case "HQ": return new Card(Suit.Heart, Number.Queen);
                case "HK": return new Card(Suit.Heart, Number.King);

                case "CA": return new Card(Suit.Club, Number.Ace);
                case "C2": return new Card(Suit.Club, Number.Two);
                case "C3": return new Card(Suit.Club, Number.Three);
                case "C4": return new Card(Suit.Club, Number.Four);
                case "C5": return new Card(Suit.Club, Number.Five);
                case "C6": return new Card(Suit.Club, Number.Six);
                case "C7": return new Card(Suit.Club, Number.Seven);
                case "C8": return new Card(Suit.Club, Number.Eight);
                case "C9": return new Card(Suit.Club, Number.Nine);
                case "C10": return new Card(Suit.Club, Number.Ten);
                case "CJ": return new Card(Suit.Club, Number.Jack);
                case "CQ": return new Card(Suit.Club, Number.Queen);
                case "CK": return new Card(Suit.Club, Number.King);

                case "DA": return new Card(Suit.Diamond, Number.Ace);
                case "D2": return new Card(Suit.Diamond, Number.Two);
                case "D3": return new Card(Suit.Diamond, Number.Three);
                case "D4": return new Card(Suit.Diamond, Number.Four);
                case "D5": return new Card(Suit.Diamond, Number.Five);
                case "D6": return new Card(Suit.Diamond, Number.Six);
                case "D7": return new Card(Suit.Diamond, Number.Seven);
                case "D8": return new Card(Suit.Diamond, Number.Eight);
                case "D9": return new Card(Suit.Diamond, Number.Nine);
                case "D10": return new Card(Suit.Diamond, Number.Ten);
                case "DJ": return new Card(Suit.Diamond, Number.Jack);
                case "DQ": return new Card(Suit.Diamond, Number.Queen);
                case "DK": return new Card(Suit.Diamond, Number.King);

                default: return null;
            }
        }

        /// <summary>
        /// 生成card
        /// </summary>
        /// <param name="root"></param>
        /// <param name="listCard"></param>
        /// <param name="xmlTab"></param>
        /// <returns></returns>
        private static Card[] ReadXmlCard(XmlNode root, Card[] listCard, string xmlTab)
        {
            int i = 0;
            while (listCard[i] != null)
                i++;
            XmlNode list = root.SelectSingleNode(xmlTab);
            XmlNodeList ele = list.ChildNodes;
            foreach (XmlElement e in ele)
                listCard[i++] = GetWhichCard(e.InnerText);
            return listCard;
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="listCard"></param>
        /// <param name="Mouse_Up_Card"></param>
        /// <returns></returns>
        private static Card[] AddEvent(Card[] listCard, MouseEventHandler Mouse_Up_Card)
        {
            foreach(var card in listCard)
                card.AddMouseUp(card, Mouse_Up_Card);
            return listCard;
        }

        /// <summary>
        /// 保存牌局
        /// </summary>
        /// <param name="listCard"></param>
        public static void SaveGameXML(Card[] listCard, string name)
        {
            XmlTextWriter xtw = new XmlTextWriter(@"../../save/" + name + ".xml", null);
            xtw.Formatting = Formatting.Indented;
            xtw.WriteStartDocument();
            xtw.WriteStartElement("solitaire");
            xtw.WriteStartElement("random");
            for(int i = 28; i < 52; i++)
            {
                xtw.WriteElementString("card", GetWhichCode(listCard[i]));
            }
            xtw.WriteEndElement();
            
            for(int i = 1; i < 8; i++)
            {
                int sum = ((i - 1) * i) / 2;
                xtw.WriteStartElement("middle" + i.ToString());
                for (int j = sum ; j < sum + i ; j++) 
                {
                    xtw.WriteElementString("card", GetWhichCode(listCard[j]));
                }
                xtw.WriteEndElement();
            }

            xtw.WriteEndElement();
            xtw.Flush();
            xtw.Close();
        }

        /// <summary>
        /// 根据牌组生成XML
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private static string GetWhichCode(Card card)
        {
            string result = "";
            switch (card.CardSuit)
            {
                case Suit.Club: result += "C";break;
                case Suit.Diamond: result += "D";break;
                case Suit.Heart: result += "H";break;
                case Suit.Spade: result += "S";break;
                default:break;
            }
            switch (card.CardNumber)
            {
                case Number.Ace: result += "A"; break;
                case Number.Two: result += "2"; break;
                case Number.Three: result += "3"; break;
                case Number.Four: result += "4"; break;
                case Number.Five: result += "5"; break;
                case Number.Six: result += "6"; break;
                case Number.Seven: result += "7"; break;
                case Number.Eight: result += "8"; break;
                case Number.Nine: result += "9"; break;
                case Number.Ten: result += "10"; break;
                case Number.Jack: result += "J"; break;
                case Number.Queen: result += "Q"; break;
                case Number.King: result += "K"; break;
            }
            return result;
        }

        public static Point HorizontalCenter(Control c, Control p)
        {
            return new Point((p.Width - c.Width) / 2, c.Location.Y);
        }

        public static Point VerticalCenter(Control c, Control p)
        {
            return new Point(c.Location.X, (p.Height - c.Height) / 2);
        }

        public static Point HorizontalVerticalCenter(Control c, Control p)
        {
            return new Point((p.Width - c.Width) / 2, (p.Height - c.Height) / 2);
        }
    }
}

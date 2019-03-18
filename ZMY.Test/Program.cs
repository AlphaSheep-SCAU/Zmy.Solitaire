using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ZMY.Test
{
    class Program
    {
        public static bool IsIntersected(rectangle c1, rectangle c2)
        {
            Point c2LeftUp = new Point(c2.minx, c2.miny);
            Point c2RightDown = new Point(c2LeftUp.X + c2.width, c2LeftUp.Y + c2.height);
            Console.WriteLine(c2LeftUp.ToString() + c2RightDown.ToString());

            Point c1LeftUp = new Point(c1.minx, c1.miny);
            Point c1RightDown = new Point(c1LeftUp.X + c1.width, c1LeftUp.Y + c1.height);
            Console.WriteLine(c1LeftUp.ToString() + c1RightDown.ToString());

            int minx = Math.Max(c2LeftUp.X, c1LeftUp.X);
            int miny = Math.Max(c2LeftUp.Y, c1LeftUp.Y);
            int maxx = Math.Min(c2RightDown.X, c1RightDown.X);
            int maxy = Math.Min(c2RightDown.Y, c1RightDown.Y);

            Console.WriteLine(minx);
            Console.WriteLine(miny);
            Console.WriteLine(maxx);
            Console.WriteLine(maxy);
            if (minx < maxx && miny < maxy)
                return true;
            else
                return false;
        }

        public static void aaa(int a, out int b)
        {
            b = a;
        }

        enum a
        {
            one = 1,
            two = 2,
            three = 3
        };

        static void Main(string[] args)
        {
            //rectangle a = new rectangle(190, 15, 130, 180);
            //rectangle b = new rectangle(190, 224, 130, 376);
            //Console.WriteLine(IsIntersected(a,b));

            //Stack<int> c = new Stack<int>();
            //c.Push(1);
            //c.Push(2);
            //c.Push(3);
            //c.Push(4);
            //c.Push(5);
            //c.Push(6);
            //c.Push(7);
            //c.Push(8);
            //int[] d = c.ToArray();

            //foreach(int i in d)
            //{
            //    Console.WriteLine(i);
            //}

            //a o = a.one;
            //a t = a.two;
            //Console.WriteLine(o + 1 == t);

            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"../../testshuffle/test.xml");
            //XmlNode list = doc.SelectSingleNode("solitaire");
            //list = list.SelectSingleNode("middle1");
            ////XmlNodeList l = list.ChildNodes;
            ////foreach (XmlNode node in l)
            ////{
            //    XmlNodeList ele = list.ChildNodes;
            //    foreach(XmlElement e in ele)
            //    {
            //        Console.WriteLine(e.InnerText);
            //    }
            ////}

            //Stack<int> s = new Stack<int>();
            //s.Push(1);
            //s.Push(2);
            //s.Push(3);
            //s.Push(4);
            //s.Push(5);
            //s.Push(6);
            //s.Push(7);
            //s.Push(8);
            //s.Push(9);
            //s.Push(10);
            //s.Push(11);
            //s.Push(12);
            //List<int> li = s.ToList();
            //int b = 0;
            //aaa(50, out b);
            //Console.WriteLine(b);
            //XmlTextWriter xtw = new XmlTextWriter(@"../../testshuffle/hehe.xml", null);
            //xtw.Formatting = Formatting.Indented;
            //xtw.WriteStartDocument();
            //xtw.WriteStartElement("solitaire");
            //xtw.WriteStartElement("random");
            //xtw.WriteElementString("card","A1");
            //xtw.WriteElementString("card","A1");
            //xtw.WriteElementString("card","A1");
            //xtw.WriteElementString("card","A1");
            //xtw.WriteElementString("card","A1");
            //xtw.WriteEndElement();
            //xtw.WriteEndElement();
            //xtw.Flush();
            //xtw.Close();
            Console.Read();
        }
    }
    class rectangle
    {
        public int minx { get; set; }
        public int miny { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public rectangle(int minx,int miny,int width,int height)
        {
            this.minx = minx;
            this.miny = miny;
            this.width = width;
            this.height = height;
        }
    }
}

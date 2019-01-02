﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        static void Main(string[] args)
        {
            rectangle a = new rectangle(190, 15, 130, 180);
            rectangle b = new rectangle(190, 224, 130, 376);
            Console.WriteLine(IsIntersected(a,b));
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

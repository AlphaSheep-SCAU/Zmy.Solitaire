using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmy.Solitaire
{
    public partial class RotateLabel : UserControl
    {
        [Browsable(true), Description("Text")]
        private string rText;
        public string RText
        {
            get
            {
                return rText;
            }
            set
            {
                rText = value;
                Graphics g = CreateGraphics();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.RotateTransform(180);
                g.TranslateTransform(-Width, -Height);
                g.DrawString(RText, base.Font, new SolidBrush(base.ForeColor), 0, 0);
            }
        }

        public RotateLabel()
        {
            InitializeComponent();
            rText = "A";
        }

        /// <summary>
        /// 重写OnPaint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = CreateGraphics();//创建Graphics对象
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//设置指定抗锯齿的呈现
            g.RotateTransform(180);//旋转180°
            g.TranslateTransform(-Width, -Height);//平移图像
            g.DrawString(RText, base.Font, new SolidBrush(base.ForeColor), 0, 0);
        }

        private void RotateLabel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

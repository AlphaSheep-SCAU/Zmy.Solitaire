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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.RotateTransform(180);
            g.TranslateTransform(-Width, -Height);
            g.DrawString(RText, base.Font, new SolidBrush(base.ForeColor), 0, 0);
        }

        private void RotateLabel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

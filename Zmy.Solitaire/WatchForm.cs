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
    public partial class WatchForm : Form
    {
        public Stack<Card>[] stackMiddleCard;
        public Stack<Card> stackRandomCard;
        public Stack<Card> stackRandomShowCard;
        public Stack<Card>[] stackFinishedCard;

        public WatchForm()
        {
            InitializeComponent();
            stackMiddleCard = new Stack<Card>[7];
            stackFinishedCard = new Stack<Card>[4];
            stackRandomCard = new Stack<Card>();
            stackRandomShowCard = new Stack<Card>();
        }

        public WatchForm(Stack<Card>[] smc, Stack<Card> src, Stack<Card> srsc,Stack<Card>[] sfc) 
        {
            InitializeComponent();
            stackMiddleCard = new Stack<Card>[7];
            for (int i = 0; i < smc.Length; i++)
            {
                stackMiddleCard[i] = new Stack<Card>(smc[i].ToArray());
            }
            stackFinishedCard = new Stack<Card>[4];
            for(int i = 0; i < sfc.Length; i++)
            {
                stackFinishedCard[i] = new Stack<Card>(sfc[i].ToArray());
            }
            stackRandomCard = new Stack<Card>(src.ToArray());
            stackRandomShowCard = new Stack<Card>(srsc.ToArray());
            LoadForm();
        }

        public void LoadForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";

            Stack<Card>[] t = stackMiddleCard;
            while (t[0].Count != 0)
            {
                textBox1.Text += t[0].Peek().CardSuit;
                textBox1.Text += ((int)t[0].Pop().CardNumber + 1) + " ";
            }
            while (t[1].Count != 0)
            {
                textBox2.Text += t[1].Peek().CardSuit;
                textBox2.Text += ((int)t[1].Pop().CardNumber + 1) + " ";
            }
            while (t[2].Count != 0)
            {
                textBox3.Text += t[2].Peek().CardSuit;
                textBox3.Text += ((int)t[2].Pop().CardNumber + 1) + " ";
            }
            while (t[3].Count != 0)
            {
                textBox4.Text += t[3].Peek().CardSuit;
                textBox4.Text += ((int)t[3].Pop().CardNumber + 1) + " ";
            }
            while (t[4].Count != 0)
            {
                textBox5.Text += t[4].Peek().CardSuit;
                textBox5.Text += ((int)t[4].Pop().CardNumber + 1) + " ";
            }
            while (t[5].Count != 0)
            {
                textBox6.Text += t[5].Peek().CardSuit;
                textBox6.Text += ((int)t[5].Pop().CardNumber + 1) + " ";
            }
            while (t[6].Count != 0)
            {
                textBox7.Text += t[6].Peek().CardSuit;
                textBox7.Text += ((int)t[6].Pop().CardNumber + 1) + " ";
            }

            Stack<Card> t2 = stackRandomCard;
            while(t2.Count != 0)
            {
                textBox8.Text += t2.Peek().CardSuit;
                textBox8.Text += ((int)t2.Pop().CardNumber + 1) + " ";
            }

            t2 = stackRandomShowCard;
            while (t2.Count != 0)
            {
                textBox9.Text += t2.Peek().CardSuit;
                textBox9.Text += ((int)t2.Pop().CardNumber + 1) + " ";
            }

            t = stackFinishedCard;
            while (t[0].Count != 0)
            {
                textBox10.Text += t[0].Peek().CardSuit;
                textBox10.Text += ((int)t[0].Pop().CardNumber + 1) + " ";
            }
            while (t[1].Count != 0)
            {
                textBox11.Text += t[1].Peek().CardSuit;
                textBox11.Text += ((int)t[1].Pop().CardNumber + 1) + " ";
            }
            while (t[2].Count != 0)
            {
                textBox12.Text += t[2].Peek().CardSuit;
                textBox12.Text += ((int)t[2].Pop().CardNumber + 1) + " ";
            }
            while (t[3].Count != 0)
            {
                textBox13.Text += t[3].Peek().CardSuit;
                textBox13.Text += ((int)t[3].Pop().CardNumber + 1) + " ";
            }
        }
    }
}

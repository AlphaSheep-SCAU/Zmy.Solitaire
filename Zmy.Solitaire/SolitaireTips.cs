using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zmy.Solitaire.customComponent;

namespace Zmy.Solitaire
{
    class SolitaireTips
    {
        public List<Card> ObjectCardArray { get; set; }
        public SolitaireStack<Card> ObjectStack { get; set; }
        public Card SingleCard { get; set; }

        public SolitaireTips(List<Card> oca,SolitaireStack<Card> os)
        {
            //ObjectCardArray = (Card[])oca.Clone();
            ObjectCardArray = oca;
            ObjectStack = os;
            SingleCard = null;
        }

        public SolitaireTips(Card sc, SolitaireStack<Card> os)
        {
            SingleCard = sc;
            ObjectStack = os;
            ObjectCardArray = null;
        }

        public override string ToString()
        {
            if (ObjectCardArray != null)
                return ObjectCardArray[0].CardSuit.ToString() + ObjectCardArray[0].CardNumber.ToString() + " to "
                    + ObjectCardArray[ObjectCardArray.Count - 1].CardSuit.ToString() + ObjectCardArray[ObjectCardArray.Count - 1].CardNumber.ToString()
                    + " → " + ObjectStack.ToString();
            else
                return SingleCard.CardSuit.ToString() + SingleCard.CardNumber.ToString() + " → " + ObjectStack.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zmy.Solitaire.customComponent;

namespace Zmy.Solitaire
{
    public class PlayerStep
    {
        public Card DragCard { get; set; }
        public List<Card> DragCards { get; set; }
        public SolitaireStack<Card> DragCardStack { get; set; }
        public SolitaireStack<Card> DestinationStack { get; set; }
        public bool IsShowNext { get; set; }


        public PlayerStep(Card DragCard, List<Card> DragCards, SolitaireStack<Card> DragCardStack, SolitaireStack<Card> DestinationStack, bool IsShowNext)
        {
            this.DragCard = DragCard;
            this.DragCards = DragCards;
            this.DragCardStack = DragCardStack;
            this.DestinationStack = DestinationStack;
            this.IsShowNext = IsShowNext;
        }

        public override string ToString()
        {
            string re = "";
            if(DragCard != null)
            {
                //re = DragCard.CardSuit.ToString() + (DragCard.CardNumber).ToString() + " in " + DragCardStack.ToString() + "->" + DestinationStack + " ";
                re = $"{DragCard.CardSuit}{DragCard.CardNumber} in {DragCardStack} → {DestinationStack} ";
            }
            else
            {
                re = DragCards[0].CardSuit.ToString() + (DragCards[0].CardNumber).ToString() + " to " + DragCards[DragCards.Count - 1].CardSuit.ToString() + 
                    (DragCards[DragCards.Count - 1].CardNumber).ToString() + " in " + DragCardStack.ToString() + "->" + DestinationStack + " ";
            }
            return re;
        }
    }
}

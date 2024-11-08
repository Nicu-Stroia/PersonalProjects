using Macao.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Macao
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();


        public void Shuffle(List<Card> shuffleCards)
        {
            Random shuffle = new Random();
            int cardsSize = shuffleCards.Count;
            int shuffleCardsSize = shuffleCards.Count;
            int randomIndex;
            for (int i = 0; i < cardsSize; i++)
            {
                randomIndex = shuffle.Next(shuffleCardsSize);
                Cards.Add(shuffleCards[randomIndex]);
                shuffleCards.Remove(shuffleCards[randomIndex]);
                shuffleCardsSize--;
            }
        }

        public void Move(List<Card> discardCards)
        {
            int cardsSize = Cards.Count;
            foreach(Card card in Cards)
            {
                discardCards.Add(card);
            }
            if(discardCards.Count == Cards.Count)
            {
                foreach(Card card in discardCards)
                {
                    Cards.Remove(card);
                }
            }
            if (Cards.Count == 0)
            {
                Shuffle(discardCards);
            }
        }
    }
}

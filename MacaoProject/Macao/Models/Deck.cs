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


        public void Shuffle()
        {
            Random shuffle = new Random();
            int cardsSize = Cards.Count;
            int randomIndex;
            for (int i = 0; i < Cards.Count; i++)
            {
                randomIndex = shuffle.Next(cardsSize);
                Cards.Add(Cards[randomIndex]);
                Cards.Remove(Cards[randomIndex]);
                cardsSize--;
            }
        }

        public void Move(List<Card> discardCards)
        {
            foreach(Card card in Cards)
            {
                discardCards.Add(card);
            }
            Cards.Clear();
        }

        public void ShuffleDiscardDeck (List<Card> discardCards)
        {
            Random shuffle = new Random();
            int discardCardsSize = discardCards.Count;
            int randomIndex;
            for (int i = 0; i < discardCardsSize; i++)
            {
                randomIndex = shuffle.Next(discardCards.Count);
                Cards.Add(discardCards[randomIndex]);
                discardCards.Remove(discardCards[randomIndex]);
            }
        }
    }
}

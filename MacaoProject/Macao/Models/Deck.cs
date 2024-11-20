using Macao.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Card CardBack { get; set; } = new Card();

        public Deck() { }

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
            discardCards.AddRange(Cards);
            Cards.Clear();
        }
    }
}

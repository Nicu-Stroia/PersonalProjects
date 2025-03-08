using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macao
{
    public class Player
    {
        public string Name { get; set; }

        public int CardPositionX { get; set; }

        public int CardPositionY { get; set; }

        public Deck Deck { get; set; } = new Deck();

        public void DrawCard(Card selectedCard)
        {
           Deck.Cards.Add(selectedCard);
        }

        public void PlaceCard(Card topCard, Card playerCard)
        {
            topCard.Value = playerCard.Value;
            topCard.Symbol = playerCard.Symbol;
            topCard.Picture = playerCard.Picture;
            Deck.Cards.Remove(playerCard);
        }
    }
}

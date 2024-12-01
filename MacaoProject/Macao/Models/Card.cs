using Macao.Enums;
using System;
using System.Collections.Generic;
namespace Macao
{
    public class Card
    {
        public CardValueEnum Value { get; set; }

        public CardSymbolEnum Symbol { get; set; }

        public string Picture { get; set; }

        public Card()
        {

        }

        public Card(CardValueEnum value, CardSymbolEnum symbol, string image)
        {
            Value = value;
            Symbol = symbol;
            Picture = image;
        }

        public bool Validation(Card card, Card firstCard)
        {
            Player player = new Player();
            if(firstCard.Value == card.Value || firstCard.Symbol == card.Symbol)
            {
                player.PlaceCard(card, firstCard);
                return true;
            }
            return false;
        }
    }
}

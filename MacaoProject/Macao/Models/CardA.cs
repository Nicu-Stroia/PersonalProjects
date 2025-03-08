using Macao.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
namespace Macao
{
    public class CardA : Card
    {
        public override CardEffectEnum Effect { get; set; } = CardEffectEnum.SkipATurn;

        public CardA(Card newCard)
        {
            Value = newCard.Value;
            Symbol = newCard.Symbol;
            Picture = newCard.Picture;
        }
    }
}

using Macao.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macao
{
    public class CardSeven : Card
    {
        public override CardEffectEnum Effect { get; set; } = CardEffectEnum.ChangeColor;

        public CardSeven(Card newCard)
        {
            Value = newCard.Value;
            Symbol = newCard.Symbol;
            Picture = newCard.Picture;
        }
    }
}

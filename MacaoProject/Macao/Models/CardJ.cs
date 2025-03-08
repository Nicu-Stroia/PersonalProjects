using Macao.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macao.Models
{
    public class CardJ : Card
    {
        public override CardEffectEnum Effect { get; set; } = CardEffectEnum.TakeTwoCards;

        public CardJ(Card newCard)
        {
            Value = newCard.Value;
            Symbol = newCard.Symbol;
            if(Symbol == CardSymbolEnum.Heart)
            {
                Effect = CardEffectEnum.TakeThreeCards;
            }
            Picture = newCard.Picture;
        }
    }
}

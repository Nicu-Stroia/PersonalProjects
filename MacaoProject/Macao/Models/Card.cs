using Macao.Enums;
using System.Windows.Forms;
namespace Macao
{
    public class Card
    {
        public CardValueEnum Value { get; set; }

        public CardSymbolEnum Symbol { get; set; }

        public virtual CardEffectEnum Effect { get; set; } = CardEffectEnum.NoEffect;

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


        public bool IsMoveValid(Card topCard)
        {
            if(Value == CardValueEnum.Seven)
            {
                return true;
            }
            if (topCard.Value == Value || topCard.Symbol == Symbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using Macao.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macao
{
    public class Card
    {
        public CardValue CardValue { get; set; }
        public CardSymbol CardSymbol { get; set; }

        public Card(CardValue value, CardSymbol symbol)
        {
            CardValue = value;
            CardSymbol = symbol;
        }

        public string Picture { get; set; }

        public void Validation()
        {

        }

    }
}

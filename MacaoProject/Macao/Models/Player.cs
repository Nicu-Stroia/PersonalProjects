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

        public void LastCard()
        {

        }

        public void DrawCard()
        {

        }

        public void PlaceCard(Card card, Card firstCard)
        {
            firstCard = card;
        }
    }
}

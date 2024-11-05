using Macao.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macao
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public void Move(Deck discardDeck)
        {
        }

        public void Shuffle()
        {
        }
    }
}

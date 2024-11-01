using Macao.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macao
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Deck deck = new Deck();
            //deck.CreateDeck();
            List<Card> cards = new List<Card>();
            Card newCard = new Card(CardValue.Two, CardSymbol.Heart);
            cards.Add(newCard);
            Card newCard2 = new Card(CardValue.Three, CardSymbol.Diamond);
            cards.Add(newCard2);
            Card newCard3 = new Card(CardValue.King, CardSymbol.Spade);
            cards.Add(newCard3);
            Application.Run(new Form1());
        }
    }
}

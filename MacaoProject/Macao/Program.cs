using Macao.Enums;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
            Deck deck = new Deck();
            List<Card> discardCards = new List<Card>();
            Card newCard = new Card(CardValue.Two, CardSymbol.Heart);
            deck.Cards.Add(newCard);
            Card newCard2 = new Card(CardValue.Three, CardSymbol.Club);
            deck.Cards.Add(newCard2);
            Card newCard3 = new Card(CardValue.Four, CardSymbol.Heart);
            deck.Cards.Add(newCard3);
            Card newCard4 = new Card(CardValue.Five, CardSymbol.Spade);
            deck.Cards.Add(newCard4);
            Card newCard5 = new Card(CardValue.Two, CardSymbol.Diamond);
            deck.Cards.Add(newCard5);
            Card newCard6 = new Card(CardValue.Five, CardSymbol.Club);
            deck.Cards.Add(newCard6);
            deck.Shuffle();
            deck.Move(discardCards);
            deck.ShuffleDiscardDeck(discardCards);
            Application.Run(new Form1());
        }
    }
}

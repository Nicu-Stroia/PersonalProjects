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
            List<Card> cards = new List<Card>();
            Card newCard = new Card(CardValue.Two, CardSymbol.Heart);
            cards.Add(newCard);
            Card newCard2 = new Card(CardValue.Three, CardSymbol.Club);
            cards.Add(newCard2);
            Card newCard3 = new Card(CardValue.Four, CardSymbol.Heart);
            cards.Add(newCard3);
            Card newCard4 = new Card(CardValue.Five, CardSymbol.Spade);
            cards.Add(newCard4);
            Card newCard5 = new Card(CardValue.Two, CardSymbol.Diamond);
            cards.Add(newCard5);
            Card newCard6 = new Card(CardValue.Five, CardSymbol.Club);
            cards.Add(newCard6);
            //Shuffle
            Random shuffle = new Random();
            List<Card> shuffleCards = new List<Card>();
            int cardsSize = cards.Count;
            for (int i = 0; i < cardsSize; i++)
            {
                int randomIndex = shuffle.Next(cards.Count);
                shuffleCards.Add(cards[randomIndex]);
                cards.Remove(cards[randomIndex]);
            }

            //Move
            List<Card> discardCards = new List<Card>();
            Random randomCard = new Random();
            int randomCardIndex = randomCard.Next(shuffleCards.Count);
            Card startCard = shuffleCards[randomCardIndex];
            discardCards.Add(startCard);
            shuffleCards.Remove(startCard);
            int shuffleCardsSize = shuffleCards.Count;
            for (int i = 0; i < shuffleCardsSize; i++ )
            {
                for (int j = 0; j < shuffleCards.Count; j++)
                {
                    if (startCard.CardValue == shuffleCards[j].CardValue || startCard.CardSymbol == shuffleCards[j].CardSymbol)
                    {
                        startCard = shuffleCards[j];
                        discardCards.Add(shuffleCards[j]);
                        shuffleCards.Remove(shuffleCards[j]);
                        break;
                    }
                }
            }
            int discardCardsSize = discardCards.Count;
            if (shuffleCards.Count == 0)
            {
                for (int i = 0; i < discardCardsSize; i++)
                {
                        int randomIndex = shuffle.Next(discardCards.Count);
                        shuffleCards.Add(discardCards[randomIndex]);
                        discardCards.Remove(discardCards[randomIndex]);
                }
            }
            Application.Run(new Form1());
        }
    }
}

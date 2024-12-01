using Macao.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Macao
{
    public class Game
    {
        public Player PlayerTurn { get; set; } = new Player();

        public Card StartCard { get; set; }

        public Deck StartDeck { get; set; }

        public Deck Player1Deck { get; set; } = new Deck();

        public Deck Player2Deck { get; set; } = new Deck();

        public Deck CreateDeck()
        {
            Deck deck = new Deck();
            string fileName = @"C:\ProjectsGit\PersonalProjects\MacaoProject\Macao\Pictures\";
            string[] picture = Directory.GetFiles(fileName);

            int index = 0;
            for (CardValueEnum value = CardValueEnum.Two; value <= CardValueEnum.King; value++)
            {
                for (CardSymbolEnum symbol = CardSymbolEnum.Club; symbol <= CardSymbolEnum.Spade; symbol++)
                {
                    Card card = new Card(value, symbol, picture[index]);
                    deck.Cards.Add(card);
                    index++;
                }
            }
            return deck;
        }

        public void DisplayWinner()
        {

        }

        public void NextTurn()
        {

        }

        public void StartGame()
        {
            StartDeck = CreateDeck();
            StartDeck.Shuffle();
        }

        public void ShowHand()
        {

        }
    }
}

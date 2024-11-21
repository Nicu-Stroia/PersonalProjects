using Macao.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macao
{
    public partial class GamePlaceForm : Form
    {
        public List<PictureBox> Player1Cards {  get; set; } = new List<PictureBox>();

        public List<PictureBox> Player2Cards { get; set; } = new List<PictureBox>();

        public List<PictureBox> RemainingCards { get; set; } = new List<PictureBox>();

        public List<PictureBox> DiscardCards { get; set; } = new List<PictureBox>();

        public GamePlaceForm()
        {
            InitializeComponent();
        }

        private void SetStartCard(Game game)
        {
            int n = game.StartDeck.Cards.Count;
            Card startCard = new Card();
            startCard = game.StartDeck.Cards[0];
            game.StartDeck.Cards.Remove(startCard);
            InitialCard.Image = Image.FromFile(startCard.Picture);
        }
        private void AddPlayer1Cards(Game game)
        {
            Player1Cards.Add(Player1Card1);
            Player1Cards.Add(Player1Card2);
            Player1Cards.Add(Player1Card3);
            Player1Cards.Add(Player1Card4);
            Player1Cards.Add(Player1Card5);

            Card randomPlayerCard = new Card();
            foreach(PictureBox pictureCard in Player1Cards)
            {
                randomPlayerCard = game.StartDeck.Cards[0];
                pictureCard.Image = Image.FromFile(randomPlayerCard.Picture);
                game.StartDeck.Cards.Remove(randomPlayerCard);
            }
        }

        private void AddPlayer2Cards(Game game)
        {
            Player2Cards.Add(Player2Card1);
            Player2Cards.Add(Player2Card2);
            Player2Cards.Add(Player2Card3);
            Player2Cards.Add(Player2Card4);
            Player2Cards.Add(Player2Card5);

            Card randomPlayerCard = new Card();
            foreach (PictureBox pictureCard in Player2Cards)
            {
                randomPlayerCard = game.StartDeck.Cards[0];
                pictureCard.Image = Image.FromFile(randomPlayerCard.Picture);
                game.StartDeck.Cards.Remove(randomPlayerCard);
            }
        }

        private void AddRemainingCards(Game game)
        {
            int startDeckSize = game.StartDeck.Cards.Count;
            for (int i = 0; i < startDeckSize; i++)
            {
                PictureBox pictureCardsInitialDeck = new PictureBox();
                RemainingCards.Add(pictureCardsInitialDeck);
            }

            Card randomCard = new Card();
            int cardCount = 0;
            foreach(PictureBox pictureCard in RemainingCards)
            {
                randomCard = game.StartDeck.Cards[cardCount];
                pictureCard.Image = Image.FromFile(randomCard.Picture);
                cardCount++;
            }
        }

        private void AddToDiscardDeck(Game game)
        {
            foreach (PictureBox pictureCard in RemainingCards)
            {
                DiscardCards.Add(pictureCard);
            }
        }

        private void SetCardBack()
        {
            Deck deck = new Deck();
            deck.CardBack.Picture = MacaoConstants.BackCardImagePath;
            InitialDeck.Image = Image.FromFile(deck.CardBack.Picture);
        }

        private void GamePlaceForm_Load(object sender, EventArgs e)
        {
            Game newGame = new Game();
            newGame.StartGame();

            SetStartCard(newGame);

            AddPlayer1Cards(newGame);

            AddPlayer2Cards(newGame);

            AddRemainingCards(newGame);

            AddToDiscardDeck(newGame);

            SetCardBack();
        }
        private void InitialDeck_MouseClick(object sender, MouseEventArgs e)
        {
            if (RemainingCards.Count > 0)
            {
                DiscardDeck.Image = RemainingCards[0].Image;
                RemainingCards.RemoveAt(0);
            }
            if(RemainingCards.Count ==0)
            {
                InitialDeck.Image = null;
                MessageBox.Show("There are no more cards");
            }
        }
    }
}

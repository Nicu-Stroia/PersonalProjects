using Macao.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
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

        Game newGame = new Game();

        public GamePlaceForm()
        {
            InitializeComponent();
        }

        private void SetStartCard(Game game)
        {
            game.StartCard = game.StartDeck.Cards[0];
            game.StartDeck.Cards.Remove(game.StartCard);
            InitialCard.Image = Image.FromFile(game.StartCard.Picture);
        }

        private void AddPlayer1Cards(Game game)
        {
            Player1Cards.Add(Player1Card1);
            Player1Cards.Add(Player1Card2);
            Player1Cards.Add(Player1Card3);
            Player1Cards.Add(Player1Card4);
            Player1Cards.Add(Player1Card5);

            Card randomPlayerCard = new Card();
            foreach (PictureBox pictureCard in Player1Cards)
            {
                randomPlayerCard = game.StartDeck.Cards[0];
                game.Player1Deck.Cards.Add(randomPlayerCard);
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
                game.Player2Deck.Cards.Add(randomPlayerCard);
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

        private void AddToDiscardDeck()
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

        private void WhoStarts(Game game)
        {
            Random randomTurn = new Random();
            int playerTurn = 0;
            if (playerTurn == 0)
            {
                playerTurn = randomTurn.Next(1, 3);
            }
            if (playerTurn == 1)
            {
                game.PlayerTurn.Name = Player1.Text;
                MessageBox.Show("Player1 starts");
            }
            if (playerTurn == 2)
            {
                game.PlayerTurn.Name = Player2.Text;
                MessageBox.Show("Player2 starts");
            }
        }

        private bool ManageTurn(Label playerLabel)
        {
            if (playerLabel.Text == newGame.PlayerTurn.Name)
            {
                if(playerLabel.Text == Player1.Text)
                {
                    newGame.PlayerTurn.Name = Player2.Text;
                }
                if(playerLabel.Text == Player2.Text)
                {
                    newGame.PlayerTurn.Name = Player1.Text;
                }
                return true;
            }
            else
            {
                MessageBox.Show("It's the other player's turn");
                return false;
            }
        }

        private void GamePlaceForm_Load(object sender, EventArgs e)
        {
            newGame.StartGame();

            SetStartCard(newGame);

            AddPlayer1Cards(newGame);

            AddPlayer2Cards(newGame);

            AddRemainingCards(newGame);

            SetCardBack();

            WhoStarts(newGame);
        }
        private void InitialDeck_MouseClick(object sender, MouseEventArgs e)
        {
            if (RemainingCards.Count > 0)
            {
                DiscardDeck.Image = RemainingCards[0].Image;
                RemainingCards.RemoveAt(0);
            }
            if (RemainingCards.Count == 0)
            {
                InitialDeck.Image = null;
                MessageBox.Show("There are no more cards");
            }
        }

        private void ClickOnACard(PictureBox pictureCard, Card card)
        {
            if(card.Validation(card, newGame.StartCard) == true && pictureCard.Image != null)
            {
                newGame.StartCard = card;
                InitialCard.Image = pictureCard.Image;
                pictureCard.Image = null;
            }
        }

        private void Player1Card1_Click(object sender, EventArgs e)
        {
            if (ManageTurn(Player1) == true)
            {
                ClickOnACard(Player1Card1, newGame.Player1Deck.Cards[0]);
            }
            
        }

        private void Player1Card2_Click(object sender, EventArgs e)
        {
            if (ManageTurn(Player1) == true)
            {
                ClickOnACard(Player1Card2, newGame.Player1Deck.Cards[1]);
            }
        }

        private void Player1Card3_Click(object sender, EventArgs e)
        {
            if (ManageTurn(Player1) == true)
            {
                ClickOnACard(Player1Card3, newGame.Player1Deck.Cards[2]);
            }
        }

        private void Player1Card4_Click(object sender, EventArgs e)
        {
            if (ManageTurn(Player1) == true)
            {
                ClickOnACard(Player1Card4, newGame.Player1Deck.Cards[3]);
            }
        }

        private void Player1Card5_Click(object sender, EventArgs e)
        {
            if (ManageTurn(Player1) == true)
            {
                ClickOnACard(Player1Card5, newGame.Player1Deck.Cards[4]);
            }
        }

        private void Player2Card1_Click(object sender, EventArgs e)
        {
            if(ManageTurn(Player2) == true)
            {
                ClickOnACard(Player2Card1, newGame.Player2Deck.Cards[0]);
            }
        }

        private void Player2Card2_Click(object sender, EventArgs e)
        {
            if (ManageTurn(Player2) == true)
            {
                ClickOnACard(Player2Card2, newGame.Player2Deck.Cards[1]);
            }
        }

        private void Player2Card3_Click(object sender, EventArgs e)
        {
            if (ManageTurn(Player2) == true)
            {
                ClickOnACard(Player2Card3, newGame.Player2Deck.Cards[2]);
            }
        }

        private void Player2Card4_Click(object sender, EventArgs e)
        {
            if (ManageTurn(Player2) == true)
            {
                ClickOnACard(Player2Card4, newGame.Player2Deck.Cards[3]);
            }
        }

        private void Player2Card5_Click(object sender, EventArgs e)
        {
            if (ManageTurn(Player2) == true)
            {
                ClickOnACard(Player2Card5, newGame.Player2Deck.Cards[4]);
            }
        }
    }
}

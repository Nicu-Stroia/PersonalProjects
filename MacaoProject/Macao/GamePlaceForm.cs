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

        public List<PictureBox> MoveCards { get; set; } = new List<PictureBox>();

        public GamePlaceForm()
        {
            InitializeComponent();
        }

        public void AddPlayer1Cards(PictureBox picture)
        {
            Player1Cards.Add(picture);
        }

        public void AddPlayer2Cards(PictureBox picture)
        {
            Player2Cards.Add(picture);
        }

        private void GamePlaceForm_Load(object sender, EventArgs e)
        {
            Deck deck = new Deck();
            Game newGame = new Game();
            Deck startDeck = newGame.CreateDeck();
            newGame.StartGame(startDeck);

            int startDeckSize = startDeck.Cards.Count;
            int counterPlayerCard = 0;
            Card startCard = new Card();
            startCard = startDeck.Cards[counterPlayerCard];
            InitialCard.Image = Image.FromFile(startCard.Picture);
            startDeck.Cards.Remove(startCard);

            Card randomPlayerCard = new Card();
            AddPlayer1Cards(Player1Card1);
            AddPlayer1Cards(Player1Card2);
            AddPlayer1Cards(Player1Card3);
            AddPlayer1Cards(Player1Card4);
            AddPlayer1Cards(Player1Card5);
            foreach (PictureBox pictureCard in Player1Cards)
            {
                randomPlayerCard = startDeck.Cards[counterPlayerCard];
                pictureCard.Image = Image.FromFile(randomPlayerCard.Picture);
                startDeck.Cards.Remove(randomPlayerCard);
            }

            AddPlayer2Cards(Player2Card1);
            AddPlayer2Cards(Player2Card2);
            AddPlayer2Cards(Player2Card3);
            AddPlayer2Cards(Player2Card4);
            AddPlayer2Cards(Player2Card5);
            foreach (PictureBox pictureCard in Player2Cards)
            {
                randomPlayerCard = startDeck.Cards[counterPlayerCard];
                pictureCard.Image = Image.FromFile(randomPlayerCard.Picture);
                startDeck.Cards.Remove(randomPlayerCard);
            }

            for (int i = Player1Cards.Count + Player2Cards.Count + 1; i < startDeckSize; i++)
            {
                PictureBox pictureCardsInitialDeck = new PictureBox();
                RemainingCards.Add(pictureCardsInitialDeck);
            }
            foreach (PictureBox pictureCard in RemainingCards)
            {
                randomPlayerCard = startDeck.Cards[counterPlayerCard];
                pictureCard.Image = Image.FromFile(randomPlayerCard.Picture);
                counterPlayerCard++;
            }
            foreach(PictureBox pictureCard in RemainingCards)
            {
                MoveCards.Add(pictureCard);
            }

            deck.CardBack.Picture = @"C:\ProjectsGit\PersonalProjects\MacaoProject\Macao\Pictures\CardBack.png";
            InitialDeck.Image = Image.FromFile(deck.CardBack.Picture);
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

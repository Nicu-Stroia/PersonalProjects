using Macao.Enums;
using Macao.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Macao
{
    public partial class GamePlaceForm : Form
    {
        private List<PictureBox> DrawDeckPictureBoxes { get; set; } = new List<PictureBox>();

        private List<PictureBox> DiscardDeckPictureBoxes { get; set; } = new List<PictureBox>();


        private Game newGame = new Game();

        public GamePlaceForm()
        {
            InitializeComponent();

            FormClosing += CloseApplication;
        }  

        private void CloseApplication(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CreatePictureBox(PictureBox card, int posX, int posY)
        {
            card.Size = new Size(130, 180);
            card.Location = new Point(posX, posY);
            card.BorderStyle = BorderStyle.FixedSingle;
            card.SizeMode = PictureBoxSizeMode.StretchImage;
            card.Click += ClickOnACard;
            this.Controls.Add(card);
        }

        private void SetStartCard()
        {
            PictureBox initialCard = new PictureBox();
            int posX = 460;
            int posY = 310;
            CreatePictureBox(initialCard, posX, posY);
            initialCard.Image = Image.FromFile(newGame.TopCard.Picture);
        }

        private void CreatePictureBoxesForPlayerCards(Player player)
        {
            for (int i = 0; i < player.Deck.Cards.Count; i++)
            {
                Card playerCard = player.Deck.Cards[i];

                PictureBox pictureBox = new PictureBox();
                CreatePictureBox(pictureBox, player.CardPositionX, player.CardPositionY);

                player.CardPositionX += 80;
                pictureBox.Tag = playerCard;
                pictureBox.Image = Image.FromFile(playerCard.Picture);
            }
        }

        private void AddPictureBoxesForDrawDeck()
        {
            int drawDeckSize = newGame.DrawDeck.Cards.Count;
            for (int i = 0; i < drawDeckSize; i++)
            {
                PictureBox pictureCardsInitialDeck = new PictureBox();
                DrawDeckPictureBoxes.Add(pictureCardsInitialDeck);
            }

            int cardCount = 0;
            foreach (PictureBox pictureCard in DrawDeckPictureBoxes)
            {
                Card randomCard = newGame.DrawDeck.Cards[cardCount];
                pictureCard.Tag = randomCard;
                pictureCard.Image = Image.FromFile(randomCard.Picture);
                cardCount++;
            }
        }

        private void RebuildDrawDeckPictureBoxes()
        {
            if(DrawDeckPictureBoxes.Count != 0)
            {
                DrawDeckPictureBoxes.Clear();
            }
            AddPictureBoxesForDrawDeck();
        }

        private void SetReaminingDeckBack()
        {
            int posX = 1000;
            int posY = 310;
            PictureBox pictureCardBack = new PictureBox();
            CreatePictureBox(pictureCardBack, posX, posY);
            newGame.DrawDeck.CardBack.Picture = MacaoConstants.BackCardImagePath;
            pictureCardBack.Image = Image.FromFile(newGame.DrawDeck.CardBack.Picture);

        }

        private void SetFirstPlayer()
        {
            int playerOrder;
            Random randomTurn = new Random();
            playerOrder = randomTurn.Next(1, 3);
            newGame.SetStartingPlayer(playerOrder);
            if (playerOrder == 1)
            {
                MessageBox.Show("Player1 starts");
                HighlightPlayerName();
            }
            if (playerOrder == 2)
            {
                MessageBox.Show("Player2 starts");
                HighlightPlayerName();
            }
        }



        private void GamePlaceForm_Load(object sender, EventArgs e)
        {
            newGame.StartGame();

            SetStartCard();

            CreatePictureBoxesForPlayerCards(newGame.Player1);
            CreatePictureBoxesForPlayerCards(newGame.Player2);

            AddPictureBoxesForDrawDeck();

            SetReaminingDeckBack();

            SetFirstPlayer();
        }

        private void ArrangePlayerCards(Player player)
        {
            player.CardPositionX += 80;
            if (player.CardPositionX > 1340)
            {
                player.CardPositionX = 300;
                player.CardPositionY += 100;
            }
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            if (newGame.DrawDeck.Cards.Count > 0)
            {
                PictureBox drawCardPicture = new PictureBox();
                Card drawnCard = newGame.DrawDeck.Cards[0];
                if (newGame.PlayerTurn == newGame.Player1.Name)
                {
                    drawCardPicture = DrawDeckPictureBoxes[0];

                    CreatePictureBox(drawCardPicture, newGame.Player1.CardPositionX, newGame.Player1.CardPositionY);
                    ArrangePlayerCards(newGame.Player1);

                    newGame.Player1.DrawCard(drawnCard);

                    HighlightAndSwitchTurn();
                }
                else
                {
                    drawCardPicture = DrawDeckPictureBoxes[0];

                    CreatePictureBox(drawCardPicture, newGame.Player2.CardPositionX, newGame.Player2.CardPositionY);
                    ArrangePlayerCards(newGame.Player2);                   
                   
                    newGame.Player2.DrawCard(drawnCard);

                    HighlightAndSwitchTurn();
                }
                newGame.DrawDeck.Cards.RemoveAt(0);
                DrawDeckPictureBoxes.RemoveAt(0);
            }
            else
            {
                MessageBox.Show("Press the 'Rebuild Draw Deck' button to regenerate the draw deck.");
            }
        }

        private void RebuildDrawDeckButton_Click(object sender, EventArgs e)
        {
            if (newGame.IsDrawDeckRebuildNeeded())
            {
                newGame.RebuidDrawDeck();
                RebuildDrawDeckPictureBoxes();
            }
            else
            {
                MessageBox.Show("The draw deck already contains the cards.");
            }
        }

        private void HighlightPlayerName()
        {
            if (newGame.IsAllowedToPlaceCard(newGame.Player1))
            {
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Underline);
                Player2Label.Font = new Font(Player2Label.Font, FontStyle.Regular);
            }
            else
            {
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Regular);
                Player2Label.Font = new Font(Player2Label.Font, FontStyle.Underline);
            }
        }

        private void AdjustTopCard(PictureBox clickedCard, Card topCard, Card playerCard, Player currentPlayer)
        {
            currentPlayer.PlaceCard(topCard, playerCard);
            newGame.DiscardDeck.AddToDiscardDeck(playerCard);

            clickedCard.Location = new Point(460, 310);
            clickedCard.BringToFront();

        }

        private void HighlightAndSwitchTurn()
        {
            newGame.SwitchTurn();
            HighlightPlayerName();
        }

        private void AddPictureBoxesForCardsToDraw(Player afectedPlayer, int numberOfCards)
        {
            PictureBox drawnCard = null;
            if (DrawDeckPictureBoxes.Count < numberOfCards)
            {
                RebuildDrawDeckPictureBoxes();
            }
            for (int i = 1; i <= numberOfCards; i++)
            {
                drawnCard = DrawDeckPictureBoxes[0];
                CreatePictureBox(drawnCard, afectedPlayer.CardPositionX, afectedPlayer.CardPositionY);

                ArrangePlayerCards(afectedPlayer);

                DrawDeckPictureBoxes.RemoveAt(0);
                newGame.DrawDeck.Cards.RemoveAt(0);
            }
        }

        private void DisplayCardsToDraw(Player currentPlayer, int numberOfCards)
        {
            
            if (currentPlayer.Name == newGame.Player1.Name)
            {
                AddPictureBoxesForCardsToDraw(newGame.Player2, numberOfCards);
            }
            else
            {
                AddPictureBoxesForCardsToDraw(newGame.Player1, numberOfCards);
            }
        }

        private void DisplayWinner(Player currentPlayer)
        {
            if (newGame.IsWinner(currentPlayer))
            {
                MessageBox.Show(currentPlayer.Name + " win the game");
                this.Close();
            }
        }


        private void ClickOnACard(object sender, EventArgs e)
        {
            PictureBox clickedCard = sender as PictureBox;
            if (clickedCard != null && clickedCard.Tag is Card playerCard)
            {

                Player playerOwner = newGame.GetCardOwner(playerCard);
                if (newGame.IsAllowedToPlaceCard(playerOwner))
                {
                    if (playerCard.IsMoveValid(newGame.TopCard))
                    {
                        AdjustTopCard(clickedCard, newGame.TopCard, playerCard, playerOwner);
                        if (playerCard.Effect != CardEffectEnum.NoEffect)
                        {
                            if (playerCard.Effect == CardEffectEnum.ChangeColor)
                            {
                                ChooseColorForm chooseColor = new ChooseColorForm();
                                DialogResult result = chooseColor.ShowDialog();
                                playerCard.Symbol = chooseColor.SelectedOption;
                                HighlightAndSwitchTurn();
                            }

                            if (playerCard.Effect == CardEffectEnum.TakeTwoCards)
                            {
                                DisplayCardsToDraw(playerOwner, 2);
                            }

                            if (playerCard.Effect == CardEffectEnum.TakeThreeCards)
                            {
                                DisplayCardsToDraw(playerOwner, 3);
                            }

                            newGame.ApplyEffect(playerCard, playerOwner);
                        }
                        else
                        {
                            HighlightAndSwitchTurn();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This card doesn’t match with the current card");
                    }
                }
                else
                {
                    MessageBox.Show("It's the other player's turn");
                }
                DisplayWinner(playerOwner);
            }
        }


    }
}

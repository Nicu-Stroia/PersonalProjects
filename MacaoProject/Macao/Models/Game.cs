using Macao.Enums;
using Macao.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        public string PlayerTurn { get; set; }

        public Card TopCard { get; set; } = new Card();

        public Deck DrawDeck { get; set; } = new Deck();

        public Deck DiscardDeck { get; set; } = new Deck();

        public Player Player1 { get; set; } = new Player();

        public Player Player2 { get; set; } = new Player();

        public Deck CreateDrawDeck()
        {
            string fileName = @"C:\ProjectsGit\PersonalProjects\MacaoProject\Macao\Pictures\";
            string[] picture = Directory.GetFiles(fileName);
            int index = 0;

            for (CardValueEnum value = CardValueEnum.Two; value <= CardValueEnum.King; value++)
            {
                for (CardSymbolEnum symbol = CardSymbolEnum.Club; symbol <= CardSymbolEnum.Spade; symbol++)
                {
                    Card card = new Card(value, symbol, picture[index]);

                    if (card.Value == CardValueEnum.Two)
                    {
                        card = new CardTwo(card);
                    }

                    if (card.Value == CardValueEnum.Seven)
                    {
                        card = new CardSeven(card);
                    }

                    if (card.Value == CardValueEnum.Ace)
                    {
                        card = new CardA(card);
                    }

                    if (card.Value == CardValueEnum.Jack)
                    {
                        card = new CardJ(card);
                    }

                    DrawDeck.Cards.Add(card);
                    index++;
                }
            }
            return DrawDeck;
        }

        public void StartGame()
        {
            Player1.Name = "Player1";
            Player2.Name = "Player2";

            Player1.CardPositionX = 300;
            Player1.CardPositionY = 0;

            Player2.CardPositionX = 300;
            Player2.CardPositionY = 520;

            CreateDrawDeck();
            DrawDeck.Shuffle();

            TopCard.Value = DrawDeck.Cards[0].Value;
            TopCard.Symbol = DrawDeck.Cards[0].Symbol;
            TopCard.Picture = DrawDeck.Cards[0].Picture;
            DiscardDeck.AddToDiscardDeck(DrawDeck.Cards[0]);
            DrawDeck.Cards.RemoveAt(0);

            AddCardsToPlayer(Player1);
            AddCardsToPlayer(Player2);
        }

        public void AddCardsToPlayer(Player newPlayer)
        {
            Card randomPlayerCard = new Card();
            for (int i = 0; i < 5; i++)
            {
                randomPlayerCard = DrawDeck.Cards[i];
                newPlayer.Deck.Cards.Add(randomPlayerCard);
            }

            for (int i = 0; i < 5; i++)
            {
                DrawDeck.Cards.RemoveAt(0);
            }
        }

        public void SetStartingPlayer(int playerOrder)
        {
            if (playerOrder == 1)
            {
                PlayerTurn = Player1.Name;
            }
            if (playerOrder == 2)
            {
                PlayerTurn = Player2.Name;
            }
        }

        public Player GetCardOwner(Card currentPlayerCard)
        {
            foreach (Card player1Card in Player1.Deck.Cards)
            {
                if (player1Card.Value == currentPlayerCard.Value && player1Card.Symbol == currentPlayerCard.Symbol)
                {
                    return Player1;
                }
            }

            foreach (Card player2Card in Player2.Deck.Cards)
            {
                if (player2Card.Value == currentPlayerCard.Value && player2Card.Symbol == currentPlayerCard.Symbol)
                {
                    return Player2;
                }
            }

            return null;
        }

        public bool IsAllowedToPlaceCard(Player currentPlayer)
        {
            if (PlayerTurn == currentPlayer.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SwitchTurn()
        {
            if (PlayerTurn == Player1.Name)
            {
                PlayerTurn = Player2.Name;
            }
            else
            {
                PlayerTurn = Player1.Name;
            }
        }

        public bool IsOponnentAbleToRespondWithACard(Player afectedPlayer)
        {
            if(PlayerTurn != afectedPlayer.Name)
            {
                return true;
            }
            return false;
        }

        public void DrawCardsForPlayer(Player afectedPlayer, int numberOfCards)
        {
            if(DrawDeck.Cards.Count < numberOfCards && DrawDeck.Cards.Count != 0)
            {
                RebuidDrawDeck();
            }
            for (int i = 0; i < numberOfCards; i++)
            {
                afectedPlayer.DrawCard(DrawDeck.Cards[i]);
            }
        }

        public void TakeTwoOrThreeCards(Player currentPlayer, int numberOfCards)
        {
            if (currentPlayer.Name == Player1.Name)
            {
                DrawCardsForPlayer(Player2, numberOfCards);
            }
            else
            {
                DrawCardsForPlayer(Player1, numberOfCards);
            }
        }

        public void SelectedSymbol(CardSymbolEnum currentCardSymbol)
        {
            TopCard.Symbol = currentCardSymbol;
        }

        public void ApplyEffect(Card currentCard, Player currentPlayer)
        {
            switch (currentCard.Effect)
            {
                case CardEffectEnum.SkipATurn:
                    PlayerTurn = currentPlayer.Name;
                    break;

                case CardEffectEnum.TakeTwoCards:
                    TakeTwoOrThreeCards(currentPlayer, 2);
                    break;

                case CardEffectEnum.TakeThreeCards:
                    TakeTwoOrThreeCards(currentPlayer, 3);
                    break;

                case CardEffectEnum.ChangeColor:
                    SelectedSymbol(currentCard.Symbol);
                    break;

                case CardEffectEnum.NoEffect:
                default:
                    break;
            }

        }

        public bool IsWinner(Player currentPlayer)
        {
            if (currentPlayer.Deck.Cards.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsDrawDeckRebuildNeeded()
        {
            if (DrawDeck.Cards.Count == 0)
            {
                return true;
            }
            return false;
        }

        public Deck RebuidDrawDeck()
        {
            DiscardDeck.Shuffle();
            
            for (int i = 0; i < DiscardDeck.Cards.Count - 1; i++)
            {
                DrawDeck.Cards.Add(DiscardDeck.Cards[i]);

            }
            if (DrawDeck.Cards.Count > 0 && DrawDeck.Cards.Count <= 3)
            {
                int drawDeckSize = DrawDeck.Cards.Count-1;
                for (int i = 0; i < drawDeckSize; i++)
                {
                    DiscardDeck.Cards.RemoveAt(0);
                }
            }
            else
            {
                for (int i = 0; i < DrawDeck.Cards.Count; i++)
                {
                    DiscardDeck.Cards.RemoveAt(0);
                }
            }
            return DrawDeck;
        }
    }
}

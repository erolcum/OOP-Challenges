using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spades
{
    public class Game
    {
        private bool suitBroken;
        public Deck Deck { get; set; }
        public Player[] players = new Player[4];
        public Game() 
        {
            int idx;
            int j = 1;
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            do
            {
                Console.Write("Enter your index (0-3) : ");
                idx = int.Parse(Console.ReadLine());
            } while (idx < 0 || idx > 3);
           for (int i = 0; i < 4; i++) 
            { 
                if (i== idx) { players[i] = new HumanPlayer(name); }
                else 
                { 
                    players[i] = new ComputerPlayer("Comp-" + j);
                    j++;
                }
            }

            Deck = new Deck();
            
        }

        public Card singlePlay(int playerIndex, Suit followedSuit, bool firstPlayer) 
        {
            Card playedCard = players[playerIndex].playCard(firstPlayer, suitBroken, followedSuit);
            if (playedCard.Suit == Suit.SPADES) suitBroken = true;
            Console.Write(playedCard.ToString() + " ");
            players[playerIndex].Hand.removeCard(playedCard);
            return playedCard;
        }
        // return is the winner of the turn
        public int playTurn(int playerIndex) 
        {
            Card playedCard, winnerCard;
            int winnerIndex = playerIndex;
            Suit followedSuit = Suit.HEARTS;
            winnerCard = singlePlay(playerIndex, followedSuit, true);
            followedSuit = winnerCard.Suit;
            playerIndex = (playerIndex + 1) % 4;
            for (int i = 0; i < 3; i++)
            {
                playedCard = singlePlay(playerIndex, followedSuit, false);
                if (playedCard.CompareTo(winnerCard) > 0) 
                { 
                    winnerCard = playedCard;
                    winnerIndex = playerIndex;
                }
                playerIndex = (playerIndex + 1) % 4;
            }
            Console.WriteLine();
            return winnerIndex;
        }

        public void displayDeck() 
        {
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine(players[j].displayHand());
            }

        }
        // play 13 turns
        public void playHand() 
        {
            int firstPlayer = 0;
            suitBroken = false;
            Deck.shuffle();
            for (int i = 0; i < 4; i++) 
            {
                players[i].initializeHand();
            }    
            Deck.dealAllCards(players);
            for (int i = 0; i < 4; i++)
            {
                players[i].Hand.sortCards();
            }

            displayDeck();
            biddingStage();
            for (int i = 0; i < 13; i++) 
            {
                firstPlayer = playTurn(firstPlayer);
                Console.WriteLine(players[firstPlayer].Name + " has won the turn!");
                players[firstPlayer].Tricks ++;
                if (i != 12) 
                {
                    displayDeck();
                }
                
            }
            for (int i = 0; i < 4; i++) 
            {
                players[i].calculatePoints();
            }
        }

        public void playGame()
        {
            playHand();
            while (!gameOver()) { playHand(); }
            Player winner = winnerOfTheGame();
            Console.WriteLine("\nWinner is " + winner.Name);
        }

        public void biddingStage() 
        {
            for (int i = 0; i < 4; i++) 
            {
                if (players[i] is ComputerPlayer ) 
                {
                    Console.WriteLine(players[i].Name + "'s bid : " + players[i].makeBid());
                }else players[i].makeBid();
            }
        }

        public Player winnerOfTheGame() 
        { 
            Player winner = null;
            for (int i = 0; i < 4; i++)
            {
                if (players[i].Points >= 500)
                {
                    winner  = players[i];
                }
            }
            return winner;
        }
        public bool gameOver() 
        {
            for (int i = 0; i < 4; i++) 
            {
                if (players[i].Points >= 500) 
                { 
                    return true;
                }
            }
            return false;
        }
    }
}

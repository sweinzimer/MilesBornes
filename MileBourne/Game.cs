using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MileBourne
{
    class Game
    {

        
        public ICommand StartCommand { get { Start(); return null; } }
        public List<Player> playerList { get; } = new List<Player>();
        public int turnCount = 0;
        public async void Start()
        {
            

            for (int i = 0; i < 7; i++)
            {
                foreach (Player player in playerList)
                    player.Draw();

            }

            bool gameOver = false;
            while (!gameOver)
            {
                foreach (Player player in playerList)
                {
                    Task<bool> gameDone = player.Turn();
                    if (await gameDone && !player.Extending)
                    {
                        if (!player.Extending)
                        {
                            if(playerList.IndexOf(player)==1)
                            {
                                if (player.Score > 5000) { gameOver = true; }
                                if (playerList[0].Score > 4659) { gameOver = true; }
                                if (Deck.CardCount() < 16) { gameOver = true; }
                                if (player.SpeedStackTop is Cards.Hazard) { gameOver = true; };
                                if (playerList[0].Extending) { gameOver = true; }
                                
                                if (!gameOver)
                                {
                                    player.Extending = true;
                                }
                                
                            }
                            else
                            {
                                MessageBoxResult res =   MessageBox.Show($"Do you want to extend to 1000km {player.PlayerName}?", "", MessageBoxButton.YesNo);
                                if (res== MessageBoxResult.Yes)
                                {
                                    player.Extending = true;
                                }
                                else
                                {
                                    gameOver = true;
                                }
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }

                    
                    turnCount++;
                }
               // System.Threading.Thread.Sleep(10 * 1000);

            }

            int a = playerList[0].Score;
            int b = playerList[1].Score;
            playerList[0].OnPropertyChanged(nameof(Player.DistanceTraveled));
            playerList[0].OnPropertyChanged(nameof(Player.Score));
            playerList[1].OnPropertyChanged(nameof(Player.DistanceTraveled));
            playerList[1].OnPropertyChanged(nameof(Player.Score));



            if (a> 5000 || b > 5000)
            {
                if (a > b)
                { MessageBox.Show($"{playerList[0].PlayerName} Wins!"); }
                else
                { MessageBox.Show($"{playerList[1].PlayerName} Wins!"); }
            }else
            {
                Deck = new Deck();
                playerList[0].nextRound(Deck);
                playerList[1].nextRound(Deck);
                Start();
            }
          




        }
        public Deck Deck { get; set; }
        
        public Game()
        {

            Deck = new Deck();
            playerList.Add(new Player("Paul", 1, Deck, this));
            playerList.Add(new Player("Betty", 2, Deck, this));


        }


        public bool isGameOver() { return false; }
		

    }
}

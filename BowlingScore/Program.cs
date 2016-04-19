using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Read number of players from the console
                Console.WriteLine("Please enter the number of players: ");
                int numberOfPlayers = 0;
                while (!int.TryParse(Console.ReadLine(), out numberOfPlayers) || numberOfPlayers < 1)
                {
                    Console.WriteLine("The value you entered is not correct (example: 2)");
                };

                //Create new players
                List<Player> gamePlayers = new List<Player>();

                for(int playerCount =0; playerCount < numberOfPlayers; playerCount++)
                {
                    // prompt user to enter player names and get a name for each player
                    Console.WriteLine("Please enter a name for player {0}: ", playerCount + 1);
                    gamePlayers.Add(new Player(Console.ReadLine()));
                }

                //Loop through the frames of the game
                for (int frameNumber = 1; frameNumber <= 10; frameNumber++)
                {
                    Console.WriteLine("************************************");
                    Console.WriteLine("Frame {0}.", frameNumber);

                    //Loop through each player's term inside each frame
                    foreach (var player in gamePlayers)
                    {
                        PlayThroughFrame(player, frameNumber);
                    }
                }

                OutputFinalScore(gamePlayers);

            }
            catch(Exception e)
            {
                Console.WriteLine("There was an unexpected problem: {0}", e.Message);
            }

            Console.ReadLine();
        }

        public static void OutputFinalScore(List<Player> gamePlayers)
        {
            Player winner = new Player("winner");
            bool tieGame = false;

            Console.WriteLine("*************************************");
            Console.WriteLine("*******      End Of Game      *******");
            Console.WriteLine("*************************************");

            //Calculate the scores for each players
            foreach (var player in gamePlayers)
            {
                player.Score = player.CalculatePlayerScore();
                Console.WriteLine("{0} had a score of {1}", player.Name, player.Score);

                // check to see if it is a tie game
                if (player.Score == winner.Score && winner.Name != "winner")
                {
                    tieGame = true;
                    winner.Name += string.Format(" and {0}", player.Name);
                }

                // see if the current player is the winner
                if (player.Score > winner.Score || winner.Name == "winner")
                {
                    winner = player;
                    tieGame = false;
                }                
            }

            if(tieGame)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("{0} have tied the game with a score of {1}!", winner.Name, winner.Score);
            }
            else
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("{0} has won the game with a score of {1}!", winner.Name, winner.Score);
            }

            
        }

        public static void PlayThroughFrame(Player player, int frameNumber)
        {
            int pinsStanding = 10;
            int ball = 1;
            int expectedNumberOfBalls = 2;

            Console.WriteLine("{0}'s Turn", player.Name);
            

            do // loop until the frame is done or all of the pins are knocked down
            {
                int pinsKnockedDown = 0;
                bool resultIsCorrect = true;

                do // perform a loop to check for valid input (integer less than or equal to the number of pins standing)
                {
                    Console.WriteLine("Please enter balls knocked down by {0}", player.Name);
                    resultIsCorrect = int.TryParse(Console.ReadLine(), out pinsKnockedDown) && pinsKnockedDown >= 0;

                    if(resultIsCorrect)
                    {
                        resultIsCorrect = player.AddPinsToScore(pinsStanding, pinsKnockedDown);
                        
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number between 0 and {0}", pinsStanding);
                    }

                    //only subtract the number of pins knocked down if it is valid input
                    pinsStanding -= resultIsCorrect ? pinsKnockedDown : 0 ;

                    

                } while (!resultIsCorrect);

                

                //    // add an extra ball if there is a spare
                //if (ball == 2 && pinsStanding == 0)
                //{
                //    Console.WriteLine("{0} has earned an extra throw!", player.Name);
                //    expectedNumberOfBalls++;
                //    // reset the pins to 10
                //    pinsStanding = 10;
                //}
               
                // on the 10th frame...
                if(frameNumber == 10) 
                {
                    // if we get a strike
                    if (ball == 1 && pinsStanding == 0)
                    {
                        Console.WriteLine("{0} has earned 2 extra throws!", player.Name);
                        expectedNumberOfBalls = 3;
                    }

                    // if we get a spare and ball one was not a strike
                    if (ball == 2 && pinsStanding == 0 && expectedNumberOfBalls != 3)
                    {
                        Console.WriteLine("{0} has earned an extra throw!", player.Name);
                        expectedNumberOfBalls = 3 ;
                    }

                    // if we have a bonus ball AND the number of pins standing is zero, then we will
                    pinsStanding = (expectedNumberOfBalls >= ball && pinsStanding == 0) ? 10 : pinsStanding;
                }

                
                // the ball has been thrown in this frame
                ball++;

            } while (pinsStanding > 0 && ball <= expectedNumberOfBalls);
        }

        
    }
}

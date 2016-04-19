using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore
{
    public class Player
    {
        public List<int> PinCount { get; set; }
        public string Name { get; set; }        
        public int Score { get; set; }     
        
        public Player(string playerName)
        {
            Name = playerName;
            Score = 0;
            PinCount = new List<int>();
        }   

        public bool AddPinsToScore(int pinsStanding, int pinsDown)
        {
            if(pinsDown <= pinsStanding)
            {
                Console.WriteLine("{0} Knocked Down {1} pins!", Name, pinsDown);
                PinCount.Add(pinsDown);
                return true;
            }
            else
            {
                Console.WriteLine("{0} cannot knock down more than {1} pins.", Name, pinsStanding);
                return false;
            }
        }      

        public int CalculatePlayerScore()
        {
            Score = Scoring.ComputeScore(PinCount);
            return Score;
        }


    }
}

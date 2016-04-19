using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore
{
    public class Scoring
    {
        public static int ComputeScore(List<int> perBallScores)
        {
            int numberOfBallsThrown = perBallScores.Count;
            int finalScore = 0;
            bool continuingFrame = true;
            int previousBallInFrame = 0;
            int numberOfBallsPlayed=0; //each frame should count as 2 balls played

            //stop execution if there are not enough scores provided
            if (numberOfBallsThrown < 10) { return -1; }
            
            try {
                for (int ballThrown = 0; (ballThrown < numberOfBallsThrown && finalScore < 300); ballThrown++)
                {
                    int currentScore = perBallScores[ballThrown];

                    numberOfBallsPlayed++;

                    if (currentScore == 10) // if there is a strike
                    {
                        finalScore +=  (currentScore + perBallScores[ballThrown + 1] + perBallScores[ballThrown + 2]); // add current score to next two balls

                        numberOfBallsPlayed++; // strike counts as two balls played
                    }

                    else if (currentScore + previousBallInFrame >= 10) //if there is a spare
                    {
                        //break if the user knocked down too many balls on a spare
                        if (currentScore + previousBallInFrame > 10) {
                            return -1; }

                        //increment current score plus the bonus round
                        finalScore += currentScore + perBallScores[ballThrown + 1];
                        
                        //reset score counter for previous ball
                        previousBallInFrame = 0;
                        continuingFrame = !continuingFrame;
                        
                        //if this is the last ball of frame 10, increment the ball counter
                        if(ballThrown+2 == numberOfBallsThrown) { ballThrown++; }
                    }

                    else if (currentScore < 10) // normal ball
                    {
                        //tally score
                        finalScore += currentScore;
                        // set the previous score to current score if it is zero, 
                        // or reset it to zero if it has already been set
                        previousBallInFrame = continuingFrame ? currentScore : 0;
                        continuingFrame = !continuingFrame;
                    }
                    else // invalid input scenario
                    {
                        return -1;
                    }
                }

                if(numberOfBallsPlayed < 20) 
                { return -1; }
            }
            catch (ArgumentOutOfRangeException)
            {
                return -1; // either an extra play on spare or strike is missing
            }

            return finalScore;
        }
    }
}

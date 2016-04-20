using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using BowlingScore;
using System.IO;

namespace BowlingScoreUnitTests
{
    [TestClass]
    public class Main_AcceptanceTests
    {
        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Acceptance")]
        public void SinglePlayerGameCanWinWithoutStrikesOrSpares()
        {
            using (var sw = new StringWriter())
            {
                string testInput = "1\n"    //number of player
                    + "Steve\n"             // Player 1 Name
                    + "2\n" + "2\n"         // Frame 1
                    + "2\n" + "2\n"         // Frame 2
                    + "2\n" + "2\n"         // Frame 3
                    + "2\n" + "2\n"         // Frame 4
                    + "2\n" + "2\n"         // Frame 5
                    + "2\n" + "2\n"         // Frame 6
                    + "2\n" + "2\n"         // Frame 7
                    + "2\n" + "2\n"         // Frame 8
                    + "2\n" + "2\n"         // Frame 9
                    + "2\n" + "2\n";        // Frame 10

                string expectedResult = "Steve has won the game with a score of 40!";
                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.Main(new string[] { "" });

                    // Assert
                    string actualResult = sw.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Last();

                    Assert.AreEqual(expectedResult, actualResult);
                }
            }
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Acceptance")]
        public void SinglePlayerGameCanWinWithALLStrikes()
        {
            using (var sw = new StringWriter())
            {
                string testInput = "1\n"    //number of player
                    + "Steve\n"             // Player 1 Name
                    + "10\n"          // Frame 1
                    + "10\n"         // Frame 2
                    + "10\n"          // Frame 3
                    + "10\n"          // Frame 4
                    + "10\n"          // Frame 5
                    + "10\n"          // Frame 6
                    + "10\n"          // Frame 7
                    + "10\n"          // Frame 8
                    + "10\n"                    // Frame 9
                    + "10\n" + "10\n" + "10\n";        // Frame 10

                string expectedResult = "Steve has won the game with a score of 300!";

                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.Main(new string[] { "" });

                    // Assert
                    string actualResult = sw.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Last();

                    Assert.AreEqual(expectedResult, actualResult);
                }
            }
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Acceptance")]
        public void SinglePlayerGameCanWinWithALLSpares()
        {
            // create a stringwriter to retrieve console output with
            using (var sw = new StringWriter())
            {
                // define the test input data as a string
                string testInput = "1\n"             //number of players
                    + "Steve\n"                      // Player 1 Name
                    + "1\n" + "9\n"         // Frame 1
                    + "2\n" + "8\n"         // Frame 2
                    + "3\n" + "7\n"         // Frame 3
                    + "4\n" + "6\n"         // Frame 4
                    + "5\n" + "5\n"         // Frame 5
                    + "6\n" + "4\n"         // Frame 6
                    + "7\n" + "3\n"         // Frame 7
                    + "8\n" + "2\n"         // Frame 8
                    + "9\n" + "1\n"         // Frame 9
                    + "5\n" + "5\n" + "10\n";      // Frame 10

                string expectedResult = "Steve has won the game with a score of 159!";
                //create a string reader to write to console with
                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.Main(new string[] { "" });

                    // Assert
                    string actualResult = sw.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Last();

                    Assert.AreEqual(expectedResult, actualResult);
                }
            }
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Acceptance")]
        public void SinglePlayerGameCanWinWithScoreOfZero()
        {
            // create a stringwriter to retrieve console output with
            using (var sw = new StringWriter())
            {
                // define the test input data as a string
                string testInput = "1\n"             //number of player
                    + "Steve\n"                      // Player 1 Name
                    + "0\n" + "0\n"         // Frame 1
                    + "0\n" + "0\n"         // Frame 2
                    + "0\n" + "0\n"         // Frame 3
                    + "0\n" + "0\n"         // Frame 4
                    + "0\n" + "0\n"         // Frame 5
                    + "0\n" + "0\n"         // Frame 6
                    + "0\n" + "0\n"         // Frame 7
                    + "0\n" + "0\n"         // Frame 8
                    + "0\n" + "0\n"         // Frame 9
                    + "0\n" + "0\n";        // Frame 10

                string expectedResult = "Steve has won the game with a score of 0!";

                //create a string reader to write to console with
                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.Main(new string[] { "" });

                    // Assert
                    string actualResult = sw.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Last();

                    Assert.AreEqual(expectedResult, actualResult);
                }
            }
        }


        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Acceptance")]
        public void MultiplePlayerGameCanChooseCorrectWinnerWhenPlayerOneWins()
        {
            // create a stringwriter to retrieve console output with
            using (var sw = new StringWriter())
            {
                // define the test input data as a string
                string testInput = "2\n"    //number of players
                    + "Steve\n"             // Player 1 Name
                    + "Renmin\n"            // Player 2 Name
                    + "3\n" + "2\n"         // Frame 1
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 2
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 3
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 4
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 5
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 6
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 7
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 8
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 9
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"        // Frame 10
                    +"2\n" + "2\n";

                string expectedResult = "Steve has won the game with a score of 41!";
                //create a string reader to write to console with
                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.Main(new string[] { "" });

                    // Assert
                    string actualResult = sw.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Last();

                    Assert.AreEqual(expectedResult, actualResult);
                }
            }
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Acceptance")]
        public void MultiplePlayerGameCanChooseCorrectWinnerWhenPlayerTwoWins()
        {
            // create a stringwriter to retrieve console output with
            using (var sw = new StringWriter())
            {
                // define the test input data as a string
                string testInput = "2\n"    //number of players
                    + "Steve\n"             // Player 1 Name
                    + "Renmin\n"            // Player 2 Name
                    + "2\n" + "2\n"         // Frame 1
                    + "3\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 2
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 3
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 4
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 5
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 6
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 7
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 8
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 9
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"        // Frame 10
                    + "2\n" + "2\n";

                string expectedResult = "Renmin has won the game with a score of 41!";
                //create a string reader to write to console with
                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.Main(new string[] { "" });

                    // Assert
                    string actualResult = sw.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Last();

                    Assert.AreEqual(expectedResult, actualResult);
                }
            }
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Acceptance")]
        public void MultiplePlayerGameCanChooseCorrectWinnersWhenThereIsATieGame()
        {
            // create a stringwriter to retrieve console output with
            using (var sw = new StringWriter())
            {
                // define the test input data as a string
                string testInput = "2\n"    //number of players
                    + "Steve\n"             // Player 1 Name
                    + "Renmin\n"            // Player 2 Name
                    + "2\n" + "2\n"         // Frame 1
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 2
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 3
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 4
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 5
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 6
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 7
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 8
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"         // Frame 9
                    + "2\n" + "2\n"
                    + "2\n" + "2\n"        // Frame 10
                    + "2\n" + "2\n";

                string expectedResult = "Steve and Renmin have tied the game with a score of 40!";
                //create a string reader to write to console with
                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.Main(new string[] { "" });

                    // Assert
                    string actualResult = sw.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Last();

                    Assert.AreEqual(expectedResult, actualResult);
                }
            }
        }


        [TestMethod]
        [TestCategory("Negative")]
        [TestCategory("Acceptance")]
        public void SinglePlayerGameDoesNotAllowNegativePlayerCount()
        {
            // create a stringwriter to retrieve console output with
            using (var sw = new StringWriter())
            {
                // define the test input data as a string
                string testInput = "-1\n" + "1\n"    //incorrect, then correct number of player
                    + "Steve\n"                      // Player 1 Name
                    + "0\n" + "0\n"         // Frame 1
                    + "0\n" + "0\n"         // Frame 2
                    + "0\n" + "0\n"         // Frame 3
                    + "0\n" + "0\n"         // Frame 4
                    + "0\n" + "0\n"         // Frame 5
                    + "0\n" + "0\n"         // Frame 6
                    + "0\n" + "0\n"         // Frame 7
                    + "0\n" + "0\n"         // Frame 8
                    + "0\n" + "0\n"         // Frame 9
                    + "0\n" + "0\n";        // Frame 10

                string expectedResult = "The value you entered is not correct (example: 2)";

                //create a string reader to write to console with
                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.Main(new string[] { "" });

                    // Assert
                    //retrieve the second line from the console output
                    string actualResult = sw.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1];

                    Assert.AreEqual(expectedResult, actualResult);
                }
            }
        }




    }
}

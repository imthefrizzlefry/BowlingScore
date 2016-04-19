using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BowlingScore;


namespace BowlingScoreUnitTests
{
    [TestClass]
    public class Player_PlayThroughFrame_IntegrationTests
    {
        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Integration")]
        public void Player_PlayThroughFrame_PlayerOnlyGetsTwoScoresWithNormalFrame()
        {
            string testInput = "4\n"    // Ball 1
                             + "4\n";   // Ball 2

            int expectedResult = 4;

            Player testPlayer = new Player("PlayerForTest");
            
            using (var sw = new StringWriter())
            {
                

                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.PlayThroughFrame(testPlayer, 1);

                    Assert.AreEqual(expectedResult, testPlayer.PinCount[0]);
                    Assert.AreEqual(expectedResult, testPlayer.PinCount[1]);
                    
                    //attempt to access the third index of the player's pinCount for the frame
                    try {
                        Assert.IsNull(testPlayer.PinCount[2]);
                        Assert.Fail("Only Two values should have been saved to the player.");
                    }
                    catch (ArgumentOutOfRangeException) { /* this should happen every time*/ }
                }
            }
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Integration")]
        public void Player_PlayThroughFrame_PlayerGetsExtraBallWithSpareOnFrameTen()
        {
            string testInput = "5\n"    // Ball 1
                             + "5\n"    // Ball 2
                             + "5\n";   // Ball 3

            int expectedResult = 5;

            Player testPlayer = new Player("PlayerForTest");

            using (var sw = new StringWriter())
            {


                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.PlayThroughFrame(testPlayer, 10);

                    Assert.AreEqual(expectedResult, testPlayer.PinCount[0]);
                    Assert.AreEqual(expectedResult, testPlayer.PinCount[1]);
                    Assert.AreEqual(expectedResult, testPlayer.PinCount[2]);
                    
                }
            }
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Integration")]
        public void Player_PlayThroughFrame_PlayerGetsExtraBallWithStrikeOnFrameTen()
        {
            string testInput = "10\n"    // Ball 1
                             + "10\n"    // Ball 2
                             + "10\n";   // Ball 3

            int expectedResult = 10;

            Player testPlayer = new Player("PlayerForTest");

            using (var sw = new StringWriter())
            {


                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.PlayThroughFrame(testPlayer, 10);

                    Assert.AreEqual(expectedResult, testPlayer.PinCount[0]);
                    Assert.AreEqual(expectedResult, testPlayer.PinCount[1]);
                    Assert.AreEqual(expectedResult, testPlayer.PinCount[2]);
                }
            }
        }

        [TestMethod]
        [TestCategory("Negative")]
        [TestCategory("Integration")]
        public void Player_PlayThroughFrame_InvalidNumberOfPinsKnockedDownIsNotSavedToPlayer()
        {
            string testInput = "invalid value\n"    // Ball 1
                             + "3\n"    // Ball 2
                             + "3\n";   // Ball 3

            int expectedResult = 3;

            Player testPlayer = new Player("PlayerForTest");

            using (var sw = new StringWriter())
            {


                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.PlayThroughFrame(testPlayer, 10);

                    Assert.AreEqual(expectedResult, testPlayer.PinCount[0]);
                    Assert.AreEqual(expectedResult, testPlayer.PinCount[1]);

                    //attempt to access the third index of the player's pinCount for the frame
                    try
                    {
                        Assert.IsNull(testPlayer.PinCount[2]);
                        Assert.Fail("Only Two values should have been saved to the player.");
                    }
                    catch (ArgumentOutOfRangeException) { /* this should happen every time*/ }
                }
            }
        }

        [TestMethod]
        [TestCategory("Negative")]
        [TestCategory("Integration")]
        public void Player_PlayThroughFrame_NegativeNumberOfPinsKnockedDownIsNotSavedToPlayer()
        {
            string testInput = "-1\n"    // Ball 1
                             + "3\n"    // Ball 2
                             + "3\n";   // Ball 3

            int expectedResult = 3;

            Player testPlayer = new Player("PlayerForTest");

            using (var sw = new StringWriter())
            {


                using (var sr = new StringReader(testInput))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    BowlingScore.Program.PlayThroughFrame(testPlayer, 10);

                    Assert.AreEqual(expectedResult, testPlayer.PinCount[0]);
                    Assert.AreEqual(expectedResult, testPlayer.PinCount[1]);

                    //attempt to access the third index of the player's pinCount for the frame
                    try
                    {
                        Assert.IsNull(testPlayer.PinCount[2]);
                        Assert.Fail("Only Two values should have been saved to the player.");
                    }
                    catch (ArgumentOutOfRangeException) { /* this should happen every time*/ }
                }
            }
        }



    }
}

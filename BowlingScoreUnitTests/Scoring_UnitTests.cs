using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BowlingScore;

namespace BowlingScoreUnitTests
{
    [TestClass]
    public class Scoring_UnitTests
    {
        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Unit")]
        public void ComputeScore_PerfectGameHasCorrectScore()
        {
            List<int> testInput = new List<int>
            {
                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10
            };

            int expectedOutput = 300;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from a perfect game is not correct.");
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Unit")]
        public void ComputeScore_GameWithAllSparesHasCorrectScore()
        {
            List<int> testInput = new List<int>
            {
                4, 6,
                4, 6,
                4, 6,
                4, 6,
                4, 6,
                4, 6,
                4, 6,
                4, 6,
                4, 6,
                4, 6, 1,
            };

            int expectedOutput = 137;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from a perfect game is not correct.");
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Unit")]
        public void ComputeScore_UserNeverGetsAStrikeOrSpare()
        {
            List<int> testInput = new List<int>
            {
                2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2
            };

            int expectedOutput = 40;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from a game with no Strikes or Spares is not correct.");
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Unit")]
        public void ComputeScore_UserGetsASpare()
        {
            List<int> testInput = new List<int>
            {
                2, 8,
                2, 2,
                2, 2,
                2, 2,
                2, 2,
                2, 2,
                2, 2,
                2, 2,
                2, 2,
                2, 2
            };

            int expectedOutput = 48;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from a game where the user gets a Spare is not correct.");
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Unit")]
        public void ComputeScore_UserGetsAStrike()
        {
            List<int> testInput = new List<int>
            {
                10, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2
            };

            int expectedOutput = 50;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from a game where the user gets a Strike is not correct.");
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Unit")]
        public void ComputeScore_SpareAcrossFramesWithFirstBallIsZero()
        {
            List<int> testInput = new List<int>
            {
                0, 5, 5, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2
            };

            int expectedOutput = 44;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from a game where the user almost gets a spare is not correct.");
        }

        [TestMethod]
        [TestCategory("Positive")]
        [TestCategory("Unit")]
        public void ComputeScore_SpareAfterPreviousFramesFirstBallIsZero()
        {
            List<int> testInput = new List<int>
            {
                0, 5,
                5, 5,
                2, 2,
                2, 2,
                2, 2,
                2, 2,
                2, 2,
                2, 2,
                2, 2,
                2, 2
            };

            int expectedOutput = 49;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from a game where the user gets a Spare is not correct.");
        }


        [TestMethod]
        [TestCategory("Negative")]
        [TestCategory("Unit")]
        public void ComputeScore_InsufficientScoresProvided()
        {
            List<int> testInput = new List<int>
            {
                1, 2, 3, 4
            };

            int expectedOutput = -1;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from an insufficient number of inputs is not correct.");

        }

        [TestMethod]
        [TestCategory("Negative")]
        [TestCategory("Unit")]
        public void ComputeScore_InvalidScoreReportedByUser()
        {
            List<int> testInput = new List<int>
            {
                1, 2, 3, 40, 5, 4, 3, 2, 1, 0
            };

            int expectedOutput = -1;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The user should not be able to knock down more than 10 pins by a single ball.");

        }

        [TestMethod]
        [TestCategory("Negative")]
        [TestCategory("Unit")]
        public void ComputeScore_SpareRequiresAnAdditionalScoreThatWasNotProvided()
        {
            List<int> testInput = new List<int>
            {
                4, 6, 3, 7, 5, 5, 7, 3, 9, 1
            };

            int expectedOutput = -1;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from an insufficient number of inputs is not correct.");

        }

        [TestMethod]
        [TestCategory("Negative")]
        [TestCategory("Unit")]
        public void ComputeScore_SpareWereTooManyPinsWereKnockedDown()
        {
            List<int> testInput = new List<int>
            {
                6, 6, 3, 1, 2, 3, 4, 5, 4, 3, 2, 1, 0, 3, 4, 5, 4, 3, 2, 1, 0
            };

            int expectedOutput = -1;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from an insufficient number of inputs is not correct.");

        }

        [TestMethod]
        [TestCategory("Negative")]
        [TestCategory("Unit")]
        public void ComputeScore_LastBallIsASpareButNoExtraPlay()
        {
            List<int> testInput = new List<int>
            {
                2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 8
            };

            int expectedOutput = -1;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from an insufficient number of inputs is notcorrect.");

        }

        [TestMethod]
        [TestCategory("Negative")]
        [TestCategory("Unit")]
        public void ComputeScore_LastBallIsAStrikeButOnlyOneExtraPlay()
        {
            List<int> testInput = new List<int>
            {
                2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 10, 8
            };

            int expectedOutput = -1;

            int actualOutput = Scoring.ComputeScore(testInput);

            Assert.AreEqual(expectedOutput, actualOutput, "The score from an insufficient number of inputs is notcorrect.");

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisGame;
using System.Collections.Generic;

namespace TennisGameUnitTests
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// This test proves that points are scored rightly
        /// </summary>
        [TestMethod]
        public void PointsGainedByPlayer()
        {
            ushort expectedScoreP1 = 0, expectedScoreP2 = 0;
            Tennis tennisGame = new Tennis();

            Assert.Equals(expectedScoreP1, tennisGame.GetNumScore(PlayerEnum.Player1));
            Assert.Equals(expectedScoreP2, tennisGame.GetNumScore(PlayerEnum.Player2));

            
            for (int i = 0; i < 6; i++)
            {
                tennisGame.SetGainedPoint(PlayerEnum.Player1);
                Assert.Equals(++expectedScoreP1, tennisGame.GetNumScore(PlayerEnum.Player1));

                tennisGame.SetGainedPoint(PlayerEnum.Player2);
                Assert.Equals(++expectedScoreP2, tennisGame.GetNumScore(PlayerEnum.Player2));
            }
        }

        /// <summary>
        /// A game is won by the first player to have won at least four points in total
        /// and at least two points more than the opponent.
        /// </summary>
        [TestMethod]
        public void GameWonByPlayerWith4PointsAnd2PointsMoreTheOpponent()
        {
            int i;
            Tennis tennisGame = new Tennis();

            //Player1 Player2 4-0
            for(i=0; i<4; i++)
            {
                Assert.AreEqual(false, tennisGame.HasGameEnded());
                tennisGame.SetGainedPoint(PlayerEnum.Player1);
            }
            Assert.AreEqual(true, tennisGame.HasGameEnded());
            Assert.AreEqual(PlayerEnum.Player1, tennisGame.GetTheWinner());

            tennisGame.StartNewGame();

            //Player1 Player2 0-4
            for (i = 0; i < 4; i++)
            {
                Assert.AreEqual(false, tennisGame.HasGameEnded());
                tennisGame.SetGainedPoint(PlayerEnum.Player2);
            }
            Assert.AreEqual(true, tennisGame.HasGameEnded());
            Assert.AreEqual(PlayerEnum.Player2, tennisGame.GetTheWinner());

            tennisGame.StartNewGame();

            //Player1 Player2 4-2
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(true, tennisGame.HasGameEnded());
            Assert.AreEqual(PlayerEnum.Player1, tennisGame.GetTheWinner());

            tennisGame.StartNewGame();

            //Player1 Player2 5-3
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(false, tennisGame.HasGameEnded());
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(true, tennisGame.HasGameEnded());
            Assert.AreEqual(PlayerEnum.Player1, tennisGame.GetTheWinner());
        }

        /// <summary>
        /// The running score of each game is described in a manner peculiar to tennis:
        /// scores from zero to three points are described as "Love", "Fifteen",
        /// "Thirty", and "Forty" respectively.
        /// </summary>
        [TestMethod]
        public void ScoreDescription()
        {
            Tennis tennisGame = new Tennis();
            Assert.AreEqual(ScoreEnum.Love, tennisGame.GetDescScore(PlayerEnum.Player1));
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(ScoreEnum.Fifteen, tennisGame.GetDescScore(PlayerEnum.Player1));
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(ScoreEnum.Thirty, tennisGame.GetDescScore(PlayerEnum.Player1));
            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            Assert.AreEqual(ScoreEnum.Forty, tennisGame.GetDescScore(PlayerEnum.Player1));

            tennisGame.StartNewGame();

            Assert.AreEqual(ScoreEnum.Love, tennisGame.GetDescScore(PlayerEnum.Player2));
            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            Assert.AreEqual(ScoreEnum.Fifteen, tennisGame.GetDescScore(PlayerEnum.Player2));
            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            Assert.AreEqual(ScoreEnum.Thirty, tennisGame.GetDescScore(PlayerEnum.Player2));
            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            Assert.AreEqual(ScoreEnum.Forty, tennisGame.GetDescScore(PlayerEnum.Player2));
        }

        /// <summary>
        /// If at least three points have been scored by each player, and the scores are equal,
        /// the score is "Deuce".
        /// </summary>
        [TestMethod]
        public void GameScoreDeuce()
        {
            Tennis tennisGame = new Tennis();

            Assert.AreNotEqual(GameUtility.Deuce, tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            tennisGame.SetGainedPoint(PlayerEnum.Player2);

            Assert.AreNotEqual(GameUtility.Deuce, tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            tennisGame.SetGainedPoint(PlayerEnum.Player2);

            Assert.AreNotEqual(GameUtility.Deuce, tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            tennisGame.SetGainedPoint(PlayerEnum.Player2);

            Assert.AreEqual(GameUtility.Deuce, tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            tennisGame.SetGainedPoint(PlayerEnum.Player2);

            Assert.AreEqual(GameUtility.Deuce, tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            tennisGame.SetGainedPoint(PlayerEnum.Player2);

            Assert.AreEqual(GameUtility.Deuce, tennisGame.GetGameScore());
        }

        /// <summary>
        /// If at least three points have been scored by each side and a player has
        /// one more point than his opponent, the score of the game is "Advantage"
        /// for the player in the lead.
        /// </summary>
        [TestMethod]
        public void GameScoreAdvantage()
        {
            Tennis tennisGame = new Tennis();

            tennisGame.SetGainedPoint(PlayerEnum.Player1);

            Assert.AreNotEqual(GameUtility.GetAdvantageMessage(PlayerEnum.Player1), tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            tennisGame.SetGainedPoint(PlayerEnum.Player1);

            Assert.AreNotEqual(GameUtility.GetAdvantageMessage(PlayerEnum.Player1), tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            tennisGame.SetGainedPoint(PlayerEnum.Player1);

            Assert.AreNotEqual(GameUtility.GetAdvantageMessage(PlayerEnum.Player1), tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            tennisGame.SetGainedPoint(PlayerEnum.Player1);

            Assert.AreEqual(GameUtility.GetAdvantageMessage(PlayerEnum.Player1), tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player2);
            tennisGame.SetGainedPoint(PlayerEnum.Player1);

            Assert.AreEqual(GameUtility.GetAdvantageMessage(PlayerEnum.Player1), tennisGame.GetGameScore());

            tennisGame.StartNewGame();

            tennisGame.SetGainedPoint(PlayerEnum.Player2);

            Assert.AreNotEqual(GameUtility.GetAdvantageMessage(PlayerEnum.Player2), tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            tennisGame.SetGainedPoint(PlayerEnum.Player2);

            Assert.AreNotEqual(GameUtility.GetAdvantageMessage(PlayerEnum.Player2), tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            tennisGame.SetGainedPoint(PlayerEnum.Player2);

            Assert.AreNotEqual(GameUtility.GetAdvantageMessage(PlayerEnum.Player2), tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            tennisGame.SetGainedPoint(PlayerEnum.Player2);

            Assert.AreEqual(GameUtility.GetAdvantageMessage(PlayerEnum.Player2), tennisGame.GetGameScore());

            tennisGame.SetGainedPoint(PlayerEnum.Player1);
            tennisGame.SetGainedPoint(PlayerEnum.Player2);

            Assert.AreEqual(GameUtility.GetAdvantageMessage(PlayerEnum.Player2), tennisGame.GetGameScore());
        }
    }
}

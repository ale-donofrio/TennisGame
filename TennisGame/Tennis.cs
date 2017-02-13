using System;

namespace TennisGame
{
    /// <summary>
    /// This class is used to manage a tennis game
    /// </summary>
    public class Tennis
    {
        private int player1Points = 0;
        private int player2Points = 0;

        public PlayerEnum? GetLeadingPlayer()
        {
            PlayerEnum? leader = null;
            if(player1Points > player2Points)
            {
                leader = PlayerEnum.Player1;
            }
            else if(player2Points > player1Points)
            {
                leader = PlayerEnum.Player2;
            }
            return leader;
        }

        /// <summary>
        /// This method gets the winner of the game
        /// </summary>
        /// <returns>The player who won the game of null if the game hasn't ended yet</returns>
        public PlayerEnum? GetTheWinner()
        {
            PlayerEnum? winner = null;
            if (player1Points >= player2Points + GameUtility.gapToWin)
            {
                if (player1Points >= GameUtility.minPointsToWin)
                {
                    winner = PlayerEnum.Player1;
                }
            }
            else if (player2Points >= player1Points + GameUtility.gapToWin)
            {
                if (player2Points >= GameUtility.minPointsToWin)
                {
                    winner = PlayerEnum.Player2;
                }
            }
            return winner;
        }

        /// <summary>
        /// It scores a point for a player
        /// </summary>
        /// <param name="player">The player who gained the point</param>
        public void SetGainedPoint(PlayerEnum player)
        {
            if (!HasGameEnded())
            {
                if (player == PlayerEnum.Player1)
                {
                    player1Points++;
                }
                else
                {
                    player2Points++;
                }
            }
        }

        /// <summary>
        /// It gets points gained by a player
        /// </summary>
        /// <param name="player">The player whose points need to be returned</param>
        /// <returns>Player's points</returns>
        public int GetNumScore(PlayerEnum player)
        {
            int retValue = 0;
            if (player == PlayerEnum.Player1)
            {
                retValue = player1Points;
            }
            else
            {
                retValue = player2Points;
            }
            return retValue;
        }

        /// <summary>
        /// It starts a new game resetting players' points
        /// </summary>
        public void StartNewGame()
        {
            player1Points = 0;
            player2Points = 0;
        }

        /// <summary>
        /// It says if the game ended
        /// </summary>
        /// <returns>True if the game ended</returns>
        public bool HasGameEnded()
        {
            return GetTheWinner().HasValue;
        }

        /// <summary>
        /// It gets the descriptive score of a player
        /// </summary>
        /// <param name="player">The player whose score has to be descripted</param>
        /// <returns>The description of the score</returns>
        public string GetDescScore(PlayerEnum player)
        {
            string score;
            int pointToAnalyze;
            if (player == PlayerEnum.Player1)
            {
                pointToAnalyze = player1Points;
            }
            else
            {
                pointToAnalyze = player2Points;
            }
            string[] scoreDescriptions = Enum.GetNames(typeof(ScoreEnum));
            if (pointToAnalyze > scoreDescriptions.Length - 1)
            {
                score = pointToAnalyze.ToString();
            }
            else if (pointToAnalyze >= 0)
            {
                score = scoreDescriptions[pointToAnalyze];
            }
            else
            {
                score = string.Empty;
            }
            return score;
        }

        /// <summary>
        /// It gets the score of the game
        /// </summary>
        /// <returns>The score of the game</returns>
        public string GetGameScore()
        {
            string gameScore = string.Empty;
            if (player1Points == player2Points && player1Points >= GameUtility.minPointsToDeuce)
            {
                gameScore = GameUtility.Deuce;
            }
            else if (player1Points >= GameUtility.minPointsToAdvantage && player2Points >= GameUtility.minPointsToAdvantage)
            {
                if (player1Points == player2Points + GameUtility.gapToAdvantage)
                {
                    gameScore = GameUtility.GetAdvantageMessage(PlayerEnum.Player1);
                }
                else if (player2Points == player1Points + GameUtility.gapToAdvantage)
                {
                    gameScore = GameUtility.GetAdvantageMessage(PlayerEnum.Player2);
                }
            }
            else
            {
                gameScore = string.Format("{0} - {1}", GetDescScore(PlayerEnum.Player1), GetDescScore(PlayerEnum.Player2));
            }
            return gameScore;
        }
    }
}

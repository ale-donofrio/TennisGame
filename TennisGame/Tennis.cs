using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    public class Tennis
    {
        private int player1Points = 0;
        private int player2Points = 0;

        public PlayerEnum? GetTheWinner()
        {
            PlayerEnum? winner = null;
            if (player1Points >= player2Points + 2)
            {
                if (player1Points >= 4)
                {
                    winner = PlayerEnum.Player1;
                }
            }
            else if (player2Points >= player1Points + 2)
            {
                if (player2Points >= 4)
                {
                    winner = PlayerEnum.Player2;
                }
            }
            return winner;
        }

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

        public void StartNewGame()
        {
            player1Points = 0;
            player2Points = 0;
        }

        public bool HasGameEnded()
        {
            return GetTheWinner().HasValue;
        }

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
            if (pointToAnalyze > 3)
            {
                score = pointToAnalyze.ToString();
            }
            else if (pointToAnalyze >= 0)
            {
                score = Enum.GetNames(typeof(ScoreEnum))[pointToAnalyze];
            }
            else
            {
                score = string.Empty;
            }
            return score;
        }

        public string GetGameScore()
        {
            string gameScore = string.Empty;
            if (player1Points == player2Points && player1Points >= 3)
            {
                gameScore = GameUtility.Deuce;
            }
            else if (player1Points >= 3 && player2Points >= 3)
            {
                if (player1Points == player2Points + 1)
                {
                    gameScore = GameUtility.GetAdvantageMessage(PlayerEnum.Player1);
                }
                else if (player2Points == player1Points + 1)
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

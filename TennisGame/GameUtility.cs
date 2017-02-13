using System;

namespace TennisGame
{
    public class GameUtility
    {
        public const int minPointsToWin = 4;
        public const int gapToWin = 2;
        public const int minPointsToDeuce = 3;
        public const int minPointsToAdvantage = 3;
        public const int gapToAdvantage = 1;

        public static string Deuce = "Deuce";
        public static string Advantage = "Advantage";

        public static string GetAdvantageMessage(PlayerEnum player)
        {
            string retVal;
            if (player == PlayerEnum.Player1)
                retVal = string.Format("{0} {1}", Advantage, Enum.GetName(typeof(PlayerEnum), PlayerEnum.Player1));
            else
                retVal = string.Format("{0} {1}", Advantage, Enum.GetName(typeof(PlayerEnum), PlayerEnum.Player2));
            return retVal;
        }
    }
}

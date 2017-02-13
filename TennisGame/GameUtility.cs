using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    public class GameUtility
    {
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

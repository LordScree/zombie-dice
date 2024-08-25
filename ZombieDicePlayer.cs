﻿
namespace LordScree.ZombieDice
{
    public class ZombieDicePlayer
    {
        public int BankedBrains { get; private set; }
        public string PlayerName { get; set; }
        public bool Winner { get; private set; } = false;

        public void BankBrains(int brainsToBank)
        {
            // Winners cannot bank more brains.
            if (Winner) throw new WinnerOverbankException();

            BankedBrains += brainsToBank;
            Winner = BankedBrains >= GameState.TargetBrains;
        }

        public ZombieDicePlayer(string name) => PlayerName = name;

        internal static ZombieDicePlayer GetPlayer(string name)
        {
            return new ZombieDicePlayer(name);
        }
    }
}
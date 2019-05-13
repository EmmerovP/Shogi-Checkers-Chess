using System;

public class Game
{
    public class CurrentGame
    {
        public GameType gameType;
        public PlayerType playerType;
    }

    public enum GameType
    {
        chess,
        draughts,
        shogi,
        custom
    }

    public enum PlayerType
    {
        single,
        localmulti,
        webmulti
    }
}

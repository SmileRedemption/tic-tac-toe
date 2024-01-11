using System;

namespace GameLogic.Data
{
    [Serializable]
    public class GameProgress
    {
        public Board Board;
        public Sign CurrentSign;
        public int CountOfMove;

        public GameProgress(Board board, Sign currentSign, int countOfMove)
        {
            Board = board;
            CurrentSign = currentSign;
            CountOfMove = countOfMove;
        }
    }
}
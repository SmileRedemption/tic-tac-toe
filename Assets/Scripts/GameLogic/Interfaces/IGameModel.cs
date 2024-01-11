using System;

namespace GameLogic.Interfaces
{
    public interface IGameModel
    {
        bool TryMakeMove(int cellIndex);
        event Action GameWon;
        event Action GameDraw;
    }
}
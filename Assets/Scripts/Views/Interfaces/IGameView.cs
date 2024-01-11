using System;

namespace Interfaces
{
    public interface IGameView
    {
        void GameWon();
        void GameDraw();
        void UpdateBoard(int cellIndex);
        event Action<int> MoveMade;
    }
}
using System;
using GameLogic.Data;
using GameLogic.Interfaces;

namespace GameLogic
{
    public class GameModel : IGameModel, ISaveLoadProgress
    {
        private const int CountMoveForDraw = 9;
        private readonly SaveLoadSystem _saveLoadSystem = new();
        private Board _board = new();
        private int _moveCounter;
        private Sign _currentSign = Sign.X;
        private bool _isGameOver;
        
        public event Action GameWon;
        public event Action GameDraw;
        public event Action<Sign[], Sign> ProgressLoaded;

        public bool TryMakeMove(int cellIndex)
        {
            if (_isGameOver)
                return false;

            if (_board.TryMakeMove(cellIndex, _currentSign))
            {
                _moveCounter++;
                if (CheckWin())
                {
                    _isGameOver = true;
                    GameWon?.Invoke();
                    return true;
                }

                if (CheckDraw())
                {
                    _isGameOver = true;
                    GameDraw?.Invoke();
                    return true;
                }

                SwapCurrentSign();
                return true;
            }

            return false;
        }

        private bool CheckDraw() =>
            _moveCounter == CountMoveForDraw;

        private bool CheckWin() =>
            _board.IsVerticalWin() || _board.IsHorizontalWin() || _board.IsDiagonalWin();

        private void SwapCurrentSign() =>
            _currentSign = (_currentSign == Sign.X) ? Sign.O : Sign.X;

        public void UpdateProgress() => 
            _saveLoadSystem.UpdateProgress(new GameProgress(_board, _currentSign, _moveCounter));

        public void LoadProgress()
        {
            var gameProgress = _saveLoadSystem.LoadProgress();
            _board = gameProgress.Board;
            _currentSign = gameProgress.CurrentSign;
            _moveCounter = gameProgress.CountOfMove;
            ProgressLoaded?.Invoke(_board.GetCellSigns(), _currentSign);
        }
    }
}
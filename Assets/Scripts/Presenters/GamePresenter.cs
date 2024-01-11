using GameLogic;
using GameLogic.Interfaces;
using Interfaces;

namespace Presenters
{
    public class GamePresenter : IPresenter
    {
        private readonly IGameModel _gameModel;
        private readonly IGameView _gameView;

        public GamePresenter(IGameModel gameModel, IGameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Enable()
        {
            _gameModel.GameWon += OnGameWon;
            _gameModel.GameDraw += OnGameDraw;
            _gameView.MoveMade += OnMoveMade;
        }

        public void Disable()
        {
            _gameModel.GameWon -= OnGameWon;
            _gameModel.GameDraw -= OnGameDraw;
            _gameView.MoveMade -= OnMoveMade;
        }
        
        private void OnGameWon() => 
            _gameView.GameWon();

        private void OnGameDraw() => 
            _gameView.GameDraw();

        private void OnMoveMade(int cellIndex)
        {
            if (_gameModel.TryMakeMove(cellIndex)) 
                _gameView.UpdateBoard(cellIndex);
        }
    }
}
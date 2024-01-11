using System;
using GameLogic;
using Interfaces;
using UIWindow;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour, IGameView
{
    [SerializeField] private BoardView _boardView;
    [SerializeField] private PlayerView _playerXView;
    [SerializeField] private PlayerView _playerOView;
    [SerializeField] private WinWindow _winWindow;
    [SerializeField] private DrawWindow _drawWindow;
    [SerializeField] private SaveLoadView _saveLoadView;
    
    private PlayerView _currentPlayer;
    private PlayerView _nextPlayer;
    
    public event Action<int> MoveMade;

    private void Start()
    {
        _currentPlayer = _playerXView;
        _nextPlayer = _playerOView;
        _nextPlayer.SetAvailableMoveOff();
        _boardView.MoveRequested += OnMoveMade;
        _saveLoadView.UpdatedGameView += OnUpdateGameView;
    }

    private void OnDestroy()
    {
        _boardView.MoveRequested -= OnMoveMade;
        _saveLoadView.UpdatedGameView -= OnUpdateGameView;
    }

    public void GameWon() => 
        _winWindow.Show(_currentPlayer.GetSign(), _nextPlayer.GetSign());

    public void GameDraw() => 
        _drawWindow.Show(_currentPlayer.GetSign(), _nextPlayer.GetSign());

    public void UpdateBoard(int cellIndex)
    {
        _boardView.UpdateBoard(cellIndex, _currentPlayer.GetSign());
        SwapCurrentPlayer();
    }
    
    private void SwapCurrentPlayer()
    {
        _currentPlayer.SetAvailableMoveOff();
        (_currentPlayer, _nextPlayer) = (_nextPlayer, _currentPlayer);
        _currentPlayer.SetAvailableMoveOn();
    }
    
    private void OnUpdateGameView(Sign[] board, Sign current)
    {
        _boardView.UpdateBoard(board, _playerXView.GetSign(), _playerOView.GetSign());
        SetCurrentPlayer(current);
    }

    private void SetCurrentPlayer(Sign current)
    {
        if (current == Sign.X)
        {
            _currentPlayer = _playerXView;
            _nextPlayer = _playerOView;
        }
        else
        {
            _currentPlayer = _playerOView;
            _nextPlayer = _playerXView;
        }
        _currentPlayer.SetAvailableMoveOn();
        _nextPlayer.SetAvailableMoveOff();
    }

    private void OnMoveMade(int cellIndex) => 
        MoveMade?.Invoke(cellIndex);
}
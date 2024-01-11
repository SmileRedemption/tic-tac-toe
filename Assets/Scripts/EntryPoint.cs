using GameLogic;
using Presenters;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private SaveLoadView _saveLoadView;
    
    private IPresenter[] _presenters;

    private void Awake()
    {
        var gameModel = new GameModel();
        _presenters = new IPresenter[]
        {
            new GamePresenter(gameModel, _gameView),
            new SaveLoadPresenter(gameModel, _saveLoadView)
        };
    }

    private void OnEnable()
    {
        foreach (var presenter in _presenters) 
            presenter.Enable();
    }

    private void OnDisable()
    {
        foreach (var presenter in _presenters) 
            presenter.Disable();
    }
}
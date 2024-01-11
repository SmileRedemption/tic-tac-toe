using System;
using GameLogic;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadView : MonoBehaviour, ISaveLoadView
{
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _loadButton;

    public event Action SaveButtonClick;
    public event Action LoadButtonClick;
    
    public void UpdateView(Sign[] board, Sign current) => 
        UpdatedGameView?.Invoke(board, current);

    public event Action<Sign[], Sign> UpdatedGameView;

    private void OnEnable()
    {
        _saveButton.onClick.AddListener(SaveProgress);
        _loadButton.onClick.AddListener(LoadProgress);
    }

    private void OnDisable()
    {
        _saveButton.onClick.RemoveListener(SaveProgress);
        _loadButton.onClick.RemoveListener(LoadProgress);
    }

    private void SaveProgress() => 
        SaveButtonClick?.Invoke();

    private void LoadProgress() => 
        LoadButtonClick?.Invoke();
}
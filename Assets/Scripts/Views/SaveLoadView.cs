using System;
using System.Collections;
using GameLogic;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadView : MonoBehaviour, ISaveLoadView
{
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _loadButton;
    [SerializeField] private TMP_Text _textLoad;
    [SerializeField] private TMP_Text _textSave;
    
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

    private void SaveProgress()
    {
        SaveButtonClick?.Invoke();
        StartCoroutine(TextShowForSeconds(_textSave.gameObject, 2));
    }

    private void LoadProgress()
    {
        LoadButtonClick?.Invoke();
        StartCoroutine(TextShowForSeconds(_textLoad.gameObject, 2));
    }

    private IEnumerator TextShowForSeconds(GameObject text, int seconds)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(seconds);
        text.SetActive(false);
    }
}
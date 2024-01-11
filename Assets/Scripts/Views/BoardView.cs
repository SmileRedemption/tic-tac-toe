using System;
using GameLogic;
using UnityEngine;

public class BoardView : MonoBehaviour
{
    private CellView[] _cellsView;

    public event Action<int> MoveRequested; 
    
    private void Start()
    {
        _cellsView = GetComponentsInChildren<CellView>();
        
        for (var i = 0; i < _cellsView.Length; i++)
        {
            _cellsView[i].Initialize(i);
            _cellsView[i].OnCellClicked += OnMadeMove;
        }
    }

    private void OnDestroy()
    {
        foreach (var cellView in _cellsView)
        {
            cellView.OnCellClicked -= OnMadeMove;
        }
    }

    private void OnMadeMove(int cellIndex)
    {
        MoveRequested?.Invoke(cellIndex);
    }

    public void UpdateBoard(int cellIndex, Sprite sign)
    {
        _cellsView[cellIndex].UpdateCell(sign);
    }

    public void UpdateBoard(Sign[] signs, Sprite xView, Sprite oView)
    {
        for (var index = 0; index < signs.Length; index++)
        {
            switch (signs[index])
            {
                case Sign.None:
                    _cellsView[index].ResetCell();
                    break;
                case Sign.X:
                    _cellsView[index].UpdateCell(xView);
                    break;
                case Sign.O:
                    _cellsView[index].UpdateCell(oView);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
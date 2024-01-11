using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class CellView : MonoBehaviour
{
    private int _index;
    private Button _button;
    private Image _image;
    private Sprite _emptyCellSprite;

    public event Action<int> OnCellClicked;

    public void Initialize(int index) => 
        _index = index;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _emptyCellSprite = _image.sprite;
    }
    
    private void OnEnable() => 
        _button.onClick.AddListener(OnButtonClicked);

    private void OnDisable() => 
        _button.onClick.RemoveListener(OnButtonClicked);

    private void OnButtonClicked() => 
        OnCellClicked?.Invoke(_index);

    public void UpdateCell(Sprite sprite) => 
        _image.sprite = sprite;

    public void ResetCell() => 
        _image.sprite = _emptyCellSprite;
}
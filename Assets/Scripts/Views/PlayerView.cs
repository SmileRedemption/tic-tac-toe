using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _availableColor;
    [SerializeField] private Color _disableColor;
    
    public Sprite GetSign() => 
        _image.sprite;

    public void SetAvailableMoveOn() => 
        _image.color = _availableColor;

    public void SetAvailableMoveOff() => 
        _image.color = _disableColor;
}
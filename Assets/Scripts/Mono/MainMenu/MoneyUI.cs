using System;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private RectTransform _paperRectTransform;
    [SerializeField] private RectTransform _textRectTransform;
    private Vector2 _paperBaseSize;
    private Vector2 _textBaseSize;

    private void Awake()
    {
        _paperBaseSize = _paperRectTransform.sizeDelta;
        _textBaseSize = _textRectTransform.sizeDelta;
    }

    private void Update()
    {
        _textRectTransform.sizeDelta = new Vector2(_textBaseSize.x + _moneyText.preferredWidth, _textBaseSize.y);
        _paperRectTransform.sizeDelta = new Vector2(_paperBaseSize.x + _moneyText.preferredWidth, _paperBaseSize.y);
    }
}

using System;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterButton : MonoBehaviour
{
    public static event Action OnLetterClicked;
    
    [SerializeField] private TMP_Text _letterText;
    [SerializeField] private Button _letterButton;
    [SerializeField] private RectTransform _topButtonRect;
    [SerializeField] private RectTransform _bottomButtonRect;
    [SerializeField] private float _animationDuration;
    private Vector2 _prevPos;

    private char _letter;

    private void Start()
    {
        _prevPos = _topButtonRect.anchoredPosition;
    }

    public void SetLetterText(char letter)
    {
        _letter = letter;
        _letterText.text = _letter.ToString();
    }

    public void SetButtonCallback(Action<char> action)
    {
        _letterButton.onClick.RemoveAllListeners();
        _letterButton.onClick.AddListener(() =>
        {
            action?.Invoke(_letterText.text.FirstOrDefault());
            SetButtonActive(false);
        });
    }

    public void SetButtonActive(bool isActive)
    {
        OnLetterClicked?.Invoke();
        if (!isActive)
        {
            _letterText.text = "";
            _letterButton.interactable = false;
            _topButtonRect.DOLocalMove(_bottomButtonRect.anchoredPosition, _animationDuration);
        }
        else
        {
            _topButtonRect.DOLocalMove(_prevPos, _animationDuration/2).onComplete += () =>
            {
                _letterText.text = _letter.ToString();
                _letterButton.interactable = true;
            };
        }
        
    }
}

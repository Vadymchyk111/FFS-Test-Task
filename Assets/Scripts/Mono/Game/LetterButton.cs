using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _letterText;
    [SerializeField] private Button _letterButton;

    public void SetLetterText(char letter)
    {
        _letterText.text = letter.ToString();
    }

    public void SetButtonCallback(Action<char> action)
    {
        _letterButton.onClick.RemoveAllListeners();
        _letterButton.onClick.AddListener(() => action?.Invoke(_letterText.text.FirstOrDefault()));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private List<LetterButton> _letterButtons;
    [SerializeField] private List<Placeholder> _placeholders;
    [SerializeField] private Placeholder _placeholderPrefab;
    [SerializeField] private Transform _placeholderParent;
    [SerializeField] private TMP_Text _wordText;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _sendButton;
    [Inject] private ILevelManager _levelManager;
    [Inject] private GameController _gameController;

    private void Start()
    {
        _resetButton.onClick.AddListener(ResetButtonText);
        _sendButton.onClick.AddListener(CheckIfWordExist);
    }

    public void SetLevelUI()
    {
        LevelData data = _levelManager.GetCurrentLevel();
        for (int i = 0; i < data.levelName.Length; i++)
        {
            _letterButtons[i].SetLetterText(data.levelName[i]);
            _letterButtons[i].SetButtonCallback(ChangeButtonText);
        }

        foreach (string word in data.words)
        {
            Placeholder placeholder = Instantiate(_placeholderPrefab, _placeholderParent);
            placeholder.SetupWord(word);
            _placeholders.Add(placeholder);
        }
    }

    private void ChangeButtonText(char letter)
    {
        _wordText.text += letter;
    }

    private void ResetButtonText()
    {
        _wordText.text = "";
    }

    private void CheckIfWordExist()
    {
        Placeholder placeholder = _placeholders.FirstOrDefault(x => x.Word.Equals(_wordText.text, StringComparison.OrdinalIgnoreCase));
        if (placeholder != null)
        {
            placeholder.OpenWord();
        }
    }
}

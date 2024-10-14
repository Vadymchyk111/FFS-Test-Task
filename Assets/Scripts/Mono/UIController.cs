using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlaceholderHint _placeholderHint;
    [SerializeField] private List<LetterButton> _letterButtons;
    [SerializeField] private List<Placeholder> _placeholders;
    [SerializeField] private Placeholder _placeholderPrefab;
    [SerializeField] private Transform _placeholderParent;
    [SerializeField] private Transform _placeholderContentPoint;
    [SerializeField] private TMP_Text _wordText;
    [SerializeField] private TMP_Text _levelNameText;
    [SerializeField] private TMP_Text _hintText;
    [SerializeField] private TMP_Text _hintCounter;
    [SerializeField] private TMP_Text _menuMoneyText;
    [SerializeField] private TMP_Text _gameMoneyText;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _sendButton;
    [SerializeField] private Button _hintButton;
    [SerializeField] private GameTimer _gameTimer;
    [SerializeField] private float _duration;
    [Inject] private ILevelManager _levelManager;
    [Inject] private GameController _gameController;
    [Inject] private MoneyManager _moneyManager;
    [Inject] private IHintSystem _hintSystem;
    [Inject] private ShopController _shopController;

    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _hintPanel;
    [SerializeField] private GameObject _hintPlacePanel;
    [SerializeField] private GameObject _menuPanel;
    
    private ObjectPool<Placeholder> _placeholderPool;
    
    public List<Placeholder> Placeholders => _placeholders;

    private void Start()
    {
        _resetButton.onClick.AddListener(ResetButtonText);
        _sendButton.onClick.AddListener(CheckIfWordExist);
        UpdateMoneyUI(_moneyManager.GetBalance());
        _placeholderPool = new ObjectPool<Placeholder>(_placeholderPrefab, _placeholderParent, 15);
    }

    private void OnEnable()
    {
        _moneyManager.OnBalanceChanged += UpdateMoneyUI;
        _placeholderHint.OnHintSpended += UpdateHintUI;
        _gameTimer.OnTimerCompleted += () =>
        {
            _menuPanel.SetActive(true);
            _gamePanel.SetActive(false);
            ReturnToObjectPool();
        };
        _backButton.onClick.AddListener(() =>
        {
            _gameTimer.StopTimer();
            _menuPanel.SetActive(true);
            _gamePanel.SetActive(false);
            ReturnToObjectPool();
        });
        
        _shopController.OnHindBought += UpdateHintUI;
        _hintButton.onClick.AddListener((() =>
        {
            if (_hintSystem.GetHintsCount() == 0)
            {
                _shopController.ActivateBuyHintPanel();
                return;
            }
            
            _hintText.text = _gameController.GetHint();
            if (_hintText.text != null)
            {
                _hintPanel.SetActive(true);
                UpdateHintUI();
            }
        }));
    }

    private void OnDisable()
    {
        _moneyManager.OnBalanceChanged -= UpdateMoneyUI;
        _shopController.OnHindBought -= UpdateHintUI;
        _placeholderHint.OnHintSpended -= UpdateHintUI;
    }

    private void ReturnToObjectPool()
    {
        foreach (var placeholder in _placeholders)
        {
            _placeholderPool.ReturnToPool(placeholder);
        }

        _placeholders.Clear();
    }
    
    public void SetLevelUI()
    {
        _gamePanel.SetActive(true);
        _gameTimer.StartTimer(_duration);
        LevelData data = _levelManager.GetCurrentLevel();
        _levelNameText.text = data.levelName;
        for (int i = 0; i < data.levelName.Length; i++)
        {
            _letterButtons[i].SetLetterText(data.levelName[i]);
            _letterButtons[i].SetButtonCallback(ChangeButtonText);
        }

        foreach (string word in data.words)
        {
            Placeholder placeholder = _placeholderPool.Get();
            placeholder.SetupWord(word);
            
            placeholder.PlaceholderButton.onClick.RemoveAllListeners();
            placeholder.PlaceholderButton.onClick.AddListener(() =>
            {
                if (placeholder.IsOpened)
                {
                    return;
                }

                _placeholderHint.SetupPlaceholder(placeholder);
                _hintPlacePanel.SetActive(true);
            });

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
        foreach (LetterButton letterButton in _letterButtons)
        {
            letterButton.SetButtonActive(true);
        }
    }

    private void UpdateMoneyUI(int money)
    {
        _menuMoneyText.text = money.ToString();
        _gameMoneyText.text = money.ToString();
    }

    private void UpdateHintUI()
    {
        _hintCounter.text = _hintSystem.GetHintsCount().ToString();
    }

    private void CheckIfWordExist()
    {
        Placeholder placeholder = _placeholders.FirstOrDefault(x => x.Word.Equals(_wordText.text, StringComparison.OrdinalIgnoreCase));
        if (placeholder != null && !placeholder.IsOpened)
        {
            _placeholderParent.DOLocalMove(_placeholderContentPoint.localPosition, .1f).SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.Linear);
            placeholder.OpenWord();
            _moneyManager.AddMoney(30);
            UpdateMoneyUI(_moneyManager.GetBalance());
            _gameController.SaveLevelProgress(_levelManager.GetCurrentLevel().levelName, _placeholders.Count(x=>x.IsOpened)/(float)_placeholders.Count*100f);
        }

        ResetButtonText();
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (_placeholders.TrueForAll(x => x.IsOpened))
        {
            _gameTimer.StopTimer();
            _menuPanel.SetActive(true);
            _gamePanel.SetActive(false);
        }
    }
}

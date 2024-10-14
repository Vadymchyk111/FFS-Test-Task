using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlaceholderHint : MonoBehaviour
{
    public event Action OnHintSpended;
    
    [SerializeField] private Button _letterButton;
    [SerializeField] private Button _wordButton;
    [SerializeField] private int _letterPrice;
    [SerializeField] private int _wordPrice;
    [Inject] private IHintSystem _hintSystem;
    [Inject] private MoneyManager _moneyManager;
    
    private Placeholder _placeholder;

    private void TrySpendHint(int price, Action action)
    {
        if (_moneyManager.SpendMoney(price) && _hintSystem.GetHintsCount() > 0)
        {
            _hintSystem.DecrementHintCount();
            action?.Invoke();
            OnHintSpended?.Invoke();
        }
    }

    private void Start()
    {
        _letterButton.onClick.AddListener(() => TrySpendHint(_letterPrice, _placeholder.OpenLetter));
        _wordButton.onClick.AddListener(() => TrySpendHint(_wordPrice, _placeholder.OpenWord));
    }

    public void SetupPlaceholder(Placeholder placeholder)
    {
        _placeholder = placeholder;
    }
}

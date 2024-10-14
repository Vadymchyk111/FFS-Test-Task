using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopController : MonoBehaviour
{
    public event Action OnHindBought;
    
    [Inject] private MoneyManager _moneyManager;
    [Inject] private IHintSystem _hintSystem;
    [SerializeField] private int _hintPrice;
    [SerializeField] private GameObject hindPanel;
    [SerializeField] private Button _buyButton;

    private void Start()
    {
        _buyButton.onClick.AddListener(BuyHint);
    }

    public void BuyHint()
    {
        if (_moneyManager.SpendMoney(_hintPrice))
        {
            _hintSystem.IncrementHintCount();
            OnHindBought?.Invoke();
            hindPanel.SetActive(false);
        }

        else
            Debug.Log("Not enought");
    }

    public void ActivateBuyHintPanel()
    {
        hindPanel.SetActive(true);
    }
}

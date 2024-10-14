using System;
using UnityEngine;
using Zenject;

public class MoneyManager
{
    private int _balance = 100;

    public Action<int> OnBalanceChanged;

    [Inject]
    public MoneyManager()
    {
        _balance = PlayerPrefs.GetInt("Money", 100);
    }

    public int GetBalance()
    {
        return _balance;
    }

    public void AddMoney(int amount)
    {
        if (amount < 0)
        {
            return;
        }
        
        _balance += amount;
        SaveBalance();
    }

    public bool SpendMoney(int amount)
    {
        if (amount < 0)
        {
            return false;
        }

        if (_balance < amount)
        {
            return false;
        }

        _balance -= amount;
        SaveBalance();
        return true;
    }
    
    private void SaveBalance()
    {
        PlayerPrefs.SetInt("Money", _balance);
        OnBalanceChanged?.Invoke(_balance);
    }
}
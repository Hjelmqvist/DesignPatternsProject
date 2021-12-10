using System;
using UnityEngine;

public class Wallet
{
    public static Wallet Instance { get; private set; } = new Wallet();

    const int MAX_GOLD = 99;
    int _currentGold;

    public int Gold => _currentGold;

    public event Action<int> OnGoldChanged;

    public void ModifyGold(int amount)
    {
        _currentGold = Mathf.Clamp( _currentGold + amount, 0, MAX_GOLD );
        OnGoldChanged?.Invoke( _currentGold );
    }
}

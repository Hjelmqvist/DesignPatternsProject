using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public static Inventory Instance { get; private set; } = new Inventory();

    const int MAX_GOLD = 99;

    int _currentGold;
    List<Item> _items = new List<Item>();

    public int Gold => _currentGold;

    public static event Action<int> OnGoldChanged;
    public static event Action<List<Item>, Item> OnItemAdded;

    public void ModifyGold(int amount)
    {
        _currentGold = Mathf.Clamp( _currentGold + amount, 0, MAX_GOLD );
        OnGoldChanged.Invoke( _currentGold );
    }

    public void AddItem(Item item)
    {
        if (item != null)
        {
            _items.Add( item );
            OnItemAdded.Invoke( _items, item );
        } 
    }

    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i] == item)
            {
                _items.RemoveAt( i );
                return true;
            }
        }
        return false;
    }
}

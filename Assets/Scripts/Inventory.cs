using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] int _maxGold = 99;

    int _currentGold;
    Item _currentItem;

    public int Gold => _currentGold;

    public UnityEvent<int> OnGoldChanged;
    public UnityEvent<Item> OnItemChanged;

    public void ModifyGold(int amount)
    {
        _currentGold = Mathf.Clamp( _currentGold + amount, 0, _maxGold );
        OnGoldChanged.Invoke( _currentGold );
    }

    public void SetItem(Item item)
    {
        _currentItem = item;
        OnItemChanged.Invoke( item );
    }

    public void UseCurrentItem()
    {
        if (_currentItem)
        {
            _currentItem.UseItem();
            _currentItem = null;
            OnItemChanged.Invoke( null );
        }
    }
}

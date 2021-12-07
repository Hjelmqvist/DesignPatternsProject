using UnityEngine;

public abstract class Item : Interactable, IItem
{
    [SerializeField] string _itemName;

    public virtual void UseItem()
    {
        throw new System.NotImplementedException();
    }
}
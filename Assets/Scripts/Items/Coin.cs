using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    [SerializeField] int _coinValue = 1;

    protected override void Interact(PlayerCharacter player)
    {
        // player.Inventory.ModifyGold( _coinValue );
    }
}

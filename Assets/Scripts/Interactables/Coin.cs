using UnityEngine;

public class Coin : Interactable
{
    [SerializeField] int _coinValue = 1;

    public int Value => _coinValue;

    protected override void Interact(PlayerCharacter player)
    {
        Wallet.Instance.ModifyGold( _coinValue );
        Destroy( gameObject );
    }
}
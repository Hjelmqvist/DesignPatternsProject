using System;
using UnityEngine;

public class Key : Interactable
{
    [SerializeField] KeyType _type;

    public enum KeyType { Blue, Green, Red, Yellow }

    public static event Action<KeyType> OnKeyPickedUp;

    protected override void Interact(PlayerCharacter player)
    {
        OnKeyPickedUp?.Invoke( _type );
        Destroy( gameObject );
    }
}

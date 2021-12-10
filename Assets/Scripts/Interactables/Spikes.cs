using UnityEngine;

public class Spikes : Interactable
{
    [SerializeField] int _damage = 1;

    protected override void Interact(PlayerCharacter player)
    {
        Health health = player.Health;
        health.ModifyHealth( -_damage );
    }
}
using UnityEngine;

public class DeathZone : Interactable
{
    [SerializeField] int _damage = 1;

    protected override void Interact(PlayerCharacter player)
    {
        Health health = player.Health;
        health.ModifyHealth( -_damage );
        if (health.CurrentHealth > 0)
            Checkpoint.MovePlayerToCheckpoint();
    }
}
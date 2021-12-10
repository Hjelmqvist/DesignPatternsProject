using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Interactable : MonoBehaviour
{
    protected abstract void Interact(PlayerCharacter player);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent( out PlayerCharacter player ))
        {
            Interact( player );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerCharacter player))
        {
            Interact( player );
        }
    }
}
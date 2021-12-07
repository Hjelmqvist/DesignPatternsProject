using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected abstract void Interact(PlayerCharacter player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerCharacter player))
        {
            Interact( player );
        }
    }
}
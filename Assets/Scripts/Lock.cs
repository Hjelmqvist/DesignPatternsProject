using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] Key.KeyType _type;

    private void OnEnable()
    {
        Key.OnKeyPickedUp += OnKeyPickedUp;
    }

    private void OnDisable()
    {
        Key.OnKeyPickedUp -= OnKeyPickedUp;
    }

    private void OnKeyPickedUp(Key.KeyType type)
    {
        if (_type == type)
            Destroy( gameObject );
    }
}
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Health
{
    [SerializeField] int _health = 100;
    [SerializeField] int _maxHealth;

    public int CurrentHealth => _health;

    [Space]
    public UnityEvent<HealthChangedArgs> OnHealthChanged;

    public void ModifyHealth(int value)
    {
        int previousHealth = _health;
        _health = Mathf.Clamp( _health + value, 0, _maxHealth );

        if (previousHealth != _health)
            OnHealthChanged.Invoke( new HealthChangedArgs( _health, previousHealth ) );
    }
}

public struct HealthChangedArgs
{
    public readonly int CurrentHealth;
    public readonly int PreviousHealth;

    public HealthChangedArgs(int currentHealth, int previousHealth)
    {
        CurrentHealth = currentHealth;
        PreviousHealth = previousHealth;
    }
}
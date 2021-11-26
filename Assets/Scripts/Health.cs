using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Health
{
    [SerializeField] int _health;
    int _currentHealth;

    [Space(20)]
    public UnityEvent<HealthChangedArgs> OnHealthChanged;

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

    public void ModifyHealth(int value)
    {
        int previousHealth = _currentHealth;
        _currentHealth = Mathf.Clamp( _currentHealth + value, 0, _health );

        if (previousHealth != _currentHealth)
            OnHealthChanged.Invoke( new HealthChangedArgs( _currentHealth, previousHealth ) );
    }
}
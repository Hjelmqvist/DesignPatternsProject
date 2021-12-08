using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacter : Character
{
    public static PlayerCharacter Instance { get; private set; }

    [Space]
    [SerializeField] string _horizontalAxisName = "Horizontal";
    [SerializeField] string _jumpButtonName = "Jump";
    [SerializeField] float _deathJumpForce = 1;

    PlayerInput _input;
    PlayerMovement _movement;

    public UnityEvent OnPlayerDeath;

    protected override void Awake()
    {
        if (Instance != null && !Instance.Equals( null ))
        {
            Destroy( gameObject );
            return;
        }
        Instance = this;
        DontDestroyOnLoad( gameObject );

        base.Awake();
        _input = new PlayerInput( _horizontalAxisName, _jumpButtonName );
        _movement = new PlayerMovement( this, _input );
    }

    protected override void Update()
    {
        base.Update();

        _input.OnUpdate();
        _movement.OnUpdate();
    }

    public void HealthChanged(HealthChangedArgs args)
    {
        if (args.CurrentHealth <= 0)
        {
            RB.velocity = Vector2.up * _deathJumpForce;
            OnPlayerDeath.Invoke();
            enabled = false;
        }
    }
}
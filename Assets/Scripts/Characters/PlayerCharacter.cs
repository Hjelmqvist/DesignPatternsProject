using UnityEngine;
using UnityEngine.Events;

public class PlayerCharacter : Character
{
    [Space]
    [SerializeField] string _horizontalAxisName = "Horizontal";
    [SerializeField] string _jumpButtonName = "Jump";
    [SerializeField] float _deathJumpForce = 1;

    PlayerInput _input;
    PlayerMovement _movement;

    public UnityEvent OnPlayerDeath;

    protected override void Awake()
    {
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

    public override void HealthChanged(HealthChangedArgs args)
    {
        base.HealthChanged( args );
        RB.velocity = Vector2.zero;

        if (IsAlive == false)
        {
            RB.AddForce( Vector2.up * _deathJumpForce, ForceMode2D.Impulse );
            OnPlayerDeath.Invoke();
        }
        else
            transform.position = Checkpoint.GetCheckpointPosition();
    }
}
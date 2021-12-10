using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] float _movementSpeed = 1;
    [SerializeField] float _jumpForce = 1;
    [SerializeField] Vector2 _groundCheckOffset;
    [SerializeField] Vector2 _groundCheckSize;

    CharacterAnimator _animator;

    public bool IsAlive { get; private set; } = true;
    public float Direction { get; private set; }
    public bool IsGrounded { get; private set; }
    public Health Health => _health;
    public Rigidbody2D RB { get; private set; }

    protected virtual void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        _animator = new CharacterAnimator( GetComponent<Animator>(), this, GetComponent<SpriteRenderer>() );
    }

    protected virtual void Update()
    {
        IsGrounded = GroundedCheck();
        _animator.OnUpdate();
    }

    public void Move(float direction)
    {
        Vector2 vel = RB.velocity;
        vel.x = direction * _movementSpeed;
        RB.velocity = vel;
        Direction = direction;
    }

    public void Jump()
    {
        RB.AddForce( Vector2.up * _jumpForce, ForceMode2D.Impulse );
    }

    private bool GroundedCheck()
    {
        Vector2 point = (Vector2)transform.position + _groundCheckOffset;
        return Physics2D.BoxCastAll( point, _groundCheckSize, 0, Vector2.zero ).Length > 1;
    }

    public virtual void HealthChanged(HealthChangedArgs args)
    {
        bool dead = args.CurrentHealth <= 0;
        IsAlive = !dead;
        if (dead)
            _animator.OnCharacterDeath();
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawCube( (Vector2)transform.position + _groundCheckOffset, _groundCheckSize );
    }
}
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] float _movementSpeed = 1;
    [SerializeField] float _jumpForce = 1;
    [SerializeField] Vector2 _groundCheckOffset;
    [SerializeField] Vector2 _groundCheckSize;

    public float Direction { get; private set; }
    public bool IsGrounded { get; private set; }
    public Health Health => _health;
    public Rigidbody2D RB { get; private set; }

    protected virtual void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        IsGrounded = GroundedCheck();
    }

    public void Move(float direction)
    {
        if (Mathf.Approximately( direction, 0 ) == false)
        {
            Vector2 vel = RB.velocity;
            vel.x = direction * _movementSpeed;
            RB.velocity = vel;

           // RB.velocity.Set( movement, RB.velocity.y );
            Debug.Log( RB.velocity );
        }
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

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawCube( (Vector2)transform.position + _groundCheckOffset, _groundCheckSize );
    }
}
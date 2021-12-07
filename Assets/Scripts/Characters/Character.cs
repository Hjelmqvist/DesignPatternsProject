using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] float _movementSpeed = 1;
    [SerializeField] float _jumpForce = 1;
    [SerializeField] Vector2 _groundCheckOffset;
    [SerializeField] Vector2 _groundCheckSize;

    public float Direction { get; protected set; }
    public bool IsGrounded { get; private set; }
    public Health Health => _health;
    public Rigidbody2D RB { get; private set; }

    protected virtual void Update()
    {
        IsGrounded = GroundedCheck();
        RB = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        if (Mathf.Approximately( direction, 0 ) == false)
        {
            float positionChange = direction * _movementSpeed * Time.deltaTime;
            transform.Translate( Vector2.right * positionChange );
        }
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
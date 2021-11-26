using UnityEngine;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] string _horizontalAxisName = "Horizontal";
    [SerializeField] float _movementSpeed = 1;
    [SerializeField] string _jumpButtonName = "Jump";
    [SerializeField] float _jumpForce = 1;

    Rigidbody2D _rb;
    SpriteRenderer _renderer;

    public void Execute()
    {
        float x = Input.GetAxisRaw( _horizontalAxisName );
        Move( x );

        if (Input.GetButtonDown( _jumpButtonName ))
            Jump();

        SetRotation( x );
    }

    private void Move(float x)
    { 
        Vector2 velocity = _rb.velocity;
        velocity.x = x * _movementSpeed * Time.deltaTime;
        _rb.velocity = velocity;
    }

    private void Jump()
    {
        _rb.AddForce( Vector2.up * _jumpForce );
    }

    private void SetRotation(float x)
    {
        if (x != 0)
            _renderer.flipX = x < 0;
    }

    public void Setup(Rigidbody2D rb, SpriteRenderer renderer)
    {
        _rb = rb;
        _renderer = renderer;
    }
}
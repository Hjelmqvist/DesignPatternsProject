using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCharacter : Character
{
    [Space]
    [SerializeField] string _horizontalAxisName = "Horizontal";
    [SerializeField] float _jumpForce = 1;
    [SerializeField] string _jumpButtonName = "Jump";

    protected Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();

        // Jump in Update to check Input every frame
        if (Input.GetButtonDown( _jumpButtonName ) && IsGrounded)
            Jump();
    }

    private void FixedUpdate()
    {
        // Movement in FixedUpdate to prevent rubber banding with Physics stuff
        float x = Input.GetAxisRaw( _horizontalAxisName );
        Direction = x;
        Move( x );
    }

    private void Jump()
    {
        _rb.AddForce( Vector2.up * _jumpForce, ForceMode2D.Impulse );
    }
}
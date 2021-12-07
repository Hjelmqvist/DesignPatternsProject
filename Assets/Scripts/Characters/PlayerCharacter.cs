using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCharacter : Character
{
    public static PlayerCharacter Instance { get; private set; }

    [Space]
    [SerializeField] string _horizontalAxisName = "Horizontal";
    [SerializeField] string _jumpButtonName = "Jump";

    private void Awake()
    {
        if (Instance == null || Instance.Equals( null ))
        {
            Instance = this;
            DontDestroyOnLoad( gameObject );
        }
        else
            Destroy( gameObject );
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
}
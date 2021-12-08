using UnityEngine;

[RequireComponent( typeof( Animator ), typeof(Character), typeof(SpriteRenderer))]
public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] string _groundedBool = "IsGrounded";
    [SerializeField] string _movespeedFloat = "Movespeed";
    [SerializeField] string _deathBool = "Dead";

    Animator _animator;
    Character _character;
    SpriteRenderer _renderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _character = GetComponent<Character>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float dir = _character.Direction;

        _animator.SetBool( _groundedBool, _character.IsGrounded );
        _animator.SetFloat( _movespeedFloat, Mathf.Abs(dir) );

        if (Mathf.Approximately(dir, 0) == false)
            _renderer.flipX = _character.Direction < 0;
    }

    public void OnCharacterDeath()
    {
        _animator.SetBool( _deathBool, true );
    }
}
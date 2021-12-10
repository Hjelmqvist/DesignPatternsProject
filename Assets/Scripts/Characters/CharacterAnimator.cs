using UnityEngine;

public class CharacterAnimator
{
    const string _groundedBool = "IsGrounded";
    const string _movespeedFloat = "Movespeed";
    const string _deathBool = "Dead";

    Animator _animator;
    Character _character;
    SpriteRenderer _renderer;

    public CharacterAnimator(Animator animator, Character character, SpriteRenderer renderer)
    {
        _animator = animator;
        _character = character;
        _renderer = renderer;
    }

    public void OnUpdate()
    {
        float dir = _character.Direction;

        _animator.SetBool( _groundedBool, _character.IsGrounded );
        _animator.SetFloat( _movespeedFloat, Mathf.Abs( dir ) );

        if (Mathf.Approximately( dir, 0 ) == false)
            _renderer.flipX = _character.Direction < 0;
    }

    public void OnCharacterDeath()
    {
        _animator.SetBool( _deathBool, true );
    }
}
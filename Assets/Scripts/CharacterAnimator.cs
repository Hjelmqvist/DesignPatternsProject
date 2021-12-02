using UnityEngine;

[RequireComponent( typeof( Animator ), typeof(Character), typeof(SpriteRenderer))]
public class CharacterAnimator : MonoBehaviour
{
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

        _animator.SetBool( "IsGrounded", _character.IsGrounded );
        _animator.SetFloat( "Movespeed", Mathf.Abs(dir) );


        if (Mathf.Approximately(dir, 0) == false)
            _renderer.flipX = _character.Direction < 0;
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Spring : Interactable
{
    [SerializeField] float _springPower = 10;
    [SerializeField] float _secondsToReset = 1;
    [SerializeField] string _animatorBool = "Ready";
    bool _isReady = true;

    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void Interact(PlayerCharacter player)
    {
        if (_isReady)
        {
            player.RB.AddForce( Vector2.up * _springPower, ForceMode2D.Impulse );
            _animator.SetBool( _animatorBool, false );
            _isReady = false;
            StartCoroutine( ResetAfterSeconds( _secondsToReset ) );
        }
    }

    IEnumerator ResetAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds( seconds );
        _animator.SetBool( _animatorBool, true );
        _isReady = true;
    }
}
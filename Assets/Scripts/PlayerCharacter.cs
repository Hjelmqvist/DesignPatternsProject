using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerCharacter : Character
{
    [SerializeField] PlayerMovement _movement;

    Rigidbody2D _rb;
    SpriteRenderer _renderer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();

        _movement.Setup( _rb, _renderer );
    }

    private void Update()
    {
        _movement.Execute();
    }
}
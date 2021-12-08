using UnityEngine;

public class PlayerInput
{
    string _horizontal;
    string _jump;

    public float Direction { get; private set; }
    public bool Jump { get; private set; }

    public PlayerInput(string horizontal, string jump)
    {
        _horizontal = horizontal;
        _jump = jump;
    }

    public void OnUpdate()
    {
        Direction = Input.GetAxis( _horizontal );
        Jump = Input.GetButtonDown( _jump );
    }
}
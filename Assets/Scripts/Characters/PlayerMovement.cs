public class PlayerMovement
{
    Character _character;
    PlayerInput _input;

    public PlayerMovement(Character character, PlayerInput input)
    {
        _character = character;
        _input = input;
    }

    public void OnUpdate()
    {
        if (_character.IsAlive == false)
            return;

        _character.Move( _input.Direction );
        if (_input.Jump && _character.IsGrounded)
            _character.Jump();
    }
}
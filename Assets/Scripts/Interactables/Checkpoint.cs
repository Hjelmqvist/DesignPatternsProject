using UnityEngine;

public class Checkpoint : Interactable
{
    [SerializeField] Vector2 _respawnPointOffset;
    [SerializeField] float _debugSphereRadius = 0.2f;
    Animator _animator;

    private static Checkpoint _currentCheckpoint;
    public Vector2 Position { get { return (Vector2)transform.position + _respawnPointOffset; } }

    public static Vector2 GetCheckpointPosition()
    {
        return _currentCheckpoint != null
             ? _currentCheckpoint.Position 
             : Vector2.zero;
    }

    protected override void Interact(PlayerCharacter player)
    {
        _currentCheckpoint = this;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _currentCheckpoint == this ? Color.green : Color.red;
        Gizmos.DrawSphere( (Vector2)transform.position + _respawnPointOffset, _debugSphereRadius );
    }
}
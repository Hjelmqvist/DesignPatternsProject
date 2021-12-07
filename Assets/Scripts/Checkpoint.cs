using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Checkpoint : Interactable
{
    [SerializeField] string _checkpointActiveString = "Active";
    Animator _animator;

    public static Vector2 _checkpointPosition;
    private static event Action<Checkpoint> OnCheckpointChanged;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _checkpointPosition = PlayerCharacter.Instance.transform.position;
    }

    public static void MovePlayerToCheckpoint()
    {
        PlayerCharacter.Instance.RB.MovePosition( _checkpointPosition );
    }

    protected override void Interact(PlayerCharacter player)
    {
        _checkpointPosition = player.transform.position;
        OnCheckpointChanged?.Invoke( this );
    }

    private void OnEnable()
    {
        OnCheckpointChanged += Checkpoint_OnCheckpointChanged;
    }

    private void OnDisable()
    {
        OnCheckpointChanged -= Checkpoint_OnCheckpointChanged;
    }

    private void Checkpoint_OnCheckpointChanged(Checkpoint checkpoint)
    {
        _animator.SetBool( _checkpointActiveString, checkpoint == this );
    }
}
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform _cannonJoint;
    [SerializeField] Transform _cannonSpawnpoint;
    [SerializeField] float _rotationSpeed = 10;
    [SerializeField, Tooltip("Time before changing to searching again.")] float _maxLostTime = 2f;

    [Space]
    [SerializeField] Projectile _projectile;
    [SerializeField] int _initialCapacity;
    [SerializeField] float _roundsPerSecond;

    ComponentPool<Projectile> _projectilePool;
    PlayerCharacter _target;
    TurretState _state;

    private void Start()
    {
        _projectilePool = new ComponentPool<Projectile>( _projectile, _initialCapacity, transform );
        _state = new TurretSearchState( this );
    }

    private void Update()
    {
        _state.OnUpdate();
    }

    public Vector2 GetDirection()
    {
        return _cannonJoint.rotation * Vector2.up;
    }

    public Vector2 GetSpawnpoint()
    {
        return _cannonSpawnpoint.position;
    }

    public void RotateCannon(float rotation)
    {
        float current = _cannonJoint.eulerAngles.z;
        float newRotation = current + rotation * _rotationSpeed;
        _cannonJoint.rotation = Quaternion.AngleAxis( newRotation, Vector3.forward );
    }

    public void SetDirection(Vector2 direction)
    {
        _cannonJoint.up = direction;
    }

    public void SetTarget(PlayerCharacter player)
    {
        _target = player;
    }

    public void ChangeState(TurretState.Type type)
    {
        switch (type)
        {
            case TurretState.Type.Search:
                _state = new TurretSearchState( this );
                break;
            case TurretState.Type.Attack:
                _state = new TurretAttackState( this, _target, _projectilePool, _maxLostTime, _roundsPerSecond );
                break;
            default:
                break;
        }
    }
}

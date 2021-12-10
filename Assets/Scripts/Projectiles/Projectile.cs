using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour, IPoolable<Projectile>
{
    [SerializeField] int _damage = 1;
    [SerializeField] float _speed;
    [SerializeField] float _secondsAlive;
    [SerializeField] Vector2 _startDirection;
    Vector2 _direction;
    float _timeSpentAlive;

    ComponentPool<Projectile> _pool;
    Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _startDirection;
    }

    void Update()
    {
        _timeSpentAlive += Time.deltaTime;
        if (_timeSpentAlive > _secondsAlive)
            ReturnToPool();
    }

    void OnEnable()
    {
        _timeSpentAlive = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out PlayerCharacter player ))
        {
            player.Health.ModifyHealth( -_damage );
        }
        ReturnToPool();
    }

    public Projectile FromPosition(Vector2 position)
    {
        transform.position = position;
        return this;
    }

    public Projectile InDirection(Vector2 direction)
    {
        direction.Normalize();
        _direction = direction;
        transform.right = direction;
        _rb.velocity = direction * _speed;
        return this;
    }

    public void SetPool(ComponentPool<Projectile> pool)
    {
        _pool = pool;
    }

    public void ReturnToPool()
    {
        if (_pool != null)
            _pool.ReturnToPool( this );
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackState : TurretState
{
    PlayerCharacter _player;
    ComponentPool<Projectile> _pool;
    float _maxLostTime;
    float _secondsBetweenShots;

    float _lostPlayerTime;
    float _lastShotTime = float.MinValue;

    public TurretAttackState(Turret turret, PlayerCharacter player, ComponentPool<Projectile> pool, float maxLostTime, float roundsPerSecond) : base( turret )
    {
        _player = player;
        _pool = pool;
        _maxLostTime = maxLostTime;
        _secondsBetweenShots = 1f / roundsPerSecond;
    }

    public override void OnUpdate()
    { 
        RaycastHit2D hit = Physics2D.Raycast( _turret.GetSpawnpoint(), _turret.GetDirection() );

        if (hit && hit.transform.CompareTag( "Player" ))
        {
            Vector2 direction = _player.transform.position - _turret.transform.position;
            _turret.SetDirection( direction );
            _lostPlayerTime = 0;
            TryShoot( direction );
        }
        else
        {
            _lostPlayerTime += Time.deltaTime;
            if (_lostPlayerTime >= _maxLostTime)
                _turret.ChangeState( Type.Search );
        }
    }

    private void TryShoot(Vector2 direction)
    {
        if (_lastShotTime + _secondsBetweenShots <= Time.time)
        {
            Projectile projectile = _pool.GetFromPool();
            projectile.FromPosition( _turret.GetSpawnpoint() )
                      .InDirection( direction );
            _lastShotTime = Time.time;
        } 
    }
}

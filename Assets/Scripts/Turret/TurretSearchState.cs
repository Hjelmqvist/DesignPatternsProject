using UnityEngine;

public class TurretSearchState : TurretState
{
    public TurretSearchState(Turret turret) : base( turret )
    {
    }

    public override void OnUpdate()
    {
        _turret.RotateCannon( 1 * Time.deltaTime );

        RaycastHit2D hit = Physics2D.Raycast( _turret.GetSpawnpoint(), _turret.GetDirection());

        if (hit && hit.transform.TryGetComponent(out PlayerCharacter player))
        {
            _turret.SetTarget( player );
            _turret.ChangeState( Type.Attack );
        }
    }
}
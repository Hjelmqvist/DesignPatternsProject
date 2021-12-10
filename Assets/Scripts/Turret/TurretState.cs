public abstract class TurretState
{
    public enum Type { Search, Attack }

    protected Turret _turret;

    public TurretState(Turret turret)
    {
        _turret = turret;
    }

    public abstract void OnUpdate();
}
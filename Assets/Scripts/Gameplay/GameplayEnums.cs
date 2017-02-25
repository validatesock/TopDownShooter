namespace VldateSck
{
    public enum GunType
    {
        None = -1,
        Pistol,
        Shotgun,
        RocketLauncher,
        Count
    }

    public enum AmmoType
    {
        None = -1,
        Bullet,
        Shell,
        Rocket,
    }

    public enum FireType
    {
        Regular = 0,
        First = Regular,
        Auto,
        Burst,
        Count
    }

    public enum MovementDirection
    {
        Forward = 0,
        Backward,
        Left,
        Right,
        Count
    }

    public enum CharacterState
    {
        Alive = 0,
        Dead
    }
}
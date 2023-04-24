using Asteroids;

public sealed class PlayerWeapon : IWeapon
{
    public void Shoot(float shootForce)
    {
        var bullet = ServiceLocator.GetService<BulletsPool>();
        bullet.GetBaseObjPool<Bullet>(shootForce);
    }
}

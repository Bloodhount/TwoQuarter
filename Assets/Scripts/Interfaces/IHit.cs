using System;


public interface IHit
{
    event Action<int, string> OnHitChange;
    void TakeDamage(int damage);
}


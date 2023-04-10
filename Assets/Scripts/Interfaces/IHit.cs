using System;

namespace Observer
{
    public interface IHit
    {
        event Action<int> OnHitChange;
        void TakeDamage(int damage);
    }
}

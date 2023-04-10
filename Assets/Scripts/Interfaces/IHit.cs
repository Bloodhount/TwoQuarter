using System;

namespace Observer
{
    public interface IHit
    {
        event Action<int, string> OnHitChange;
        void TakeDamage(int damage);
    }
}

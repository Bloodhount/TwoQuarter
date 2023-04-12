using Asteroids;

namespace Asteroids.ChainOfResponsibility
{
    public class EnemyModifier 
    {
        protected Enemy _enemy;
        protected EnemyModifier Next;

        public EnemyModifier(Enemy enemy)
        {
            _enemy = enemy;
        }
        public void Add(EnemyModifier enemyModifier)
        {
            if (Next != null)
            {
                Next.Add(enemyModifier);
            }
            else
            {
                Next = enemyModifier;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}

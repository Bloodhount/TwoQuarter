using Asteroids;

namespace ChainOfResponsibility
{
    internal class AddDefenceModifier : EnemyModifier
    {
        private readonly int _maxDefence;

        public AddDefenceModifier(Enemy enemy, int defence) : base(enemy)
        {
            _maxDefence = defence;
        }
        public override void Handle()
        {
            if (_enemy.Defence <= _maxDefence)
            {
                _enemy.Defence++;
            }
            base.Handle();
        }
    }
}
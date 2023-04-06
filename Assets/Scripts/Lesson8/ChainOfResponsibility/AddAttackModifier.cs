using Asteroids;

namespace ChainOfResponsibility
{
    internal class AddAttackModifier : EnemyModifier
    {
        private readonly int _attack;

        public AddAttackModifier(Enemy enemy, int attack) : base(enemy)
        {
<<<<<<< HEAD
            _attack = attack;
=======
            _attack = _attack;
>>>>>>> 5ba6a86a4c2a6219ca716ca62a822a543072ed69
        }
        public override void Handle()
        {
            _enemy.Attack += _attack;
            base.Handle();
        }
    }
}
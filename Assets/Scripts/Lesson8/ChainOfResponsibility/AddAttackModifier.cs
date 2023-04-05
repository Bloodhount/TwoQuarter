﻿using Asteroids;

namespace ChainOfResponsibility
{
    internal class AddAttackModifier : EnemyModifier
    {
        private readonly int _attack;

        public AddAttackModifier(Enemy enemy, int attack) : base(enemy)
        {
            _attack = _attack;
        }
        public override void Handle()
        {
            _enemy.Attack += _attack;
            base.Handle();
        }
    }
}
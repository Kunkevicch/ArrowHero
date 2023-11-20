namespace ArrowHero.Core
{
    class SimpleEnemyDeadState : State
    {
        private SimpleEnemy _enemy;

        public SimpleEnemyDeadState(FSM FSM, SimpleEnemy enemy) : base(FSM)
        {
            _enemy = enemy;
        }

        public override void Enter()
        {
            _enemy.CapsuleCollider.enabled = false;
            _enemy.RB.isKinematic = true;
        }

    }
}

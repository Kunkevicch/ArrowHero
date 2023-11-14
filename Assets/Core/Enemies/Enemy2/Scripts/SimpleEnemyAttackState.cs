using UnityEngine;

namespace ArrowHero.Core
{
    public class SimpleEnemyAttackState : State
    {
        private SimpleEnemy _enemy;
        private float _attackTimer;

        public SimpleEnemyAttackState(FSM FSM, SimpleEnemy enemy) : base(FSM)
        {
            _enemy = enemy;
        }

        public override void Enter()
        {
            ResetTimer();
        }

        public override void Update()
        {
            if ( !_enemy.EnemyAI.IsReachedPlayer() )
            {
                _FSM.SetState<SimpleEnemyIdleState>();
            }

            _attackTimer -= Time.deltaTime;

            if ( _attackTimer < 0 )
            {
                _enemy.EnemyAI.AttackPlayer();
                ResetTimer();
            }
        }

        public override void FixedUpdate()
        {
        }

        private void ResetTimer()
        {
            _attackTimer = _enemy.EnemyConfig.AttackDelayTimer;
        }
    }
}
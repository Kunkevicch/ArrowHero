using UnityEngine;

namespace ArrowHero.Core
{
    public class SimpleEnemyIdleState : State
    {
        private SimpleEnemy _enemy;

        private float _waitTimer;

        public SimpleEnemyIdleState(FSM FSM, SimpleEnemy enemy) : base(FSM)
        {
            _enemy = enemy;
        }

        public override void Enter() 
        {
            ResetTimer();
        }

        public override void Update() 
        {
            _waitTimer -= Time.deltaTime;

            if (_waitTimer <= 0)
            {
                if( _enemy.EnemyAI.IsReachedPlayer() )
                {
                    _FSM.SetState<SimpleEnemyAttackState>();
                }
                else
                {
                    _FSM.SetState<SimpleEnemyMoveState>();
                }
            }
        }

        public override void FixedUpdate() { }
        
        public override void Exit() { }


        private void ResetTimer()
        {
            _waitTimer = _enemy.EnemyConfig.WaitTimer;
        }
    }
}
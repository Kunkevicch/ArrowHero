using UnityEngine;

namespace ArrowHero.Core
{
    public class SimpleEnemyMoveState : State
    {
        private SimpleEnemy _enemy;
        private float _waitTimer;
        private Vector3 _startPosition;

        public SimpleEnemyMoveState(FSM FSM, SimpleEnemy enemy) : base(FSM)
        {
            _enemy = enemy;
        }

        public override void Enter()
        {
            ResetTimer();
            _startPosition = _enemy.transform.position;
            Debug.Log("Я начал идти");
        }

        public override void FixedUpdate()
        {
            _waitTimer -= Time.deltaTime;
            if ( _waitTimer <= 0 )
            {
                
                _FSM.SetState<SimpleEnemyIdleState>();

            }
            else
            {
                if ( Vector3.Distance(_startPosition, _enemy.transform.position) >= _enemy.EnemyConfig.MoveDistance )
                {
                    _FSM.SetState<SimpleEnemyIdleState>();
                }
                _enemy.EnemyAI.MoveToRandomPoint();

            }
        }

        private void ResetTimer()
        {
            _waitTimer = _enemy.EnemyConfig.WaitTimer;
        }

    }
}
using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class SimpleEnemyFSM : MonoBehaviour
    {
        private FSM _fsm;
        private SimpleEnemy _enemy;
        private ObjectPool _objectPool;

        [Inject]
        private void Construct(ObjectPool objectPool)
        {
            _objectPool = objectPool;
        }

        private void Awake()
        {
            _enemy = GetComponent<SimpleEnemy>();
        }

        private void Start()
        {
            _fsm = new FSM();

            _fsm.AddState(new SimpleEnemyIdleState(_fsm, _enemy));
            _fsm.AddState(new SimpleEnemyMoveState(_fsm, _enemy));
            _fsm.AddState(new SimpleEnemyAttackState(_fsm, _enemy));
            _fsm.SetState<SimpleEnemyIdleState>();

        }

        private void Update()
        {
            _fsm.Update();
        }

        private void FixedUpdate()
        {
            _fsm.FixedUpdate();
        }
    }
}
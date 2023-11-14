using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class PlayerFSM : MonoBehaviour
    {
        private FSM _fsm;
        private Player _player;
        private EnemyController _enemyController;
        private ObjectPool _objectPool;

        [Inject]
        private void Construct(EnemyController enemyController, ObjectPool objectPool)
        {
            _enemyController = enemyController;
            _objectPool = objectPool;
        }

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void Start()
        {
            _fsm = new FSM();

            _fsm.AddState(new PlayerStateIdle(_fsm, _player, _enemyController));
            _fsm.AddState(new PlayerStateMove(_fsm, _player));
            _fsm.AddState(new PlayerStateAttack(_fsm, _player, _enemyController, _objectPool));
            _fsm.SetState<PlayerStateIdle>();
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
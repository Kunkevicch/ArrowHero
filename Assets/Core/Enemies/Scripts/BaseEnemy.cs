using UnityEngine;

namespace ArrowHero.Core
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        [SerializeField]
        protected EnemyConfig _enemyConfig;
        public EnemyConfig EnemyConfig => _enemyConfig;

        [SerializeField]
        protected Transform _attackPoint;
        public Transform AttackPoint => _attackPoint;

        protected EnemyAnimator _enemyAnimator;
        public EnemyAnimator EnemyAnimator => _enemyAnimator;

        protected BaseEnemyAI _enemyAi;
        public BaseEnemyAI EnemyAI => _enemyAi;

        protected CharacterEvent _enemyEvent;
        public CharacterEvent EnemyEvent => _enemyEvent;

        protected Rigidbody _rb;
        public Rigidbody RB => _rb;

        protected virtual void Awake()
        {
            _enemyEvent = GetComponent<CharacterEvent>();
            _enemyAi = GetComponent<BaseEnemyAI>();
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _rb = GetComponent<Rigidbody>();
        }
    }
}
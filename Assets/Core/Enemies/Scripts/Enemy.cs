using UnityEngine;

namespace ArrowHero.Core
{
    #region Attributes
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BaseEnemyAI))]
    [RequireComponent(typeof(BaseHealth))]
    [RequireComponent(typeof(EnemyEvent))]
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(EnemyReward))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    #endregion
    public abstract class Enemy : MonoBehaviour
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

        protected EnemyEvent _enemyEvent;
        public EnemyEvent EnemyEvent => _enemyEvent;

        protected BaseHealth _health;
        public BaseHealth Health => _health;

        protected Rigidbody _rb;
        public Rigidbody RB => _rb;

        protected CapsuleCollider _capsuleCollider;
        public CapsuleCollider CapsuleCollider => _capsuleCollider;

        protected virtual void Awake()
        {
            _enemyEvent = GetComponent<EnemyEvent>();
            _enemyAi = GetComponent<BaseEnemyAI>();
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _health = GetComponent<BaseHealth>();
            _rb = GetComponent<Rigidbody>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
        }
    }
}
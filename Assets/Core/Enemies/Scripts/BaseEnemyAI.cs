using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace ArrowHero.Core
{
    public abstract class BaseEnemyAI : MonoBehaviour
    {
        protected Enemy _enemy;

        protected Player _player;

        protected NavMeshAgent _agent;

        protected bool _isVisible;

        protected bool _isDead;

        protected ObjectPool _objectPool;

        [SerializeField]
        protected LayerMask _playerLayer;

        [Inject]
        protected void Construct(Player player, ObjectPool objectPool)
        {
            _player = player;
            _objectPool = objectPool;
        }

        public bool IsReachedPlayer()
        {
            Vector3 enemyPosition = new Vector3(transform.position.x, transform.position.y / 2, transform.position.z);

            Vector3 playerPosition = new Vector3(_player.transform.position.x, _player.transform.position.y / 2, _player.transform.position.z);

            Physics.Raycast(enemyPosition, playerPosition, out RaycastHit hitInfo, _playerLayer);

            return hitInfo.collider.gameObject.IsInLayer(_playerLayer);
        }

        protected virtual void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _agent = GetComponent<NavMeshAgent>();
        }

        protected void OnEnable()
        {
            _enemy.EnemyEvent.death += OnDeath;
        }

        private void OnDeath()
        {
            _isDead = true;
        }

        private void OnDisable()
        {
            _enemy.EnemyEvent.death -= OnDeath;
        }

        public abstract void MoveToRandomPoint();

        public abstract void AttackPlayer();
    }
}
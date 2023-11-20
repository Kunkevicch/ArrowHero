using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class EnemyReward : MonoBehaviour
    {
        [SerializeField]
        private Coin _coin;

        private Enemy _enemy;

        private Player _player;

        private ObjectPool _objectPool;

        [Inject]
        private void Construct(Player player, ObjectPool objectPool)
        {
            _player = player;
            _objectPool = objectPool;
        }

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnEnable()
        {
            _enemy.EnemyEvent.death += OnDeath;
        }

        private void OnDeath()
        {
            Coin coin = (Coin)_objectPool.ReuseComponent(_coin.gameObject,transform.position,Quaternion.identity);
            coin.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            _enemy.EnemyEvent.death -= OnDeath;
        }
    }
}
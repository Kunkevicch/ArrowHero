using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class EnemyController : MonoBehaviour
    {
        public Action EnemySpawned;
        public Action EnemiesCleared;

        private GameController _gameController;
        private EnemyFactory _enemyFactory;

        private Coroutine _enemySpawnCoroutine;
        private WaitForFixedUpdate _waitForFixedUpdate;

        private Coroutine _enemyDiedCoroutine;

        private const float WAIT_TIMER = 3f;

        [SerializeField]
        private List<Enemy> _currentEnemies = new();

        public bool IsEnemyExists()
        {
            return _currentEnemies.Count > 0;
        }

        public List<Enemy> GetCurrentEnemies()
        {
            return _currentEnemies;
        }

        public Vector3 GetNearestEnemyPosition(Vector3 origin)
        {
            Level currentLevel = _gameController.CurrentLevel;
            
            if ( currentLevel.GetLevelEnemies().Count == 0 ) return Vector3.zero;

            List<Enemy> enemies = GetCurrentEnemies();

            float minDistance = float.MaxValue;
            Enemy nearestEnemy = enemies.Last();
            foreach ( Enemy enemy in enemies )
            {
                float distance = ( enemy.transform.position - origin ).sqrMagnitude;
                if ( distance < minDistance )
                {
                    nearestEnemy = enemy;
                    minDistance = distance;
                }
            }
            return nearestEnemy == null? Vector3.zero : nearestEnemy.transform.position;
        }

        public Vector3 GetPlayerPosition()
        {
            return _gameController.Player.transform.position;
        }

        [Inject]
        private void Construct(GameController gameController, EnemyFactory enemyFactory)
        {
            _gameController = gameController;
            _enemyFactory = enemyFactory;
        }

        private void Start()
        {

            if ( _gameController.CurrentLevel.GetLevelEnemies().Count > 0 )
            {
                StartEnemySpawn();
            }
        }

        private void StartEnemySpawn()
        {
            if ( _enemySpawnCoroutine != null )
            {
                StopCoroutine(_enemySpawnCoroutine);
                _enemySpawnCoroutine = null;
            }
            _enemySpawnCoroutine = StartCoroutine(SpawnEnemyRoutine());
        }

        private IEnumerator SpawnEnemyRoutine()
        {
            int listIndex = _gameController.CurrentLevel.GetLevelEnemies().Count-1;
            
            while ( listIndex>= 0)
            {
                var lastEnemy = _gameController.CurrentLevel.GetLevelEnemies()[listIndex];
                var enemy = SpawnEnemy<Enemy>(lastEnemy);
                listIndex--;
                enemy.transform.position = Vector3.zero;
                _currentEnemies.Add(enemy);
                yield return _waitForFixedUpdate;
            }
            StopCoroutine(_enemySpawnCoroutine);
            _enemySpawnCoroutine = null;
            EnemySpawned?.Invoke();
        }

        private Enemy SpawnEnemy<T>(Enemy enemyType) where T : Enemy
        {
            var enemy = _enemyFactory.GetEnemy<T>(enemyType);
            return enemy;
        }

        private void OnEnable()
        {
            EnemyEvent.enemyDied += OnEnemyDied;
        }

        private void OnEnemyDied(Enemy enemy)
        {
            _currentEnemies.Remove(enemy);
            if(_currentEnemies.Count == 0 )
            {
                _enemyDiedCoroutine = StartCoroutine(EnemyDiedWithDelay());
            }
        }

        private IEnumerator EnemyDiedWithDelay()
        {
            WaitForSeconds wait = new WaitForSeconds(WAIT_TIMER);
            Debug.Log("Началось!");
            yield return wait;
            Debug.Log("Все!");
            EnemiesCleared?.Invoke();
            StopCoroutine(_enemyDiedCoroutine);
            _enemyDiedCoroutine = null;
        }

        private void OnDisable()
        {
            EnemyEvent.enemyDied -= OnEnemyDied;
        }
    }
}
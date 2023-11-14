using System;
using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class GameController : MonoBehaviour
    {

        public Action<GameStage> GameStageChange;

        private GameStage _currentGameStage = GameStage.Preparation;
        public GameStage CurrentGameStage 
        {
            private set
            {
                if ( value == _currentGameStage ) return;

                _currentGameStage = value;

                GameStageChange?.Invoke(value);
            }
            get
            {
                return _currentGameStage;
            }
        }

        private Level _currentLevel;
        public Level CurrentLevel => _currentLevel;


        private Player _player;
        public Player Player => _player;

        private LevelList _levelList;
        private EnemyFactory _enemyFactory;
        private EnemyController _enemyController;

        [Inject]
        private void Construct(Player player, LevelList levelList, EnemyFactory enemyFactory, EnemyController enemyController)
        {
            _player = player;
            _levelList = levelList;
            _enemyFactory = enemyFactory;
            _enemyController = enemyController;
        }

        private void Awake()
        {
            SelectRandomLevel();
            SpawnPlayer();
            _enemyFactory.Initialize();
        }

        private void OnEnable()
        {
            _enemyController.EnemySpawned += OnEnemySpawned;
        }

        private void SelectRandomLevel()
        {
            if ( _levelList.Levels.Count > 0 )
            {
                int levelIndex = UnityEngine.Random.Range(0, _levelList.Levels.Count);
                _currentLevel = _levelList.Levels[levelIndex];
            }
            Instantiate(_currentLevel, Vector3.zero, Quaternion.identity);
        }

        private void SpawnPlayer()
        {
            _player.transform.position = new Vector3(_currentLevel.PlayerSpawnPoint.position.x, _currentLevel.PlayerSpawnPoint.position.y+1, _currentLevel.PlayerSpawnPoint.position.z);
        }

        private void OnDisable()
        {
            _enemyController.EnemySpawned -= OnEnemySpawned;
        }

        private void OnEnemySpawned()
        {
            CurrentGameStage = GameStage.GameLoop;
        }
    }

    public enum GameStage
    {
        Preparation,
        GameLoop,
        Failed,
        Victory
    }
}
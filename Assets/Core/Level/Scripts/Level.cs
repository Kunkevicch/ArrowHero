using System.Collections.Generic;
using UnityEngine;

namespace ArrowHero.Core
{
    public class Level : MonoBehaviour
    {
        public Transform PlayerSpawnPoint => _playerSpawnPoint;

        public MeshRenderer GroundMesh=> _groundMesh;

        public LevelConfig LevelConfig => _levelConfig;

        [SerializeField]
        private Transform _playerSpawnPoint;

        [SerializeField]
        private MeshRenderer _groundMesh;

        [SerializeField]
        private LevelConfig _levelConfig;

        public List<Enemy> GetLevelEnemies()
        {
            return _levelConfig.Enemies;
        }

    }
}

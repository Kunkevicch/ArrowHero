using UnityEngine;

namespace ArrowHero.Core
{
    public class Level : MonoBehaviour
    {
        public Transform PlayerSpawnPoint => _playerSpawnPoint;

        public MeshRenderer GroundMesh=> _groundMesh;

        [SerializeField]
        private Transform _playerSpawnPoint;

        [SerializeField]
        private MeshRenderer _groundMesh;

    }
}

using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class GameController : MonoBehaviour
    {
        private Player _player;
        private Level _level;

        private void Awake()
        {
            SpawnPlayer();
        }

        [Inject]
        private void Construct(Player player, Level level)
        {
            _player = player;
            _level = level;
        }

        private void SpawnPlayer()
        {
            _player.transform.position = new Vector3(_level.PlayerSpawnPoint.position.x, _level.PlayerSpawnPoint.position.y+1, _level.PlayerSpawnPoint.position.z);
        }
    }

}
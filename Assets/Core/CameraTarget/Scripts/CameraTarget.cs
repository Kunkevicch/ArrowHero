using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class CameraTarget : MonoBehaviour
    {
        private GameController _gameController;
        private Player _player;

        [Inject]
        private void Construct(GameController gameController, Player player)
        {
            _gameController = gameController;
            _player = player;
        }

        private void Start()
        {
            transform.position = _gameController.CurrentLevel.transform.position;
        }

        private void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y , _player.transform.position.z);
        }
    }
}
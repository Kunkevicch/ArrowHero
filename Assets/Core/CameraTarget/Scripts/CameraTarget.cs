using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class CameraTarget : MonoBehaviour
    {
        private Level _level;
        private Player _player;

        [Inject]
        private void Construct(Level level, Player player)
        {
            _level = level;
            _player = player;
        }

        private void Start()
        {
            transform.position = _level.transform.position;
        }

        private void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y , _player.transform.position.z);
        }
    }
}
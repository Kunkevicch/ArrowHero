using UnityEngine;

namespace ArrowHero.Core
{
    public class Player : MonoBehaviour
    {
        public PlayerConfig PlayerConfig => _playerConfig;
        
        [SerializeField]
        private PlayerConfig _playerConfig;


        public Rigidbody Rb => _rb;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
    }
}
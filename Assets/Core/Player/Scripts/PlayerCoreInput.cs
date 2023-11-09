using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class PlayerCoreInput : MonoBehaviour
    {
        private Player _player;

        private CoreInput _coreInput;

        [Inject]
        private void Construct(CoreInput coreInput)
        {
            _coreInput = coreInput;
        }

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void FixedUpdate()
        {
            MoveInput();
        }

        private void MoveInput()
        {
            float horizontalMove = _coreInput.Joystick.Horizontal; 
            float verticalMove = _coreInput.Joystick.Vertical;
            
            _player.Rb.velocity = new Vector3(horizontalMove * _player.PlayerConfig.MoveSpeed, _player.Rb.velocity.y, verticalMove * _player.PlayerConfig.MoveSpeed);

            if (horizontalMove != 0 || verticalMove != 0)
            {
                _player.transform.rotation = Quaternion.LookRotation(new Vector3(_coreInput.Joystick.Direction.x, 0f, _coreInput.Joystick.Direction.y));
            }
        }
    }
}
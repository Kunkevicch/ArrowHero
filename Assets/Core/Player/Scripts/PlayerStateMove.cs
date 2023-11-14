using UnityEngine;

namespace ArrowHero.Core
{
    public class PlayerStateMove : State
    {
        private Player _player;

        public PlayerStateMove(FSM FSM,Player player) : base(FSM)
        {
            _player = player;
        }

        public override void Enter()
        {
        }

        public override void Update()
        {
            
        }

        public override void FixedUpdate()
        {
            MoveInput();
        }

        private void MoveInput()
        {
            float horizontalMove = _player.Input.Joystick.Horizontal;
            float verticalMove = _player.Input.Joystick.Vertical;

            _player.Rb.velocity = new Vector3(horizontalMove * _player.PlayerConfig.MoveSpeed, _player.Rb.velocity.y, verticalMove * _player.PlayerConfig.MoveSpeed);

            if ( horizontalMove != 0 || verticalMove != 0 )
            {
                _player.transform.rotation = Quaternion.LookRotation(new Vector3(_player.Input.Joystick.Direction.x, 0f, _player.Input.Joystick.Direction.y));
                _player.PlayerEvent.CallMove(_player.Rb.velocity.magnitude);
            }
            else
            {
                _FSM.SetState<PlayerStateIdle>();
            }
        }
    }
}
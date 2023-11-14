namespace ArrowHero.Core
{
    public class PlayerStateIdle : State
    {
        private Player _player;
        private EnemyController _enemyController;

        public PlayerStateIdle(FSM FSM, Player player, EnemyController enemyController) : base(FSM)
        {
            _player = player;
            _enemyController = enemyController;
        }

        public override void Enter()
        {
            _player.PlayerEvent.CallIdle();
        }

        public override void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            float horizontalMove = _player.Input.Joystick.Horizontal;
            float verticalMove = _player.Input.Joystick.Vertical;

            if ( horizontalMove != 0 || verticalMove != 0 )
            {
                _FSM.SetState<PlayerStateMove>();
            }
            else if(_enemyController.IsEnemyExists())
            {
                _FSM.SetState<PlayerStateAttack>();
            }
        }
    }
}
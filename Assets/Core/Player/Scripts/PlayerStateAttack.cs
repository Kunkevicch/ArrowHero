using UnityEngine;

namespace ArrowHero.Core
{
    public class PlayerStateAttack : State
    {
        private Player _player;
        private EnemyController _enemyController;
        private float _attackTime = 0f;
        private ObjectPool _objectPool;

        public PlayerStateAttack(FSM FSM, Player player, EnemyController enemyController, ObjectPool objectPool) : base(FSM)
        {
            _player = player;
            _enemyController = enemyController;
            _attackTime = _player.PlayerConfig.AttackSpeed;
            _objectPool = objectPool;
        }

        public override void Enter()
        {
            _attackTime = _player.PlayerConfig.AttackSpeed;
        }

        public override void Update()
        {
            CheckInput();
            CheckAttack();
        }

        private void CheckInput()
        {
            float horizontalMove = _player.Input.Joystick.Horizontal;
            float verticalMove = _player.Input.Joystick.Vertical;


            if ( horizontalMove != 0 || verticalMove != 0 )
            {
                _FSM.SetState<PlayerStateMove>();
            }
            else if ( _enemyController.IsEnemyExists() )
            {
                _FSM.SetState<PlayerStateAttack>();
            }
        }

        private void CheckAttack()
        {
            if ( !_enemyController.IsEnemyExists() )
            {
                _FSM.SetState<PlayerStateIdle>();
            }
            else
            {
                _attackTime -= Time.deltaTime;
                if ( _attackTime < 0 )
                {
                    Attack();
                    _attackTime = _player.PlayerConfig.AttackSpeed;
                }
            }
        }

        private void Attack()
        {
            Vector3 targetEnemy = _enemyController.GetNearestEnemyPosition(_player.transform.position);
            _player.transform.LookAt(new Vector3(targetEnemy.x, 1f, targetEnemy.z));
            Projectile projectile = (Projectile)_objectPool.ReuseComponent(_player.PlayerConfig.ProjectilePrefab, _player.AttackPoint.position, _player.transform.rotation);
            projectile.InitProjectile(_player.PlayerConfig.DamagePerShot);
            projectile.gameObject.SetActive(true);
        }
    }
}
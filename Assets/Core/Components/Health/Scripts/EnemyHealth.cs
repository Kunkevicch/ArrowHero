using UnityEngine;

namespace ArrowHero.Core
{
    public class EnemyHealth : BaseHealth
    {
        private Enemy _enemy;
        
        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            InitHealth();
        }

        public override void TakeDamage(int damage)
        {
            if(IsDead) return;

            _currentHP = Mathf.Clamp(_currentHP - damage, 0, MaxHP);

            if ( _currentHP <= 0 )
            {
                _isDead = true;
                _enemy.EnemyEvent.CallDeath();
                _enemy.EnemyEvent.CallEnemyDied(_enemy);
            }
        }

        protected override void InitHealth()
        {
            MaxHP = _enemy.EnemyConfig.MaxHP;
            _currentHP = MaxHP;
        }
    }
}
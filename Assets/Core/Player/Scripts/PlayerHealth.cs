using UnityEngine;

namespace ArrowHero.Core
{
    public class PlayerHealth : BaseHealth
    {
        private Player _player;

        public override void TakeDamage(int damage)
        {
            if ( IsDead ) return;

            _currentHP = Mathf.Clamp(_currentHP - damage, 0, MaxHP);
            
            if(_currentHP <= 0 )
            {
                _isDead = true;
                _player.PlayerEvent.CallDeath();
            }
        }

        private void Awake()
        {
            _player = GetComponent<Player>();
            InitHealth();
        }

        protected override void InitHealth()
        {
            MaxHP = _player.PlayerConfig.MaxHP;
            _currentHP = MaxHP;
        }
    }
}
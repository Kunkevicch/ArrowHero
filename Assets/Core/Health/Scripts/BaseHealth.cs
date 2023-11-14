using UnityEngine;

namespace ArrowHero.Core
{
    public abstract class BaseHealth : MonoBehaviour
    {
        protected int _maxHP;
        public int MaxHP
        {
            protected set
            {
                if ( value < 0 ) return;
                _maxHP = value;
            }
            get
            { 
                return _maxHP; 
            }
        }

        protected int _currentHP;
        public int CurrentHP => _currentHP;

        protected bool _isDead = false;
        public bool IsDead => _isDead;

        protected abstract void HealthInit();
        public abstract void TakeDamage(int damage);

        
    }
}

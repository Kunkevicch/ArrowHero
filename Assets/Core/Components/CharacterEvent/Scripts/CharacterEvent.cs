using System;
using UnityEngine;

namespace ArrowHero.Core
{
    public class CharacterEvent : MonoBehaviour
    {
        public event Action idle;
        public event Action<float> move;
        public event Action attack;
        public event Action death;

        public Action<bool> canMove;
        public Action<bool> canAttack;

        public virtual void CallIdle()
        {
            idle?.Invoke();
        }

        public virtual void CallMove(float velocity)
        {
            move?.Invoke(velocity);
        }

        public virtual void CallAttack()
        {
            attack?.Invoke();
        }

        public virtual void CallDeath()
        {
            death?.Invoke();
        }
    }
}

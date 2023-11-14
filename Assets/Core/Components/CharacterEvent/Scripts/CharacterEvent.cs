using System;
using UnityEngine;

namespace ArrowHero.Core
{
    public class CharacterEvent : MonoBehaviour
    {
        public Action idle;
        public Action<float> move;
        public Action attack;
        public Action death;

        public Action<bool> canMove;
        public Action<bool> canAttack;
        public Action Pause;

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

using UnityEngine;

namespace ArrowHero.Core
{
    public static class AnimationUtil
    {
        public static readonly int IdleKey = Animator.StringToHash("isIdle");
        public static readonly int VelocityKey = Animator.StringToHash("velocity");
        public static readonly int AttackKey = Animator.StringToHash("attack");
        public static readonly int DeathKey = Animator.StringToHash("isDead");
    }
}
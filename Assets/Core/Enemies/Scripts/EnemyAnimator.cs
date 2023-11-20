using UnityEngine;

namespace ArrowHero.Core
{
    public class EnemyAnimator : MonoBehaviour
    {
        private Animator _animator;
        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _enemy.EnemyEvent.idle += OnIdle;
            _enemy.EnemyEvent.move += OnMove;
            _enemy.EnemyEvent.attack += OnAttack;
            _enemy.EnemyEvent.death += OnDeath;
        }

        private void OnIdle()
        {
            ResetAnimation();
        }

        private void OnMove(float velocity)
        {
            ResetAnimation();
            _animator.SetFloat(AnimationUtil.VelocityKey, velocity);
        }

        private void OnAttack()
        {
            ResetAnimation();
            _animator.SetTrigger(AnimationUtil.AttackKey);
        }

        private void OnDeath()
        {
            ResetAnimation();
            _animator.SetTrigger(AnimationUtil.DeathKey);
            Unsubscribe();
        }

        private void ResetAnimation()
        {
            _animator.SetFloat(AnimationUtil.VelocityKey, 0f);
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            _enemy.EnemyEvent.idle -= OnIdle;
            _enemy.EnemyEvent.move -= OnMove;
            _enemy.EnemyEvent.attack -= OnAttack;
            _enemy.EnemyEvent.death -= OnDeath;
        }
    }
}

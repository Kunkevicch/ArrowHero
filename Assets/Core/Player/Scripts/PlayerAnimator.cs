using UnityEngine;

namespace ArrowHero.Core
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _player.PlayerEvent.idle += OnIdle;
            _player.PlayerEvent.move += OnMove;
            _player.PlayerEvent.attack += OnAttack;
            _player.PlayerEvent.death += OnDeath;
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
            _player.PlayerEvent.idle -= OnIdle;
            _player.PlayerEvent.move -= OnMove;
            _player.PlayerEvent.attack -= OnAttack;
            _player.PlayerEvent.death -= OnDeath;
        }
    }
}
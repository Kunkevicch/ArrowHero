using UnityEngine;
using UnityEngine.AI;

namespace ArrowHero.Core
{
    public class SimpleEnemyAI : BaseEnemyAI
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override void MoveToRandomPoint()
        {
            if ( _isDead ) return;

            Vector3 randomPoint = _player.transform.position + Random.insideUnitSphere * 10f;

            NavMeshHit hit;

            if ( NavMesh.SamplePosition(randomPoint, out hit, 10.0f, NavMesh.AllAreas) )
            {
                _agent.destination = hit.position;
            }
        }

        public override void AttackPlayer()
        {
            if(_isDead ) return;

            transform.LookAt(_player.transform.position);

            Projectile projectile = (Projectile)_objectPool.ReuseComponent(_enemy.EnemyConfig.Projectile.gameObject, _enemy.AttackPoint.position, transform.rotation);
            projectile.InitProjectile(_enemy.EnemyConfig.DamagePerShot);
            projectile.gameObject.SetActive(true);
        }
    }
}
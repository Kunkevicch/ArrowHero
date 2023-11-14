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
            Vector3 randomPoint = _player.transform.position + Random.insideUnitSphere * 10f;

            NavMeshHit hit;

            if ( NavMesh.SamplePosition(randomPoint, out hit, 10.0f, NavMesh.AllAreas) )
            {
                _agent.destination = hit.position;
            }
        }

        public override void AttackPlayer()
        {
            transform.LookAt(_player.transform.position);

            Projectile projectile = (Projectile)_objectPool.ReuseComponent(_enemy.EnemyConfig.Projectile.gameObject, _enemy.AttackPoint.position, transform.rotation);
            projectile.gameObject.SetActive(true);
        }
    }
}
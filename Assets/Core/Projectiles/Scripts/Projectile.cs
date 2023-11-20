using UnityEngine;

namespace ArrowHero.Core
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private LayerMask _impactLayer;

        private int _damage;

        public void InitProjectile(int damage)
        {
            _damage = damage;
        }

        private void Update()
        {
            if ( speed != 0 )
            {
                transform.position += transform.forward * ( speed * Time.deltaTime );
            }
            else
            {
                Debug.Log("Нет скорости!");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if ( other.gameObject.IsInLayer(_impactLayer) )
            {
                DealDamage(other.GetComponent<BaseHealth>());
                DisableAmmo();
                SpawnEffect();
            }
        }

        private void DealDamage(BaseHealth health)
        {
            health.TakeDamage(_damage);
        }

        private void DisableAmmo()
        {
            gameObject.SetActive(false);
        }

        private void SpawnEffect()
        {
        }
    }
}
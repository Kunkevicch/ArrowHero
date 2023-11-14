using UnityEngine;

namespace ArrowHero.Core
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private LayerMask _impactLayer;

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
                DisableAmmo();
                SpawnEffect();
            }
        }

        public void DisableAmmo()
        {
            gameObject.SetActive(false);
        }

        private void SpawnEffect()
        {
            Debug.Log("Пиф-паф");
        }
    }
}
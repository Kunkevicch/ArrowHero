using UnityEngine;

namespace TowersDominax.Core
{
    public class Projectile : MonoBehaviour
    {

        public float speed = 10f;
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 1f);
        }

        // Update is called once per frame
        void Update()
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
    }
}

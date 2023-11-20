using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    [DisallowMultipleComponent]
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] 
        private Pool[] _poolArray = null;

        private Transform _objectPoolTransform;
        private Dictionary<int, Queue<Component>> _poolDictionary = new Dictionary<int, Queue<Component>>();

        private Coroutine _createPoolWithDelay;
        private float _poolDelay;
        [System.Serializable]
        public struct Pool
        {
            public int poolSize;
            public GameObject prefab;
            public string componentType;
            public bool isInjected;
        }

        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _container = diContainer;
        }

        private void Start()
        {
            _objectPoolTransform = this.gameObject.transform;

            for ( int i = 0; i < _poolArray.Length; i++ )
            {
                CreatePool(_poolArray[i].prefab, _poolArray[i].poolSize, _poolArray[i].componentType, _poolArray[i].isInjected);
            }
        }

        private void CreatePool(GameObject prefab, int poolSize, string componentType, bool isInjected)
        {
            int poolKey = prefab.GetInstanceID();

            string prefabName = prefab.name;

            GameObject parentGameObject = new GameObject(prefabName + "_anchor");

            parentGameObject.transform.SetParent(_objectPoolTransform);

            if ( _poolDictionary.ContainsKey(poolKey) == false )
            {
                _poolDictionary.Add(poolKey, new Queue<Component>());

                for ( int i = 0; i < poolSize; i++ )
                {
                    GameObject newObject;

                    if ( !isInjected )
                    {
                        newObject = Instantiate(prefab, parentGameObject.transform) as GameObject;
                    }
                    else
                    {
                        newObject = _container.InstantiatePrefab(prefab, parentGameObject.transform) as GameObject;
                    }

                    newObject.SetActive(false);

                    _poolDictionary[poolKey].Enqueue(newObject.GetComponent(Type.GetType(componentType)));
                }
            }
        }

        public Component ReuseComponent(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            int poolKey = prefab.GetInstanceID();

            if ( _poolDictionary.ContainsKey(poolKey) )
            {
                Component componentToReuse = GetComponentFromPool(poolKey);

                ResetObject(position, rotation, componentToReuse, prefab);

                return componentToReuse;
            }
            else
            {
                Debug.Log($"Нет объектов для пула {prefab}");
                return null;
            }

        }

        private Component GetComponentFromPool(int poolKey)
        {
            Component componentToReuse = _poolDictionary[poolKey].Dequeue();
            _poolDictionary[poolKey].Enqueue(componentToReuse);

            if ( componentToReuse.gameObject.activeSelf == true )
            {
                componentToReuse.gameObject.SetActive(false);
            }

            return componentToReuse;
        }

        private void ResetObject(Vector3 position, Quaternion rotation, Component componentToReuse, GameObject prefab)
        {
            componentToReuse.transform.position = position;
            componentToReuse.transform.rotation = rotation;
            componentToReuse.gameObject.transform.localScale = prefab.transform.localScale;
        }
    }
}
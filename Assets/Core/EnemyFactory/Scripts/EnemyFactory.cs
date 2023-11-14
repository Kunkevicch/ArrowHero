using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class EnemyFactory
    {
        public Action EnemyFactoryInitComplete;
        public bool IsInited => _isInited;

        private Dictionary<Type, BaseEnemy> _enemiesPrefab = new Dictionary<Type, BaseEnemy>();

        private bool _isInited = false;

        private DiContainer _container;
        private EnemyTypes _enemyType;

        [Inject]
        private void Construct(DiContainer container, EnemyTypes enemiesType)
        {
            _container = container;
            _enemyType = enemiesType;
        }

        public void Initialize()
        {
            _enemyType.EnemyTypeList.ForEach(enemy =>
            {
                _enemiesPrefab[enemy.GetType()] = enemy;
            });
            _isInited = true;

            EnemyFactoryInitComplete?.Invoke();
            EnemyFactoryInitComplete = null;
        }

        public T GetEnemy<T>(BaseEnemy enemy) where T : BaseEnemy
        {
            var enemyType = enemy.GetType();
            var enemyPrefab = _enemiesPrefab[enemyType];
            return _container.InstantiatePrefabForComponent<T>(enemyPrefab, Vector3.zero, Quaternion.identity, null);
        }


    }
}
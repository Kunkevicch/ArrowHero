using System.Collections.Generic;
using UnityEngine;

namespace ArrowHero.Core
{
    [CreateAssetMenu(fileName = "EnemiesType", menuName = "Configs/Enemy/Type")]
    public class EnemyTypes : ScriptableObject
    {
        public List<Enemy> EnemyTypeList => _enemyTypeList;

        [SerializeField]
        private List<Enemy> _enemyTypeList;

    }
}

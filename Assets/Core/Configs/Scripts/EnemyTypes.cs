using System.Collections.Generic;
using UnityEngine;

namespace ArrowHero.Core
{
    [CreateAssetMenu(fileName = "EnemiesType", menuName = "Configs/Enemy/Type")]
    public class EnemyTypes : ScriptableObject
    {
        public List<BaseEnemy> EnemyTypeList => _enemyTypeList;

        [SerializeField]
        private List<BaseEnemy> _enemyTypeList;

    }
}

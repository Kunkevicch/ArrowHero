using UnityEngine;

namespace ArrowHero.Core
{
    [CreateAssetMenu(fileName = "PlayerConfig_", menuName = "Configs/Player")]
    public class PlayerConfig : ScriptableObject
    {
        #region Attributes
        [SerializeField]
        [Header("Скорость передвижения")]
        [Tooltip("Скорость передвижения")]
        #endregion
        private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;

        #region Attributes
        [SerializeField]
        [Header("Количество здоровья")]
        [Tooltip("Количество здоровья")]
        [Min(1)]
        #endregion
        private int _healthPoint;
        public int HealthPoint => _healthPoint;

        #region Attributes
        [SerializeField]
        [Header("Скорость атаки")]
        [Tooltip("Скорость атаки - задержка между атаками в секундах")]
        #endregion
        private float _attackSpeed;
        public float AttackSpeed => _attackSpeed;

        #region Attributes
        [SerializeField]
        [Header("Урон за выстрел")]
        [Tooltip("Урон за выстрел")]
        #endregion
        private int _damagePerShot;
        public int DamagePerShot => _damagePerShot;

    }
}

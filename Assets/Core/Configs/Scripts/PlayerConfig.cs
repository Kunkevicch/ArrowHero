using UnityEngine;

namespace ArrowHero.Core
{
    [CreateAssetMenu(fileName = "PlayerConfig_", menuName = "Configs/Player")]
    public class PlayerConfig : ScriptableObject
    {
        #region Attributes
        [SerializeField]
        [Header("�������� ������������")]
        [Tooltip("�������� ������������")]
        #endregion
        private float _moveSpeed;
        public float MoveSpeed => _moveSpeed;

        #region Attributes
        [SerializeField]
        [Header("���������� ��������")]
        [Tooltip("���������� ��������")]
        [Min(1)]
        #endregion
        private int _healthPoint;
        public int HealthPoint => _healthPoint;

        #region Attributes
        [SerializeField]
        [Header("�������� �����")]
        [Tooltip("�������� ����� - �������� ����� ������� � ��������")]
        #endregion
        private float _attackSpeed;
        public float AttackSpeed => _attackSpeed;

        #region Attributes
        [SerializeField]
        [Header("���� �� �������")]
        [Tooltip("���� �� �������")]
        #endregion
        private int _damagePerShot;
        public int DamagePerShot => _damagePerShot;

    }
}

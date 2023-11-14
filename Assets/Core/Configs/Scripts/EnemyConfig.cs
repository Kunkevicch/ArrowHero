using UnityEngine;

namespace ArrowHero.Core
{
    [ CreateAssetMenu(fileName = "EnemyConfig_", menuName = "Configs/Enemy") ]
    public class EnemyConfig : ScriptableObject
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
        [Header("��������� �����������")]
        [Tooltip("����������, ������� �������� ���� �� ���")]
        #endregion
        private float _moveDistance;
        public float MoveDistance => _moveDistance;

        #region Attributes
        [SerializeField]
        [Header("����� �������������")]
        [Tooltip("�����, ������� ����")]
        #endregion
        private float _waitTimer;
        public float WaitTimer => _waitTimer;

        #region Attributes
        [SerializeField]
        [Header("���������� ��������")]
        [Tooltip("���������� ��������")]
        #endregion
        private int _maxHP;
        public int MaxHP => _maxHP;

        #region Attributes
        [SerializeField]
        [Header("�������� �����")]
        [Tooltip("�������� �����")]
        #endregion
        private float _attackDelayTimer;
        public float AttackDelayTimer => _attackDelayTimer;

        #region Attributes
        [SerializeField]
        [Header("���� �� �������")]
        [Tooltip("���� �� �������/����")]
        #endregion
        private float _damagePerShot;
        public float DamagePerShot => _damagePerShot;

        #region Attributes
        [SerializeField]
        [Header("���� �� �������")]
        [Tooltip("���� �� �������/����")]
        #endregion
        private Projectile _projectile;
        public Projectile Projectile => _projectile;
    }
}
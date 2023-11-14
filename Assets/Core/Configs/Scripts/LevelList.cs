using System.Collections.Generic;
using UnityEngine;

namespace ArrowHero.Core
{
    [CreateAssetMenu(fileName = "LevelList_", menuName = "Configs/LevelList")]
    public class LevelList : ScriptableObject
    {
        public List<Level> Levels => _levels;
        #region Attributes
        [SerializeField]
        [Header("������")]
        [Tooltip("������, ������� ����� ���������� �� ���� ����������� ����")]
        #endregion
        private List<Level> _levels;
    }
}
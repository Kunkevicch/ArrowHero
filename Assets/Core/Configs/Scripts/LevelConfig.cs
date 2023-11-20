using System.Collections.Generic;
using UnityEngine;

namespace ArrowHero.Core
{
    [CreateAssetMenu(fileName = "LevelConfig_",menuName = "Configs/Level")]
    public class LevelConfig : ScriptableObject
    {
        #region Attributes
        [SerializeField]
        [Header("�������� ������")]
        [Tooltip("�������� ������")]
        #endregion
        private string _levelName;
        public string LevelName => _levelName;

        #region Attributes
        [SerializeField]
        [Header("������ ������")]
        [Tooltip("������ ������")]
        #endregion
        private List<Enemy> _enemies; 
        public List<Enemy> Enemies => _enemies;
    }
}
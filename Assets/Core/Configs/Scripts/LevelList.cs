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
        [Header("Уровни")]
        [Tooltip("Уровни, которые будут попадаться по мере прохождения игры")]
        #endregion
        private List<Level> _levels;
    }
}
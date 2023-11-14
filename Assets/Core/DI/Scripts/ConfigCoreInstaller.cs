using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    [CreateAssetMenu(fileName = "CoreSOInstaller", menuName = "Installers/CoreSOInstaller")]
    public class ConfigCoreInstaller : ScriptableObjectInstaller<ConfigCoreInstaller>
    {
        [SerializeField]
        private EnemyTypes _enemiesType;

        [SerializeField]
        private LevelList _levelList;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyTypes>().FromScriptableObject(_enemiesType).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelList>().FromScriptableObject(_levelList).AsSingle().NonLazy();
        }
    }
}
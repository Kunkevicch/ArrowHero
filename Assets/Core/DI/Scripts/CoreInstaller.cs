using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class CoreInstaller : MonoInstaller
    {

        [SerializeField]
        private GameController _gameController;

        [SerializeField]
        private EnemyController _enemyController;

        [SerializeField]
        private ObjectPool _objectPool;

        [SerializeField]
        private Player _playerPrefab;

        [SerializeField]
        private CoreInput _coreInputPrefab;

        [SerializeField]
        private CameraTarget _cameraTargetPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameController>().FromComponentInNewPrefab(_gameController).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyController>().FromComponentInNewPrefab(_enemyController).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ObjectPool>().FromComponentInNewPrefab(_objectPool).AsSingle().NonLazy();
            Container.Bind<EnemyFactory>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<Player>().FromComponentInNewPrefab(_playerPrefab).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CoreInput>().FromComponentInNewPrefab(_coreInputPrefab).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CameraTarget>().FromComponentInNewPrefab(_cameraTargetPrefab).AsSingle().NonLazy();
        }
    }
}
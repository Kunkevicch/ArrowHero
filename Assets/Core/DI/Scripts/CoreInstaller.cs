using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class CoreInstaller : MonoInstaller
    {

        [SerializeField]
        private GameController _gameControllerPrefab;

        [SerializeField]
        private Player _playerPrefab;

        [SerializeField]
        private Level _levelPrefab;

        [SerializeField]
        private CoreInput _coreInputPrefab;

        [SerializeField]
        private CameraTarget _cameraTargetPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameController>().FromComponentInNewPrefab(_gameControllerPrefab).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Player>().FromComponentInNewPrefab(_playerPrefab).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Level>().FromComponentInNewPrefab(_levelPrefab).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CoreInput>().FromComponentInNewPrefab(_coreInputPrefab).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CameraTarget>().FromComponentInNewPrefab(_cameraTargetPrefab).AsSingle().NonLazy();
        }
    }
}
using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class Player : MonoBehaviour
    {
        public PlayerConfig PlayerConfig => _playerConfig;

        [SerializeField]
        private PlayerConfig _playerConfig;

        [SerializeField]
        private Transform _attackPoint;

        public Transform AttackPoint => _attackPoint;

        private CharacterEvent _playerEvent;
        public CharacterEvent PlayerEvent => _playerEvent;

        private Rigidbody _rb;
        public Rigidbody Rb => _rb;

        private GameController _gameController;


        public CoreInput Input => _coreInput;
        private CoreInput _coreInput;


        [Inject]
        private void Construct(GameController gameController, CoreInput coreInput)
        {
            _gameController = gameController;
            _coreInput = coreInput;

        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _playerEvent = GetComponent<CharacterEvent>();
        }

        private void OnEnable()
        {
            _gameController.GameStageChange += OnGameStageChange;
        }

        private void OnDisable()
        {
            _gameController.GameStageChange -= OnGameStageChange;
        }

        private void OnGameStageChange( GameStage newGameStage)
        {
            switch(newGameStage)
            {
                case GameStage.Preparation:
                    _playerEvent.canMove?.Invoke(false);
                    break;
                case GameStage.GameLoop:
                    _playerEvent.canMove?.Invoke(true);
                    _playerEvent.canAttack?.Invoke(true);
                    break;

                case GameStage.Victory:
                    _playerEvent.canAttack?.Invoke(false);
                    break;

                case GameStage.Failed:
                    _playerEvent.canMove?.Invoke(false);
                    break;
            }
        }
    }
}
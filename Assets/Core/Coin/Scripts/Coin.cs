using System;
using System.Collections;
using UnityEngine;
using Zenject;


namespace ArrowHero.Core
{
    public class Coin : MonoBehaviour
    {
        public static event Action<int> rewardGet;

        [SerializeField]
        private int _coinValue;

        [SerializeField]
        private float _coinSpeed;

        private GameController _gameController;

        private Coroutine _giveRewardCoroutine;

        private bool _isRewarded;

        [Inject]
        private void Construct(GameController gameController, ScoreController scoreController)
        {
            _gameController = gameController;
        }

        private void OnEnable()
        {
            _gameController.GameStageChange += OnGameStageChanged;
            _isRewarded = false;
        }

        private void OnGameStageChanged(GameStage newGameStage)
        {
            
            if ( newGameStage == GameStage.Victory || newGameStage == GameStage.Failed )
            {
                StartReward();
            }
        }

        private void StartReward()
        {
            if ( _giveRewardCoroutine != null )
            {
                StopCoroutine(_giveRewardCoroutine);
                _giveRewardCoroutine = null;
            }

            _giveRewardCoroutine = StartCoroutine(GivePlayerRewardRoutine());
        }

        private IEnumerator GivePlayerRewardRoutine()
        {
            WaitForFixedUpdate wait = new();
            while ( !_isRewarded )
            {
                Vector3 direction = _gameController.Player.transform.position - transform.position;
                transform.position += direction * _coinSpeed * Time.deltaTime;
                yield return wait;
            }
            StopCoroutine(_giveRewardCoroutine);
            _giveRewardCoroutine = null;
            rewardGet?.Invoke(_coinValue);
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if ( other.gameObject.IsInLayer(GameObjectExt.playerLayer) ) 
            {
                _isRewarded = true;
            }
        }

        private void OnDisable()
        {
            _gameController.GameStageChange -= OnGameStageChanged;
        }
    }
}
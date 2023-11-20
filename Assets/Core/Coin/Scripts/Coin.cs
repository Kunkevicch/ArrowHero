using System.Collections;
using UnityEngine;
using Zenject;

namespace ArrowHero.Core
{
    public class Coin : MonoBehaviour
    {
        [Inject]
        private GameController _gameController;

        private Coroutine _giveRewardCoroutine;

        private bool _isRewarded;

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
                transform.Translate(_gameController.Player.transform.position.normalized * Time.deltaTime,Space.World);
                yield return wait;
            }
            StopCoroutine(_giveRewardCoroutine);
            _giveRewardCoroutine = null;
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
using System;
using UnityEngine;

namespace ArrowHero.Core
{
    public class ScoreController : MonoBehaviour
    {
        public event Action<int> scoreChange;

        [SerializeField]
        private int _playerScore;
        public int PlayerScore
        {
            private set
            {
                if ( value < 0 ) return;
                
                _playerScore = value;
                scoreChange?.Invoke(_playerScore);
            }

            get => _playerScore;
        }

        private void AddScore(int score)
        {
            PlayerScore += score;
        }

        private void OnEnable()
        {
            Coin.rewardGet += OnRewardGetted;
        }

        private void OnRewardGetted(int rewardValue)
        {
            AddScore(rewardValue);
        }

        private void OnDisable()
        {
            Coin.rewardGet -= OnRewardGetted;
        }
    }
}
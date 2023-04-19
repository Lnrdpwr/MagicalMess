using UnityEngine;

namespace YG.Example
{
    public class RewardedAd : MonoBehaviour
    {
        [SerializeField] int AdID;

        private LevelManager _levelManager;

        private void Start()
        {
            _levelManager = LevelManager.Instance;
        }

        private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
        private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

        void Rewarded(int id)
        {
            RevivePlayer();
        }

        void RevivePlayer()
        {   
            _levelManager.RevivePlayer();
            gameObject.SetActive(false);
        }
    }
}
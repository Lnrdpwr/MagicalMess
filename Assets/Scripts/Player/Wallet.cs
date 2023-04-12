using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;

    private int _coins = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _coins += coin.GetCoins();
            _coinsText.text = _coins.ToString();
        }
    }

    public bool StealCoin()
    {
        int _stealAmount = Mathf.RoundToInt(Spawner.Instance.Coefficient);
        if (_coins >= _stealAmount)
        {
            _coins -= _stealAmount;
            _coinsText.text = _coins.ToString();
            return true;
        }
        return false;
    }
}

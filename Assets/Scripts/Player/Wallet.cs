using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;

    public int Coins = 0;

    internal static Wallet Instance;

    private void Awake()
    {
        Coins = 0;
        Instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            Coins += coin.GetCoins();
            _coinsText.text = Coins.ToString();
        }
    }

    public bool StealCoin()
    {
        int _stealAmount = Mathf.RoundToInt(Spawner.Instance.Coefficient);
        if (Coins >= _stealAmount)
        {
            Coins -= _stealAmount;
            _coinsText.text = Coins.ToString();
            return true;
        }
        return false;
    }
    
    public void ChangeMoney(float newAmount){
        Coins = Mathf.RoundToInt(newAmount);
        _coinsText.text = Coins.ToString();
    }
}

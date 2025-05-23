using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private MagnitPassive _magnitPassive;

    private int _coins;

    internal static Wallet Instance;

    private void Awake()
    {
        Instance = this;
        PlayerPrefs.SetInt("CollectedCoins", 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            SoundManager.Instance.PlayClip(_coinSound);
            _coins += coin.GetCoins();
            _coinsText.text = _coins.ToString();
            PlayerPrefs.SetInt("CollectedCoins", _coins);

            _magnitPassive.affectedBodies.Remove(collision.attachedRigidbody);
        }
    }

    public bool StealCoin()
    {
        int _stealAmount = Mathf.RoundToInt(Spawner.Instance.Coefficient);
        if (_coins >= _stealAmount)
        {
            _coins -= _stealAmount;
            _coinsText.text = _coins.ToString();
            PlayerPrefs.SetInt("CollectedCoins", _coins);
            return true;
        }
        return false;
    }
    
    public void ChangeMoney(float newAmount){
        _coins = Mathf.RoundToInt(newAmount);
        _coinsText.text = _coins.ToString();
        PlayerPrefs.SetInt("CollectedCoins", _coins);
    }

    public int GetCoins()
    {
        return _coins;
    }
}

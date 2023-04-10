using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private LevelManager _levelManager;
    private int _amountOfMoney;

    private void Start()
    {
        _levelManager = LevelManager.Instance;
        _amountOfMoney = _levelManager.CoinsPerKill;
    }

    public int GetCoins()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        return _amountOfMoney;
    }
}

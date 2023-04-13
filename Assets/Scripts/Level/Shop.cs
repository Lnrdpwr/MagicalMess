using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //Статы
    [SerializeField] private float _healthDelta, _manaDelta, _damageDelta, _speedDelta;
    [SerializeField] private float _healthCost, _manaCost, _damageCost, _speedCost;

    //Спеллы
    [SerializeField] private GameObject[] _spells;
    [SerializeField] private float _spellCost;
    [SerializeField] private float _spellDamageDelta;
    [SerializeField] private Button _spellButton;

    private PlayerHealth _playerHealth;
    private PlayerSpell _playerMana;
    private PlayerShooting _playerShooting;
    private Wallet _wallet;
    private int _walletAmount;

    internal static Shop Instance;

    private void Awake()
    {
        Instance = this;

        _playerHealth = PlayerHealth.Instance;
        _playerMana = PlayerSpell.Instance;
        _playerShooting = PlayerShooting.Instance;
        _wallet = Wallet.Instance;
    }

    private void OnEnable
    {
        _walletAmount = Wallet.Coins;//Уточнить
    }

    public void UpgradeHealth()
    {
        if (_walletAmount >= _healthCost)
        {
            _playerHealth.UpdateMaximumHealth(_healthDelta);//Добавить
            _walletAmount -= _healthCost;
            _healthCost = Mathf.Round(_healthCost * 1.5f);
        }
        _wallet.ChangeMoney(_walletAmount);
    }

    public void UpgradeMana()
    {
        if (_walletAmount >= _manaCost)
        {
            _playerMana.UpdateMaximumMana(_manaDelta);//Добавить
            _walletAmount -= _manaCost;
            _manaCost = Mathf.Round(_manaCost * 1.5f);
        }
        _wallet.ChangeMoney(_walletAmount);
    }

    public void UpgradeDamage()
    {
        if (_walletAmount >= _damageCost)
        {
            _playerShooting.Damage += _damageDelta;
            _walletAmount -= _damageCost;
            _damageCost = Mathf.Round(_damageCost * 1.5f);
        }
        _wallet.ChangeMoney(_walletAmount);
    }

    public void UpgradeSpeed()
    {
        if (_walletAmount >= _speedCost)
        {
            _playerShooting.Speed += _speedDelta;
            _walletAmount -= _speedCost;
            _speedCost = Mathf.Round(_speedCost * 1.5f);
        }
        _wallet.ChangeMoney(_walletAmount);//Добавить
    }

    public void BuySpell(int index)
    {
        if (_walletAmount >= _spellCost)
        {
            _playerMana.SetSpell(_spells[i]);//Добавить
            _walletAmount -= _spellCost;
            _speedCost = Mathf.Round(_speedCost / 2);
            _spellButton.onClick.RemoveAllListeners();
            _spellButton.onClick.AddListener(UpgradeSpell);
        }
        _wallet.ChangeMoney(_walletAmount);
    }

    public void UpgradeSpell()
    {
        if (_walletAmount >= _spellCost)
        {
            _playerMana.Damage += _spellDamageDelta;//Добавить
            _walletAmount -= _speedCost;
            _spellCost = Mathf.Round(_spellCost * 1.5f);
        }
        _wallet.ChangeMoney(_walletAmount);
    }
}
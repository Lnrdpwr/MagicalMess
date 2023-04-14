using System;
using TMPro;
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
    [SerializeField] private GameObject[] _spellButtonsObjects;

    //UI
    [SerializeField] private Button[] _spellButtons;
    [SerializeField] private TMP_Text[] _spellCostTexts;
    [SerializeField] private TMP_Text[] _statsCostTexts;
    [SerializeField] private TMP_Text _shopCoinsAmount;
     
    private PlayerHealth _playerHealth;
    private PlayerSpell _playerMana;
    private PlayerShooting _playerShooting;
    private Wallet _wallet;
    private float _walletAmount = 0;
    private int _mainSpellButton;

    public float SpellDamageModifier = 1;

    internal static Shop Instance;

    private void Awake()
    {
        Instance = this;
    }
    

    private void Start()
    {
        _playerHealth = PlayerHealth.Instance;
        _playerMana = PlayerSpell.Instance;
        _playerShooting = PlayerShooting.Instance;
        _wallet = Wallet.Instance;
    }

    public void SetPanelOn()
    {   
        gameObject.SetActive(true);
        _walletAmount = PlayerPrefs.GetInt("CollectedCoins");
        _shopCoinsAmount.text = _walletAmount.ToString();
    }

    public void UpgradeHealth()
    {
        if (_walletAmount >= _healthCost)
        {
            _playerHealth.ChangeMaximumHealth(_healthDelta);
            _walletAmount -= _healthCost;
            _healthCost = Mathf.Round(_healthCost * 1.5f);
            _statsCostTexts[0].text = _healthCost.ToString();
            _wallet.ChangeMoney(_walletAmount);
            _shopCoinsAmount.text = _walletAmount.ToString();
        }
    }

    public void UpgradeMana()
    {
        if (_walletAmount >= _manaCost)
        {
            _playerMana.ChangeMaximumMana(_manaDelta);
            _walletAmount -= _manaCost;
            _manaCost = Mathf.Round(_manaCost * 1.5f);
            _statsCostTexts[1].text = _manaCost.ToString();
            _wallet.ChangeMoney(_walletAmount);
            _shopCoinsAmount.text = _walletAmount.ToString();
        }
    }

    public void UpgradeDamage()
    {
        if (_walletAmount >= _damageCost)
        {
            _playerShooting.Damage += _damageDelta;
            _walletAmount -= _damageCost;
            _damageCost = Mathf.Round(_damageCost * 1.5f);
            _statsCostTexts[2].text = _damageCost.ToString();
            _wallet.ChangeMoney(_walletAmount);
            _shopCoinsAmount.text = _walletAmount.ToString();
        }
    }

    public void UpgradeSpeed()
    {
        if (_walletAmount >= _speedCost)
        {
            _playerShooting.BulletSpeed += _speedDelta;
            _walletAmount -= _speedCost;
            _speedCost = Mathf.Round(_speedCost * 1.5f);
            _statsCostTexts[3].text = _speedCost.ToString();
            _wallet.ChangeMoney(_walletAmount);
            _shopCoinsAmount.text = _walletAmount.ToString();
        }
    }

    public void BuySpell(int index)
    {
        if (_walletAmount >= _spellCost)
        {
            _playerMana.SetSpell(_spells[index]);
            _walletAmount -= _spellCost;
            _spellCost = Mathf.Round(_spellCost / 2);

            foreach (GameObject button in _spellButtonsObjects)
                button.SetActive(false);

            _spellButtonsObjects[index].SetActive(true);
            _spellCostTexts[index].text = _spellCost.ToString();
            _spellButtons[index].onClick.RemoveAllListeners();
            _spellButtons[index].onClick.AddListener(UpgradeSpell);

            _wallet.ChangeMoney(_walletAmount);
            _shopCoinsAmount.text = _walletAmount.ToString();

            _mainSpellButton = index;
        }
    }

    public void UpgradeSpell()
    {
        if (_walletAmount >= _spellCost)
        {
            SpellDamageModifier += _spellDamageDelta;
            _playerMana.ManaUsage += 0.5f;
            _walletAmount -= _spellCost;
            _spellCost = Mathf.Round(_spellCost * 1.5f);
            _wallet.ChangeMoney(_walletAmount);
            _shopCoinsAmount.text = _walletAmount.ToString();
            _spellCostTexts[_mainSpellButton].text = _spellCost.ToString();
        }
    }
}
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassiveSkills : MonoBehaviour
{
    [SerializeField] private PlayerShooting _playerShooting;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private MagnitPassive _magnet;
    [SerializeField] private AudioClip _buttonSound;
    //UI
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TMP_Text[] _buttonTexts;
    [SerializeField] private GameObject _panel;


    private int _previousUpgrade;

    public void ArrowpPiercingUpLevel()
    {
        _playerShooting.PiercingPower += 1;
    }

    public void SplitArrowUpLevel()
    {
        _playerShooting.ShootsCount += 1;
        if(_playerShooting.MaxAngle < 80)
        {
            _playerShooting.MaxAngle += 10f;
        }
    }

    public void ThickArrowsUpLevel()
    {
        if (_playerShooting.BulletSpeed > 1)
        {
            _playerShooting.BulletSpeed -= 1;
        }

        _playerShooting.Damage += 1;
        _playerShooting.ReloadTime += 0.2f;
        _playerShooting.ArrowScale += new Vector3(0.5f, 0.5f, 0);
    }

    public void SmallArrowsUpLevel()
    {
        if (_playerShooting.ReloadTime >= 0.4f)
        {
            _playerShooting.ReloadTime -= 0.2f;
        }

        if (_playerShooting.Damage > 1)
        {
            _playerShooting.Damage -= 1;
        }

        _playerShooting.BulletSpeed += 1;
    }

    public void LightnessInTheLegsUpLevel()
    {
        _playerMovement.Speed += 1;
        
        if (_playerHealth.MaximumHealth > 1)
        {
            _playerHealth.MaximumHealth -= 1;
        }
    }

    public void TitanUpLevel()
    {
        _playerHealth.ChangeMaximumHealth(1);
        _playerMovement.PlayerScale += new Vector3(0.5f, 0.5f, 0);
    }

    public void MonsterMark()
    {
        _playerShooting.isTracked = true;
    }

    public void Magnet()
    {
        _magnet.IsActive = true;
    }

    public void HidePanel()
    {
        SoundManager.Instance.PlayClip(_buttonSound);
        _panel.SetActive(false);
        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].onClick.RemoveAllListeners();
        }
    }

    public void ShowUpgradePanel()
    {
        
        for(int i = 0; i < _buttons.Length; i++)
        {
            int chosenUpgrade = 0;
            do
            {
                chosenUpgrade = Random.Range(0, 7);
            } while (chosenUpgrade == _previousUpgrade || (_playerShooting.isTracked && chosenUpgrade == 6));
            _previousUpgrade = chosenUpgrade;

            switch (chosenUpgrade)
            {
                case 0:
                    _buttons[i].onClick.AddListener(ArrowpPiercingUpLevel);
                    _buttonTexts[i].text = "Пронзание\n+1 к пронзанию";
                    break;
                case 1:
                    _buttons[i].onClick.AddListener(SplitArrowUpLevel);
                    _buttonTexts[i].text = "Разрезанная стрела\n+1 стрела";
                    break;
                case 2:
                    _buttons[i].onClick.AddListener(ThickArrowsUpLevel);
                    _buttonTexts[i].text = "Толстая стрела\n+размер\n+урон\nмедленнее перезарядка\n-скорость";
                    break;
                case 3:
                    _buttons[i].onClick.AddListener(SmallArrowsUpLevel);
                    _buttonTexts[i].text = "Мелкие стрелы\n+скорость\nбыстрее перезарядка\n-урон";
                    break;
                case 4:
                    _buttons[i].onClick.AddListener(LightnessInTheLegsUpLevel);
                    _buttonTexts[i].text = "Лёгкие поножи\n+скорость\n-здоровье";
                    break;
                case 5:
                    _buttons[i].onClick.AddListener(TitanUpLevel);
                    _buttonTexts[i].text = "Титан\n+здоровье\n+размер";
                    break;
                case 6:
                    _buttons[i].onClick.AddListener(MonsterMark);
                    _buttonTexts[i].text = "Метка монстра\nнаносит урон через время";
                    break;
            }
            _buttons[i].onClick.AddListener(HidePanel);
        }
        _panel.SetActive(true);
    }
}

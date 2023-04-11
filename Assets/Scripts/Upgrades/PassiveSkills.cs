using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassiveSkills : MonoBehaviour
{
    [SerializeField] PlayerShooting _playerShooting;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] PlayerHealth _playerHealth;
    //UI
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TMP_Text[] _buttonTexts;
    [SerializeField] private GameObject _panel;
    //Если будет перевод, то добавить два списка с описаниями

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
        _playerHealth.ChangeMaxHealth(1);
        _playerMovement.PlayerScale += new Vector3(0.5f, 0.5f, 0);
    }

    public void MonsterMark()
    {
        _playerShooting.isTracked = true;
    }

    public void HidePanel()
    {
        _panel.SetActive(false);
        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].onClick.RemoveAllListeners();
        }
    }

    public void ShowUpgradePanel()
    {
        int chosenUpgrade = Random.Range(0, 7);
        for(int i = 0; i < _buttons.Length; i++)
        {
            switch (chosenUpgrade)
            {
                case 0:
                    _buttons[i].onClick.AddListener(ArrowpPiercingUpLevel);
                    _buttonTexts[i].text = "Piercing\n(+1 piercing)";
                    break;
                case 1:
                    _buttons[i].onClick.AddListener(SplitArrowUpLevel);
                    _buttonTexts[i].text = "Split arrow\n(+1 arrow)";
                    break;
                case 2:
                    _buttons[i].onClick.AddListener(ThickArrowsUpLevel);
                    _buttonTexts[i].text = "Thick arrow\n(+size,\n+damage,\nincrease reload,\n-speed)";
                    break;
                case 3:
                    _buttons[i].onClick.AddListener(SmallArrowsUpLevel);
                    _buttonTexts[i].text = "Small arrow\n(+speed,\ndecrease reload,\n-damage)";
                    break;
                case 4:
                    _buttons[i].onClick.AddListener(LightnessInTheLegsUpLevel);
                    _buttonTexts[i].text = "Light boots\n(+speed,\n-health)";
                    break;
                case 5:
                    _buttons[i].onClick.AddListener(TitanUpLevel);
                    _buttonTexts[i].text = "Titan\n(+health,\n+size)";
                    break;
                case 6:
                    _buttons[i].onClick.AddListener(MonsterMark);
                    _buttonTexts[i].text = "Monster mark\n(deals damage after time)";
                    break;
            }
            _buttons[i].onClick.AddListener(HidePanel);
        }
        _panel.SetActive(true);
    }
}

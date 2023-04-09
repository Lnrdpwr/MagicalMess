using UnityEngine;

public class PassiveSkills : MonoBehaviour
{
    [SerializeField] PlayerShooting _playerShooting;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] PlayerHealth _playerHealth;

    public void ArrowpPiercingUpLevel()
    {
        _playerShooting.PiercingPower += 1;
    }

    public void SplitArrowUpLevel()
    {
        _playerShooting.ShootsCount += 1;
    }

    public void ThickArrowsUpLevel()
    {
        if (_playerShooting.Speed > 1)
        {
            _playerShooting.Speed -= 1;
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

        _playerShooting.Speed += 1;
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
        _playerHealth.MaximumHealth += 2;
        _playerMovement.PlayerScale += new Vector3(0.5f, 0.5f, 0);
    }

    public void MonsterMark()
    {
        _playerShooting.isTracked = true;
    }
}

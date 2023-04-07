using UnityEngine;

public class PassiveSkills : MonoBehaviour
{
    [SerializeField] PlayerShooting _playerShooting;
   
    public void ArrowpPiercingUpLevel()
    {
        _playerShooting.PiercingPower += 1;
    }

    public void SplitArrowUpLevel()
    {
        _playerShooting.ShootsCount += 1;
    }


}

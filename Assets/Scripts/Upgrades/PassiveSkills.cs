using UnityEngine;

public class PassiveSkills : MonoBehaviour
{
    [SerializeField] PlayerShooting _playerShooting;
    [SerializeField] Bullet _bullet;
   
    public void ArrowpPiercingUpLevel()
    {
        _bullet.PiercingPower += 1;
    }

    public void SplitArrowUpLevel()
    {
        _playerShooting.ShootsCount += 1;
    }


}

using UnityEngine;

public class PassiveSkills : MonoBehaviour
{
    [SerializeField] Bullet _bullet;
   
    //Повысить уровень "Пронзания стрелой"
    public void ArrowpPiercingUpLevel()
    {
        _bullet.PiercingPower += 1;
    }
}

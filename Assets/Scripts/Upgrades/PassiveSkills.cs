using UnityEngine;

public class PassiveSkills : MonoBehaviour
{
    [SerializeField] Bullet _bullet;
   
    //�������� ������� "��������� �������"
    public void ArrowpPiercingUpLevel()
    {
        _bullet.PiercingPower += 1;
    }
}

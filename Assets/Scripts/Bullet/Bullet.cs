using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _piercesBeforeDestruction;

    public float Damage;
    public int PiercingPower;
    public bool isTracked;

    public void Start()
    {
        _piercesBeforeDestruction = PiercingPower;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.Damage = Damage;

            enemy.DoDamage();
            _piercesBeforeDestruction -= 1;

            if (isTracked == true)
            {
                enemy.DoDamageAfterTrack(2);  
            }

            if (_piercesBeforeDestruction <= 0)
            {
                Destroy(gameObject);
                _piercesBeforeDestruction = PiercingPower;
            }
        }
    }
}

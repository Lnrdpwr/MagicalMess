using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _piercesBeforeDestruction;

    public float _damage;
    public int PiercingPower;

    public void Start()
    {
        _piercesBeforeDestruction = PiercingPower;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.DoDamage(_damage);
            _piercesBeforeDestruction -= 1;

            if (_piercesBeforeDestruction <= 0)
            {
                Destroy(gameObject);
                _piercesBeforeDestruction = PiercingPower;
            }
        }
    }
}

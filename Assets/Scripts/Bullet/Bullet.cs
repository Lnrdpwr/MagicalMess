using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeBeforeDestroy;

    private int _piercesBeforeDestruction;

    public float Damage;
    public int PiercingPower;
    public bool isTrackActive;

    public void Start()
    {
        _piercesBeforeDestruction = PiercingPower;

        StartCoroutine(DestroyBullet(_timeBeforeDestroy));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.DoDamage(0, Damage, false);

            _piercesBeforeDestruction -= 1;

            if (isTrackActive == true)
            {
                enemy.DoDamage(2, Damage, true);  
            }

            if (_piercesBeforeDestruction <= 0)
            {
                Destroy(gameObject);
                _piercesBeforeDestruction = PiercingPower;
            }
        }
    }

    IEnumerator DestroyBullet(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

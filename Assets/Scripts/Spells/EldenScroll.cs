using System.Collections;
using UnityEngine;

public class EldenScroll : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _timeBeforeDestroy;
    [SerializeField] private GameObject _fireWallPrefab;

    private Rigidbody2D _rigidbody2D;
 
    public void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = _speed * gameObject.transform.up;

        StartCoroutine(DestroyFireBoll(_timeBeforeDestroy));
    }

    public void FixedUpdate()
    {
        _speed += 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.DoDamage(0, _damage, false);
            Destroy(gameObject);
            SummonFireWall();
        }
    }

    public void SummonFireWall()
    {
        FireWall fireWall = Instantiate(_fireWallPrefab, gameObject.transform.position, _fireWallPrefab.transform.rotation).GetComponent<FireWall>();

        fireWall.Damage = Mathf.Round(_damage * 0.2f);
    }


    IEnumerator DestroyFireBoll(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        SummonFireWall();
    }
}

using System.Collections;
using UnityEngine;

public class EldenScroll : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _timeBeforeDestroy;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _enemiesLayer;
    [SerializeField] private GameObject _fireWallPrefab;

    private Rigidbody2D _rigidbody2D;
 
    public void Start()
    {
        _damage *= Shop.Instance.SpellDamageModifier;
        transform.parent = null;

        Collider2D[] closestEnemies = Physics2D.OverlapCircleAll(transform.position, _radius, _enemiesLayer);
        if(closestEnemies.Length > 0)
        {
            Vector3 chosenEnemy = closestEnemies[Random.Range(0, closestEnemies.Length)].transform.position;
            Vector2 direction = chosenEnemy - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));
        }

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

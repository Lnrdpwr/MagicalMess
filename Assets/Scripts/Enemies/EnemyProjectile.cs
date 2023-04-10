using System.Collections;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _projectileDamage;

    private Transform _target;
    private Rigidbody2D _projectileRigidbody;

    private void Start()
    {
        _projectileRigidbody = GetComponent<Rigidbody2D>();
        _target = PlayerMovement.Instance.transform;

        Vector2 direction = (_target.position - transform.position).normalized * _speed;
        _projectileRigidbody.velocity = direction;

        _projectileDamage *= Spawner.Instance.Coefficient;

        StartCoroutine(SelfDestroy());
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerHealth player))
        {
            player.ChangeHealth(-_projectileDamage);
            Destroy(gameObject);
        }
    }
}

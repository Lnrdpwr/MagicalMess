using System.Collections;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private EnemyAnimations _enemyAnimations;
    private Rigidbody2D _enemyRigidbody;
    private Transform _target;

    private void Start()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();

        _target = PlayerMovement.Instance.transform;
        _enemyAnimations.SetMovingAnimation(true);

        StartCoroutine(SelfDestroy());
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_target.position - transform.position).normalized * _speed;
        _enemyRigidbody.velocity = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))//Потом collision.TryGetComponent(out PlayerWallet wallet)
        {
            //Добавить алгоритм воровства
            _speed *= -1;//Что бы гоблин бежал от игрока
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}

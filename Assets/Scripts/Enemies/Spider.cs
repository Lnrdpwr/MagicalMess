using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _effect, _acid;

    private EnemyAnimations _enemyAnimations;
    private Transform _target;
    private Rigidbody2D _enemyRigidbody;

    private void Start()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();

        _target = PlayerMovement.Instance.transform;
        _enemyAnimations.SetMovingAnimation(true);
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_target.position - transform.position).normalized * _speed;
        _enemyRigidbody.velocity = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(_effect, transform.position, Quaternion.identity);
            Instantiate(_acid, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

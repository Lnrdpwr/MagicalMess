using UnityEngine;

public class Sceleton : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _effect;

    private EnemyAnimations _enemyAnimations;
    private Rigidbody2D _enemyRigidbody;
    private Transform _target;

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

    private void OnDestroy()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
    }
}

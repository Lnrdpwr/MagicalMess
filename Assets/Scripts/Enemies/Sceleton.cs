using UnityEngine;

public class Sceleton : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private EnemyAnimations _enemyAnimations;

    private Rigidbody2D _enemyRigidbody;
    private Transform _target;

    void Start()
    {
        _target = PlayerMovement.Instance.transform;
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _enemyAnimations.SetMovingAnimation(true);
    }

    void FixedUpdate()
    {
        Vector2 direction = (_target.position - transform.position).normalized * _speed;
        _enemyRigidbody.velocity = direction;
    }
}

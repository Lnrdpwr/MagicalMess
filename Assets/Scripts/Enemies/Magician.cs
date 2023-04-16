using System.Collections;
using UnityEngine;

public class Magician : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minimalDistance, _maximalDistance;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _timeToSpawnProjectile;

    private EnemyAnimations _enemyAnimations;
    private Rigidbody2D _enemyRigidbody;
    private Transform _target;

    private bool _isWalking = true;

    private void Start()
    {
        _enemyAnimations = GetComponent<EnemyAnimations>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();

        _target = PlayerMovement.Instance.transform;
        _enemyAnimations.SetMovingAnimation(true);

        StartCoroutine(SpawnProjectiles());
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, _target.position);
        if (distance > _maximalDistance)//Если далеко от игрока
        {
            Vector2 direction = (_target.position - transform.position).normalized * _speed;
            _enemyRigidbody.velocity = direction;
            if (!_isWalking)
            {
                _isWalking = true;
                _enemyAnimations.SetMovingAnimation(_isWalking);
            }
        }
        else if(distance < _minimalDistance)//Если игрок слишком близко
        {
            Vector2 direction = (_target.position - transform.position).normalized * _speed;
            _enemyRigidbody.velocity = -direction;
            if (!_isWalking)
            {
                _isWalking = true;
                _enemyAnimations.SetMovingAnimation(_isWalking);
            }
        }
        else if (_isWalking)
        {
            _enemyRigidbody.velocity = Vector2.zero;
            _isWalking = false;
            _enemyAnimations.SetMovingAnimation(_isWalking);
        }
        else
        {
            _enemyRigidbody.velocity = Vector2.zero;
        }
    }

    IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToSpawnProjectile);
            Instantiate(_projectile, _projectileSpawnPoint.position, Quaternion.identity);
            _enemyAnimations.StartAttack();
        }
    }
}

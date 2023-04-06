using System.Collections;
using UnityEngine;

public class Witch : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minimalDistance, _maximalDistance;
    [SerializeField] private Transform _batSpawnPoint;
    [SerializeField] private GameObject _bat;
    [SerializeField] private float _timeToSpawnBat;

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

        StartCoroutine(SpawnBats());
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
    }

    IEnumerator SpawnBats()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeToSpawnBat);
            Instantiate(_bat, _batSpawnPoint.position, Quaternion.identity);
            _enemyAnimations.SpawnBat();
        }
    }
}

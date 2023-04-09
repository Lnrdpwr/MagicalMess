using System.Collections;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] private float _maximumSpeed;
    [SerializeField] private float _inactiveTime;
    [SerializeField] private AnimationCurve _speedChange;

    private EnemyAnimations _enemyAnimations;
    private Rigidbody2D _enemyRigidbody;
    private Transform _target;
    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = _maximumSpeed;
        _enemyAnimations = GetComponent<EnemyAnimations>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();

        _target = PlayerMovement.Instance.transform;
        _enemyAnimations.SetMovingAnimation(true);
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_target.position - transform.position).normalized * _currentSpeed;
        _enemyRigidbody.velocity = direction;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Inactive());
        }
    }

    IEnumerator Inactive()
    {
        for(float i = 0; i <= _inactiveTime; i += Time.deltaTime)
        {
            _currentSpeed = _speedChange.Evaluate(i / _inactiveTime) * _maximumSpeed;
            yield return new WaitForEndOfFrame();
        }
        _currentSpeed = _maximumSpeed;
    }
}

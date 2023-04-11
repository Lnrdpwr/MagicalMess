using System.Collections;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private GameObject _coin;

    private EnemyAnimations _enemyAnimations;
    private Rigidbody2D _enemyRigidbody;
    private Transform _target;
    private EnemyHealth _health;
    private bool _stoleMoney = false;
    private bool _playerHadCoin = false;


    private void Start()
    {
        _health = GetComponent<EnemyHealth>();
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
        if(collision.TryGetComponent(out Wallet wallet) && !_stoleMoney)
        {
            _playerHadCoin = wallet.StealCoin();
            _speed *= -1;//Что бы гоблин бежал от игрока
            _stoleMoney = true;
        }
    }

    public void ReturnCoin()
    {
        if (_playerHadCoin)
        {
            Instantiate(_coin, transform.position, Quaternion.identity);
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(_lifeTime);
        _health.DestroyEnemy();
    }
}

using System.Collections;
using UnityEngine;

public class WitchScythe : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _rotationaLspeed;
    [SerializeField] private float _timeBeforeDestroy;
    [SerializeField] private Sprite _scytheRight;
    [SerializeField] private Sprite _scytheLeft;

    private BoxCollider2D _boxCollider;
    private PlayerMovement _playerMovement;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    public void Start()
    {
        _playerMovement = gameObject.GetComponentInParent<PlayerMovement>();
        _damage *= Shop.Instance.SpellDamageModifier;
        _boxCollider = GetComponent<BoxCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(LifeTime(_timeBeforeDestroy));
    }

    public void FixedUpdate()
    {
        int coeff;

        if (_playerMovement.PlayerLookFlip == true)
        {
            coeff = -1;
            _spriteRenderer.sprite = _scytheRight;
            _boxCollider.size = new Vector2(0.5f, 1.2f);
            _boxCollider.offset = new Vector2(0.95f, 0.72f);
        }
        else
        {
            coeff = 1;
            _spriteRenderer.sprite = _scytheLeft;
            _boxCollider.size = new Vector2(1.2f, 0.5f);
            _boxCollider.offset = new Vector2(0.6f, 1.07f);
        }

        transform.position = transform.parent.position;
        _rigidbody2D.rotation += coeff * _rotationaLspeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.DoDamage(0, _damage, false);
        }
    }

    IEnumerator LifeTime(float timeBeforeDestroy)
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        Destroy(gameObject);
    }
}

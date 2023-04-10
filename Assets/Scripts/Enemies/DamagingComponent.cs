using UnityEngine;

public class DamagingComponent : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private bool _isKamikaze;

    private EnemyHealth _health;

    private void Start()
    {
        _damage *= Spawner.Instance.Coefficient;
        if (_isKamikaze)
        {
            _health = GetComponent<EnemyHealth>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth _player))
        {
            _player.ChangeHealth(-_damage);
            if (_isKamikaze)
            {
                _health.DestroyEnemy();
            }
        }
    }
}
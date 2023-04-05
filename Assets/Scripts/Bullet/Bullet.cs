using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;//Ещё не изменяется при улучшении

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out EnemyHealth _enemy))
        {
            _enemy.DoDamage(_damage);
        }
        Destroy(gameObject);
    }
}

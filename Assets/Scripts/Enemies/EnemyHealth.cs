using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private GameObject _effect;

    public void DoDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

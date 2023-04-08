using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private GameObject _effect;

    public float Damage;

    public void DoDamage()
    {
        _health -= Damage;
        if(_health <= 0)
        {
            DestroyEnemy();
        }
    }

    public void DoDamageAfterTrack(float time)
    {
        Invoke("DoDamage", time);
    }

    public void DestroyEnemy()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

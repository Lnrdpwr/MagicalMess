using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private GameObject _effect;

    public void DoDamageAfterTrack(float time, float damage)
    {
        StartCoroutine(DoDamage(time, damage));
    }

    public void DestroyEnemy()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator DoDamage(float time, float damage)
    {
        yield return new WaitForSeconds(time);
        _health -= damage;
        if (_health <= 0)
        {
            DestroyEnemy();
        }
    }
}

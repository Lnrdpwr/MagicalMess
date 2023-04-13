using System.Collections;
using UnityEngine;

public class SmokeLeaf : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _timeBeforeDestroy;
    [SerializeField] private float _timeBetweenDamage;

    private bool _isReloaded = true;

    private void Start()
    {
        StartCoroutine(LifeTime(_timeBeforeDestroy));
    }

    private void FixedUpdate()
    {
        if (_isReloaded)
        {
            StartCoroutine(Reload(_timeBetweenDamage));
        }  
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemy))
        {
            if (_isReloaded)
            {
                enemy.DoDamage(0, _damage, false);
                _isReloaded = false;
            }
        }
    }

    IEnumerator Reload(float timeBetweenDamage)
    {
        yield return new WaitForSeconds(0.1f);
        _isReloaded = false;
        yield return new WaitForSeconds(timeBetweenDamage);
        _isReloaded = true;
    }

    IEnumerator LifeTime(float timeBeforeDestroy)
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        Destroy(gameObject);
    }
}

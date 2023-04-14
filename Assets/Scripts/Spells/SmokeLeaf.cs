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
        transform.parent = null;
        StartCoroutine(LifeTime(_timeBeforeDestroy));
        _damage *= Shop.Instance.SpellDamageModifier;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemy))
        {
            if (_isReloaded)
            {
                enemy.DoDamage(0, _damage, false);
                _isReloaded = false;
                StartCoroutine(Reload(_timeBetweenDamage));
            }
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
                StartCoroutine(Reload(_timeBetweenDamage));
            }
        }
    }

    IEnumerator Reload(float timeBetweenDamage)
    {
        yield return new WaitForSeconds(timeBetweenDamage);
        _isReloaded = true;
    }

    IEnumerator LifeTime(float timeBeforeDestroy)
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class SmokeLeaf : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _timeBeforeDestroy;
    [SerializeField] private float _timeBetweenDamage;
    [SerializeField] private AnimationCurve _disappearCurve;

    private bool _isReloaded = true;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(LifeTime(_timeBeforeDestroy));
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
        _isReloaded = false;
        yield return new WaitForSeconds(timeBetweenDamage);
        _isReloaded = true;
    }

    IEnumerator LifeTime(float timeBeforeDestroy)
    {
        for (float i = 0; i < timeBeforeDestroy; i += Time.deltaTime)
        {
            _spriteRenderer.color = new Color(1, 1, 1, _disappearCurve.Evaluate(i / timeBeforeDestroy));
            yield return new WaitForEndOfFrame();
        }
        //yield return new WaitForSeconds(timeBeforeDestroy);       
        Destroy(gameObject);
    }
}

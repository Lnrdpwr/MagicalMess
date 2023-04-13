using System.Collections;
using UnityEngine;

public class WitchScythe : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _rotationaLspeed;
    [SerializeField] private float _timeBeforeDestroy;

    private Rigidbody2D _rigidbody2D;

    public void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        _rigidbody2D.rotation -= _rotationaLspeed;
        gameObject.transform.position = gameObject.transform.parent.position; 
    }

    public void StartTimer()
    {
        StartCoroutine(LifeTime(_timeBeforeDestroy));
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
        gameObject.SetActive(false);
    }
}

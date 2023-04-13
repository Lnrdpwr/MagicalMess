using System.Collections;
using UnityEngine;

public class WitchScythe : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _rotationaLspeed;
    [SerializeField] private float _timeBeforeDestroy;

    private Rigidbody2D _rigidbody2D;

    public Transform Parent;

    public void Start()
    {
        gameObject.transform.SetParent(Parent);
        gameObject.transform.localScale = Parent.localScale;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(LifeTime(_timeBeforeDestroy));
    }

    public void FixedUpdate()
    {
        _rigidbody2D.rotation -= _rotationaLspeed;
        gameObject.transform.position = Parent.position; 
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

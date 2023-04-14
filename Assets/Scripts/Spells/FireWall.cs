using System.Collections;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    [SerializeField] private Vector3 _increasingScale;
    [SerializeField] private float _timeToScale;
    [SerializeField] private SpriteRenderer _frontSR;
    [SerializeField] private SpriteRenderer _backSR;
 
    public float Damage;

    public void Start()
    {
        StartCoroutine(ChangeScale());
        Damage *= Shop.Instance.SpellDamageModifier;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemy))
        {
            enemy.DoDamage(0, Damage, false);
        }
    }

    IEnumerator ChangeScale()
    {
        var frontColor = _frontSR.color;
        var backColor = _backSR.color;

        for (float i = 0; i <= _timeToScale; i += Time.deltaTime)
        {
            gameObject.transform.localScale += _increasingScale * Time.deltaTime;
           
            frontColor.a -= Time.deltaTime;
            backColor.a -= Time.deltaTime;
            _frontSR.color = frontColor;
            _backSR.color = backColor;

            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }

}

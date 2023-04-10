using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private MonsterMark _monsterMark;
    [SerializeField] private float _health;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _coin;
    [SerializeField] private bool _canDropCoins;

    private void Start()
    {
        _health *= Spawner.Instance.Coefficient;
    }

    public void DoDamage(float time, float damage,bool doTrack)
    {
        if (doTrack == true && _health != damage)
        {
            _monsterMark.StartTimer(time);
        }
        
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
            if (Random.Range(0, 100) < 10 && _canDropCoins)
                Instantiate(_coin, transform.position, Quaternion.identity);

            DestroyEnemy();
        }
    }
}

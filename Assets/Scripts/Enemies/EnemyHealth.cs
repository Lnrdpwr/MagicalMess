using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private MonsterMark _monsterMark;
    [SerializeField] private float _health;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _coin, _egg, _manaStar;
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
        if(TryGetComponent(out Goblin goblin))
            goblin.ReturnCoin();
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator DoDamage(float time, float damage)
    {
        yield return new WaitForSeconds(time);
        if(_health > 0)//Двойная проверка, что бы не спавнить несколько монет при попадании нескольких стрел
        {
            _health -= damage;
            if (_health <= 0)
            {
                if (Spawner.Instance.CoinsToDrop >= GameObject.FindGameObjectsWithTag("Enemy").Length && _canDropCoins)
                {
                    Instantiate(_coin, transform.position, Quaternion.identity);
                }
                else if(_canDropCoins)
                {
                    int dropChance = Random.Range(0, 100);
                    switch (dropChance)
                    {
                        case < 20:
                            Instantiate(_coin, transform.position, Quaternion.identity);
                            break;
                        case < 30:
                            Instantiate(_egg, transform.position, Quaternion.identity);
                            break;
                        case < 40:
                            Instantiate(_manaStar, transform.position, Quaternion.identity);
                            break;
                    }
                }
                DestroyEnemy();
            }
        }
    }
}

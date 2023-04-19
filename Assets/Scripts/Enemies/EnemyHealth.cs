using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private MonsterMark _monsterMark;
    [SerializeField] private float _health;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _coin, _egg, _manaStar;
    [SerializeField] private bool _canDropCoins;
    [SerializeField] private AudioClip _damagedSound, _destroySound;
    [SerializeField] private Image _healthBar;

    private float _currentHealth;

    private void Start()
    {
        _health *= Spawner.Instance.Coefficient;
        _currentHealth = _health;
    }

    public void DoDamage(float time, float damage,bool doTrack)
    {
        if (doTrack == true && _currentHealth != damage)
        {
            _monsterMark.StartTimer(time);
        }
        
        StartCoroutine(DoDamage(time, damage));
    }

    public void DestroyEnemy()
    {
        SoundManager.Instance.PlayClip(_destroySound);
        if(TryGetComponent(out Goblin goblin))
            goblin.ReturnCoin();
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator DoDamage(float time, float damage)
    {
        yield return new WaitForSeconds(time);
        if(_currentHealth > 0)//Двойная проверка, что бы не спавнить несколько монет при попадании нескольких стрел
        {
            _currentHealth -= damage;
            _healthBar.fillAmount = _currentHealth / _health;
            if (_currentHealth <= 0)
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
            else
            {
                SoundManager.Instance.PlayClip(_damagedSound);
            }
        }
    }
}

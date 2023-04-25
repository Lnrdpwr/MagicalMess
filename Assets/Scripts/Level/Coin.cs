using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private LevelManager _levelManager;
    private int _amountOfMoney;
    private SpriteRenderer _coinRenderer;

    private void Start()
    {
        _levelManager = LevelManager.Instance;
        _amountOfMoney = _levelManager.CoinsPerKill;
        _coinRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SelfDestroy());
    }

    public int GetCoins()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        return _amountOfMoney;
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(5);

        float alpha = 1;
        for(float i = 5; i > 0; i -= 0.5f)
        {
            alpha = Mathf.Abs(alpha - 0.75f);
            _coinRenderer.color = new Color(1, 1, 1, alpha);
            yield return new WaitForSeconds(0.34f);
            alpha = 1;
            _coinRenderer.color = new Color(1, 1, 1, alpha);
            yield return new WaitForSeconds(0.16f);
        }

        Destroy(gameObject);
    }
}

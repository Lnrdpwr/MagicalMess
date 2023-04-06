using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maximumHealth;
    [SerializeField] private Image _healthBar;
    [SerializeField] private AnimationCurve _healthBarChangeCurve;
    [SerializeField] private float _timeToChangeBar;
    [SerializeField] private float _invincibleTime;

    private float _currentHealth;
    private SpriteRenderer _playerRenderer;
    private bool _isInvincible;

    private void Start()
    {
        _currentHealth = _maximumHealth;
        _playerRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeHealth(float changeAmount)//Отрицательное, если надо нанести урон
    {
        if(changeAmount > 0 || !_isInvincible)
        {
            _currentHealth += changeAmount;
        }
        
        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        else if(_currentHealth <= _maximumHealth)
        {
            StartCoroutine(ChangeBar(_currentHealth - changeAmount, changeAmount));
            StartCoroutine(Invincible());
        }
        else
        {
            _currentHealth = _maximumHealth;
        }
    }

    IEnumerator ChangeBar(float changeFrom, float previousChange)
    {
        for(float i = 0; i <= _timeToChangeBar; i += Time.deltaTime)
        {
            _healthBar.fillAmount = (changeFrom + _healthBarChangeCurve.Evaluate(i / _timeToChangeBar) * previousChange) / _maximumHealth;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Invincible()
    {
        _isInvincible = true;
        int alpha = 1;
        for(float i = 0; i <= _invincibleTime; i += _invincibleTime / 5)
        {
            alpha = Mathf.Abs(alpha - 1);
            _playerRenderer.color = new Color(1, 1, 1, alpha);
            yield return new WaitForSeconds(_invincibleTime / 5);
        }
        _playerRenderer.color = new Color(1, 1, 1, 1);
        _isInvincible = false;
    }
}

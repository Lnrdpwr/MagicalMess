using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maximumHealth;
    [SerializeField] private Image _healthBar;
    [SerializeField] private AnimationCurve _healthBarChangeCurve;
    [SerializeField] private float _timeToChangeBar;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maximumHealth;
    }

    public void ChangeHealth(float changeAmount)//Отрицательное, если надо нанести урон
    {
        _currentHealth += changeAmount;
        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        else if(_currentHealth <= _maximumHealth)
        {
            StartCoroutine(ChangeBar(_currentHealth - changeAmount, changeAmount));
        }
    }

    IEnumerator ChangeBar(float changeFrom, float previousChange)
    {
        Debug.Log(changeFrom);
        for(float i = 0; i <= _timeToChangeBar; i += Time.deltaTime)
        {
            Debug.Log((changeFrom + _healthBarChangeCurve.Evaluate(i / _timeToChangeBar) * previousChange) / _maximumHealth);
            _healthBar.fillAmount = (changeFrom + _healthBarChangeCurve.Evaluate(i / _timeToChangeBar) * previousChange) / _maximumHealth;
            yield return new WaitForEndOfFrame();
        }
    }
}

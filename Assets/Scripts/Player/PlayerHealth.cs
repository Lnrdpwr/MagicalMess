using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private AnimationCurve _healthBarChangeCurve;
    [SerializeField] private float _timeToChangeBar;
    [SerializeField] private float _invincibleTime;
    [SerializeField] private GameObject _healthbarObject;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private AudioClip _hurtSound, _healSound;

    private float _currentHealth;
    private SpriteRenderer _playerRenderer;
    private bool _isInvincible;
    private bool _canChangeBar = true;

    public float MaximumHealth;

    internal static PlayerHealth Instance;

    private void Start()
    {
        Instance = this;
        _currentHealth = MaximumHealth;
        _playerRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeHealth(float changeAmount)
    {

        if(!_isInvincible || changeAmount > 0)
        {
            _currentHealth += changeAmount;
            if (_currentHealth <= 0)
            {
                _healthbarObject.SetActive(false);
                _levelManager.StopGame();
                gameObject.SetActive(false);
            }
            else if (_currentHealth <= MaximumHealth && _canChangeBar)
            {
                _canChangeBar = false;
                StartCoroutine(ChangeBar(_currentHealth - changeAmount, changeAmount));
                StartCoroutine(Invincible());
            }
            else if (_currentHealth > MaximumHealth)
            {
                float tempValue = changeAmount - (_currentHealth - MaximumHealth);
                _currentHealth = MaximumHealth;
                _canChangeBar = false;
                StartCoroutine(ChangeBar(_currentHealth - tempValue, tempValue));
                StartCoroutine(Invincible());
            }

            if(changeAmount < 0)
            {
                SoundManager.Instance.PlayClip(_hurtSound);
            }
            else
            {
                SoundManager.Instance.PlayClip(_healSound);
            }
        }
    }
    
    public void ChangeMaximumHealth(float addedHealth)
    {
        MaximumHealth += addedHealth;
        _currentHealth = MaximumHealth;
        _healthBar.fillAmount = 1;
    }

    IEnumerator ChangeBar(float changeFrom, float previousChange)
    {
        for(float i = 0; i <= _timeToChangeBar; i += Time.deltaTime)
        {
            _healthBar.fillAmount = (changeFrom + _healthBarChangeCurve.Evaluate(i / _timeToChangeBar) * previousChange) / MaximumHealth;
            yield return new WaitForEndOfFrame();
        }

        _canChangeBar = true;
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

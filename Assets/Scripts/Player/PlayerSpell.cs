using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSpell : MonoBehaviour
{
    [SerializeField] private Image _manaBar;
    [SerializeField] private AnimationCurve _manaBarChangeCurve;
    [SerializeField] private float _timeToChangeBar;
    [SerializeField] private GameObject _manaBarObject;
    [SerializeField] private float _spellCooldown;

    private float _currentMana;
    private bool _canChangeBar = true;
    private GameObject _currentSpell;
    private bool _canUseSpell = false;
    
    public float MaximumMana;
    public float ManaUsage;

    internal static PlayerSpell Instance;

    private void Awake()
    {
        Instance = this;
        _currentMana = MaximumMana;
    }

    private void Update()
    {
        if (Input.GetKeyDown("f") && _canUseSpell && _currentMana >= ManaUsage)
        {
            Instantiate(_currentSpell, transform);
            _canUseSpell = false;
            _currentMana -= ManaUsage;
            StartCoroutine(Cooldown());
            StartCoroutine(ChangeBar(_currentMana + ManaUsage, -ManaUsage));
        }
    }

    public void ChangeMaximumMana(float addedMana)
    {
        MaximumMana += addedMana;
        if(_currentMana == MaximumMana - addedMana)
        {
            _currentMana = MaximumMana;
        }
        _manaBar.fillAmount = _currentMana / MaximumMana;
    }

    public void ChangeMana(float changeAmount)
    {
        _currentMana += changeAmount;
        if (_currentMana <= MaximumMana && _canChangeBar)
        {
            StartCoroutine(ChangeBar(_currentMana - changeAmount, changeAmount));
            _canChangeBar = false;
        }
        else if (_currentMana > MaximumMana)
        {
            _currentMana = MaximumMana;
        }
    }
    
    public void SetSpell(GameObject newSpell){
        _currentSpell = newSpell;
        _canUseSpell = true;
    }

    public void Revive()
    {
        _currentMana = MaximumMana;
        StartCoroutine(ChangeBar(0, MaximumMana));
    }

    IEnumerator ChangeBar(float changeFrom, float previousChange)
    {
        for (float i = 0; i <= _timeToChangeBar; i += Time.deltaTime)
        {
            _manaBar.fillAmount = (changeFrom + _manaBarChangeCurve.Evaluate(i / _timeToChangeBar) * previousChange) / MaximumMana;
            yield return new WaitForEndOfFrame();
        }
        _canChangeBar = true;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_spellCooldown);
        _canUseSpell = true;
    }
}

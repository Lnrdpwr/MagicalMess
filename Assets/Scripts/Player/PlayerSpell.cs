using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSpell : MonoBehaviour
{
    [SerializeField] private Image _manaBar;
    [SerializeField] private AnimationCurve _manaBarChangeCurve;
    [SerializeField] private float _timeToChangeBar;
    [SerializeField] private GameObject _manaBarObject;

    private float _currentMana;
    private bool _canChangeBar;

    public float MaximumMana;

    private void Start()
    {
        _currentMana = MaximumMana;
    }

    public void ChangeMaxMana(float addedMana)
    {
        MaximumMana += addedMana;
        float chageAmount = MaximumMana - _currentMana;

        StartCoroutine(ChangeBar(_currentMana + (chageAmount), chageAmount));
        _currentMana = MaximumMana;

    }

    public void ChangeMana(float changeAmount)
    {
        if (changeAmount < 0)
        {
            _currentMana += changeAmount;
            _canChangeBar = true;
        }
        else if (_currentMana < MaximumMana && _canChangeBar)
        {
            StartCoroutine(ChangeBar(_currentMana - changeAmount, changeAmount));
            _canChangeBar = false;
        }
        else if (_currentMana > MaximumMana)
        {
            _currentMana = MaximumMana;
        }
    }

    void CreateSpell()
    {
        //—юда прописать механику стрельбы спелом
    }

    IEnumerator ChangeBar(float changeFrom, float previousChange)
    {
        for (float i = 0; i <= _timeToChangeBar; i += Time.deltaTime)
        {
            _manaBar.fillAmount = (changeFrom + _manaBarChangeCurve.Evaluate(i / _timeToChangeBar) * previousChange) / MaximumMana;
            yield return new WaitForEndOfFrame();
        }
    }
}

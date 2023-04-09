using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMark : MonoBehaviour
{
    private Image _image;
    private bool _isStarted = false;
    private float _time;


    public void Start()
    {
        _image = GetComponent<Image>();
    }

    public void Update()
    {
        if (_isStarted == true)
        {
            _image.fillAmount -= Time.deltaTime / _time;
        }
    }

    public void StartTimer(float time)
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1f;
        gameObject.SetActive(true);
        _isStarted = true;
        _time = time;
    }
}

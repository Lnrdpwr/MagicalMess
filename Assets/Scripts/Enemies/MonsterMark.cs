using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMark : MonoBehaviour
{
    private Image _image;

    public void Start()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 0;
    }

    public void StartTimer(float time)
    {
        StartCoroutine(ShowMark(time));
    }

    IEnumerator ShowMark(float timeToDisappear)
    {
        for (float i = timeToDisappear; i > 0; i -= Time.deltaTime)
        {
            _image.fillAmount = i / timeToDisappear;
            yield return new WaitForEndOfFrame();
        }
        _image.fillAmount = 0f;
    }
}

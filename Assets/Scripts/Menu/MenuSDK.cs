using System.Collections;
using UnityEngine;
using YG;

public class MenuSDK : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ShowAd());
    }

    IEnumerator ShowAd()
    {
        yield return new WaitForSeconds(1);
        YandexGame.StickyAdActivity(true);
    }
}

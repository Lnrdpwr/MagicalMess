using System.Collections;
using UnityEngine;
using YG;

public class LevelSDK : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(HideAd());
    }

    IEnumerator HideAd()
    {
        yield return new WaitForSeconds(0.5f);
        YandexGame.StickyAdActivity(false);
    }
}

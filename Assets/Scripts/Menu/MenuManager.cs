using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator _transitionAnimator;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private GameObject _pcTutorialPanel, _mobileTutorialPanel;

    private string _deviceType;

    public void PlatformToTutorial()
    {
        _deviceType = YandexGame.EnvironmentData.deviceType;

        if (_deviceType == "desktop")
        {
            _pcTutorialPanel.SetActive(true);
        }
        else
        {
            _mobileTutorialPanel.SetActive(true);
        }
    }

    public void LoadScene(int sceneNum)
    {
        StartCoroutine(StartLoadScene(sceneNum));
    }

    IEnumerator StartLoadScene(int sceneNum)
    {
        _transitionAnimator.SetTrigger("FinalTransition");
        for(float i = 2; i > 0; i -= Time.deltaTime)
        {
            _musicSource.volume = i / 2;
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(sceneNum);
    }
}

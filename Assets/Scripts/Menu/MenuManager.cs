using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator _transitionAnimator;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private GameObject _pcTutorialPanel, _mobileTutorialPanel, _tutorPanel, _mainMenu, _lastPage;

    private string _deviceType;
    private bool _watchedTutorial;
    private bool _firstViewing = false;


    public void StartTutorial()
    {
        _watchedTutorial = YandexGame.savesData.watchedTutorial;
        if (!_watchedTutorial)
        {
            _firstViewing = true;
            PlatformToTutorial();
            _tutorPanel.SetActive(true);
        }
        else
        {
            LoadScene(1);
        }
    }

    public void StartGameAfterTutor()
    {
        if (_firstViewing)
        {
            YandexGame.savesData.watchedTutorial = true;
            YandexGame.SaveProgress();
            LoadScene(1);
        }
        else
        {
            _tutorPanel.SetActive(false);
            _mainMenu.SetActive(true);
            _lastPage.SetActive(false);
        }
    }

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

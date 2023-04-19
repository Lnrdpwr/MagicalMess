using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesSwitch : MonoBehaviour
{
    [SerializeField] private Animator _transitionAnimator;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private GameObject _tutoralPanel;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("PassedTutorial"))
        {
            _tutoralPanel.SetActive(true);
            PlayerPrefs.SetInt("PassedTutorial", 1);
            PlayerPrefs.Save();
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

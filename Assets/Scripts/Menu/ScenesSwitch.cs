using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesSwitch : MonoBehaviour
{
    [SerializeField] private Animator _transitionAnimator;

    public void LoadScene(int sceneNum)
    {
        StartCoroutine(StartLoadScene(sceneNum));
    }

    IEnumerator StartLoadScene(int sceneNum)
    {
        _transitionAnimator.SetTrigger("FinalTransition");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneNum);
    }
}

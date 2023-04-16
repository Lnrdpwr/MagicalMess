using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _passedWavesText;
    [SerializeField] private TMP_Text _bestResultText;
    [SerializeField] private Animator _transitionAnimator;

    public int CoinsPerKill = 1;

    internal static LevelManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public void StopGame()
    {
        int bestResult = PlayerPrefs.GetInt("BestResult", 0);
        int currentResult = _spawner.StopSpawner();
        _passedWavesText.text = "Waves passed: " + currentResult.ToString();

        if (currentResult > bestResult)
        {
            _bestResultText.text = "Best result: " + currentResult.ToString();
            PlayerPrefs.SetInt("BestResult", currentResult);
        }
        else
        {
            _bestResultText.text = "Best result: " + bestResult.ToString();
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().DestroyEnemy();
        }
        _panel.SetActive(true);
    }

    public void Restart()
    {
        StartCoroutine(StartTransition("SampleScene"));
    }

    public void GoToMenu()
    {
        StartCoroutine(StartTransition("Menu"));
    }

    IEnumerator StartTransition(string newScene)
    {
        _transitionAnimator.SetTrigger("FinalTransition");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(newScene);
    }
}

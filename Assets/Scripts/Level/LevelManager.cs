using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _passedWavesText;
    [SerializeField] private TMP_Text _bestResultText;
    
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
        SceneManager.LoadScene("SampleScene");
    }
}

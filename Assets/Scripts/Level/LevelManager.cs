using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _passedWavesText;
    
    public void StopGame()
    {
        _passedWavesText.text = "Waves passed: " + _spawner.StopSpawner().ToString();
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

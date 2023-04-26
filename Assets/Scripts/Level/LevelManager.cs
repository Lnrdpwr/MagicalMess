using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using YG;
using YG.Example;

public class LevelManager : MonoBehaviour
{
    readonly SavesYG _dataSave;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _passedWavesInGameText;
    [SerializeField] private TMP_Text _passedWavesText;
    [SerializeField] private TMP_Text _bestResultText;
    [SerializeField] private Animator _transitionAnimator;
    [SerializeField] private MusicSwitch _musicSwitch;
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private PlayerSpell _playerMana;

    private PlayerShooting _playerShooting;

    public int CoinsPerKill = 1;

    internal static LevelManager Instance;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _playerShooting = PlayerShooting.Instance;
    }

    private void FixedUpdate()
    {
        int currentResult = _spawner.WavesPassed;
        _passedWavesInGameText.text = $"Волн пройдено: {currentResult}";
    }

    public void StopGame()
    {
        int bestResult = _dataSave.qauntityWaves;
        int currentResult = _spawner.StopSpawner();
        _passedWavesText.text = "Пройдено волн: " + currentResult.ToString();

        if (currentResult > bestResult)
        {
            _bestResultText.text = "Лучший результат: " + currentResult.ToString();
            PlayerPrefs.SetInt("BestResult", currentResult);
            _dataSave.qauntityWaves = currentResult;
            SaverTest.MySaveData(_dataSave.qauntityWaves);
        }
        else
        {
            _bestResultText.text = "Лучший результат: " + bestResult.ToString();
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().DestroyEnemy();
        }
        GameObject[] acids = GameObject.FindGameObjectsWithTag("Acid");
        foreach (GameObject acid in acids)
        {
            Destroy(acid);
        }

        Leaderboard.NewRecord();

        _panel.SetActive(true);
    }

    public void RevivePlayer()
    {
        _panel.SetActive(false);
        _player.Revive();
        _playerMana.Revive();
        _spawner.ResetSpawner();
        _musicSwitch.ResetMusic();
        _playerShooting.ResetReload();
        SoundManager.Instance.GetComponent<AudioSource>().volume = 1;
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
        _musicSwitch.StopMusic();
        _transitionAnimator.SetTrigger("FinalTransition");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(newScene);
    }
}

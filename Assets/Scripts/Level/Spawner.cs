using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private Vector2 _topRight, _bottomLeft;
    [SerializeField] private float _timeToSpawn, _waveTime;
    [SerializeField] private GameObject _callWaveText;
    [SerializeField] private GameObject _wavesCountText;
    [SerializeField] private float _coefficientDelta;
    [SerializeField] private MusicSwitch _musicSwitch;
    [SerializeField] private PassiveSkills _skillsManager;
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private GameObject _shopButton;
    [SerializeField] private int _averageCoins;

    private Vector2 _spawnPosition;
    private bool _canShowText = true;
    private LevelManager _levelManager;
    private int _wavesUntillSkill = 3;

    public int WavesPassed = 0;
    public int CoinsToDrop = 5;
    public float Coefficient = 1;

    internal static Spawner Instance;

    private void Start()
    {
        Instance = this;
        _levelManager = LevelManager.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown("e") && _canShowText)
        {
            _canShowText = false;
            _callWaveText.SetActive(false);
            _wavesCountText.SetActive(false);

            StartCoroutine(SpawnCycle());
        }
    }

    IEnumerator SpawnCycle()
    {
        _shopButton.SetActive(false);
        _musicSwitch.SwitchMusic();
        for (float i = 0; i < _waveTime; i += _timeToSpawn)
        {
            int chosenEnemy = Random.Range(0, 100);
            int chosenBorder = Random.Range(-1, 2);//-1 - ñëåâà; 1 - ñïðàâà; 0 - ñâåðõó
            switch (chosenBorder)
            {
                case -1:
                    _spawnPosition = new Vector2(_bottomLeft.x, Random.Range(_bottomLeft.y, _topRight.y));
                    break;
                case 1:
                    _spawnPosition = new Vector2(_bottomLeft.x, Random.Range(_bottomLeft.y, _topRight.y));
                    break;
                case 0:
                    _spawnPosition = new Vector2(Random.Range(_bottomLeft.x, _topRight.x), _topRight.y);
                    break;
            }
            switch (chosenEnemy)
            {
                case < 40:
                    Instantiate(_enemies[0], _spawnPosition, Quaternion.identity);
                    break;
                case < 70:
                    Instantiate(_enemies[1], _spawnPosition, Quaternion.identity);
                    break;
                case < 80:
                    Instantiate(_enemies[2], _spawnPosition, Quaternion.identity);
                    break;
                case < 90:
                    Instantiate(_enemies[3], _spawnPosition, Quaternion.identity);
                    break;
                case <= 100:
                    Instantiate(_enemies[4], _spawnPosition, Quaternion.identity);
                    break;
            }
            yield return new WaitForSeconds(_timeToSpawn);
        }
        GameObject[] enemies = null;
        do
        {
            yield return new WaitForSeconds(1);
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        } while (enemies.Length > 0);
        _musicSwitch.SwitchMusic();

        _levelManager.CoinsPerKill = Mathf.RoundToInt(Coefficient);

        WavesPassed++;
        _wavesUntillSkill--;
        if(_wavesUntillSkill == 0)
        {
            Coefficient += _coefficientDelta;
            _skillsManager.ShowUpgradePanel();
            _wavesUntillSkill = 3;
            yield return new WaitWhile(() => _upgradePanel.activeSelf);
        }

        CoinsToDrop = Random.Range(4, 7);
        _wavesCountText.SetActive(true);
        _callWaveText.SetActive(true);
        _canShowText = true;
        _shopButton.SetActive(true);
    }

    public int StopSpawner()
    {
        StopAllCoroutines();
        _canShowText = false;
        _callWaveText.SetActive(false);
        return WavesPassed;
    }

    public void ResetSpawner()
    {
        _canShowText = true;
        _callWaveText.SetActive(true);
    }
}

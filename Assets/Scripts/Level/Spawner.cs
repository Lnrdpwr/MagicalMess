using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private Vector2 _topRight, _bottomLeft;
    [SerializeField] private float _timeToSpawn, _waveTime;
    [SerializeField] private GameObject _callWaveText;
    [SerializeField] private float _coefficientDelta;
    [SerializeField] private MusicSwitch _musicSwitch;
    [SerializeField] private PassiveSkills _skillsManager;
    [SerializeField] private GameObject _upgradePanel;

    private Vector2 _spawnPosition;
    private bool _canShowText = true;
    private int _wavesPassed = 0;
    private LevelManager _levelManager;
    private int _wavesUntillSkill = 5;

    public float Coefficient = 1;
    public int ActiveEnemies = 0;

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
            
            StartCoroutine(SpawnCycle());
        }
    }

    IEnumerator SpawnCycle()
    {
        _musicSwitch.SwitchMusic();
        for (float i = 0; i < _waveTime; i += _timeToSpawn)
        {
            int chosenEnemy = Random.Range(0, _enemies.Length);
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

            GameObject newEnemy = Instantiate(_enemies[chosenEnemy], _spawnPosition, Quaternion.identity);
            ActiveEnemies++;
            yield return new WaitForSeconds(_timeToSpawn);
        }
        yield return new WaitWhile(() => ActiveEnemies > 0);
        _musicSwitch.SwitchMusic();

        Coefficient += _coefficientDelta;
        _levelManager.CoinsPerKill = Mathf.RoundToInt(Coefficient);

        _wavesPassed++;
        _wavesUntillSkill--;
        if(_wavesUntillSkill == 0)
        {
            _skillsManager.ShowUpgradePanel();
            _wavesUntillSkill = 5;
            yield return new WaitWhile(() => _upgradePanel.activeSelf);
        }

        _callWaveText.SetActive(true);
        _canShowText = true;
    }

    public int StopSpawner()
    {
        StopAllCoroutines();
        _canShowText = false;
        _callWaveText.SetActive(false);
        return _wavesPassed;
    }

}

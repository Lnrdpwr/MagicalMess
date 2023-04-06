using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private Vector2 _topRight, _bottomLeft;
    [SerializeField] private float _timeToSpawn, _waveTime;

    private Vector2 _spawnPosition;

    private void Start()
    {
        StartCoroutine(SpawnCycle());
    }

    IEnumerator SpawnCycle()
    {
        for (float i = 0; i < _waveTime; i += _timeToSpawn)
        {
            int chosenEnemy = Random.Range(0, _enemies.Length);
            int chosenBorder = Random.Range(-1, 2);//-1 - слева; 1 - справа; 0 - сверху
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

            Instantiate(_enemies[chosenEnemy], _spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(_timeToSpawn);
        }
    }

}

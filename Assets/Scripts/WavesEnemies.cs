using UnityEngine;

public class WavesEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] _mobs;
    [SerializeField] private float _randX;
    [SerializeField] private float _randY;
    [SerializeField] private Vector2 _whereToSpawn;
    [SerializeField] private float _startTimeSpawn = 1.0f;
    
    private float _timeSpawn;

    private void Start()
    {
        _timeSpawn = _startTimeSpawn;
    }

    private void Update()
    {
        if (_timeSpawn <= 0)
        {
            _randX = Random.Range(-25f, 25f);
            _randY = Random.Range(18f, -1f);
            _whereToSpawn = new Vector2(_randX, _randY);
            GameObject randMob = _mobs[Random.Range(0, _mobs.Length)];
            Instantiate(randMob, _whereToSpawn, Quaternion.identity);
            _timeSpawn = _startTimeSpawn;
        }
        else
        {
            _timeSpawn -= Time.deltaTime;
        }
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    CallingWaves();
        //}
    }

    //public void CallingWaves()
    //{
    //    for (int i = 0; i < Random.Range(35, 40); i++)
    //    {
    //        if (_timeSpawn <= 0)
    //        {
    //            _randX = Random.Range(-25f, 25f);
    //            _randY = Random.Range(18f, -1f);
    //            _whereToSpawn = new Vector2(_randX, _randY);
    //            GameObject randMob = _mobs[Random.Range(0, _mobs.Length)];
    //            Instantiate(randMob, _whereToSpawn, Quaternion.identity);
    //            _timeSpawn = _startTimeSpawn;
    //        }
    //        else
    //        {
    //            _timeSpawn -= Time.deltaTime;
    //        }
    //    }
    //}
}

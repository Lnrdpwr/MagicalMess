using UnityEngine;

public class WavesEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] mobs;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CallingWaves();
            Debug.Log("yep");
        }

    }

    public void CallingWaves()
    {

    }
}

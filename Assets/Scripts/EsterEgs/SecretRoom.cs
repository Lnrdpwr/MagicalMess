using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretRoom : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TilemapCollider2D _collider;

    private bool playerCanPass = true;

    private void FixedUpdate()
    {
        if (_spawner.WavesPassed == 5 && _spawner.CanShowText)
        {
            playerCanPass = true;
        }

        if (playerCanPass)
        {
            _collider.offset = new Vector2(-20f, 0.45f);
        }
        else
        {
            _collider.offset = new Vector2(0, 0.45f);
        }
    }

}

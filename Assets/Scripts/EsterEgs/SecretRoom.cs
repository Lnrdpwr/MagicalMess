using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretRoom : MonoBehaviour
{
    [SerializeField] private GameObject _partyInTheWoods;
    [SerializeField] private GameObject _wavesCountText;
    [SerializeField] private GameObject _callWaveText;
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
            _collider.offset = new Vector2(-40f, 0.45f);
            _partyInTheWoods.SetActive(true);
        }
        else
        {
            _collider.offset = new Vector2(0, 0.45f);
            _partyInTheWoods.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement playerMovement))
        {
            _callWaveText.SetActive(false);
            _wavesCountText.SetActive(false);
        }
    }
}

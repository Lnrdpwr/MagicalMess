using UnityEngine;

public class StopSecret : MonoBehaviour
{
    [SerializeField] private GameObject _nextWaveText;
    [SerializeField] private GameObject _wavesCountText;

    [SerializeField] private GameObject _partyInTheWoods;
    [SerializeField] private GameObject _baro;
    [SerializeField] private GameObject _spotPoint;
    [SerializeField] private GameObject _secondCamera;
    [SerializeField] private SecretRoom _secretRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            _nextWaveText.SetActive(true);
            _wavesCountText.SetActive(true);

            Destroy(_partyInTheWoods);
            Destroy(_baro);
            Destroy(_spotPoint);
            Destroy(_secondCamera);

            _secretRoom.playerCanPass = false;

            Destroy(gameObject);
        }
    }
}

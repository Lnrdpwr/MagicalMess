using UnityEngine;

public class SpotPoint : MonoBehaviour
{
    [SerializeField] GameObject _cameraSpot;
    [SerializeField] ObjectSwitcher _objectSwitcher;

    public bool IsSpotReady = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ObjectSwitcher objectSwitcher) && objectSwitcher.IsCameraInHands)
        {
            _objectSwitcher.SwitchToCrossBow();
            _cameraSpot.SetActive(true);
            IsSpotReady = true;
        }
    }
}

using UnityEngine;

public class SpotPoint : MonoBehaviour
{
    [SerializeField] GameObject _cameraSpot;
    [SerializeField] GameObject _cameraButton;
    [SerializeField] ObjectSwitcher _objectSwitcher;

    public bool IsSpotReady = false;

    private void Start()
    {
        _cameraButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ObjectSwitcher objectSwitcher) && objectSwitcher.IsCameraInHands)
        {
            _objectSwitcher.SwitchToCrossBow();
            _cameraSpot.SetActive(true);
            IsSpotReady = true;
        }

        if (collision.TryGetComponent(out ObjectSwitcher objectSwitcherr))
        {
            _cameraButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ObjectSwitcher objectSwitcher))
        {
            _cameraButton.SetActive(false);
        }
    }
}

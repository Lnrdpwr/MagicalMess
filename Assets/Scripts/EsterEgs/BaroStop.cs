using UnityEngine;

public class BaroStop : MonoBehaviour
{
    [SerializeField] private CameraButton _cameraButton;
    [SerializeField] private GameObject _spotPoint;
    [SerializeField] private GameObject _finalSecretText;

    public bool IsBaroStop = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BaroStop")
        {
            IsBaroStop = true;
            _cameraButton.SwitchCameraToMain();
            _spotPoint.SetActive(false);
            _finalSecretText.SetActive(true);
        }
    }
}

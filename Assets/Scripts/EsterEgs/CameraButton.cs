using UnityEngine;

public class CameraButton : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _secondCamera;
    [SerializeField] private GameObject _baro;

    public void SwitchCamera()
    {
         _secondCamera.targetDisplay -= 1;
         _mainCamera.targetDisplay += 1;
        _baro.SetActive(true);
    }

    public void SwitchCameraToMain()
    {
        _mainCamera.targetDisplay -= 1;
        _secondCamera.targetDisplay += 1;
        _baro.SetActive(false);
    }
}

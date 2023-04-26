using UnityEngine;
using YG;

public class CrossBow : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Joystick _joystick;

    private Vector3 _mousePosition;
    private string _inputType;

    private void Update()
    {
        _inputType = YandexGame.EnvironmentData.deviceType;
        if(_inputType == "desktop")
        {
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        float angle = 0;
        if (_inputType == "desktop")
        {
            Vector3 lookDir = _mousePosition - transform.position;
            angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        }
        else if(_inputType == "mobile" || _inputType == "tablet")
        {
            float _horizonaDelta = _joystick.Horizontal;
            float _verticalDelta = _joystick.Vertical;
            angle = Mathf.Atan2(_verticalDelta, _horizonaDelta) * Mathf.Rad2Deg - 90f;
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);


        if (angle > -220f && angle < -135f)
        {
            _playerMovement.LookForward();
        }
        else if (angle > -135f && angle < -50f)
        {
            _playerMovement.LookRight();
        }
        else if ((angle > -270f && angle < -220f) || (angle < 90f && angle > 50))
        {
            _playerMovement.LookLeft();
        }
        else if (angle < 50f && angle > -50f)
        {
            _playerMovement.LookUpForward();
        }
    }
}

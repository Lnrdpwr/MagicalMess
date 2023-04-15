using UnityEngine;

public class CrossBow : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerMovement _playerMovement;

    private Vector3 _mousePosition;

    private void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector3 lookDir = _mousePosition - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > -220f && angle < -135f)
        {
            _playerMovement.LookForward();
        }
        else if (angle > -135f && angle < -50f)
        {
            _playerMovement.LookRight();
        }
        else if (angle > -270f && angle < -220f)
        {
            _playerMovement.LookLeft();
        }
        else if (angle < 15f && angle > -15f)
        {
            _playerMovement.LookUpForward();
        }
        else if (angle < 90f && angle > 50f)
        {
            _playerMovement.LookUpLeft();
        }
        else if (angle > -50f && angle < -15f )
        {
            _playerMovement.LookUpRight();
        }
       

        Debug.Log(angle);
    }
}

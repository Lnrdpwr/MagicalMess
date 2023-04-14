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
        else if (angle > -135f && angle < 0f)
        {
            _playerMovement.LookRight();
        }
        else if (angle < -180f || angle > 0f)
        {
            _playerMovement.LookLeft();
        }
       
    }
}

using UnityEngine;

public class CrossBow : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerMovement _playerMovement;

    private Transform _transform;
    private Rigidbody2D _rb;
    private Vector3 _mousePosition;

    public void Start()
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector3 lookDir = _mousePosition - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > -180f && angle < 0f)
        {
            _playerMovement.LookRight();
            //_transform.position = new Vector3(0.15f,-0.15f,0);
        }
        else if (angle < -180f || angle > 0f)
        {
            _playerMovement.LookLeft();
            //_transform.position = new Vector3(-0.15f, -0.15f,0);
        }

        Debug.Log(angle);
    }
}

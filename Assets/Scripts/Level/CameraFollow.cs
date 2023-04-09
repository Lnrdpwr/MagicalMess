using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;

    private void Start()
    {
        _target = PlayerMovement.Instance.transform;
    }

    private void Update()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, -10);
    }
}

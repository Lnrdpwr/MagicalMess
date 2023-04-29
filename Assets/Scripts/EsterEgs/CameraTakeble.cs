using UnityEngine;

public class CameraTakeble : MonoBehaviour
{
    [SerializeField] private ObjectSwitcher _objectSwitcher;
    [SerializeField] private GameObject _spotPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ObjectSwitcher objectSwitcher))
        {
            _objectSwitcher.SwitchToCamera();
            _spotPoint.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}

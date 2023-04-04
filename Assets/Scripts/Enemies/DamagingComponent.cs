using UnityEngine;

public class DamagingComponent : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private bool _isKamikaze;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.TryGetComponent(out PlayerHealth _player))
        {
            _player.DoDamage(_damage);
            if(_isKamikaze){
                Destroy(gameObject);
            }
        }*/
    }
}

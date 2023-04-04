using UnityEngine;

public class DamagingComponent : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private bool _isKqamikaze;
    [SerializeField] private GameObject _kamikazeEffect;//Ќе об€зательно указывать в инспекторе

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.TryGetComponent(out PlayerHealth _player))
        {
            _player.DoDamage(_damage);
            KamikazeDisappear();
        }*/
    }

    void KamikazeDisappear()
    {
        Instantiate(_kamikazeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

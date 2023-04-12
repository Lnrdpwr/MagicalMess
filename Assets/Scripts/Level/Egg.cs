using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private float _healAmount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerHealth player))
        {
            _healAmount = player.MaximumHealth / 5;
            player.ChangeHealth(_healAmount);
            Instantiate(_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

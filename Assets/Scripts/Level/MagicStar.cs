using UnityEngine;

public class MagicStar : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private float _manaAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerSpell player))
        {
            _manaAmount = player.MaximumMana / 5;
            player.ChangeMana(_manaAmount);
            Instantiate(_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

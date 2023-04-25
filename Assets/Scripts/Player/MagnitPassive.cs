using System.Collections.Generic;
using UnityEngine;

public class MagnitPassive : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _magnetPower;

    private HashSet<Rigidbody2D> affectedBodies = new HashSet<Rigidbody2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null && collision.TryGetComponent(out Coin coin))
        {
            affectedBodies.Add(collision.attachedRigidbody);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null && collision.TryGetComponent(out Coin coin))
        {
            affectedBodies.Remove(collision.attachedRigidbody);
        }
    }

    private void Update()
    {
        transform.position = _playerMovement.gameObject.transform.position;

        foreach (Rigidbody2D body in affectedBodies)
        {
            Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 directionToPlayer = (playerPosition - body.position).normalized;

            body.AddForce(directionToPlayer * _magnetPower);
        }
    }
}

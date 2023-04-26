using System.Collections.Generic;
using UnityEngine;

public class MagnitPassive : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _magnetPower;

    public HashSet<Rigidbody2D> affectedBodies = new HashSet<Rigidbody2D>();
    //public HashSet<Coin> affectedBodies = new HashSet<Coin>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null && collision.TryGetComponent(out Coin coin))
        {
            affectedBodies.Add(collision.GetComponent<Rigidbody2D>());
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out Coin coin))
    //    {
    //        affectedBodies.Add(collision.GetComponent<Coin>()); ;
    //    }
    //}

    private void Update()
    {
        transform.position = _playerMovement.gameObject.transform.position;

        foreach (Rigidbody2D body in affectedBodies)
        {
            Vector2 playerPosition = transform.position;
            Vector2 coinPosition = body.gameObject.transform.position;
            Vector2 direction = (playerPosition - coinPosition).normalized * _magnetPower;
            body.GetComponent<Rigidbody2D>().velocity = direction;
        }
    }
}
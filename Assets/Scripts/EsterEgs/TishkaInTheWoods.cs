using UnityEngine;

public class TishkaInTheWoods : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement playerMovement))
        {
            Destroy(gameObject);
        }
    }

}

using UnityEngine;

public class TakeRevard : MonoBehaviour
{
    [SerializeField] private BaroStop _baroStop;
    [SerializeField] private GameObject _finalSecretText;
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _sopSecret;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement playerMovement))
        {
            if (_baroStop.IsBaroStop)
            {
                _finalSecretText.SetActive(false);

                System.Random rnd = new System.Random();

                for (int i = 0; i < 10; i++)
                {
                    Instantiate(_coin, transform.position + new Vector3(rnd.Next(0, 2), rnd.Next(0, 2), 0), Quaternion.identity);
                }

                _sopSecret.SetActive(true);
            }  
        }
    }
}

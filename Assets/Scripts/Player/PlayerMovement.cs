using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _playerRigidbody;
    internal static PlayerMovement Instance;

    private Vector2 _direction;


    private void Start()
    { 
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        //Получаем вектор направления, длинна которого меньше скорости
        _direction = Vector2.ClampMagnitude(new Vector2(horizontalMovement, verticalMovement) * _speed, _speed);

        _playerRigidbody.velocity = _direction;
    }
}

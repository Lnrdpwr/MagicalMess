using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _playerRigidbody;
    internal static PlayerMovement Instance;
    private Vector2 _direction;

    public float Speed;

    private void Awake()
    {
        Instance = this;
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer =  GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        //�������� ������ �����������, ������ �������� ������ ��������
        _direction = Vector2.ClampMagnitude(new Vector2(horizontalMovement, verticalMovement) * Speed, Speed);

        _playerRigidbody.velocity = _direction;
    }

    public void LookRight()
    {
        _spriteRenderer.flipX = true;
    }

    public void LookLeft()
    {
        _spriteRenderer.flipX = false;
    }
}

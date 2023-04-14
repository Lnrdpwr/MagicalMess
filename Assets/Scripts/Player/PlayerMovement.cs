using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Sprite _forwardLookPrefab;
    [SerializeField] Sprite _leftLookPrefab;
    [SerializeField] Sprite _rightLookPrefab;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _playerRigidbody;
    internal static PlayerMovement Instance;
    private Vector2 _direction;

    public float Speed;
    public Vector3 PlayerScale;

    private void Awake()
    {
        Instance = this;
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer =  GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        transform.localScale = PlayerScale;

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        //�������� ������ �����������, ������ �������� ������ ��������
        _direction = Vector2.ClampMagnitude(new Vector2(horizontalMovement, verticalMovement) * Speed, Speed);

        _playerRigidbody.velocity = _direction;
    }

    public void LookRight()
    {
        _spriteRenderer.sprite = _rightLookPrefab;
    }

    public void LookLeft()
    {
        _spriteRenderer.sprite = _leftLookPrefab;
    }

    public void LookForward()
    {
        _spriteRenderer.sprite = _forwardLookPrefab;
    }
}

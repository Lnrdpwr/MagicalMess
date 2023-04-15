using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Sprite _forwardLookPrefab;
    [SerializeField] Sprite _leftLookPrefab;
    [SerializeField] Sprite _rightLookPrefab;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _playerRigidbody;
    internal static PlayerMovement Instance;
    private Vector2 _direction;

    public float Speed;
    public Vector3 PlayerScale;
    public bool PlayerLookFlip;

    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
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


        if (_direction == new Vector2(0, 0))
        {
            _animator.enabled = false;
        }
        else
        {
            _animator.enabled = true;
        }
    }

    public void LookRight()
    {
        _spriteRenderer.sprite = _rightLookPrefab;
        _animator.Play("PlayerGoRight");

        PlayerLookFlip = true;
    }

    public void LookLeft()
    {
        _spriteRenderer.sprite = _leftLookPrefab;
        _animator.Play("PlayerGoLeft");

        PlayerLookFlip = false;
    }

    public void LookForward()
    {
        _spriteRenderer.sprite = _forwardLookPrefab;
        _animator.Play("PlayerGoForward");
    }
}

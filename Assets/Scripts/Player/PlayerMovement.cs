using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Sprite _forwardLookPrefab;
    [SerializeField] Sprite _leftLookPrefab;
    [SerializeField] Sprite _rightLookPrefab;
    [SerializeField] Sprite _forwardLookUpPrefab;
    [SerializeField] Sprite _leftLookUpPrefab;
    [SerializeField] Sprite _rightLookUpPrefab;

    [SerializeField] private Joystick _joystick;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _playerRigidbody;
    internal static PlayerMovement Instance;
    private Vector2 _direction;
    private string _inputType;
    private float _horizontalMovement, _verticalMovement;

    public float Speed;
    public Vector3 PlayerScale;
    public bool PlayerLookFlip;

    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer =  GetComponent<SpriteRenderer>();
        _inputType = PlayerPrefs.GetString("InputType", "pc");
    }

    private void FixedUpdate()
    {
        transform.localScale = PlayerScale;

        if (_inputType == "pc")
        {
            _horizontalMovement = Input.GetAxisRaw("Horizontal");
            _verticalMovement = Input.GetAxisRaw("Vertical");
        }
        else if (_inputType == "mobile")
        {
            _horizontalMovement = _joystick.Horizontal;
            _verticalMovement = _joystick.Vertical;
        }

        _direction = Vector2.ClampMagnitude(new Vector2(_horizontalMovement, _verticalMovement) * Speed, Speed);

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
        _spriteRenderer.sortingOrder = 3;

        _spriteRenderer.sprite = _rightLookPrefab;
        _animator.Play("PlayerGoRight");

        PlayerLookFlip = true;
    }

    public void LookLeft()
    {
        _spriteRenderer.sortingOrder = 3;

        _spriteRenderer.sprite = _leftLookPrefab;
        _animator.Play("PlayerGoLeft");

        PlayerLookFlip = false;
    }

    public void LookForward()
    {
        _spriteRenderer.sortingOrder = 3;

        _spriteRenderer.sprite = _forwardLookPrefab;
        _animator.Play("PlayerGoForward");
    }

    public void LookUpForward()
    {
        _spriteRenderer.sortingOrder = 5;

        _spriteRenderer.sprite = _forwardLookUpPrefab;
        _animator.Play("PlayerGoUpForward");
    }

    public void LookUpRight()
    {
        _spriteRenderer.sortingOrder = 5;

        _spriteRenderer.sprite = _rightLookUpPrefab;
        _animator.Play("PlayerGoUpRight");
        PlayerLookFlip = true;
    }

    public void LookUpLeft()
    {
        _spriteRenderer.sortingOrder = 5;

        _spriteRenderer.sprite = _leftLookUpPrefab;
        _animator.Play("PlayerGoUpLeft");
        PlayerLookFlip = false;
    }
}

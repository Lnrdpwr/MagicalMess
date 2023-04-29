using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    [SerializeField] private PlayerShooting _playerShooting;
    [SerializeField] private CrossBow _crossBow;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _crossbowRenderer;
    [SerializeField] private Sprite _crossbowSprite;
    [SerializeField] private Sprite _cameraSpotSprite;

    public void SwitchToCamera()
    {
        _crossbowRenderer.sprite = _cameraSpotSprite;
        _crossBow.IsRotateble = false;
        _playerShooting.ShootStoping = true;
        _animator.Play("Camera");
    }

    public void SwitchToCrossBow()
    {
        _crossbowRenderer.sprite = _crossbowSprite;
        _crossBow.IsRotateble = true;
        _playerShooting.ShootStoping = false;
        _animator.Play("CameraIdle");
    }
}

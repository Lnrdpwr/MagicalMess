using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Image _reloadBar;
    [SerializeField] private Animator _reloadingBarAnimator;
    [SerializeField] private Animator _reloadingCanvasAnimator;
    [SerializeField] private AudioClip _shotClip;
    [SerializeField] private Joystick _joystick;

    private string _inputType;
    private bool _isReloaded = true;

    public bool CanShoot = true;
    public bool isTracked = false;//Метка монстра
    public float ReloadTime;//Перезарядка
    public float Damage;//Урон
    public float BulletSpeed;//Скорость снаряда
    public int PiercingPower;//Пронзание
    public int ShootsCount;//Кол-во выстрелов
    public Vector3 ArrowScale;//Размер стрелы
    public float MaxAngle = 0f;//Фиксированный разброс

    internal static PlayerShooting Instance;

    private void Awake()
    {
        Instance = this;
        _inputType = YandexGame.EnvironmentData.deviceType;
    }

    public void Update()
    {
        if (CanShoot && _isReloaded && (_inputType == "desktop" && Input.GetMouseButton(0) || (_inputType == "mobile" || _inputType == "tablet") && _joystick.Direction.magnitude >= 0.25f))
        {
            SoundManager.Instance.PlayClip(_shotClip);
            Shoot();
            StartCoroutine(Reload());
        }
    }

    private void Shoot()
    {
        float maxAngle = 80f;

        for (float angle = -(maxAngle) / 2; angle < maxAngle / 2; angle += maxAngle / ShootsCount)
        {
            Quaternion rotation = _firePoint.parent.rotation;

            if (ShootsCount > 1)
                rotation.z += angle * 0.001f;
            else
                rotation.z += 0;

            Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, rotation).GetComponent<Bullet>();

            bullet.Speed = BulletSpeed;
            bullet.Damage = Damage;
            bullet.PiercingPower = PiercingPower;
            bullet.transform.localScale = ArrowScale;
            bullet.isTrackActive = isTracked;
        }
    }

    public void ResetReload()
    {
        _isReloaded = true;
        _reloadBar.gameObject.SetActive(false);
        _reloadingBarAnimator.Play("ReloadingBarIdle");
    }

    IEnumerator Reload()
    {
        _isReloaded = false;

        _reloadBar.gameObject.SetActive(true);
        _reloadingCanvasAnimator.Play("ReloadingCanvas");
        _reloadingBarAnimator.speed = 1 / ReloadTime;
        _reloadingBarAnimator.Play("ReloadingBar");

        yield return new WaitForSeconds(ReloadTime);

        _reloadingCanvasAnimator.Play("ReloadingCanvasHide");
        _reloadingBarAnimator.Play("ReloadingBarIdle");
        yield return new WaitForSeconds(0.1f);
        _reloadBar.gameObject.SetActive(false);

        _isReloaded = true;
    }
}
